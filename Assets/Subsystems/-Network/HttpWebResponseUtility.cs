using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

	public class HttpRequest
	{
		public static ManualResetEvent allDone= new ManualResetEvent(false);
		const int BUFFER_SIZE = 1024;

		private HttpWebRequest _request;
		private Action<string> _errorCallback;
		public HttpRequest(string url)
		{
			// Create a request using a URL that can receive a post.			
			_request = HttpWebRequest.Create(url) as HttpWebRequest;
		}
		
		public HttpRequest(string url, string method)
			: this(url)
		{
			
			if (method.Equals("GET") || method.Equals("POST"))
			{
				// Set the Method property of the request to POST.
				_request.Method = method;
			}
			else
			{
				throw new Exception("Invalid Method Type");
			}
		}

		public HttpRequest(string url, string method, string data, Action<object> successfulCallBack, Action<string> errorCallBack)
			: this(url, method)
		{
			string errorMsg = string.Empty;
			// Create POST data and convert it to a byte array.
			string postData = data;
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			
			// Set the ContentType property of the WebRequest.
			_request.ContentType = "application/x-www-form-urlencoded";
			
			// Set the ContentLength property of the WebRequest.
			_request.ContentLength = byteArray.Length;
			_errorCallback = errorCallBack;
			try
			{
				System.Uri uri = new Uri(url);
				
				// Create a HttpWebrequest object to the desired URL.
				_request = (HttpWebRequest)WebRequest.Create(uri);
				_request.Method = method;
				
				// Create an instance of the RequestState and assign the previous myHttpWebRequest1
				// object to it's request field.  
				RequestState myRequestState = new RequestState();  
				myRequestState.request = _request;
				myRequestState.SuccessfulCallBack = successfulCallBack;
				myRequestState.ErrorCallback = errorCallBack;

				_request.BeginGetRequestStream((asyncResult) =>
				{
					HttpWebRequest preq = (asyncResult.AsyncState as RequestState).request;
					if (preq != null)
					{
						Stream postStream = preq.EndGetRequestStream(asyncResult);
						postStream.Write(byteArray, 0, byteArray.Length);
						postStream.Close();
					}

					// Start the asynchronous request.
					preq.BeginGetResponse(new AsyncCallback(RespCallback),myRequestState);
					
					allDone.WaitOne();
				}, myRequestState);
				

			}
			catch(WebException e)
			{
				errorMsg += "\nException raised!\n";
				errorMsg += "Message: ";
				errorMsg += e.Message;
				errorMsg += "\nStatus: ";
				errorMsg += e.Status;
				errorMsg += "\n";
			}
			catch(Exception e)
			{
				errorMsg += "\nException raised!\n";
				errorMsg += "\nMessage: ";
				errorMsg += e.Message;
				errorMsg += "\n";
			}
			if (!string.IsNullOrEmpty (errorMsg)) 
			{
				UnityEngine.Debug.Log (errorMsg);
				if (errorCallBack != null)
					errorCallBack(errorMsg);
			}
		}

		private void RespCallback(IAsyncResult asynchronousResult)
		{  

			try
			{
				// State of request is asynchronous.
				RequestState myRequestState=(RequestState) asynchronousResult.AsyncState;
				HttpWebRequest  myHttpWebRequest2=myRequestState.request;
				myRequestState.response = (HttpWebResponse) myHttpWebRequest2.EndGetResponse(asynchronousResult);
				
				// Read the response into a Stream object.
				Stream responseStream = myRequestState.response.GetResponseStream();
				myRequestState.streamResponse=responseStream;
				
				// Begin the Reading of the contents of the HTML page and print it to the console.
				responseStream.BeginRead(myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
			}
			catch(WebException e)
			{
				// Need to handle the exception
				// ...
				UnityEngine.Debug.Log(e.Message);
				ProcessManager.Add(new CallBackProcess((obj) =>
				{
					_errorCallback(obj as String);
				}, e.Message));
			}
		}
		
		private void ReadCallBack(IAsyncResult asyncResult)
		{
			try
			{
				RequestState myRequestState = (RequestState)asyncResult.AsyncState;
				Stream responseStream = myRequestState.streamResponse;
				int read = responseStream.EndRead( asyncResult );
				
				// Read the HTML page and then do something with it
				if (read > 0)
				{
					myRequestState.ReadBytes = Combine(myRequestState.ReadBytes, myRequestState.BufferRead, read);
					myRequestState.requestData.Append(Encoding.UTF8.GetString(myRequestState.BufferRead, 0, read));
					responseStream.BeginRead( myRequestState.BufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
				}
				else
				{
					if(myRequestState.requestData.Length>1)
					{
						// do something with the response stream here
						if (myRequestState.SuccessfulCallBack != null)
							ProcessManager.Add(new CallBackProcess(myRequestState.SuccessfulCallBack, myRequestState));
					}
					
					responseStream.Close();
					// Release the HttpWebResponse resource.
					myRequestState.response.Close();
					allDone.Set();     
				}
			}
			catch(WebException e)
			{
				// Need to handle the exception
				// ...
				
				UnityEngine.Debug.Log(e.Message);
				ProcessManager.Add(new CallBackProcess((obj) =>
				{
					_errorCallback(obj as String);
				}, e.Message));
			}
		}

		private static byte[] Combine( params byte[][] arrays)
		{
			byte[] rv = new byte[ arrays.Sum( a => a.Length ) ];
			int offset = 0;
			foreach ( byte[] array in arrays ) {
				System.Buffer.BlockCopy( array, 0, rv, offset, array.Length );
				offset += array.Length;
			}
			return rv;
		}

		private static byte[] Combine(byte[] array1, byte[] array2, int array2Length)
		{
			byte[] rv = new byte[array1.Length + array2Length ];
			if (array1.Length != 0)
				System.Buffer.BlockCopy( array1, 0, rv, 0, array1.Length );
			System.Buffer.BlockCopy( array2, 0, rv, array1.Length, array2Length );
			return rv;
		}
	}

	public class RequestState
	{
		// This class stores the State of the request.
		const int BUFFER_SIZE = 1024;
		public StringBuilder requestData;
		public byte[] BufferRead;
		public HttpWebRequest request;
		public HttpWebResponse response;
		public Stream streamResponse;
		public byte[] ReadBytes = new byte[0];
		public Action<object> SuccessfulCallBack;
		public Action<string> ErrorCallback;
		
		public RequestState()
		{
			BufferRead = new byte[BUFFER_SIZE];
			requestData = new StringBuilder("");
			request = null;
			streamResponse = null;
		}
	}

	public class CallBackProcess: IProcess
	{
		private bool mIsFinished = false;
		private Action<object> mCallBack;
		private object mArgument;
		public CallBackProcess(Action<object> callBack, object argument)
		{
			mCallBack = callBack;
			mArgument = argument;
		}
		#region IProcess implementation
		void IProcess.Start (){}

		void IProcess.Update (float deltaTime)
		{
			if (mCallBack != null)
				mCallBack(mArgument);
			mIsFinished = true;
		}

		void IProcess.End (){}
		bool IProcess.IsFinished (){ return mIsFinished;}
		#endregion


	}




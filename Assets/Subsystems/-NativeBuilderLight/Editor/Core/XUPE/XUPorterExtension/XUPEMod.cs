using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NativeBuilder.XCodeEditor
{
	public class XUPEMod {

		public string path {get; private set;}
		public string parentPath {get; private set;}
		public string name {get; private set;}
		public XCMod xcmod {get; private set;}
		public Dictionary<string, string> vars = new Dictionary<string, string> ();
		public XUPEMod(string path){

			path = Path.GetFullPath(path);
			DirectoryInfo di = new DirectoryInfo( path );

			if( !di.Exists ) {
				throw new IOException(path + " not exsits!");
			}


			this.path = path;
			this.name = System.IO.Path.GetFileNameWithoutExtension( path );
			this.parentPath = System.IO.Path.GetDirectoryName( path );
			this.xcmod = new XCMod(Path.Combine(path, "xupe.projmods"));
			vars.Add("version", UnityEditor.PlayerSettings.bundleVersion);

		}

		public ArrayList extCode {
			get {
				var item = (ArrayList)this.xcmod._datastore["ext.code"];
				if(item == null) item = new ArrayList();
				return item;
			}
		}


		public ArrayList translate {
			get{
				var item = (ArrayList)this.xcmod._datastore["ext.translate"];
				if(item == null) item = new ArrayList();
				return item;
			}
		}
		public ArrayList copiedFolder {
			get{
				var item = (ArrayList)this.xcmod._datastore["ext.copiedFolder"];
				if(item == null) item = new ArrayList();
				return item;
			}
		}
		
		public Hashtable property {
			get{
				var item = (Hashtable)this.xcmod._datastore["ext.property"];
			
				if(item == null) item = new Hashtable();
				return item;
			}
		}
		
		public string execute{
			get{
				var value = (string)this.xcmod._datastore["ext.execute"];
				if(value != null)
				{
					value = value.Replace("${conf}", this.path);
				}
				return value;
			}
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System; 
using System.IO;

	public class NetworkUtil
	{
        private static DateTime UnixTimestamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GenerateTimestamp()
        {
            return GenerateTimestamp(DateTime.Now);
        }

        public static long GenerateTimestamp(DateTime time)
        {
            return (long)(time.ToUniversalTime() - UnixTimestamp).TotalSeconds;
        }
#if !UNITY_WINRT
        public static DateTime ConvertFromTimestamp(long timestamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(UnixTimestamp.AddSeconds(timestamp));
        }
#endif
        private static Random RndSeed = new Random();
        public static string GenerateRndNonce()
        {
            return string.Concat(
            NetworkUtil.RndSeed.Next(1, 99999999).ToString("00000000"),
            NetworkUtil.RndSeed.Next(1, 99999999).ToString("00000000"),
            NetworkUtil.RndSeed.Next(1, 99999999).ToString("00000000"),
            NetworkUtil.RndSeed.Next(1, 99999999).ToString("00000000"));
        }

        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (T t in values)
            {
                if (buffer.Length != 0) buffer.Append(separator);
                buffer.Append(t == null ? "" : t.ToString());
            }
            return buffer.ToString();
        }

        public static string UrlEncode(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            StringBuilder buffer = new StringBuilder(text.Length);
            byte[] data = Encoding.UTF8.GetBytes(text);
            foreach (byte b in data)
            {
                char c = (char)b;
                if (!(('0'<= c && c <= '9') || ('a'<= c && c <= 'z') || ('A'<= c && c <= 'Z'))
                    && "-_.~".IndexOf(c) == -1)
                {
                    buffer.Append('%' + Convert.ToString(c, 16).ToUpper().PadLeft(2, '0'));
                }
                else
                {
                    buffer.Append(c);
                }
            }
            return buffer.ToString();
        }


        public static string MD5(string val)
        {
            return MD5(val, Encoding.UTF8);
        }

        public static string MD5(string val, Encoding encoding)
        {
            if (string.IsNullOrEmpty(val)) return "";

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] output = md5.ComputeHash(encoding.GetBytes(val));

            md5.Clear();

            StringBuilder code = new StringBuilder();
            for (int i = 0; i < output.Length; i++)
            {
                code.Append(output[i].ToString("x2"));
            }
            return code.ToString();
        }


		public static string UnzipString (byte[] compbytes )
		{
			return 	Ionic.Zlib.ZlibStream.UncompressString(compbytes);
		}

		static CustomLitJson.JsonMapper _main_json_mapper;
		public static CustomLitJson.JsonMapper MainJasonMapper()
		{
			if(_main_json_mapper==null)
			{
				_main_json_mapper=new CustomLitJson.JsonMapper();
			}
			return _main_json_mapper;
		}
		
		static CustomLitJson.JsonMapper _sub_json_mapper;
        public static CustomLitJson.JsonMapper SubJasonMapper()
		{
			if(_sub_json_mapper==null)
			{
				_sub_json_mapper=new CustomLitJson.JsonMapper();
			}
			return _sub_json_mapper;
		}
   
	}

	public class JsonMapperExtend
	{
		public static object ToObject( System.Type type, string json )
		{
			return NetworkUtil.MainJasonMapper().ReadValue(type, new CustomLitJson.JsonReader( json ));
		}

	}

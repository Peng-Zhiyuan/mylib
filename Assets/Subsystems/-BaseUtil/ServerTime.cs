//#define DebugMode
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#region TimeExtension
public enum TimeFormatType
{ 
	Digital,
	Localized, 
}
public static class TimeExtension
{
	public static string ToStringHour(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "00:00:00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D2}:{1:D2}:{2:D2}": Localization.Get ("HourTimeDetailFormat");
			return string.Format(format, (int)t.TotalHours, t.Minutes, t.Seconds);
		}
	}

	public static string ToStringMinute(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "00:00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D2}:{1:D2}": Localization.Get ("MinuteTimeDetailFormat");
			return string.Format(format, (int)t.TotalMinutes, t.Seconds);
		}
	}

	public static string ToStringDay(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "0.00:00:00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D}.{1:D2}:{2:D2}:{3:D2}": Localization.Get ("DayTimeDetailFormat");
			return string.Format(format, (int)t.TotalDays, t.Hours, t.Minutes, t.Seconds);
		}
	}

	public static string ToString (this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		double seconds = span.TotalSeconds;
		if (seconds > 86400)
			return span.ToStringDay (formatType);
		else if (seconds > 3600)
			return span.ToStringHour (formatType);
		else
			return span.ToStringMinute (formatType);
	}

	public static string ToStringHourWithoutS(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "00:00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D2}:{1:D2}": Localization.Get ("HourTimeDetailWithoutSFormat");
			return string.Format(format, (int)t.TotalHours, t.Minutes);
		}
	}

	public static string ToStringMinuteWithoutS(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D2}": Localization.Get ("MinuteTimeDetailWithoutSFormat");
			return string.Format(format, (int)t.TotalMinutes);
		}
	}

	public static string ToStringDayWithoutS(this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		TimeSpan t = span.Add(TimeSpan.FromSeconds(1));
		if (t.TotalSeconds < 0)
		{
			return "0.00:00";
		}
		else
		{
			var format = formatType == TimeFormatType.Digital? "{0:D}.{1:D2}:{2:D2}": Localization.Get ("DayTimeDetailWithoutSFormat");
			return string.Format(format, (int)t.TotalDays, t.Hours, t.Minutes);
		}
	}

	public static string ToStringWithoutS (this TimeSpan span, TimeFormatType formatType = TimeFormatType.Digital)
	{
		double seconds = span.TotalSeconds;
		if (seconds > 86400)
			return span.ToStringDayWithoutS (formatType);
		else //if (seconds > 3600)
			return span.ToStringHourWithoutS (formatType);
		//else
		//	return span.ToStringMinuteWithoutS (formatType);
	}

	public static string ToStringArray<T>(this IList<T> arr)
	{
		if (arr == null)
			return "null";
		int size = arr.Count;
		if (size == 0)
			return "[]";
		string str = "[" + arr[0];
		for (int i = 1; i < size; i++)
			str += ", " + arr[i].ToString();
		str += "]";
		return str;
	}


}
#endregion TimeExtension

	public class AlarmData
	{
		public string id;
		public Action cb;
		public DateTime date;
		public bool isOntime = false;//准时触发
	}
	public class ServerTime:Single<ServerTime>,IProcess
	{
		//public static ServerTime Instance = new ServerTime();
		public delegate void TimeUpdateCallBack (DateTime time);
		public List<AlarmData> alarmClock = new List<AlarmData>();

		private static readonly double maxDay = TimeSpan.MaxValue.TotalDays;
		private static readonly double minDay = TimeSpan.MinValue.TotalDays;
		private static readonly double maxSecond = TimeSpan.MaxValue.TotalSeconds;
		private static readonly double minSecond = TimeSpan.MinValue.TotalSeconds;
		private static readonly double maxMiliS = TimeSpan.MaxValue.TotalMilliseconds;
		private static readonly double minMiliS = TimeSpan.MinValue.TotalMilliseconds;


		private float lastRealTime = 0;
		private DateTime lastServerTime;
		private DateTime curServerTime;
		private DateTime baseTime;
		private int timeZone = 8;
		private int hour_offset;
		private int switchDayHour;
		long timeZoneMils;
//		private TimeUpdateCallBack secondUpdate;
//		private TimeUpdateCallBack hourUpdate;
//		private TimeUpdateCallBack dayUpdate;

		private static event TimeUpdateCallBack secondUpdateEvent;
		public static event TimeUpdateCallBack SecondUpdateEvent {
			add {
				secondUpdateEvent += value;
			}
			remove {
				secondUpdateEvent -= value;
			}
		}
		private static event TimeUpdateCallBack hourUpdateEvent;
		public static event TimeUpdateCallBack HourUpdateEvent {
			add {
				hourUpdateEvent += value;
			}
			remove {
				hourUpdateEvent -= value;
			}
		}
		private static event TimeUpdateCallBack dayUpdateEvent;
		public static event TimeUpdateCallBack DayUpdateEvent {
			add {
				dayUpdateEvent += value;
			}
			remove {
				dayUpdateEvent -= value;
			}
		}
		public void Init (int _timeZone, int _switchDayHour,double _serveTime = 0)
		{
			switchDayHour = _switchDayHour;
			timeZone = _timeZone;
			timeZoneMils=timeZone * 3600 * 1000;

			alarmClock.Clear();
			hour_offset = -switchDayHour;
			if(_serveTime>0)Sync(_serveTime);
			ProcessManager.Add (Instance);
		}

		public void  Start()
		{
			
		}

		public void End()
		{
			
		}

		public bool IsFinished()
		{
			return false;
		}
		private float t = 0;
		public void Update(float deltaTime)
		{
			t+=deltaTime;
			if(t<1)return;
			t=0;
			DateTime now = Now;
			if(secondUpdateEvent!=null)secondUpdateEvent.Invoke(now);
			//EventManager.Instance.SendEvent<DateTime>(EVENTTYPE.TIME_SECOND_UPDATE.ToString(), now);
			if(curServerTime.Minute != now.Minute)
			{
				if(alarmClock.Count >0)
				{
					for(int i= alarmClock.Count-1; i >= 0 ; i--)
					{
						if(alarmClock[i].date >= now)
						{
							if(alarmClock[i].cb!=null)alarmClock[i].cb();
							alarmClock.RemoveAt(i);
						}
					}
				}
				if (curServerTime.Hour != now.Hour)
				{
					if(hourUpdateEvent!=null)hourUpdateEvent.Invoke(now);
					//EventManager.Instance.SendEvent<DateTime>(EVENTTYPE.TIME_HOUR_UPDATE.ToString(), now);
					if(IsSwitchHour(now.Hour))
					{
						if(dayUpdateEvent!=null)dayUpdateEvent.Invoke(now);
						//EventManager.Instance.SendEvent(EVENTTYPE.SWITCH_DAY.ToString());
					}
				}
			}
			curServerTime = now;
		}


		public DateTime LastSyncTime
		{
			get
			{
				return lastServerTime;
			}
		}

//		public void SimpleInit(double serveTime)
//		{
//			if(StaticDatar.IsLoaded)
//			{
//				timeZone = StaticDatar.GetSingle ().m_base_dic.ContainsKey("timeZone")? int.Parse(StaticDatar.GetSingle ().m_base_dic["timeZone"].val):8;
//			}
//			else timeZone = 8;
//			timeZoneMils=timeZone * 3600 * 1000;
//			Sync(serveTime);
//		}

		public bool IsSwitchHour(int hour)
		{
			return hour == switchDayHour;
		}
		public DayOfWeek GetDayOfWeek(DateTime date,bool realy = false)
		{
			if (!realy)
			{
				date = RelativeDate(date);
			}
			return date.DayOfWeek;
		}
	

//		public bool IsSwitchDay(DateTime now, DateTime lastTime,bool realy = true)
//		{
//			if (!realy) {
//				now = RelativeDate (now);
//				lastTime = RelativeDate (lastTime);
//			}
//			if (switchDayHour != lastTime.Hour && switchDayHour = now.Hour)
//				return true;
//			return false;
//		}

		public int GetDayIndex(DateTime date, bool realy = false)
		{
			if (!realy) date = RelativeDate(date);
			return (date.Year%100)*10000+date.Month*100+date.Day;
		}

		public int GetLongDayIndex(DateTime date, bool realy = false)
		{
			if (!realy) date = RelativeDate(date);
			return (date.Year)*10000+date.Month*100+date.Day;
		}
		public long GetSecondIndex(DateTime date, bool realy = false)
		{
			if (!realy) date = RelativeDate(date);
			return (long)GetDayIndex(date)*1000000+date.Hour*10000+date.Minute*100+date.Second;
		}

		public void Sync(double serveTime)
		{
			lastRealTime = Time.realtimeSinceStartup;
			baseTime = new DateTime (1970, 1, 1, 0, 0, 0, 0);
			baseTime = baseTime.AddMilliseconds(timeZoneMils);
			curServerTime = lastServerTime = baseTime.AddMilliseconds (serveTime);//.Add(-StaticDatar.GetSingle().m_base_dic.GetElement("timeReset").val);

		}

		public DateTime ConvertFromTimestamp (double timestamp)
		{
			return baseTime.AddMilliseconds (timestamp);
		}

		public DateTime GetFurTimeFromMs (double timestamp)
		{
			return Now.AddMilliseconds (timestamp);
		}
		
		public double GetFurMsFromMs (double timestamp)
		{
			return (Now.AddMilliseconds (timestamp)-baseTime).TotalMilliseconds-timeZoneMils;
		}

		public TimeSpan Countdown(int targetHour)
		{
			DateTime date = ServerTime.Now;
			if (date.Hour <= targetHour) 
				return TimeSpan.FromSeconds (targetHour * 3600 - (date.Hour * 3600 + date.Minute * 60 + date.Second));
			else
				return TimeSpan.FromSeconds ((24+targetHour) * 3600 - (date.Hour * 3600 + date.Minute * 60 + date.Second));
		}

		public TimeSpan Countdown(DateTime targetTime)
		{
			DateTime date = ServerTime.Now;
			if (date <= targetTime) 
				return targetTime - date;
			else
				return targetTime.AddHours(24)-date;
		}
		
	    public long ConvertToTimestamp(DateTime date)
		{
			TimeSpan ts = date - baseTime;
			return (long)ts.TotalMilliseconds;
		}

		public static DateTime Now
		{
			get
			{
				float curRealTime = Time.realtimeSinceStartup;
				float timeOffset = curRealTime - Instance.lastRealTime;
				DateTime t = Instance.lastServerTime + TimeSpan.FromSeconds (timeOffset);
				return  Instance.lastServerTime + TimeSpan.FromSeconds (timeOffset);
			}
		}
		public static DateTime RelatedNow
		{
			get {
				return  ServerTime.Instance.RelativeDate (Now);
			}
		}
		public static long Tickets
		{
			get
			{
				return Instance.ConvertToTimestamp(Now);
			}
		}
		public DateTime RelativeDate(DateTime date)
		{
			return date.AddHours(hour_offset);
		}

		public bool isBegin(long sTime)
		{
			return ServerTime.Now >= FromMillSecond (sTime );
		}

		public void SetAlarmClock(string id,DateTime tarDate,Action cb)
		{
			for(int i = 0; i< alarmClock.Count; i++)
			{
				if(alarmClock[i].id == id)
				{
					alarmClock[i].date  = tarDate;
					alarmClock[i].cb  = cb;
					return;
				}
			}
			AlarmData alarm = new AlarmData();
			alarm.id = id;
			alarm.date  = tarDate;
			alarm.cb  = cb;
			alarmClock.Add(alarm);
		}

		public bool isEnd(long eTime)
		{
			return (eTime !=0 && ServerTime.Now > FromMillSecond (eTime));
		}
		public bool isNowValidTime(long sTime, long eTime)
		{
			return ServerTime.Now >= FromMillSecond (sTime )&& (eTime ==0 || ServerTime.Now <= FromMillSecond (eTime));
		}
		public bool isNowValidTime(int sTime, int eTime)
		{
			return ServerTime.Now >= FromSecond (sTime ) &&(eTime ==0 || ServerTime.Now <= FromSecond (eTime));
		}

		public bool isNowValidTime(string sTime, string eTime)
		{
			return  (string.IsNullOrEmpty(sTime) || Now >= StringToDateTime(sTime)) &&( string.IsNullOrEmpty(eTime) || Now <= StringToDateTime (eTime));
		}

		public DateTime GetNextDayZeroPoint (long milis, bool realy= false)
		{
			DateTime date = FromMillSecond(milis);
			return GetNextDayZeroPoint(date, realy);
		}
		public DateTime GetDayZeroPoint(long milis, bool realy= false)
		{
			DateTime date = FromMillSecond(milis);
			return GetDayZeroPoint(date, realy);
		}
		public DateTime GetDayZeroPoint(DateTime date,bool realy= false)
		{
			int diffMillSeconds= 0;
			if(realy)
			{
				diffMillSeconds= (date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond;

			}
			else
			{
				if(date.Hour < switchDayHour)
				{
					
					diffMillSeconds = (24- switchDayHour)* 3600 * 1000+((date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond);
		
				}
				else 
				{
					diffMillSeconds = ((date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond) - switchDayHour* 3600 * 1000;
				}
			}
			return date.AddMilliseconds(-diffMillSeconds);
		}
		public DateTime GetNextDayZeroPoint(DateTime date,bool realy= false)
		{
			int diffMillSeconds= 0;
			if(realy)
			{
				diffMillSeconds= 24 * 3600 * 1000-((date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond);
			
			}
			else
			{
				if(date.Hour < switchDayHour)
				{
					
					diffMillSeconds =  switchDayHour* 3600 * 1000-((date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond);

				}
				else 
				{
					diffMillSeconds =  (24+switchDayHour)* 3600 * 1000-((date.Hour * 3600 + date.Minute * 60 +date.Second) *1000 + date.Millisecond);
				}
			}
			return date.AddMilliseconds(diffMillSeconds);
		}

		public DateTime FromMillSecond (long milis)
		{
			double temp = milis;
			temp = Math.Max (temp, minMiliS);
			temp = Math.Min (temp, maxMiliS);
			return baseTime + TimeSpan.FromMilliseconds (temp);
		}

		public DateTime FromSecond (long second)
		{
			double temp = second;
			temp = Math.Max (temp, minSecond);
			temp = Math.Min (temp, maxSecond);
			return baseTime + TimeSpan.FromSeconds (temp);
		}



		public DateTime Parse(string dateTime)
		{
			DateTime dt = DateTime.Parse (dateTime);
			return dt;
		}


		public DateTime StringToDateTime (string dateTime)
		{
			TimeSpan ts = TimeSpan.Parse (dateTime);
			TimeSpan ts_offset = ts - Now.TimeOfDay;
			return Now.Add (ts_offset);
		}

		public  DateTime FromDay (long day)
		{
			double temp = day;
			temp = Math.Max (temp, minDay);
			temp = Math.Min (temp, maxDay);
			return baseTime + TimeSpan.FromDays (temp);
		}

		public  bool IsTodayByDay (long day,bool realy = false)
		{
			DateTime target = FromDay (day);
			DateTime now = Now;
			if (!realy)
			{
				target =  RelativeDate(target);
			}
			return target.Year == now.Year && target.Month == now.Month && target.Day == now.Day;
		}

		public  bool IsTodayBySecond (int second,bool realy = false)
		{
			DateTime target = FromSecond (second);
			DateTime now = Now;
			if (!realy)
			{
				target = RelativeDate(target);
			}
			return target.Year == now.Year && target.Month == now.Month && target.Day == now.Day;
		}

		public  int BeforeDaysBySecond (int second,bool realy = false)
		{
			DateTime target = FromSecond (second);
			DateTime TodayEnd = GetNextDayZeroPoint(Now,realy);
			TimeSpan ts = TodayEnd - target;
			return ts.Days;
		}

		public  bool IsYesTodayBySecond (int second,bool realy = false)
		{
			DateTime target = FromSecond (second);
			DateTime yestoday = Now.AddHours(-24);
			if (!realy)
			{
				target = RelativeDate(target);
			}
			return target.Year == yestoday.Year && target.Month == yestoday.Month && target.Day == yestoday.Day;
		}

		public  bool IsWeekday(int weekday,bool realy = false)
		{
			DateTime now = Now;
		
			if (!realy)
			{
				now= RelativeDate(now);
			}
			return WeekDayToIndex(now.DayOfWeek) == weekday;
		}

		public int WeekDayToIndex(DayOfWeek weekDay)
		{
			if(weekDay == DayOfWeek.Sunday)return 7;
			else return (int)weekDay;
		}

		public  bool IsWeekday(string weekdays, DateTime target,bool realy = false)
		{
			if (!realy)
			{
				target= RelativeDate(target);
			}
			if (string.IsNullOrEmpty(weekdays) || weekdays.Equals ("0"))
				return true;
			else if (weekdays.Contains (WeekDayToIndex(target.DayOfWeek).ToString())) 
				return true;
			return false;
		}

		public  bool IsWeekday(string weekdays,bool realy = false)
		{
			DateTime now = Now;
			if (!realy)
			{
				now= RelativeDate(now);
			}
			if (string.IsNullOrEmpty(weekdays) || weekdays.Equals ("0"))
				return true;
			else if (weekdays.Contains (WeekDayToIndex(now.DayOfWeek).ToString())) 
				return true;
			return false;
		}

		public  int GetDiffDayBySecond (int second)
		{
			DateTime target = FromSecond (second);
			DateTime now = Now;
			return (int)(target - now).TotalDays;
		}

		public  int GetDiffDayByDay (int day)
		{
			DateTime target = FromDay (day);
			DateTime now = Now;
			return (int)(target - now).TotalDays;
		}

		public long GetTimeZoneMs()
		{
			return timeZoneMils;
		}



	public string LastLoginToString(long time)
	{
		Debug.Log("t:"+time);
		DateTime date = FromMillSecond (time);
		int t= (int)(time/1000);
		if (ServerTime.Instance.IsTodayBySecond(t,true)) {
			return Localization.Get (4305) + "  " + ColorHelper.GreenColor (date.ToString ("HH:mm"));
		} 
		else if(ServerTime.Instance.IsYesTodayBySecond(t,true))
		{
			return Localization.Get (4306) + "  " + ColorHelper.GreenColor (date.ToString ("HH:mm"));
		}
		else 
		{
			int lastDayIndex = GetDayIndex (date,true);
			int curDayIndex = GetDayIndex (ServerTime.Now,true);
			int days = curDayIndex - lastDayIndex;
			if(days <7 && days >=0)
			{
				return Localization.Get (4981,days);
			}
			else 
			{
				return Localization.Get(4982);
			}
		}
	}
	private string FormatNumber(int val,int len)
	{
		string result = val.ToString();
		int index = result.Length;
		while(index <len)
		{
			index++;
			result="0"+result;
		}
		return result;
	}

	public string GetShortRemainTime(DateTime date)
	{
		TimeSpan ts = date - ServerTime.Now;
		if (ts.Days >= 1) {
			return Mathf.CeilToInt(ts.Days)+" "+Localization.Get (4454);
		} 
		else  return FormatNumber(ts.Hours,2)+":"+ FormatNumber(ts.Minutes,2)+":"+ FormatNumber(ts.Seconds,2) ;
	}

	public string GetFormatRemainTime(DateTime date)
	{
		TimeSpan ts = date - ServerTime.Now;
		if (ts.Days >= 1) {
			return Mathf.CeilToInt(ts.Days)+" "+Localization.Get (4454)+" "+Mathf.CeilToInt(ts.Hours)+" "+Localization.Get (4451);
		} 
		else 
		{
			if(ts.Hours >0)
			{
				return Mathf.CeilToInt(ts.Hours)+" "+Localization.Get (4451)+" "+Mathf.CeilToInt(ts.Minutes)+" "+Localization.Get (4452);
			}
			else
			{
				return ts.ToStringHour();
				//return Mathf.CeilToInt(ts.Minutes)+Localization.Get (4452);
			}
			//					else if(ts.Seconds > 0)return Mathf.CeilToInt(ts.Seconds)+Localization.Get (4453);
			//					else return "0"+Localization.Get (4453);
		}
	}
	public string GetFormatRemainTime(long time)
	{
		DateTime date = FromMillSecond (time);
		return GetFormatRemainTime(date);

	}

	public string GetResetTimeDes()
	{
		return  FormatNumber(switchDayHour,2)+":00";
	}

	public string GetTimeDes(long dateTime)
	{
		DateTime date = FromMillSecond (dateTime);
		return GetTimeDes(date);
	}

	public string GetTimeDes(DateTime dateTime)
	{
		return Localization.Get(4903,dateTime.Month,dateTime.Day);
	}

	public string GetDetailTimeDes(long dateTime)
	{
		return GetTimeDes(dateTime)+" "+GetResetTimeDes();
	}

	public string GetDetailTimeDes(DateTime dateTime)
	{
		return GetTimeDes(dateTime)+" "+GetResetTimeDes();
	}

	public string GetRemainTime(DateTime date)
	{
		TimeSpan ts = date - ServerTime.Now;
		if (ts.Days >= 1) {
			return Mathf.CeilToInt(ts.Days)+Localization.Get (4454);
		} else 
		{
			if(ts.Hours >0)
			{
				return Mathf.CeilToInt(ts.Hours)+Localization.Get (4451);
			}
			else if(ts.Minutes > 0)
			{
				return Mathf.CeilToInt(ts.Minutes)+Localization.Get (4452);
			}
			else if(ts.Seconds > 0)return Mathf.CeilToInt(ts.Seconds)+Localization.Get (4453);
			else return "0"+Localization.Get (4453);
		}
	}

	public string GetRemainTime(long time)
	{
		DateTime date = FromMillSecond (time);
		return GetFormatRemainTime(date);

	}
}


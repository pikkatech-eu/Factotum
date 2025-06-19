/***********************************************************************************
* File:         Logger.cs                                                          *
* Contents:     Class Logger                                                       *
* Author:       Stanislav Koncebovski (Stanislav.Koncebovski@dktech.de)            *
* Date:         2019-04-04 12:45                                                   *
* Version:      1.0                                                                *
* Copyright:    D&K Technologies GmbH, Barum, Germany (www.dktech.de)              *
***********************************************************************************/
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Factotum.Logging
{
	/// <summary>
	/// Multi-purpose static Logger.
	/// </summary>
	public static class Logger 
	{
		#region Public enums		
		public enum FileNameFormat
		{
			/// <summary>
			/// Logger File Name is created using the full current day time ("29191128@123456")
			/// </summary>
			CurrentDayTime,

			/// <summary>
			/// Logger File Name is created using the current hour ("29191128@12h")
			/// </summary>
			Hourly,

			/// <summary>
			/// Logger File Name is created using the current calendar day ("29191128")
			/// </summary>
			Daily,

			/// <summary>
			/// Logger File Name is created using the current calendar week ("29191128_W48")
			/// </summary>
			Weekly,

			/// <summary>
			/// Logger File Name is created as a random 8-digit number ("99581009")
			/// </summary>
			Random
		}
		#endregion

		#region Private static data		
		/// <summary>
		/// The maximum file size (1 MB).
		/// </summary>
		private static readonly int				_maxFileSize			= 1024 * 1024;

		/// <summary>
		/// The maximum file age: 1 hour.
		/// </summary>
		private static readonly TimeSpan		_maxFileAge				= new TimeSpan(1, 0, 0, 0);

		/// <summary>
		/// The minimum application name length (3 characters).
		/// </summary>
		private static readonly int				_minAppNameLength		= 3;

		/// <summary>
		/// The log folder name ("Log").
		/// </summary>
		private static string			_logFolderName			= "PikkaLogs";
		#endregion

		#region Properties		
		/// <summary>
		/// Gets the currect full log file name.
		/// </summary>
		public static string			FileName			{get;private set;}		= null;

		public static FileNameFormat	FileNameFormatAs	{get;set;}				= FileNameFormat.Hourly;

		/// <summary>
		/// Gets the currect full application name.
		/// </summary>
		public static string			ApplicationName		{get;private set;}		= null;

		public static bool				Enabled				{get;set;}				= false;

		/// <summary>
		/// The folder in which the log files should be created. 
		/// If set to null, the current folder will be used.
		/// </summary>
		public static string			LogFolder			{get;set;}				= null;

		public static string			LogFolderName		
		{
			get	{return _logFolderName;}
			set	{_logFolderName = value;}
		}
		#endregion

		#region Management		
		/// <summary>
		///		Opens the logger with a specified application name.
		///		If the name is null or shorter than 3 characrters, nothing happens.
		/// </summary>
		/// <param name="appName">Name of the application.</param>
		public static void Open(string appName)
		{
			Enabled			= true;
			ApplicationName	= appName;

			if (ApplicationName == null || ApplicationName.Length < _minAppNameLength)
			{
				return;
			}

			string folder	= LogFolder == null ? Directory.GetCurrentDirectory() : LogFolder;
			string logPath	= Path.Combine(folder, _logFolderName);

			if (!Directory.Exists(logPath))
			{
				Directory.CreateDirectory(logPath);
			}

			string fileName	= CreateFileName();

			FileName		= Path.Combine(logPath, fileName);

			WriteOpened();
		}

		/// <summary>
		/// Closes the logger.
		/// </summary>
		public static void Close()
		{
			WriteClosed();
			Enabled			= false;
		}
		#endregion

		#region Working messages		
		/// <summary>
		/// Writes a TRACE message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Trace(string message)
		{
			WriteMessage("TRACE  ", message);
		}

		/// <summary>
		/// Writes a DEBUG message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Debug(string message)
		{
			WriteMessage("DEBUG  ", message);
		}

		/// <summary>
		/// Writes an INFO message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Info(string message)
		{
			WriteMessage("INFO   ", message);
		}

		/// <summary>
		/// Writes a WARNING message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Warning(string message)
		{
			WriteMessage("WARNING", message);
		}

		/// <summary>
		/// Writes an ERROR message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Error(string message)
		{
			WriteMessage("ERROR  ", message);
		}

		/// <summary>
		/// Writes a FATAL message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Fatal(string message)
		{
			WriteMessage("FATAL  ", message);
		}
		#endregion

		#region Private Auxiliary		
		/// <summary>
		/// Reopens the logger with a new file name.
		/// </summary>
		private static void Reopen()
		{
			Open(ApplicationName);
		}

		/// <summary>
		/// Writes a (raw) message.
		/// </summary>
		/// <param name="prefix">The prefix (TRACE / DEBUG / INFO / WARNING / ERROR / FATAL).</param>
		/// <param name="rawMessage">The raw message.</param>
		private static void WriteMessage(string prefix, string rawMessage)
		{
			if (!Enabled)
			{
				return;
			}

			if (FileName == null)
			{
				return;
			}

			long fileLength		= 0;
			TimeSpan fileAge	= TimeSpan.Zero;

			try
			{
				FileInfo fi		= new FileInfo(FileName);
				fileLength		= fi.Length;
				fileAge			= DateTime.Now - File.GetCreationTime(FileName);
			}
			catch (FileNotFoundException)	{}

			if (fileLength > _maxFileSize || fileAge >= _maxFileAge)
			{
				Reopen();
			}

			string message	= $"{DateTime.Now : yyyy-MM-dd@HH:mm:ss.fff}|{prefix}|{GetLoggingPoint()}: {rawMessage}\r\n";

			if (prefix.ToUpper() == "OPENED ")
			{
				message		= "\r\n\r\n" + message;
			}

			string[] messages	= new string[]{message};
			File.AppendAllText(FileName, message);
		}

		/// <summary>
		/// Gets the point in the execution stack at which the logging takes place.
		/// </summary>
		/// <returns>Formatted string of kind $"{reflectedType}.{methodName}".</returns>
		private static string GetLoggingPoint()
		{
			StackTrace stackTrace	= new StackTrace();
			int frameNumber			= stackTrace.FrameCount >= 5 ? 4 : 3;

			string methodName		= stackTrace.GetFrame(frameNumber).GetMethod().Name;
			string reflectedType	= stackTrace.GetFrame(frameNumber).GetMethod().ReflectedType.ToString();

			return $"{reflectedType}.{methodName}";
		}

		/// <summary>
		/// Writes the "OPENED" message.
		/// </summary>
		private static void WriteOpened()
		{
			WriteMessage("OPENED ", "");
		}

		/// <summary>
		/// Writes the "CLOSED" message.
		/// </summary>
		private static void WriteClosed()
		{
			WriteMessage("CLOSED\r\n", "");
		}

		/// <summary>
		/// Creates the name of the log file depending on the preferred file name format.
		/// </summary>
		/// <returns></returns>
		private static string CreateFileName()
		{
			switch (FileNameFormatAs)
			{
				case FileNameFormat.CurrentDayTime:
					return $"{ApplicationName}_{DateTime.Now:yyyy-MM-dd@HH-mm-ss}.log";

				case FileNameFormat.Hourly:
					return $"{ApplicationName}_{DateTime.Now:yyyy-MM-dd@HH}.log";

				case FileNameFormat.Daily:
					return $"{ApplicationName}_{DateTime.Now:yyyy-MM-dd}.log";

				case FileNameFormat.Weekly:
					string fileName	= $"{ApplicationName}_{DateTime.Now:yyyy}_W";
					int week		= CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
					fileName		+= $"{week}.log";
					return fileName;

				case FileNameFormat.Random:
				default:
					Random random	= new Random((int)DateTime.Now.Ticks);
					return $"{random.Next(10000000, 99999999)}.log";
			}
		}
		#endregion
	}
}

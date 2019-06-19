
namespace TeamCityGate
{

    using System;
    using System.Globalization;
    using System.IO;

	public sealed class Logger
	{
		#region Private constants

		private const string File_Name_Format = "log_{0}_{1}.txt";
		private const string Default_Log_Format = "{0}";
		private const string Default_Message_Format = "[{0} {1}] - {2}";
		private const string File_Date_Format = "yyyy.MM.dd";
		private const string File_Time_Format = "HH.mm.ss";
		private const int Old_File_Days = 15;
		private const string Message_Date_Format = "yyyy-MM-dd";
		private const string Message_Time_Format = "HH:mm:ss";
		private const string Asterik = "*";

		#endregion Private constants

		#region Private static variables

		private static StreamWriter logfile;
		private static string loggingPath;

		#endregion Private static variables

		#region Constructors

		private Logger()
		{
		}

		static Logger()
		{
			loggingPath = AppDomain.CurrentDomain.BaseDirectory;
			CleanupOldFiles();
			DateTime dateTime = DateTime.Now;
			string filename = string.Format(File_Name_Format,
			                                dateTime.ToString(File_Date_Format),
			                                dateTime.ToString(File_Time_Format));
			string filePath = Path.Combine(loggingPath, filename);
			logfile = new StreamWriter(filePath, true);
		}

		#endregion Constructors

		#region Commands

		public static void Log(string formatString, params object[] items)
		{
		    if (!String.IsNullOrEmpty(formatString)){formatString = formatString.StartsWith(Environment.NewLine) ? formatString.Remove(1, 1) : formatString;}
			string message = String.Format(CultureInfo.CurrentCulture, formatString, items);
			message = String.Format(CultureInfo.CurrentCulture,
			                        Default_Message_Format,
			                        DateTime.Now.ToString(Message_Date_Format),
			                        DateTime.Now.ToString(Message_Time_Format),
			                        message);
			logfile.WriteLine(message);
			logfile.Flush();
		}

		public static void Log(params object[] items)
		{
			Log(Default_Log_Format, items);
		}

		public static void CleanupOldFiles()
		{
			string[] files = Directory.GetFiles(loggingPath, String.Format(File_Name_Format, Asterik, Asterik));
			foreach (string file in files)
			{
				if (File.GetCreationTime(file).AddDays(Old_File_Days).CompareTo(DateTime.Today) < 0)
				{
					File.Delete(file);
				}
			}
		}

		#endregion Commands
	}
}
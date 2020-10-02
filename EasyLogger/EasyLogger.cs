using System;
using System.Reflection;

/// <summary>
/// EasyLogger Entry Point
/// </summary>
public static class EasyLogger
{
    private static LogBase logger = null;

    /// <summary>
    /// The default directory used to store log files
    /// CommonApplicationData\\Easy Logger\\Name of your App\\User Name\\
    /// </summary>
    public static string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Easy Logger\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "\\" + UserManagement.GetUserName() + "\\";

    /// <summary>
    /// The default file path to the log file used
    /// </summary>
    public static string LogFile = LogDirectory + Assembly.GetEntryAssembly().GetName().Name + ".log";

    /// <summary>
    /// The default file path to the log file used
    /// </summary>
    internal static string LogFileBak = LogDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + ".bak";

    /// <summary>
    /// Backup log files to [FileName].bak; this is to prevent huge log files
    /// </summary>
    /// <param name="LogFilePath"></param>
    public static void BackupLogs(string LogFilePath)
    {
        LogFile = LogFilePath;

        logger = new FileLogger();
        logger.BackupLogs(LogFile);
    }

    /// <summary>
    /// Start the logging service
    /// </summary>
    /// <param name="LogFilePath"></param>
    public static void AddListener(string LogFilePath)
    {
        LogFile = LogFilePath;

        logger = new FileLogger();
        logger.AddListener(LogFile);
    }

    /// <summary>
    /// Stops and disposes of the logging service
    /// </summary>
    public static void RemoveListener()
    {
        logger = new FileLogger();
        logger.RemoveListener();
    }
    /// <summary>
    /// Insert [error] in the line
    /// </summary>
    /// <param name="message"></param>
    public static void Error(string message)
    {
        logger = new FileLogger();
        logger.Error(message);
    }
    /// <summary>
    /// Insert [error] in the line
    /// </summary>
    /// <param name="ex"></param>
    public static void Error(Exception ex)
    {
        logger = new FileLogger();
        logger.Error(ex);
    }
    /// <summary>
    /// Insert [warning] in the line
    /// </summary>
    /// <param name="message"></param>
    public static void Warning(string message)
    {
        logger = new FileLogger();
        logger.Warning(message);
    }
    /// <summary>
    /// Insert [info] in the line
    /// </summary>
    /// <param name="message"></param>
    public static void Info(string message)
    {
        logger = new FileLogger();
        logger.Info(message);
    }
}
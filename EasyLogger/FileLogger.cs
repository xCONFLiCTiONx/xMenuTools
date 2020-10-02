using System;
using System.Diagnostics;
using System.IO;

/// <summary>
/// FileLoger Class : LogBase
/// </summary>
public class FileLogger : LogBase
{
    private static TextWriterTraceListener twtl = null;
    private static ConsoleTraceListener ctl = null;

    /// <summary>
    /// Backup log files to [FileName].bak; this is to prevent huge log files
    /// </summary>
    /// <param name="LogFilePath"></param>
    public override void BackupLogs(string LogFilePath)
    {
        if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
        }
        if (File.Exists(LogFilePath + ".bak"))
        {
            File.Delete(LogFilePath + ".bak");
        }
        if (File.Exists(LogFilePath))
        {
            File.Copy(LogFilePath, LogFilePath + ".bak");
            File.Delete(LogFilePath);
        }
    }

    /// <summary>
    /// Insert [error] in the line for error logging
    /// </summary>
    /// <param name="message"></param>
    public override void Error(string message)
    {
        WriteEntry(message, "error");
    }

    /// <summary>
    /// Insert [error] in the line for specific error logging
    /// </summary>
    /// <param name="ex"></param>
    public override void Error(Exception ex)
    {
        WriteEntry(ex.Message, "error");
    }

    /// <summary>
    /// Insert [warning] in the line for warning logging
    /// </summary>
    /// <param name="message"></param>
    public override void Warning(string message)
    {
        WriteEntry(message, "warning");
    }

    /// <summary>
    /// Insert [info] in the line for information logging
    /// </summary>
    /// <param name="message"></param>
    public override void Info(string message)
    {
        WriteEntry(message, "info");
    }

    private void WriteEntry(string message, string type)
    {
        Trace.WriteLine(
                string.Format("{0} [{1}] {2}",
                              DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                              type,
                              message));
    }

    /// <summary>
    /// Start the logging service
    /// </summary>
    public override void AddListener(string LogFile)
    {
        Trace.Listeners.Clear();

        try
        {
            twtl = new TextWriterTraceListener(LogFile);

            try
            {
                ctl = new ConsoleTraceListener(false);
                Trace.Listeners.Add(twtl);
                Trace.Listeners.Add(ctl);
                Trace.AutoFlush = true;
            }
            finally
            {
                if (ctl != null)
                {
                    ctl.Dispose();
                }
            }
        }
        finally
        {
            if (twtl != null)
            {
                twtl.Dispose();
            }
        }
    }

    /// <summary>
    /// Stops and disposes of the logging service
    /// </summary>
    public override void RemoveListener()
    {
        Trace.Listeners.Remove(twtl);
        Trace.Listeners.Remove(ctl);
        Trace.Close();

        if (ctl != null)
        {
            ctl.Close();

            ctl.Dispose();
        }

        if (twtl != null)
        {
            twtl.Close();

            twtl.Dispose();
        }
    }
}

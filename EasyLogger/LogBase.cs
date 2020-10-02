using System;
/// <summary>
/// LogBase: Secondary entry point
/// </summary>
public abstract class LogBase
{
    /// <summary>
    /// Start the logging service
    /// </summary>
    /// <param name="LogFilePath"></param>
    public abstract void AddListener(string LogFilePath);
    /// <summary>
    /// Stops and disposes of the logging service
    /// </summary>
    public abstract void RemoveListener();
    /// <summary>
    /// Backup log files to [FileName].bak; this is to prevent huge log files
    /// </summary>
    /// <param name="LogFilePath"></param>
    public abstract void BackupLogs(string LogFilePath);
    /// <summary>
    /// Insert [error] in the line
    /// </summary>
    /// <param name="message"></param>
    public abstract void Error(string message);
    /// <summary>
    /// Insert [error] in the line
    /// </summary>
    /// <param name="ex"></param>
    public abstract void Error(Exception ex);
    /// <summary>
    /// Insert [warning] in the line
    /// </summary>
    /// <param name="message"></param>
    public abstract void Warning(string message);
    /// <summary>
    /// Insert [info] in the line
    /// </summary>
    /// <param name="message"></param>
    public abstract void Info(string message);
}

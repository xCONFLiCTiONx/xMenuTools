using MenuToolsProcessor.Properties;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MenuToolsProcessor
{
    public partial class AttributesMenu : Form
    {
        private readonly CultureInfo current = CultureInfo.CurrentCulture;
        private static string FilePath;
        private static string[] ThePaths;
        private readonly string FolderPathName;
        private DateTime ct;
        private DateTime at;
        private DateTime wt;
        private bool FindingTimes = true;
        private bool DoneFindingTimes = false;
        private DateTime ctTIME;
        private DateTime atTIME;
        private DateTime wtTIME;

        public AttributesMenu(string[] args)
        {
            if (args != null)
            {
                Thread thread = new Thread(WaitingForFileTimes)
                {
                    IsBackground = true
                };
                thread.Start();
                InitializeComponent();
                BringToFront();
                Activate();
                Focus();
                FormClosing += AttributesMenu_FormClosing;
                // Get : Set Attributes
                foreach (string arg in args)
                {
                    AttributesInfo.GetFileAttributes(arg);
                    ThePaths = args;
                    FilePath = arg;
                    DirectoryInfo DirectoryPath = new DirectoryInfo(FilePath);
                    if (DirectoryPath.Parent == null)
                    {
                        FolderPathName = FilePath;
                    }
                    else
                    {
                        FolderPathName = Path.GetFileName(FilePath);
                    }
                    if (File.Exists(arg) && args.Length < 2)
                    {
                        Text = Resources.labelFileName + FolderPathName;
                    }
                    else if (Directory.Exists(arg) && args.Length < 2)
                    {
                        Text = Resources.labelFolderName + FolderPathName;
                    }
                    else
                    {
                        Text = Resources.MultipleFiles;
                    }
                    SetFileAttributes();
                }
            }
            else
            {
                throw new ArgumentNullException(Resources.ErrorTitle);
            }
        }

        private void AttributesMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            Thread.Sleep(250);
            ExplorerRefresh.RefreshWindowsExplorer();
        }
        private void WaitingForFileTimes()
        {
            while (!DoneFindingTimes)
            {
                Thread.Sleep(100);
            }
            Thread.Sleep(1000);
            FindingTimes = false;
        }
        private void SetFileAttributes()
        {
            // HiddenAttributes
            if (AttributesInfo.hidden)
            {
                HiddenCheckBox.Checked = true;
            }
            if (!AttributesInfo.hidden)
            {
                HiddenCheckBox.Checked = false;
            }
            // SystemAttributes
            if (AttributesInfo.system)
            {
                SystemCheckBox.Checked = true;
            }
            if (!AttributesInfo.system)
            {
                SystemCheckBox.Checked = false;
            }
            // ReadOnlyAttributes
            if (AttributesInfo.readOnly)
            {
                ReadOnlyCheckBox.Checked = true;
            }
            if (!AttributesInfo.readOnly)
            {

                ReadOnlyCheckBox.Checked = false;
            }
            SetInternalAttributes();
        }
        private void SetInternalAttributes()
        {
            if (AttributesInfo.HiddenFilesShowing)
            {
                ShowHiddenCheckBox.Checked = true;
            }
            if (!AttributesInfo.HiddenFilesShowing)
            {
                ShowHiddenCheckBox.Checked = false;
            }
            if (AttributesInfo.SystemFilesShowing)
            {
                ShowSystemCheckBox.Checked = true;
            }
            if (!AttributesInfo.SystemFilesShowing)
            {
                ShowSystemCheckBox.Checked = false;
            }
            SetTimes();
        }
        private void SetTimes()
        {
            if (File.Exists(FilePath))
            {
                TimePicker1.Format = DateTimePickerFormat.Time;
                TimePicker1.ShowUpDown = true;
                ct = File.GetCreationTime(FilePath);
                dateTimePicker1.Value = ct.Date;
                ctTIME = DateTime.Parse(ct.Hour.ToString() + ":" + ct.Minute.ToString() + ":" + ct.Second.ToString());
                TimePicker1.Value = ctTIME;

                TimePicker2.Format = DateTimePickerFormat.Time;
                TimePicker2.ShowUpDown = true;
                at = File.GetLastAccessTime(FilePath);
                dateTimePicker2.Value = at.Date;
                atTIME = DateTime.Parse(at.Hour.ToString() + ":" + at.Minute.ToString() + ":" + at.Second.ToString());
                TimePicker2.Value = atTIME;

                TimePicker3.Format = DateTimePickerFormat.Time;
                TimePicker3.ShowUpDown = true;
                wt = File.GetLastWriteTime(FilePath);
                dateTimePicker3.Value = wt.Date;
                wtTIME = DateTime.Parse(wt.Hour.ToString() + ":" + wt.Minute.ToString() + ":" + wt.Second.ToString());
                TimePicker3.Value = wtTIME;
            }
            else if (Directory.Exists(FilePath))
            {
                TimePicker1.Format = DateTimePickerFormat.Time;
                TimePicker1.ShowUpDown = true;
                ct = Directory.GetCreationTime(FilePath);
                dateTimePicker1.Value = ct.Date;
                ctTIME = DateTime.Parse(ct.Hour.ToString() + ":" + ct.Minute.ToString() + ":" + ct.Second.ToString());
                TimePicker1.Value = ctTIME;

                TimePicker2.Format = DateTimePickerFormat.Time;
                TimePicker2.ShowUpDown = true;
                at = Directory.GetLastAccessTime(FilePath);
                dateTimePicker2.Value = at.Date;
                atTIME = DateTime.Parse(at.Hour.ToString() + ":" + at.Minute.ToString() + ":" + at.Second.ToString());
                TimePicker2.Value = atTIME;

                TimePicker3.Format = DateTimePickerFormat.Time;
                TimePicker3.ShowUpDown = true;
                wt = Directory.GetLastWriteTime(FilePath);
                dateTimePicker3.Value = wt.Date;
                wtTIME = DateTime.Parse(wt.Hour.ToString() + ":" + wt.Minute.ToString() + ":" + wt.Second.ToString());
                TimePicker3.Value = wtTIME;
            }
            DoneFindingTimes = true;
        }

        private void HiddenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(arg);
                    if (HiddenCheckBox.Checked == true)
                    {
                        File.SetAttributes(arg, File.GetAttributes(arg) | FileAttributes.Hidden);
                    }
                    else
                    {
                        attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.Hidden);
                        File.SetAttributes(arg, attributes);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    HiddenCheckBox.Enabled = false;
                    HiddenCheckBox.Text = Resources.SetHiddenUnauthorized;
                }
            }
        }

        private void SystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(arg);
                    if (SystemCheckBox.Checked == true)
                    {
                        File.SetAttributes(arg, File.GetAttributes(arg) | FileAttributes.System);
                    }
                    else
                    {
                        attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.System);
                        File.SetAttributes(arg, attributes);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    SystemCheckBox.Enabled = false;
                    SystemCheckBox.Text = Resources.SetSystemUnauthorized;
                }
            }
        }

        private void ReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(arg);
                    if (ReadOnlyCheckBox.Checked == true)
                    {
                        File.SetAttributes(arg, File.GetAttributes(arg) | FileAttributes.ReadOnly);
                    }
                    else
                    {
                        attributes = AttributesInfo.RemoveAttribute(attributes, FileAttributes.ReadOnly);
                        File.SetAttributes(arg, attributes);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    ReadOnlyCheckBox.Enabled = false;
                    ReadOnlyCheckBox.Text = Resources.SetReadOnlyUnauthorized;
                }
            }
        }

        private void ShowHiddenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ShowHiddenCheckBox.Checked == true)
                {
                    Registry.SetValue(AttributesInfo.UserRoot + AttributesInfo.ExplorerAdvanced, "Hidden", 1.ToString(current), RegistryValueKind.DWord);
                }
                else
                {
                    Registry.SetValue(AttributesInfo.UserRoot + AttributesInfo.ExplorerAdvanced, "Hidden", 2.ToString(current), RegistryValueKind.DWord);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message + Resources.WritePermissions, GetAssembly.AssemblyInformation("filename"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ShowSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ShowSystemCheckBox.Checked == true)
                {
                    Registry.SetValue(AttributesInfo.UserRoot + AttributesInfo.ExplorerAdvanced, "ShowSuperHidden", 1.ToString(current), RegistryValueKind.DWord);
                }
                else
                {
                    Registry.SetValue(AttributesInfo.UserRoot + AttributesInfo.ExplorerAdvanced, "ShowSuperHidden", 2.ToString(current), RegistryValueKind.DWord);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message + Resources.WritePermissions, GetAssembly.AssemblyInformation("filename"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        // Set Creation Time
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker1.Value.Date + TimePicker1.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetCreationTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetCreationTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker1.ValueChanged -= new EventHandler(dateTimePicker1_ValueChanged);
                        dateTimePicker1.Value = ct.Date;
                        dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker1.ValueChanged -= new EventHandler(dateTimePicker1_ValueChanged);
                        dateTimePicker1.Value = ct.Date;
                        dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker1.ValueChanged -= new EventHandler(dateTimePicker1_ValueChanged);
                        dateTimePicker1.Value = ct.Date;
                        dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                    }
                }
            }
        }
        private void TimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker1.Value.Date + TimePicker1.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetCreationTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetCreationTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker1.ValueChanged -= new EventHandler(TimePicker1_ValueChanged);
                        TimePicker1.Value = ctTIME;
                        TimePicker1.ValueChanged += new EventHandler(TimePicker1_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker1.ValueChanged -= new EventHandler(TimePicker1_ValueChanged);
                        TimePicker1.Value = ctTIME;
                        TimePicker1.ValueChanged += new EventHandler(TimePicker1_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker1.ValueChanged -= new EventHandler(TimePicker1_ValueChanged);
                        TimePicker1.Value = ctTIME;
                        TimePicker1.ValueChanged += new EventHandler(TimePicker1_ValueChanged);
                    }
                }
            }
        }
        // Set Last Access Time
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker2.Value.Date + TimePicker2.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetLastAccessTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetLastAccessTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker2.ValueChanged -= new EventHandler(dateTimePicker2_ValueChanged);
                        dateTimePicker2.Value = at.Date;
                        dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker2.ValueChanged -= new EventHandler(dateTimePicker2_ValueChanged);
                        dateTimePicker2.Value = at.Date;
                        dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker2.ValueChanged -= new EventHandler(dateTimePicker2_ValueChanged);
                        dateTimePicker2.Value = at.Date;
                        dateTimePicker2.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
                    }
                }
            }
        }
        private void TimePicker2_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker2.Value.Date + TimePicker2.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetLastAccessTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetLastAccessTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker2.ValueChanged -= new EventHandler(TimePicker2_ValueChanged);
                        TimePicker2.Value = atTIME;
                        TimePicker2.ValueChanged += new EventHandler(TimePicker2_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker2.ValueChanged -= new EventHandler(TimePicker2_ValueChanged);
                        TimePicker2.Value = atTIME;
                        TimePicker2.ValueChanged += new EventHandler(TimePicker2_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker2.ValueChanged -= new EventHandler(TimePicker2_ValueChanged);
                        TimePicker2.Value = atTIME;
                        TimePicker2.ValueChanged += new EventHandler(TimePicker2_ValueChanged);
                    }
                }
            }
        }
        // Set Last Write Time
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker3.Value.Date + TimePicker3.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetLastWriteTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetLastWriteTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker3.ValueChanged -= new EventHandler(dateTimePicker3_ValueChanged);
                        dateTimePicker3.Value = wt.Date;
                        dateTimePicker3.ValueChanged += new EventHandler(dateTimePicker3_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker3.ValueChanged -= new EventHandler(dateTimePicker3_ValueChanged);
                        dateTimePicker3.Value = wt.Date;
                        dateTimePicker3.ValueChanged += new EventHandler(dateTimePicker3_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dateTimePicker3.ValueChanged -= new EventHandler(dateTimePicker3_ValueChanged);
                        dateTimePicker3.Value = wt.Date;
                        dateTimePicker3.ValueChanged += new EventHandler(dateTimePicker3_ValueChanged);
                    }
                }
            }
        }
        private void TimePicker3_ValueChanged(object sender, EventArgs e)
        {
            foreach (string arg in ThePaths)
            {
                if (!FindingTimes)
                {
                    try
                    {
                        DateTime datetime = new DateTime();
                        datetime = dateTimePicker3.Value.Date + TimePicker3.Value.TimeOfDay;
                        if (File.Exists(arg))
                        {
                            File.SetLastWriteTime(arg, datetime);
                        }
                        else if (Directory.Exists(arg))
                        {
                            Directory.SetLastWriteTime(arg, datetime);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker3.ValueChanged -= new EventHandler(TimePicker3_ValueChanged);
                        TimePicker3.Value = wtTIME;
                        TimePicker3.ValueChanged += new EventHandler(TimePicker3_ValueChanged);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(Resources.UnauthorizedAccessExceptionP1 + "'" + arg + "'" + Resources.UnauthorizedAccessExceptionP2 + "'" + arg + "'", Resources.UnauthorizedAccessException2PTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker3.ValueChanged -= new EventHandler(TimePicker3_ValueChanged);
                        TimePicker3.Value = wtTIME;
                        TimePicker3.ValueChanged += new EventHandler(TimePicker3_ValueChanged);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, Resources.AccessError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TimePicker3.ValueChanged -= new EventHandler(TimePicker3_ValueChanged);
                        TimePicker3.Value = wtTIME;
                        TimePicker3.ValueChanged += new EventHandler(TimePicker3_ValueChanged);
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ExplorerRefresh.RefreshWindowsExplorer();
        }
    }
}

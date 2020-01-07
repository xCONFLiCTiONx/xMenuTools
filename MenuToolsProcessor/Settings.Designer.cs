namespace MenuToolsProcessor
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AllFilesSelectAllCheckbox = new System.Windows.Forms.CheckBox();
            this.TakeOwnershipFileCheckBox = new System.Windows.Forms.CheckBox();
            this.FileSymLinkCheckBox = new System.Windows.Forms.CheckBox();
            this.FileAttributesCheckBox = new System.Windows.Forms.CheckBox();
            this.CopyFileNameCheckBox = new System.Windows.Forms.CheckBox();
            this.CopyFilePathCheckBox = new System.Windows.Forms.CheckBox();
            this.BlockWithFirewallCheckBox = new System.Windows.Forms.CheckBox();
            this.NotepadCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AttributesShortcutsCheckbox = new System.Windows.Forms.CheckBox();
            this.ShortNotepadCheckbox = new System.Windows.Forms.CheckBox();
            this.ShorcutsSelectAllCheckbox = new System.Windows.Forms.CheckBox();
            this.CopyNameShortcutCheckbox = new System.Windows.Forms.CheckBox();
            this.CopyPathShorcutCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DirSelectAllCheckbox = new System.Windows.Forms.CheckBox();
            this.TakeOwnershipDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.SymLinkDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.AttributesDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.CopyNameDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.CopyPathDirectoryCheckbox = new System.Windows.Forms.CheckBox();
            this.BlockFirewallDirectoryCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PasteContentsCheckbox = new System.Windows.Forms.CheckBox();
            this.SystemFoldersCheckbox = new System.Windows.Forms.CheckBox();
            this.DirBackSelectAllCheckbox = new System.Windows.Forms.CheckBox();
            this.DirBackWallpaperCheckbox = new System.Windows.Forms.CheckBox();
            this.DirBackComLinesCheckbox = new System.Windows.Forms.CheckBox();
            this.DirBackAttributesCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 18);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(306, 269);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.AllFilesSelectAllCheckbox);
            this.tabPage1.Controls.Add(this.TakeOwnershipFileCheckBox);
            this.tabPage1.Controls.Add(this.FileSymLinkCheckBox);
            this.tabPage1.Controls.Add(this.FileAttributesCheckBox);
            this.tabPage1.Controls.Add(this.CopyFileNameCheckBox);
            this.tabPage1.Controls.Add(this.CopyFilePathCheckBox);
            this.tabPage1.Controls.Add(this.BlockWithFirewallCheckBox);
            this.tabPage1.Controls.Add(this.NotepadCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(298, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All Files";
            // 
            // AllFilesSelectAllCheckbox
            // 
            this.AllFilesSelectAllCheckbox.AutoSize = true;
            this.AllFilesSelectAllCheckbox.Location = new System.Drawing.Point(19, 12);
            this.AllFilesSelectAllCheckbox.Name = "AllFilesSelectAllCheckbox";
            this.AllFilesSelectAllCheckbox.Size = new System.Drawing.Size(70, 17);
            this.AllFilesSelectAllCheckbox.TabIndex = 20;
            this.AllFilesSelectAllCheckbox.TabStop = false;
            this.AllFilesSelectAllCheckbox.Text = "Select All";
            this.AllFilesSelectAllCheckbox.UseVisualStyleBackColor = true;
            this.AllFilesSelectAllCheckbox.CheckedChanged += new System.EventHandler(this.AllFilesSelectAllCheckbox_CheckedChanged);
            // 
            // TakeOwnershipFileCheckBox
            // 
            this.TakeOwnershipFileCheckBox.AutoSize = true;
            this.TakeOwnershipFileCheckBox.Location = new System.Drawing.Point(34, 173);
            this.TakeOwnershipFileCheckBox.Name = "TakeOwnershipFileCheckBox";
            this.TakeOwnershipFileCheckBox.Size = new System.Drawing.Size(104, 17);
            this.TakeOwnershipFileCheckBox.TabIndex = 19;
            this.TakeOwnershipFileCheckBox.TabStop = false;
            this.TakeOwnershipFileCheckBox.Text = "Take Ownership";
            this.TakeOwnershipFileCheckBox.UseVisualStyleBackColor = true;
            this.TakeOwnershipFileCheckBox.CheckedChanged += new System.EventHandler(this.TakeOwnershipFileCheckBox_CheckedChanged);
            // 
            // FileSymLinkCheckBox
            // 
            this.FileSymLinkCheckBox.AutoSize = true;
            this.FileSymLinkCheckBox.Location = new System.Drawing.Point(34, 150);
            this.FileSymLinkCheckBox.Name = "FileSymLinkCheckBox";
            this.FileSymLinkCheckBox.Size = new System.Drawing.Size(140, 17);
            this.FileSymLinkCheckBox.TabIndex = 18;
            this.FileSymLinkCheckBox.TabStop = false;
            this.FileSymLinkCheckBox.Text = "Symbolic Link (Junction)";
            this.FileSymLinkCheckBox.UseVisualStyleBackColor = true;
            this.FileSymLinkCheckBox.CheckedChanged += new System.EventHandler(this.FileSymLinkCheckBox_CheckedChanged);
            // 
            // FileAttributesCheckBox
            // 
            this.FileAttributesCheckBox.AutoSize = true;
            this.FileAttributesCheckBox.Location = new System.Drawing.Point(34, 127);
            this.FileAttributesCheckBox.Name = "FileAttributesCheckBox";
            this.FileAttributesCheckBox.Size = new System.Drawing.Size(70, 17);
            this.FileAttributesCheckBox.TabIndex = 17;
            this.FileAttributesCheckBox.TabStop = false;
            this.FileAttributesCheckBox.Text = "Attributes";
            this.FileAttributesCheckBox.UseVisualStyleBackColor = true;
            this.FileAttributesCheckBox.CheckedChanged += new System.EventHandler(this.FileAttributesCheckBox_CheckedChanged);
            // 
            // CopyFileNameCheckBox
            // 
            this.CopyFileNameCheckBox.AutoSize = true;
            this.CopyFileNameCheckBox.Location = new System.Drawing.Point(34, 104);
            this.CopyFileNameCheckBox.Name = "CopyFileNameCheckBox";
            this.CopyFileNameCheckBox.Size = new System.Drawing.Size(81, 17);
            this.CopyFileNameCheckBox.TabIndex = 16;
            this.CopyFileNameCheckBox.TabStop = false;
            this.CopyFileNameCheckBox.Text = "Copy Name";
            this.CopyFileNameCheckBox.UseVisualStyleBackColor = true;
            this.CopyFileNameCheckBox.CheckedChanged += new System.EventHandler(this.CopyFileNameCheckBox_CheckedChanged);
            // 
            // CopyFilePathCheckBox
            // 
            this.CopyFilePathCheckBox.AutoSize = true;
            this.CopyFilePathCheckBox.Location = new System.Drawing.Point(34, 81);
            this.CopyFilePathCheckBox.Name = "CopyFilePathCheckBox";
            this.CopyFilePathCheckBox.Size = new System.Drawing.Size(75, 17);
            this.CopyFilePathCheckBox.TabIndex = 15;
            this.CopyFilePathCheckBox.TabStop = false;
            this.CopyFilePathCheckBox.Text = "Copy Path";
            this.CopyFilePathCheckBox.UseVisualStyleBackColor = true;
            this.CopyFilePathCheckBox.CheckedChanged += new System.EventHandler(this.CopyFilePathCheckBox_CheckedChanged);
            // 
            // BlockWithFirewallCheckBox
            // 
            this.BlockWithFirewallCheckBox.AutoSize = true;
            this.BlockWithFirewallCheckBox.Location = new System.Drawing.Point(34, 58);
            this.BlockWithFirewallCheckBox.Name = "BlockWithFirewallCheckBox";
            this.BlockWithFirewallCheckBox.Size = new System.Drawing.Size(160, 17);
            this.BlockWithFirewallCheckBox.TabIndex = 14;
            this.BlockWithFirewallCheckBox.TabStop = false;
            this.BlockWithFirewallCheckBox.Text = "Block with Windows Firewall";
            this.BlockWithFirewallCheckBox.UseVisualStyleBackColor = true;
            this.BlockWithFirewallCheckBox.CheckedChanged += new System.EventHandler(this.BlockWithFirewallCheckBox_CheckedChanged);
            // 
            // NotepadCheckBox
            // 
            this.NotepadCheckBox.AutoSize = true;
            this.NotepadCheckBox.Location = new System.Drawing.Point(34, 35);
            this.NotepadCheckBox.Name = "NotepadCheckBox";
            this.NotepadCheckBox.Size = new System.Drawing.Size(118, 17);
            this.NotepadCheckBox.TabIndex = 13;
            this.NotepadCheckBox.TabStop = false;
            this.NotepadCheckBox.Text = "Open with Notepad";
            this.NotepadCheckBox.UseVisualStyleBackColor = true;
            this.NotepadCheckBox.CheckedChanged += new System.EventHandler(this.NotepadCheckBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.AttributesShortcutsCheckbox);
            this.tabPage2.Controls.Add(this.ShortNotepadCheckbox);
            this.tabPage2.Controls.Add(this.ShorcutsSelectAllCheckbox);
            this.tabPage2.Controls.Add(this.CopyNameShortcutCheckbox);
            this.tabPage2.Controls.Add(this.CopyPathShorcutCheckbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(298, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shortcuts";
            // 
            // AttributesShortcutsCheckbox
            // 
            this.AttributesShortcutsCheckbox.AutoSize = true;
            this.AttributesShortcutsCheckbox.Location = new System.Drawing.Point(33, 35);
            this.AttributesShortcutsCheckbox.Name = "AttributesShortcutsCheckbox";
            this.AttributesShortcutsCheckbox.Size = new System.Drawing.Size(70, 17);
            this.AttributesShortcutsCheckbox.TabIndex = 19;
            this.AttributesShortcutsCheckbox.TabStop = false;
            this.AttributesShortcutsCheckbox.Text = "Attributes";
            this.AttributesShortcutsCheckbox.UseVisualStyleBackColor = true;
            this.AttributesShortcutsCheckbox.CheckedChanged += new System.EventHandler(this.AttributesShortcutsCheckbox_CheckedChanged);
            // 
            // ShortNotepadCheckbox
            // 
            this.ShortNotepadCheckbox.AutoSize = true;
            this.ShortNotepadCheckbox.Location = new System.Drawing.Point(33, 58);
            this.ShortNotepadCheckbox.Name = "ShortNotepadCheckbox";
            this.ShortNotepadCheckbox.Size = new System.Drawing.Size(118, 17);
            this.ShortNotepadCheckbox.TabIndex = 18;
            this.ShortNotepadCheckbox.TabStop = false;
            this.ShortNotepadCheckbox.Text = "Open with Notepad";
            this.ShortNotepadCheckbox.UseVisualStyleBackColor = true;
            this.ShortNotepadCheckbox.CheckedChanged += new System.EventHandler(this.ShortNotepadCheckbox_CheckedChanged);
            // 
            // ShorcutsSelectAllCheckbox
            // 
            this.ShorcutsSelectAllCheckbox.AutoSize = true;
            this.ShorcutsSelectAllCheckbox.Location = new System.Drawing.Point(19, 12);
            this.ShorcutsSelectAllCheckbox.Name = "ShorcutsSelectAllCheckbox";
            this.ShorcutsSelectAllCheckbox.Size = new System.Drawing.Size(70, 17);
            this.ShorcutsSelectAllCheckbox.TabIndex = 17;
            this.ShorcutsSelectAllCheckbox.TabStop = false;
            this.ShorcutsSelectAllCheckbox.Text = "Select All";
            this.ShorcutsSelectAllCheckbox.UseVisualStyleBackColor = true;
            this.ShorcutsSelectAllCheckbox.CheckedChanged += new System.EventHandler(this.ShorcutsSelectAllCheckbox_CheckedChanged);
            // 
            // CopyNameShortcutCheckbox
            // 
            this.CopyNameShortcutCheckbox.AutoSize = true;
            this.CopyNameShortcutCheckbox.Location = new System.Drawing.Point(33, 104);
            this.CopyNameShortcutCheckbox.Name = "CopyNameShortcutCheckbox";
            this.CopyNameShortcutCheckbox.Size = new System.Drawing.Size(81, 17);
            this.CopyNameShortcutCheckbox.TabIndex = 16;
            this.CopyNameShortcutCheckbox.TabStop = false;
            this.CopyNameShortcutCheckbox.Text = "Copy Name";
            this.CopyNameShortcutCheckbox.UseVisualStyleBackColor = true;
            this.CopyNameShortcutCheckbox.CheckedChanged += new System.EventHandler(this.CopyNameShortcutCheckbox_CheckedChanged);
            // 
            // CopyPathShorcutCheckbox
            // 
            this.CopyPathShorcutCheckbox.AutoSize = true;
            this.CopyPathShorcutCheckbox.Location = new System.Drawing.Point(33, 81);
            this.CopyPathShorcutCheckbox.Name = "CopyPathShorcutCheckbox";
            this.CopyPathShorcutCheckbox.Size = new System.Drawing.Size(75, 17);
            this.CopyPathShorcutCheckbox.TabIndex = 15;
            this.CopyPathShorcutCheckbox.TabStop = false;
            this.CopyPathShorcutCheckbox.Text = "Copy Path";
            this.CopyPathShorcutCheckbox.UseVisualStyleBackColor = true;
            this.CopyPathShorcutCheckbox.CheckedChanged += new System.EventHandler(this.CopyPathShorcutCheckbox_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.DirSelectAllCheckbox);
            this.tabPage3.Controls.Add(this.TakeOwnershipDirectoryCheckbox);
            this.tabPage3.Controls.Add(this.SymLinkDirectoryCheckbox);
            this.tabPage3.Controls.Add(this.AttributesDirectoryCheckbox);
            this.tabPage3.Controls.Add(this.CopyNameDirectoryCheckbox);
            this.tabPage3.Controls.Add(this.CopyPathDirectoryCheckbox);
            this.tabPage3.Controls.Add(this.BlockFirewallDirectoryCheckBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(298, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Directories";
            // 
            // DirSelectAllCheckbox
            // 
            this.DirSelectAllCheckbox.AutoSize = true;
            this.DirSelectAllCheckbox.Location = new System.Drawing.Point(19, 12);
            this.DirSelectAllCheckbox.Name = "DirSelectAllCheckbox";
            this.DirSelectAllCheckbox.Size = new System.Drawing.Size(70, 17);
            this.DirSelectAllCheckbox.TabIndex = 28;
            this.DirSelectAllCheckbox.TabStop = false;
            this.DirSelectAllCheckbox.Text = "Select All";
            this.DirSelectAllCheckbox.UseVisualStyleBackColor = true;
            this.DirSelectAllCheckbox.CheckedChanged += new System.EventHandler(this.DirSelectAllCheckbox_CheckedChanged);
            // 
            // TakeOwnershipDirectoryCheckbox
            // 
            this.TakeOwnershipDirectoryCheckbox.AutoSize = true;
            this.TakeOwnershipDirectoryCheckbox.Location = new System.Drawing.Point(34, 150);
            this.TakeOwnershipDirectoryCheckbox.Name = "TakeOwnershipDirectoryCheckbox";
            this.TakeOwnershipDirectoryCheckbox.Size = new System.Drawing.Size(104, 17);
            this.TakeOwnershipDirectoryCheckbox.TabIndex = 27;
            this.TakeOwnershipDirectoryCheckbox.Text = "Take Ownership";
            this.TakeOwnershipDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.TakeOwnershipDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.TakeOwnershipDirectoryCheckbox_CheckedChanged);
            // 
            // SymLinkDirectoryCheckbox
            // 
            this.SymLinkDirectoryCheckbox.AutoSize = true;
            this.SymLinkDirectoryCheckbox.Location = new System.Drawing.Point(34, 127);
            this.SymLinkDirectoryCheckbox.Name = "SymLinkDirectoryCheckbox";
            this.SymLinkDirectoryCheckbox.Size = new System.Drawing.Size(140, 17);
            this.SymLinkDirectoryCheckbox.TabIndex = 26;
            this.SymLinkDirectoryCheckbox.TabStop = false;
            this.SymLinkDirectoryCheckbox.Text = "Symbolic Link (Junction)";
            this.SymLinkDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.SymLinkDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.SymLinkDirectoryCheckbox_CheckedChanged);
            // 
            // AttributesDirectoryCheckbox
            // 
            this.AttributesDirectoryCheckbox.AutoSize = true;
            this.AttributesDirectoryCheckbox.Location = new System.Drawing.Point(34, 104);
            this.AttributesDirectoryCheckbox.Name = "AttributesDirectoryCheckbox";
            this.AttributesDirectoryCheckbox.Size = new System.Drawing.Size(70, 17);
            this.AttributesDirectoryCheckbox.TabIndex = 25;
            this.AttributesDirectoryCheckbox.TabStop = false;
            this.AttributesDirectoryCheckbox.Text = "Attributes";
            this.AttributesDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.AttributesDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.AttributesDirectoryCheckbox_CheckedChanged);
            // 
            // CopyNameDirectoryCheckbox
            // 
            this.CopyNameDirectoryCheckbox.AutoSize = true;
            this.CopyNameDirectoryCheckbox.Location = new System.Drawing.Point(34, 81);
            this.CopyNameDirectoryCheckbox.Name = "CopyNameDirectoryCheckbox";
            this.CopyNameDirectoryCheckbox.Size = new System.Drawing.Size(81, 17);
            this.CopyNameDirectoryCheckbox.TabIndex = 24;
            this.CopyNameDirectoryCheckbox.TabStop = false;
            this.CopyNameDirectoryCheckbox.Text = "Copy Name";
            this.CopyNameDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.CopyNameDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.CopyNameDirectoryCheckbox_CheckedChanged);
            // 
            // CopyPathDirectoryCheckbox
            // 
            this.CopyPathDirectoryCheckbox.AutoSize = true;
            this.CopyPathDirectoryCheckbox.Location = new System.Drawing.Point(34, 58);
            this.CopyPathDirectoryCheckbox.Name = "CopyPathDirectoryCheckbox";
            this.CopyPathDirectoryCheckbox.Size = new System.Drawing.Size(75, 17);
            this.CopyPathDirectoryCheckbox.TabIndex = 23;
            this.CopyPathDirectoryCheckbox.TabStop = false;
            this.CopyPathDirectoryCheckbox.Text = "Copy Path";
            this.CopyPathDirectoryCheckbox.UseVisualStyleBackColor = true;
            this.CopyPathDirectoryCheckbox.CheckedChanged += new System.EventHandler(this.CopyPathDirectoryCheckbox_CheckedChanged);
            // 
            // BlockFirewallDirectoryCheckBox
            // 
            this.BlockFirewallDirectoryCheckBox.AutoSize = true;
            this.BlockFirewallDirectoryCheckBox.Location = new System.Drawing.Point(34, 35);
            this.BlockFirewallDirectoryCheckBox.Name = "BlockFirewallDirectoryCheckBox";
            this.BlockFirewallDirectoryCheckBox.Size = new System.Drawing.Size(174, 17);
            this.BlockFirewallDirectoryCheckBox.TabIndex = 22;
            this.BlockFirewallDirectoryCheckBox.TabStop = false;
            this.BlockFirewallDirectoryCheckBox.Text = "Block All with Windows Firewall";
            this.BlockFirewallDirectoryCheckBox.UseVisualStyleBackColor = true;
            this.BlockFirewallDirectoryCheckBox.CheckedChanged += new System.EventHandler(this.BlockFirewallDirectoryCheckBox_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.PasteContentsCheckbox);
            this.tabPage4.Controls.Add(this.SystemFoldersCheckbox);
            this.tabPage4.Controls.Add(this.DirBackSelectAllCheckbox);
            this.tabPage4.Controls.Add(this.DirBackWallpaperCheckbox);
            this.tabPage4.Controls.Add(this.DirBackComLinesCheckbox);
            this.tabPage4.Controls.Add(this.DirBackAttributesCheckbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(298, 243);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Background";
            // 
            // PasteContentsCheckbox
            // 
            this.PasteContentsCheckbox.AutoSize = true;
            this.PasteContentsCheckbox.Location = new System.Drawing.Point(34, 127);
            this.PasteContentsCheckbox.Name = "PasteContentsCheckbox";
            this.PasteContentsCheckbox.Size = new System.Drawing.Size(147, 17);
            this.PasteContentsCheckbox.TabIndex = 19;
            this.PasteContentsCheckbox.TabStop = false;
            this.PasteContentsCheckbox.Text = "Paste clipboard text to file";
            this.PasteContentsCheckbox.UseVisualStyleBackColor = true;
            this.PasteContentsCheckbox.CheckedChanged += new System.EventHandler(this.PasteContentsCheckbox_CheckedChanged_1);
            // 
            // SystemFoldersCheckbox
            // 
            this.SystemFoldersCheckbox.AutoSize = true;
            this.SystemFoldersCheckbox.Location = new System.Drawing.Point(34, 104);
            this.SystemFoldersCheckbox.Name = "SystemFoldersCheckbox";
            this.SystemFoldersCheckbox.Size = new System.Drawing.Size(97, 17);
            this.SystemFoldersCheckbox.TabIndex = 18;
            this.SystemFoldersCheckbox.TabStop = false;
            this.SystemFoldersCheckbox.Text = "System Folders";
            this.SystemFoldersCheckbox.UseVisualStyleBackColor = true;
            this.SystemFoldersCheckbox.CheckedChanged += new System.EventHandler(this.SystemFoldersCheckBox_CheckedChanged);
            // 
            // DirBackSelectAllCheckbox
            // 
            this.DirBackSelectAllCheckbox.AutoSize = true;
            this.DirBackSelectAllCheckbox.Location = new System.Drawing.Point(19, 12);
            this.DirBackSelectAllCheckbox.Name = "DirBackSelectAllCheckbox";
            this.DirBackSelectAllCheckbox.Size = new System.Drawing.Size(70, 17);
            this.DirBackSelectAllCheckbox.TabIndex = 17;
            this.DirBackSelectAllCheckbox.TabStop = false;
            this.DirBackSelectAllCheckbox.Text = "Select All";
            this.DirBackSelectAllCheckbox.UseVisualStyleBackColor = true;
            this.DirBackSelectAllCheckbox.CheckedChanged += new System.EventHandler(this.DirBackSelectAllCheckbox_CheckedChanged);
            // 
            // DirBackWallpaperCheckbox
            // 
            this.DirBackWallpaperCheckbox.AutoSize = true;
            this.DirBackWallpaperCheckbox.Location = new System.Drawing.Point(34, 81);
            this.DirBackWallpaperCheckbox.Name = "DirBackWallpaperCheckbox";
            this.DirBackWallpaperCheckbox.Size = new System.Drawing.Size(97, 17);
            this.DirBackWallpaperCheckbox.TabIndex = 16;
            this.DirBackWallpaperCheckbox.TabStop = false;
            this.DirBackWallpaperCheckbox.Text = "Find Wallpaper";
            this.DirBackWallpaperCheckbox.UseVisualStyleBackColor = true;
            this.DirBackWallpaperCheckbox.CheckedChanged += new System.EventHandler(this.DirBackWallpaperCheckbox_CheckedChanged);
            // 
            // DirBackComLinesCheckbox
            // 
            this.DirBackComLinesCheckbox.AutoSize = true;
            this.DirBackComLinesCheckbox.Location = new System.Drawing.Point(34, 58);
            this.DirBackComLinesCheckbox.Name = "DirBackComLinesCheckbox";
            this.DirBackComLinesCheckbox.Size = new System.Drawing.Size(101, 17);
            this.DirBackComLinesCheckbox.TabIndex = 15;
            this.DirBackComLinesCheckbox.TabStop = false;
            this.DirBackComLinesCheckbox.Text = "Command Lines";
            this.DirBackComLinesCheckbox.UseVisualStyleBackColor = true;
            this.DirBackComLinesCheckbox.CheckedChanged += new System.EventHandler(this.DirBackComLinesCheckbox_CheckedChanged);
            // 
            // DirBackAttributesCheckbox
            // 
            this.DirBackAttributesCheckbox.AutoSize = true;
            this.DirBackAttributesCheckbox.Location = new System.Drawing.Point(34, 35);
            this.DirBackAttributesCheckbox.Name = "DirBackAttributesCheckbox";
            this.DirBackAttributesCheckbox.Size = new System.Drawing.Size(70, 17);
            this.DirBackAttributesCheckbox.TabIndex = 14;
            this.DirBackAttributesCheckbox.TabStop = false;
            this.DirBackAttributesCheckbox.Text = "Attributes";
            this.DirBackAttributesCheckbox.UseVisualStyleBackColor = true;
            this.DirBackAttributesCheckbox.CheckedChanged += new System.EventHandler(this.DirBackAttributesCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(311, 296);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuTools Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox DirSelectAllCheckbox;
        private System.Windows.Forms.CheckBox TakeOwnershipDirectoryCheckbox;
        private System.Windows.Forms.CheckBox SymLinkDirectoryCheckbox;
        private System.Windows.Forms.CheckBox AttributesDirectoryCheckbox;
        private System.Windows.Forms.CheckBox CopyNameDirectoryCheckbox;
        private System.Windows.Forms.CheckBox CopyPathDirectoryCheckbox;
        private System.Windows.Forms.CheckBox BlockFirewallDirectoryCheckBox;
        private System.Windows.Forms.CheckBox AllFilesSelectAllCheckbox;
        private System.Windows.Forms.CheckBox TakeOwnershipFileCheckBox;
        private System.Windows.Forms.CheckBox FileSymLinkCheckBox;
        private System.Windows.Forms.CheckBox FileAttributesCheckBox;
        private System.Windows.Forms.CheckBox CopyFileNameCheckBox;
        private System.Windows.Forms.CheckBox CopyFilePathCheckBox;
        private System.Windows.Forms.CheckBox BlockWithFirewallCheckBox;
        private System.Windows.Forms.CheckBox NotepadCheckBox;
        private System.Windows.Forms.CheckBox DirBackSelectAllCheckbox;
        private System.Windows.Forms.CheckBox DirBackWallpaperCheckbox;
        private System.Windows.Forms.CheckBox DirBackComLinesCheckbox;
        private System.Windows.Forms.CheckBox DirBackAttributesCheckbox;
        private System.Windows.Forms.CheckBox ShortNotepadCheckbox;
        private System.Windows.Forms.CheckBox ShorcutsSelectAllCheckbox;
        private System.Windows.Forms.CheckBox CopyNameShortcutCheckbox;
        private System.Windows.Forms.CheckBox CopyPathShorcutCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SystemFoldersCheckbox;
        private System.Windows.Forms.CheckBox PasteContentsCheckbox;
        private System.Windows.Forms.CheckBox AttributesShortcutsCheckbox;
    }
}
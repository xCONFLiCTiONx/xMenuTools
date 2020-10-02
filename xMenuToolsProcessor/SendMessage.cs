using System;
using System.Windows.Forms;

namespace xMenuToolsProcessor
{
    public class SendMessage
    {
        public static DialogResult MessageForm(string text, string title = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button2)
        {
            try
            {
                // Log this message for debugging
                if (icon == MessageBoxIcon.Error)
                {
                    EasyLogger.Error(text);
                }
                else if (icon == MessageBoxIcon.Warning)
                {
                    EasyLogger.Info(text);
                }
                else
                {
                    EasyLogger.Info(text);
                }

                using (Form form = new Form())
                {
                    form.Opacity = 0;

                    form.Show();

                    form.WindowState = FormWindowState.Minimized;

                    form.WindowState = FormWindowState.Normal;

                    DialogResult dialogResult = MessageBox.Show(form, text, title, buttons, icon, defaultButton);
                    if (dialogResult == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    return dialogResult;
                }
            }
            catch (Exception ex)
            {
                EasyLogger.Error(ex);

                return DialogResult.None;
            }
        }
    }
}

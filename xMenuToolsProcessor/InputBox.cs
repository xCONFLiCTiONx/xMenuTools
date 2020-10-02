using System;
using System.Windows.Forms;

namespace xMenuToolsProcessor
{
    public partial class InputBox : Form
    {
        public InputBox(string location = null)
        {
            InitializeComponent();
            textBox1.Text = location;
            textBox1.PreviewKeyDown += TextBox1_PreviewKeyDown;
        }

        private void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Main.JunctionName = textBox1.Text;
                Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Main.JunctionName = textBox1.Text;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

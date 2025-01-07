using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoAdder.View.MessageBox
{
    public class MessageBoxDisplayer
    {
        public void ShowErrorBox(string title, string message)
        {
            System.Windows.Forms.MessageBox.Show(title, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInformationBox(string title, string message)
        {
            System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

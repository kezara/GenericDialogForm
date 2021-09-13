using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDialogForm
{
    public class FileBrowse : IDialogBrowseButton
    {
        public string ButtonBrowse_Click(string text, string filter)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = text;
                ofd.Filter = filter;
                ofd.RestoreDirectory = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    text = ofd.FileName;
                }
            }

            return text;
        }
    }
}

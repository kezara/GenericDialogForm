using System.Windows.Forms;

namespace GenericDialogForm
{
    internal class FolderBrowse : IDialogBrowseButton
    {
        public string ButtonBrowse_Click(string text, string filter = null)
        {
            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = text
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                text = folderDialog.SelectedPath;
            }

            return text;
        }
    }
}
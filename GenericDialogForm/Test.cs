using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDialogForm
{
    public class Test
    {
        private string inputPath;
        private string outputPath;
        private List<string> _paths;

        public List<string> Paths
        {
            get { return _paths; }
            private set { _paths = value; }
        }

        private List<IDialogComponents> dialogComponents { get; set; }

        public Test()
        {
            Paths = new List<string>();
        }

        private List<string> CreateDialog()
        {
            var components = new List<Tuple<DialogEnums, Tuple<string, List<string>>>>
            {
                new Tuple<DialogEnums, Tuple<string, List<string>>>( DialogEnums.FOLDER_BROWSE, 
                    new Tuple<string, List<string>>("Input Folder", new List<string> { "Input folder", "Folder path", "Select" }) ),
                new Tuple<DialogEnums, Tuple<string, List<string>>>( DialogEnums.FOLDER_BROWSE, 
                    new Tuple<string, List<string>>("Output Folder", new List<string> { "Output folder", "Folder path", "Select" }) ),
                new Tuple<DialogEnums, Tuple<string, List<string>>>( DialogEnums.FILE_NAME, 
                    new Tuple<string, List<string>>("File Name", new List<string>{"File Name:", "Name of the File"} ))
            };

            var genericDialogForm = new GenericDialogForm("Test form", components);
            genericDialogForm.Components["Input Folder"].TextBoxEnabled = false;
            genericDialogForm.ComponentsWithButton["Output Folder"].ButtonEnabled = false;
            genericDialogForm.ShowDialog();

            if (genericDialogForm.DialogResult == DialogResult.OK)
            {
                return genericDialogForm.DialogPaths;
            }
            return null;
        }

        public bool ShowItems()
        {
            bool isEnd = false;
            Paths = CreateDialog();
            if (Paths == null)
            {
                MessageBox.Show("Something went wron, please try again!");
                isEnd = ShowItems();

            }
            if (!isEnd)
            {
                MessageBox.Show($"input: {Paths[0]}\noutput: {Paths[1]}\nfile Name: {Paths[2]}"); 
            }
            return true;
        }
    }
}

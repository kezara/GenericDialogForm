using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDialogForm
{
    public partial class DialogComponentsFolderBrowse : UserControl, IDialogComponentsWithButton
    {
        private string _pathSelected;
        private bool _textBoxEnabled;
        private bool _buttonEnabled;
        private string _componentName;

        public string ComponentName
        {
            get { return _componentName; }
        }


        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set 
            { 
                _buttonEnabled = value;
                button1.Enabled = _buttonEnabled;
            }
        }


        public bool TextBoxEnabled
        {
            get { return _textBoxEnabled; }
            set 
            { 
                _textBoxEnabled = value;
                textBox1.Enabled = _textBoxEnabled;
            }
        }


        public string PathSelected
        {
            get
            {
                _pathSelected = textBox1.Text;
                return _pathSelected;
            }
            private set { _pathSelected = value; }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Tuple wher Item1 is name of the component
        /// and Item2 is List of strings that represent label, texbox and button text</param>
        public DialogComponentsFolderBrowse(Tuple<string, List<string>> text)
        {
            InitializeComponent();
            
            Name = text.Item1;
            _componentName = Name;
            label1.Text = text.Item2[0];
            textBox1.Text = text.Item2[1];
            button1.Text = text.Item2[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = textBox1.Text
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderDialog.SelectedPath;
            }
        }

        public void SetLocation(Point location)
        {
            Location = location;
        }

        public Point GetLocation()
        {
            return Location;
        }
    }
}

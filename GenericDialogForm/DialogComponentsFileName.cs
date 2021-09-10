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
    public partial class DialogComponentsFileName : UserControl, IDialogComponents
    {

        private string _pathSelected;
        private bool _textBoxEnabled;
        private string _componentName;

        public string ComponentName
        {
            get { return _componentName; }
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
            get {
                _pathSelected = textBox1.Text;
                return _pathSelected; 
            }
            private set { _pathSelected = value; }
                
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Tuple wher Item1 is name of the component
        /// and Item2 is List of strings that represent label and texbox text</param>
        public DialogComponentsFileName(Tuple<string, List<string>> text)
        {
            InitializeComponent();
            Name = text.Item1;
            _componentName = Name;
            label1.Text = text.Item2[0];
            textBox1.Text = text.Item2[1];
        }


        public Point GetLocation()
        {
            return Location;
        }

        public void SetLocation(Point location)
        {
            Location = location;
        }
    }
}

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

        public string PathSelected
        {
            get {
                _pathSelected = textBox1.Text;
                return _pathSelected; 
            }
            private set { _pathSelected = value; }
                
        }


        public DialogComponentsFileName(List<string> text)
        {
            InitializeComponent();
            label1.Text = text[0];
            textBox1.Text = text[1];
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

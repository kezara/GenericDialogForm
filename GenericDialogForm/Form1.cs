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
    public partial class Form1 : Form
    {
        private GenericDialogForm genericDialogForm;
        public Form1()
        {
            InitializeComponent();
            //var component = new DialogComponents();
            //var components = new List<DialogComponents>();

            //component.LabelText = "Input File:";
            //component.TextBoxText = "Sample Text";
            //component.ButtonText = "Select";
            //var component1 = new DialogComponents();

            //component1.LabelText = "Output File:";
            //component1.TextBoxText = "Sample Text";
            //component1.ButtonText = "Select";
            //var component2 = new DialogComponents();

            //component2.LabelText = "Output File:";
            //component2.TextBoxText = "Sample Text";
            //component2.ButtonText = "Select";

            //var component3 = new DialogComponents();

            //component3.LabelText = "Output File:";
            //component3.TextBoxText = "Sample Text";
            //component3.ButtonText = "Select";

            //var component4 = new DialogComponents();

            //component4.LabelText = "Output File:";
            //component4.TextBoxText = "Sample Text";
            //component4.ButtonText = "Select";
            //var component5 = new DialogComponents();

            //component5.LabelText = "Output File:";
            //component5.TextBoxText = "Sample Text";
            //component5.ButtonText = "Select";
            //components.Add(component);
            //components.Add(component1);
            //components.Add(component2);
            //components.Add(component3);
            //components.Add(component4);
            //components.Add(component5);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = new Test();
            test.ShowItems();
        }
    }
}

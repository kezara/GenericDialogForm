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
    /// <summary>
    /// Creates dialog form with custom number of text boxes and browse buttons
    /// </summary>
    public partial class GenericDialogForm : Form
    {
        private List<Tuple<DialogEnums, List<string>>> _inputDialogComponets;
        private int componentVerticalDistanceStep;
        private List<IDialogComponents> _outputDialogComponents;
        private List<string> _dialogPaths;

        /// <summary>
        /// containing selected paths and/or custom texts
        /// </summary>
        public List<string> DialogPaths { get; private set; }

        private List<IDialogComponents> OutputDialogComponents
        {
            get { return _outputDialogComponents; }
            set { _outputDialogComponents = value; }
        }

        /// <summary>
        /// Property <c>ComponentVerticalDistanceStep</c> determines vertical distance between two textboxes
        /// </summary>
        /// <value>default value is 40px</value>
        public int ComponentVerticalDistanceStep
        {
            get { return componentVerticalDistanceStep; }
            set { componentVerticalDistanceStep = value; }
        }


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dialogComponents">contains: 
        /// <list type="bullet">
        /// <item>if enum is FOLDER_BROWSE - label, textbox and button</item>
        /// <item>if enum is FILE_NAME - label and textbox</item>
        /// <item>List of strings in the tuple contains text for the label, textbox and button respectively if FOLDER_BROWSE</item>
        /// <item>List of strings in the tuple contains text for the label and textbox respectively if FILE_NAME</item>
        /// </list>
        public GenericDialogForm(string formTitle, List<Tuple<DialogEnums, List<string>>> dialogComponents)
        {
            InitializeComponent();
            _inputDialogComponets = dialogComponents;
            componentVerticalDistanceStep = 40;
            OutputDialogComponents = new List<IDialogComponents>();
            Text = formTitle;
        }

        private void GenericDialogForm_Load(object sender, EventArgs e)
        {
            CreateDialogComponents();
            var dialogComponentsCount = OutputDialogComponents.Count;
            OutputDialogComponents[0].SetLocation(new Point(6, 10));
            for (int i = 0; i < dialogComponentsCount; i++)
            {
                if (i > 0)
                {
                    OutputDialogComponents[i].SetLocation(new Point(6, OutputDialogComponents[i - 1].GetLocation().Y + componentVerticalDistanceStep));
                }
                Controls.Add((UserControl)OutputDialogComponents[i]);
            }

            if (dialogComponentsCount > 1)
            {
                Size = new Size (Size.Width, Size.Height + 40 * dialogComponentsCount - 1);
            }
        }

        private void CreateDialogComponents()
        {
            IDialogComponents component = null;

            foreach (var tuple in _inputDialogComponets)
            {
                switch (tuple.Item1)
                {
                    case DialogEnums.FOLDER_BROWSE:
                        component = new DialogComponentsFolderBrowse(tuple.Item2);
                        break;
                    case DialogEnums.FILE_NAME:
                        component = new DialogComponentsFileName(tuple.Item2);
                        break;
                    default:
                        break;
                }
                OutputDialogComponents.Add(component);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogPaths = new List<string>();
            foreach (var component in OutputDialogComponents)
            {
                DialogPaths.Add(component.PathSelected);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

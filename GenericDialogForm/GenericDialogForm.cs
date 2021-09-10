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
        private List<Tuple<DialogEnums, Tuple<string, List<string>>>> _inputDialogComponets;
        private int componentVerticalDistanceStep;
        private Dictionary<string, IDialogComponentsWithButton> _componentstWithButton;
        private List<string> _dialogPaths;
        private List<IDialogComponents> _componentsList;
        private Dictionary<string, IDialogComponents> _components;

        /// <summary>
        /// Contains all components in dialog form
        /// </summary>
        public Dictionary<string, IDialogComponents> Components
        {
            get { return _components; }
            set { _components = value; }
        }


        /// <summary>
        /// containing selected paths and/or custom texts
        /// </summary>
        public List<string> DialogPaths { get; private set; }

        /// <summary>
        /// contains only components which have one button
        /// </summary>
        public Dictionary<string, IDialogComponentsWithButton> ComponentsWithButton
        {
            get { return _componentstWithButton; }
            set { _componentstWithButton = value; }
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
        /// <item>if enum is FOLDER_BROWSE - tuple will contain unique name of the control, and list with strings for label, textbox and button text</item>
        /// <item>if enum is FILE_NAME - tuple will contain unique name of the control, and list with strings for label and textbox</item>
        /// <item>List of strings in the tuple contains text for the label, textbox and button respectively if FOLDER_BROWSE</item>
        /// <item>List of strings in the tuple contains text for the label and textbox respectively if FILE_NAME</item>
        /// </list>
        public GenericDialogForm(string formTitle, List<Tuple<DialogEnums, Tuple<string, List<string>>>> dialogComponents)
        {
            InitializeComponent();
            _inputDialogComponets = dialogComponents;
            componentVerticalDistanceStep = 40;
            Components = new Dictionary<string, IDialogComponents>();
            ComponentsWithButton = new Dictionary<string, IDialogComponentsWithButton>();
            _componentsList = new List<IDialogComponents>();
            Text = formTitle;
            CreateDialogComponents();
        }

        private void GenericDialogForm_Load(object sender, EventArgs e)
        {
            var dialogComponentsCount = Components.Count;
            _componentsList[0].SetLocation(new Point(6, 10));
            for (int i = 0; i < dialogComponentsCount; i++)
            {
                if (i > 0)
                {
                    _componentsList[i].SetLocation(new Point(6, _componentsList[i - 1].GetLocation().Y + componentVerticalDistanceStep));
                }
                Controls.Add((UserControl)_componentsList[i]);
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
                        try
                        {
                            ComponentsWithButton.Add(component.ComponentName, (IDialogComponentsWithButton)component);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Dialog Form components must have unique names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                        break;
                    case DialogEnums.FILE_NAME:
                        component = new DialogComponentsFileName(tuple.Item2);
                        break;
                    default:
                        break;
                }
                try
                {
                    Components.Add(component.ComponentName, component);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Dialog Form components must have unique names", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                _componentsList.Add(component);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogPaths = new List<string>();
            foreach (var component in Components)
            {
                DialogPaths.Add(component.Value.PathSelected);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

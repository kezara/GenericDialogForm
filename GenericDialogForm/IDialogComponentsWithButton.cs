using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDialogForm
{
    public interface IDialogComponentsWithButton : IDialogComponents
    {
        /// <summary>
        /// exposing button Enabled property
        /// </summary>
        bool ButtonEnabled { get; set; }
    }
}

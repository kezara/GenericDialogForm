using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDialogForm
{
    public interface IDialogComponents
    {
        /// <summary>
        /// sets location point of dialog component
        /// </summary>
        /// <param name="location"></param>
        void SetLocation(Point location);

        /// <summary>
        /// gets location point of dialog component
        /// </summary>
        /// <returns>Location point of dialog component</returns>
        Point GetLocation();

        /// <summary>
        /// Selected path in dialog form
        /// </summary>
        string PathSelected { get; }
    }
}

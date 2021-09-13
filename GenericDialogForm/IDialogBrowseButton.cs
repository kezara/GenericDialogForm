using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDialogForm
{
    public interface IDialogBrowseButton
    {
        string ButtonBrowse_Click(string text, string filter);
    }
}

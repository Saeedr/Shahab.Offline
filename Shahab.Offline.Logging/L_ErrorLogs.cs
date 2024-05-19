using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahab.Offline.Logging
{
    public static class L_ErrorLogs
    {
        public static void Errors(string ErrorText)
        {
            System.Windows.Forms.MessageBox.Show(ErrorText);
        }
    }
}

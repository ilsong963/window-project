using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Subject
    {
        string tabname;
        ImageList imagelist;

        ListViewItem objListItems;
        ListView li;
        public string Tabname
        {
            get
            {
                return tabname;
            }
            set
            {
                tabname = value;
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        // 탭 이름을 넣기위한 Tab객체
        Tab tab;

        public Form2( Tab tab)
        {
            InitializeComponent();
            init();
            this.tab = tab;
        }

        void init()
        {
            //항상 최상위
            this.TopMost = true;

            ok_btn.DialogResult = DialogResult.OK;
            cancel_btn.DialogResult = DialogResult.No;
        }

        private void ok_bnt_click(object sender, EventArgs e)
        {
            tab.Tabname = tabname_textbox.Text;
            Close();
        }

        private void cancel_bnt_click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
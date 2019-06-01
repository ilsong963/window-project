
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TabPage myTabPage;
        ListView li;
        int i = 0;


        ImageList imagelist = new ImageList();

         List<Subject> subject = new List<Subject>();



        public static string title;
        
        public Form1()
        {
            InitializeComponent();
            init();
        }

        //form1 초기설정
        void init()
        {
            this.TopMost = true; //항상 위로
        }


      


        private void button1_Click_1(object sender, EventArgs e)
        {
            Subject temp = new Subject();

            Form2 form2 = new Form2(temp);
            this.AddOwnedForm(form2);
            form2.ShowDialog(); //모달 실행





            if (form2.DialogResult == DialogResult.OK)
            {
                myTabPage = new TabPage(temp.Tabname);

                temp.listsetting();
                temp.li.ContextMenuStrip = this.contextMenuStrip1;

                myTabPage.Controls.Add(temp.li);
                Tabcontrol1.TabPages.Add(myTabPage);
            }

            Tabcontrol1.SelectedIndex = Tabcontrol1.TabCount-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedtabindex = Tabcontrol1.SelectedIndex;
            Tabcontrol1.TabPages.Remove(Tabcontrol1.SelectedTab);

            Tabcontrol1.SelectedIndex = Tabcontrol1.TabCount - 1;
        }


        //투명도 조절
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value * 0.125;
        }
    }
}
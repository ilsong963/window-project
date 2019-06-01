
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

        //파일 드래그 앤터 핸들러
        private void FileDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        //파일 드래그 드롭 핸들러
        private void FileDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            li.Items.Add(setItem(fileNames[0]));

        }

        private ListViewItem setItem(string filename)
        {
            
            //아이콘
            Icon icon;
            icon = Icon.ExtractAssociatedIcon(filename);

            ListViewItem objListItems = new ListViewItem();
            
            
            imagelist.ImageSize = new Size(32, 32);
            imagelist.Images.Add(icon);


            li.LargeImageList = imagelist;
            li.SmallImageList = imagelist;


            objListItems = li.Items.Add(filename, i++);



            return objListItems;

        
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            this.AddOwnedForm(form2);
            form2.ShowDialog(); //모달 실행





            if (form2.DialogResult == DialogResult.OK)
            {
                myTabPage = new TabPage(title);
                li = new ListView();
                li.View = View.LargeIcon;




                li.AllowDrop = true;
                li.Location = new System.Drawing.Point(6, 6);
                li.Size = new System.Drawing.Size(389, 232);
                li.TabIndex = 0;
                li.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragDrop);
                li.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragEnter);


                li.ContextMenuStrip = this.contextMenuStrip1;

                myTabPage.Controls.Add(li);
                Tabcontrol1.TabPages.Add(myTabPage);
            }
            Tabcontrol1.SelectedIndex = Tabcontrol1.TabCount-1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tabcontrol1.TabPages.Remove(Tabcontrol1.SelectedTab);
        }


        //투명도 조절
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value * 0.125;
        }
    }
}
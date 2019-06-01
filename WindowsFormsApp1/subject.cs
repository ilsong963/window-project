using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Subject
    {
        string tabname;
        ImageList imagelist;

        ListViewItem objListItems;
        public ListView li;
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
            
            li.Items.Add(fileNames[0]);

        }
        private ListViewItem setItem(string filename)
        {

            //아이콘
            Icon icon;
            icon = Icon.ExtractAssociatedIcon(filename);

            objListItems = new ListViewItem();


            imagelist.ImageSize = new Size(32, 32);
            imagelist.Images.Add(icon);


            li.LargeImageList = imagelist;
            li.SmallImageList = imagelist;


            objListItems = li.Items.Add(filename);



            return objListItems;


        }
        public void listsetting()
        {
            li = new ListView();
            li.View = View.LargeIcon;




            li.AllowDrop = true;
            li.Location = new System.Drawing.Point(6, 6);
            li.Size = new System.Drawing.Size(389, 232);
            li.TabIndex = 0;
            li.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragDrop);
            li.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragEnter);


           
        }

    }
}

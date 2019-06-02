using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{
    public class Tab
    {
        string tabname;

        ImageList imagelist = new ImageList();
        ListViewItem objListItems;

        public ListView li;
        int imageindex = 0;
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
            setItem(fileNames[0]);

        }
        private void setItem(string filename)
        {

            //아이콘
            Icon icon = Icon.ExtractAssociatedIcon(filename);

            
            objListItems = new ListViewItem();

            imagelist.ImageSize = new Size(32, 32);
            imagelist.Images.Add(icon.ToBitmap());


            li.LargeImageList = imagelist;
            li.SmallImageList = imagelist;

            objListItems = li.Items.Add(filename, Path.GetFileNameWithoutExtension(filename),imageindex++);


            li.Items.Add(objListItems);
            
        }
        
        public void listSetting()
        {
            li = new ListView();
            
            li.View = View.LargeIcon;
            li.AllowDrop = true;
            li.Location = new System.Drawing.Point(6, 6);
            li.Size = new System.Drawing.Size(400, 230);
            li.TabIndex = 0;
            li.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragDrop);
            li.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragEnter);
            li.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);

        }
        private void DoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(li.SelectedItems.ToString());
            System.Diagnostics.Process.Start(li.SelectedItems.ToString());      // 외부 프로그램

        }
        
    }
}

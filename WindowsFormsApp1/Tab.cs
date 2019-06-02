using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public class Tab
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr findname, int howShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr findname);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string SClassName, string SWindowName);

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

            SetHeight(li,100);


        }
        private void SetHeight(ListView LV, int height)
        {
            // listView 높이 지정
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            LV.SmallImageList = imgList;
        }
        private void DoubleClick(object sender, MouseEventArgs e)
        {
            Process[] processList = Process.GetProcessesByName(li.FocusedItem.Name);
            if (processList.Length < 1)
            {
                System.Diagnostics.Process.Start(li.FocusedItem.Name);      // 외부 프로그램 실행

            }
            else
            {
                IntPtr findname = FindWindow(null, li.FocusedItem.Name);
                // 프로그램이 최소화 되어 있다면 활성화 시킴 
                ShowWindowAsync(findname, 1);
                // 윈도우에 포커스를 줘서 최상위로 만듬
                SetForegroundWindow(findname);
            }

        }
        
    }
}

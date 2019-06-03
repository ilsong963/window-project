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

        ImageList imagelist;
        ListViewItem objListItems;

        public ListView li;
        int imageindex = 0;

        public Tab()
        {
            imagelist = new ImageList();
        }



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
            if (!isExist(fileNames[0]))
            {

                setItem(fileNames[0]);

            }

        }
        private bool isExist(string fileName)
        {

            foreach (ListViewItem item in li.Items)
            {
                if(item.Name == fileName)
                {
                    return true;
                }
            }
            
            return false;
        }
        private void setItem(string filename)
        {

            //아이콘
            Icon icon = Icon.ExtractAssociatedIcon(filename);


            objListItems = new ListViewItem();

            imagelist.ImageSize = new Size(25, 25);
            imagelist.Images.Add(icon.ToBitmap());


            li.LargeImageList = imagelist;
            li.SmallImageList = imagelist;

            objListItems = li.Items.Add(filename, Path.GetFileNameWithoutExtension(filename), imageindex++);

            li.Items.Add(objListItems);
            
        }

        public void listSetting()
        {
            li = new ListView();

            li.View = View.Tile;

            li.AllowDrop = true;
            li.Location = new System.Drawing.Point(6, 6);
            li.Size = new System.Drawing.Size(250, 235);
            li.TabIndex = 0;
            li.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragDrop);
            li.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDrop_DragEnter);
            li.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DoubleClick);
            li.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
       
        }
        private void MouseClick(object sender, MouseEventArgs e)
        {
            //오른쪽 클릭일 경우
            if (e.Button.Equals(MouseButtons.Right))
            {
                //선택된 아이템의 Text를 저장해 놓습니다. 중요한 부분.
                string selectedNickname = li.GetItemAt(e.X, e.Y).Text;

                //오른쪽 메뉴를 만듭니다
                ContextMenu m = new ContextMenu();

                //메뉴에 들어갈 아이템을 만듭니다
                MenuItem m1 = new MenuItem();

                m1.Text = "삭제하기";

                

                //메뉴에 메뉴 아이템을 등록해줍니다
                m.MenuItems.Add(m1);

                //현재 마우스가 위치한 장소에 메뉴를 띄워줍니다
                m.Show(li, new Point(e.X, e.Y));

                m1.Click += new System.EventHandler(this.menuItem1_Click);
            }

            
        }
        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            li.FocusedItem.Remove();
        }

        private void DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                Process[] processList = Process.GetProcessesByName(li.FocusedItem.Name);
                if (processList.Length < 1)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(li.FocusedItem.Name);      // 외부 프로그램 실행
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        DialogResult result=  MessageBox.Show("경로가 수정되었거나 파일이 삭제되었습니다.\n리스트에서 삭제하시겠습니까?", "ERROR", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            li.FocusedItem.Remove();
                        }

                    }
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
}

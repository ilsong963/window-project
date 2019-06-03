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
        //최소화된 창 활성화 시키는 함수
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr findname, int howShow);

        //창 포커스를 최상위로 만드는 함수
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr findname);

        //매개변수로 받은 정보로 창을 찾는 함수
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string SClassName, string SWindowName);

        ImageList imagelist;
        ListViewItem objListItems;

        public ListView li;
        int imageindex = 0;

        public Tab()
        {
            imagelist = new ImageList();
        }

        public string Tabname { get; set; }

        //파일 드래그 앤터 핸들러
        private void FileDrop_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;
        }

        //파일 드래그 드롭 핸들러
        private void FileDrop_DragDrop(object sender, DragEventArgs e)
        {
            DirectoryInfo dirInfo;

            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);

            //폴더가 아닐시 리스트에 추가 
            foreach (string file in fileNames)
            {
                dirInfo = new DirectoryInfo(file);
                if (dirInfo.Attributes.ToString() != "Directory")
                {
                    if (!isExist(file))
                    {
                        setIcon(file);
                        //파일경로와 파일이름, 아이콘으로 아이템에 추가
                        li.Items.Add(file, Path.GetFileNameWithoutExtension(file), imageindex++);
                    }
                }
            }



        }

        //중복 체크 함수
        private bool isExist(string fileName)
        {

            foreach (ListViewItem item in li.Items)
            {
                if (item.Name == fileName)
                {
                    return true;
                }
            }

            return false;
        }

        //리스트에 아이콘을 연결하는 함수
        private void setIcon(string filename)
        {

            //아이콘이미지추출
            Icon icon = Icon.ExtractAssociatedIcon(filename);


            objListItems = new ListViewItem();

            imagelist.ImageSize = new Size(25, 25);
            imagelist.Images.Add(icon.ToBitmap());


            li.LargeImageList = imagelist;
            li.SmallImageList = imagelist;



        }

        //리스트 뷰 생성후 셋팅 함수
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

        //마우스 클릭 메서드
        private void MouseClick(object sender, MouseEventArgs e)
        {
            //오른쪽 클릭일 경우
            if (e.Button.Equals(MouseButtons.Right))
            {
                //선택된 리스트 아이템의 정보 가져오기
                string selectedNickname = li.GetItemAt(e.X, e.Y).Text;

               //메뉴생성
                ContextMenu m = new ContextMenu();

                //메뉴에 들어갈 아이템 생성
                MenuItem m1 = new MenuItem();

                m1.Text = "삭제하기";
                m.MenuItems.Add(m1);

                //마우스 위치에 메뉴 띄우기
                m.Show(li, new Point(e.X, e.Y));

                //메뉴 클릭 핸들러에 삭제 함수 연결
                m1.Click += new System.EventHandler(this.menuItem1_Click);
            }


        }
        //삭제 함수
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //아이템 선택 갯수 가져오기
            int cnt = li.SelectedItems.Count;

            //삭제
            if (cnt > 2)
            {
                for (int i = cnt - 1; i >= 0; i--)

                {
                    li.Items.Remove(li.SelectedItems[i]);

                }
            }
            else
                li.FocusedItem.Remove();
        }

        //응용프로그램 연결 창 함수
        public static void ShowOpenWithDialog(string path)
        {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }

        //더블클릭 함수
        private void DoubleClick(object sender, MouseEventArgs e)
        {
            //왼쪽 클릭으로만 제어가능
            if (e.Button != MouseButtons.Right)
            {
                //실행시키려는 프로그램이 기존에 실행이 되었는지 체크
                Process[] processList = Process.GetProcessesByName(li.FocusedItem.Name);
                if (processList.Length < 1)
                {
                    //Win32Exception 체크
                    try
                    {
                        // 실행
                        System.Diagnostics.Process.Start(li.FocusedItem.Name);      
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        switch (ex.NativeErrorCode)
                        {
                            case 2: //경로에 파일이 존제하지 않을때
                                DialogResult result = MessageBox.Show("기존 파일의 경로가 변경되었습니다. \n리스트에서 삭제하시겠습니까?", "ERROR", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    li.FocusedItem.Remove();
                                }
                                break;
                            case 1155: //연결된 응용프로그램이 없을때
                                //응용프로그램 연결 함수 호출
                                ShowOpenWithDialog(li.FocusedItem.Name);
                                break;
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

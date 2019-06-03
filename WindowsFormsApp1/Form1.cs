
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
        List<Tab> tablist;


        public Form1()
        {
            InitializeComponent();
            init();
        }

        //form1 초기설정
        void init()
        {
            //항상 위로
            this.TopMost = true;
            tablist = new List<Tab>();
        }





        private void tab_new_btn_click(object sender, EventArgs e)
        {
            Tab temp = new Tab();
            Form2 form2 = new Form2(temp);
            this.AddOwnedForm(form2);
            form2.ShowDialog(); //모달 실행


            if (form2.DialogResult == DialogResult.OK)
            {
                myTabPage = new TabPage(temp.Tabname);

                //Tab 클래스에 있는 list를 세팅하는 메서드호출
                temp.listSetting();

                myTabPage.Controls.Add(temp.li);
                Tabcontrol.TabPages.Add(myTabPage);
                tablist.Add(temp);
            }

            //선택된 탭인덱스를 증가시켜서 새로만든게 포커싱되도록.
            Tabcontrol.SelectedIndex = Tabcontrol.TabCount - 1;
        }

        private void tab_del_btn_click(object sender, EventArgs e)
        {
            if (tablist.Count != 0)
            {
                DialogResult result = MessageBox.Show(Tabcontrol.SelectedTab.Text + "탭을 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo);
                if (Tabcontrol.TabCount == 0)
                {
                    MessageBox.Show("삭제할 탭이 없습니다");
                }
                else
                {
                    //탭 제거 함수 실행
                    delTab(result);
                }
            }
            else
                MessageBox.Show("삭제할 탭이 없습니다");

        }
        private void delTab(DialogResult result)
        {
            int selectedtabindex = Tabcontrol.SelectedIndex;

            if (result == DialogResult.Yes)
            {
                tablist.RemoveAt(Tabcontrol.SelectedIndex);
                Tabcontrol.TabPages.Remove(Tabcontrol.SelectedTab);
            }

            // 탭의 포커싱 제어
            if (selectedtabindex == Tabcontrol.TabCount)
            {
                Tabcontrol.SelectedIndex = Tabcontrol.TabCount - 1;
            }
            else
            {
                Tabcontrol.SelectedIndex = selectedtabindex;
            }

        }


        //투명도 조절
        private void transparency_trackbar_Scroll(object sender, EventArgs e)
        {
            this.Opacity = transparency_trackbar.Value * 0.125;
        }

        private void tab_rename_btn_click(object sender, EventArgs e)
        {
            if (tablist.Count != 0)
            {
                Form2 form2 = new Form2(tablist[Tabcontrol.SelectedIndex]);
                this.AddOwnedForm(form2);
                form2.ShowDialog(); //모달 실행
                Tabcontrol.SelectedTab.Text = tablist[Tabcontrol.SelectedIndex].Tabname;
            }
            else
                MessageBox.Show("이름을 변경할 탭이 없습니다");
        }


    }
}
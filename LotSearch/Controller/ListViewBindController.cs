using LotSearch.Container;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotSearch.Util;
using System.Windows.Forms;

namespace LotSearch.Controller
{
    class ListViewBindController : StringStocker
    {
        const int LIST_VIEW_NAME = 0;
        const int TOP_USER_NAME = 1;

        const int WHO = 0;
        const int ITEM = 1;
        const int LOT = 2;

        public ListViewBindController()
        {
        }

        //public string[] ParseLog(XIVLog xivlog)
        //{
        public string[] ParseLog(string xivlog)
        {
            //アイテム名前後の不要な文字列を削除
            string who = xivlog.SubstrALine(0, "は");
            string item = xivlog.SubstrALine(xivlog.IndexOf("は") + 1, "を出した");
            item = item.SubstrALine(item.IndexOf("") + 1, "に");
            string lot = xivlog.SubstrALine(xivlog.IndexOf("のダイスで") + 5, "を出した");

            return new string[] { who, item, lot };
        }

        public async Task SetListDataAsync(String xivlog, ControlPanel panel)
        {
            List<Label> lbllist = panel.GetAllControls<Label>(panel);
            List<ListView> lvlist = panel.GetAllControls<ListView>(panel);
            string[] args = ParseLog(xivlog);

            var lv_container = new LotListViewContainer()
            {
                ITEM = args[ITEM].RemoveUnicode(),
                LOT = args[LOT],
                //WHO = GetUserFromLogName(args[WHO])
                WHO = args[WHO].SubstrALine(0, " ")
            };

            string lblName;
            if (string.IsNullOrEmpty((lblName = GetListViewName(lv_container, lbllist))))
            {
                return;
            }

            ListView lv;
            (lv = panel.GetListViewObject(lblName)).Items.Add(new ListViewItem(lv_container.toArray()));

            lv.ListViewItemSorter = new ListViewItemComparer(1);
            lv.Sort();

            // 最大のLOTを出したユーザーを取得する
            SetTopUserName(lv, panel);
        }

        private string GetListViewName(LotListViewContainer container, List<Label> lbllist)
        {
            foreach(Label lbl in lbllist)
            {
                if (lbl.Text.Equals(container.ITEM)){
                    return lbl.Name;
                }
            }

            return string.Empty;
        }

        public void SetTopUserName(ListView lv, ControlPanel panel)
        {
            TextBox textBox;
            if ((textBox = panel.GetTextBoxObject(lv.Name)) != null)
            {
                textBox.Text = GetTopUser(lv);
            }
        }
       
        private string GetTopUser(ListView lv)
        {
            string user = "";
            int highest = 0;
            int lot = 0;
            foreach (ListViewItem item in lv.Items)
            {
                if (highest < (lot = int.Parse(item.SubItems[1].Text)) ) 
                {
                    highest = lot;
                    user = item.Text;
                }
            }

            return user;
        }
    }
}

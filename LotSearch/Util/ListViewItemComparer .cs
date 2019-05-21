using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotSearch.Util
{
    /// <summary>
    /// ListViewの項目の並び替えに使用するクラス
    /// </summary>
    public class ListViewItemComparer : IComparer
    {
        private int _column;

        /// <summary>
        /// ListViewItemComparerクラスのコンストラクタ
        /// </summary>
        /// <param name="col">並び替える列番号</param>
        public ListViewItemComparer(int col)
        {
            _column = col;
        }

        //xがyより小さいときはマイナスの数、大きいときはプラスの数、
        //同じときは0を返す
        public int Compare(object x, object y)
        {
            //ListViewItemの取得
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            //xとyを文字列として比較する
            return string.Compare(itemy.SubItems[_column].Text,
                itemx.SubItems[_column].Text);
        }
    }
}

using LotSearch.Container;
using LotSearch.Util;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotSearch.Controller
{
    class LotController
    {
        DiscordPostController d_controller;

        public LotController()
        {
            d_controller = new DiscordPostController();
        }

        public async Task CommitAsync(String xivlog, ControlPanel panel)
        {
            //アイテム名前後の不要な文字列を削除
            string trimmedLog = xivlog.RemoveUnicode();
            string item = trimmedLog.SubstrALine(trimmedLog.IndexOf("") + 1, STRINGSTOCK.KEY_WORD_SEARCH.GetStringValue());
            //item = util.SubstrALine(item, 0, "×1");

            var who = await this.LotSearchAsync(item);

            string reultText = item + "　は　" + who;

            // ディスコードへ通知
            //var res = await d_controller.SendToDiscord(reultText);

            // リストへ追加
            panel.SetItemOnLabel(item, who);

            //new Util().Log(xivlog);
        }

        public async Task<string> LotSearchAsync(string equip)
        {
            ConvertActParam convertActParam = new ConvertActParam();
            var container = new LotContainer()
            {
                ITEM = convertActParam.GetItemNames(equip),
                JOB = convertActParam.GetJobNames(equip)
            };

            if(string.IsNullOrEmpty(container.ITEM))
            {
                throw new Exception("アイテムが特定できませんでした。");
            }
            if (string.IsNullOrEmpty(container.JOB))
            {
                throw new Exception("ジョブが特定できませんでした。");
            }

            var json = new JsonComposer().GetJson(container);

            var res = await new HttpHelper().DoPostAsync(json, STRINGSTOCK.URL_LOTSEARCH.GetStringValue(), false);

            return res;
        }
    }
}

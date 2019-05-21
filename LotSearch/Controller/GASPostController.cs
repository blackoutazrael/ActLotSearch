using LotSearch.Container;
using LotSearch.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LotSearch.Controller
{
    class GASPostController: StringStocker
    {
        Dictionary<string, int> rowObj;
        Dictionary<string, string> columnObj;
        Dictionary<string, string> nextRoleObj;

        #region コンストラクタ
        public GASPostController()
        {
            this.rowObj = new Dictionary<string, int>()
            {
                {Users["T1"], 4},
                {Users["T2"], 5},
                {Users["M1"], 6},
                {Users["M2"], 7},
                {Users["R1"], 8},
                {Users["C1"], 9},
                {Users["H1"], 10},
                {Users["H2"], 11}
            };

            this.columnObj = new Dictionary<string, string>()
            {
                { "頭", "5" },
                { "胴", "6" },
                { "手", "7" },
                { "帯", "8" },
                { "脚", "9" },
                { "足", "10" },
                { "耳", "11" },
                { "首", "12" },
                { "腕", "13" },
                { "指", "14" },
                { "薬", "15" },
                { "石", "16" },
                { "武器強化", "17" },
                { "繊維", "18" },
                { "箱", "19" }
            };
        }

        private Dictionary<string,string> GetNextRoleLetter(string column)
        {
            switch (column)
            {
                case "15":
                    return new Dictionary<string, string>(){
                        { Users["T1"], "D"},
                        { Users["T2"], "D"},
                        { Users["M1"], "H"},
                        { Users["M2"], "H"},
                        { Users["R1"], "H"},
                        { Users["C1"], "H"},
                        { Users["H1"], "T"},
                        { Users["H2"], "T"}
                    };
                case "16":
                    return new Dictionary<string, string>(){
                        { Users["T1"], "H"},
                        { Users["T2"], "H"},
                        { Users["M1"], "T"},
                        { Users["M2"], "T"},
                        { Users["R1"], "T"},
                        { Users["C1"], "T"},
                        { Users["H1"], "D"},
                        { Users["H2"], "D"}
                    };
                case "17":
                    return new Dictionary<string, string>(){
                        { Users["T1"], "H"},
                        { Users["T2"], "H"},
                        { Users["M1"], "T"},
                        { Users["M2"], "T"},
                        { Users["R1"], "T"},
                        { Users["C1"], "T"},
                        { Users["H1"], "D"},
                        { Users["H2"], "D"}
                    };
                case "18":
                    return new Dictionary<string, string>(){
                        { Users["T1"], "H"},
                        { Users["T2"], "H"},
                        { Users["M1"], "T"},
                        { Users["M2"], "T"},
                        { Users["R1"], "T"},
                        { Users["C1"], "T"},
                        { Users["H1"], "D"},
                        { Users["H2"], "D"}
                    };
                default:
                    return new Dictionary<string, string>(){
                        { Users["T1"], "H"},
                        { Users["T2"], "H"},
                        { Users["M1"], "T"},
                        { Users["M2"], "T"},
                        { Users["R1"], "T"},
                        { Users["C1"], "T"},
                        { Users["H1"], "D"},
                        { Users["H2"], "D"}
                    };
            }
        }
        #endregion

        public async Task<string> RegisterAsync(LotContainer container, object sender)
        {
            string userRow = ( this.rowObj[container.USER] + (container.IS_FIRST_PRIORITY ? 0 : 12) ).ToString();
            string itemColumn = this.columnObj[container.ITEM]; ;
            string nextRoleLetter = string.Empty; 

            if (int.Parse(itemColumn) >= 15 && int.Parse(itemColumn) < 19)
            {
                nextRoleObj = this.GetNextRoleLetter(itemColumn);
                nextRoleLetter = this.nextRoleObj[container.USER];
            }

            if (string.IsNullOrEmpty(userRow))
            {
                throw new Exception("ユーザー名が不正です。");
            }

            if (string.IsNullOrEmpty(itemColumn))
            {
                throw new Exception("アイテム名が不正です。");
            }

            JsonComposer composer = new JsonComposer();
            string json = composer.GetGASPOSTJson(userRow, itemColumn, nextRoleLetter);
            
            var poster = new HttpHelper();
            var res = await poster.DoPostAsync(json, STRINGSTOCK.URL_LOTMANAGE_GAS.GetStringValue(), false);
            if ((await poster.DoPostAsync(json, STRINGSTOCK.URL_LOTMANAGE_GAS.GetStringValue(), true)).Equals("error"))
            {
                throw new InvalidOperationException("更新に失敗しました 。");
            }

            return container.USER + "さん の 『" + container.EQUIPNAME + "』を取得済みにしました。";
        }
    }
}

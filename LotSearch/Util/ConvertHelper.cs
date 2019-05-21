using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Util
{
    // 変換クラス枠組み
    public abstract class Converter
    {
        public abstract string ConvertParam();
    }

    // 変換クラス取得クラスの枠組み
    public abstract class ConverterBuilder
    {
        protected abstract Converter factoryMethod(Dictionary<string, string> dictionary, string job);
        public Converter GetConverter(Dictionary<string, string> _dictionary, string _job)
        {
            return factoryMethod(_dictionary, _job);
        }
    }

    // 変換クラスの取得処理本体
    class GetConverter : ConverterBuilder
    {
        protected override Converter factoryMethod(Dictionary<string, string> dictionary, string job)
        {
            return new ParameterConverter(dictionary, job);
        }
    }

    // 変換処理の本体
    public class ParameterConverter : Converter
    {
        private string job;
        private Dictionary<string, string> dictionary;


        public ParameterConverter(Dictionary<string, string> _dictionary, string _job)
        {
            this.dictionary = _dictionary;
            this.job = _job;
        }

        override public string ConvertParam()
        {
            foreach (KeyValuePair<string, string> kvp in this.dictionary)
            {
                if (this.job.Contains(kvp.Key))
                {
                    return kvp.Value;
                }
            }

            return "";
        }
    }

    // 処理の呼び出し
    public class ConvertActParam
    {
        #region パラメータ & コンストラクタ
        private Dictionary<string, string> jobDictionary = new Dictionary<string, string>()
        {
            {"ディフェンダー", "V" },
            {"ストライカー", "St" },
            {"アタッカー", "St" },
            {"スレイヤー", "Sl" },
            {"スカウト", "Dn" },
            {"レンジャー", "Dr" },
            {"キャスター", "I" },
            {"ヒーラー", "M" }
        };

        private Dictionary<string, string> itemDictionary = new Dictionary<string, string>()
        {
            // 頭
            {"サークレット", "頭" },
            {"アイマスク", "頭" },
            {"キャップ", "頭" },
            {"ヘルム", "頭" },
            {"ヘッドギア", "頭" },
            {"バイザー", "頭" },
            {"マスク", "頭" },
            {"ハット", "頭" },
            {"眼帯", "頭" },
            {"面", "頭" },
            {"冠", "頭" },

            // 胴
            {"ガンビスン", "胴" },
            {"コート", "胴" },
            {"ジャケット", "胴" },
            {"アーマー", "胴" },
            {"タパード", "胴" },
            {"道着", "胴" },
            {"羽織", "胴" },
            {"袈裟", "胴" },
            {"ベスト", "胴" },

            // 手
            {"アームガード", "手" },
            {"グローブ", "手" },
            {"ガントレット", "手" },
            {"籠手", "手" },
            {"手甲", "手" },

            // 帯
            {"タセット", "帯" },
            {"ベルト", "帯" },
            {"帯", "帯" },

            // 脚
            {"トラウザー", "脚" },
            {"ボトム", "脚" },
            {"袴", "脚" },
            {"スカート", "脚" },

            // 足
            {"シューズ", "足" },
            {"ブーツ", "足" },
            {"グリーヴ", "足" },
            {"脛当", "足" },
            {"草履", "足" },

            // 耳
            {"イヤーカフ", "耳"},
            {"耳飾", "耳"},
            {"イヤリング", "耳"},

            // 首
            {"チョーカー", "首"},
            {"首飾", "首"},
            {"ネックレス", "首"},

            // 腕
            {"ブレスレット", "腕"},
            {"腕輪", "腕"},
            {"数珠", "腕"},
            {"アルミラ", "腕"},
            {"アミュレット", "腕"},

            // 指
            {"リング", "指"},
            {"指輪", "指"},
        };

        ConverterBuilder builder;
        public ConvertActParam()
        {
            builder = new GetConverter();
        }
        #endregion

        public string GetJobNames(string param)
        {
            Converter converter = this.builder.GetConverter(jobDictionary, param);
            return converter.ConvertParam();
        }

        public string GetItemNames(string param)
        {
            Converter converter = this.builder.GetConverter(itemDictionary, param);
            return converter.ConvertParam();
        }
    }
}

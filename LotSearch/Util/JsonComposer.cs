using LotSearch.Container;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Util
{
    [JsonObject]
    class JsonComposer
    {
        public JsonComposer()
        {
        }

        /* LOT権利者検索用 */
        [JsonObject]
        public class Params
        {
            [JsonProperty("JOBS")]
            public string Job { get; set; }

            [JsonProperty("EQUIP")]
            public string Equip { get; set; }

            public Params(string job, string equip)
            {
                this.Job = job;
                this.Equip = equip;
            }
        }

        public string GetJson(LotContainer container)
        {
            var param = new Params(container.JOB, container.ITEM);

            return JsonConvert.SerializeObject(param);
        }

        /* DISCORD API用 */
        [JsonObject]
        public class DiscordContent
        {
            [JsonProperty("content")]
            public string Content { get; set; }

            public DiscordContent(string content)
            {
                this.Content = content;
            }
        }
        public string GetDiscordContentJson(string content)
        {
            var discordContent = new DiscordContent(content);

            return JsonConvert.SerializeObject(discordContent);
        }

        /* GAS用 */
        [JsonObject]
        public class GASPOST
        {
            [JsonProperty("row")]
            public string Rownum { get; set; }

            [JsonProperty("column")]
            public string Columnnum { get; set; }

            [JsonProperty("nextRole")]
            public string Nextrole { get; set; }

            public GASPOST(string rownum, string columnnum, string nextrole)
            {
                this.Rownum = rownum;
                this.Columnnum = columnnum;
                this.Nextrole = nextrole;
            }
        }

        public string GetGASPOSTJson(string rownum, string columnnum, string nextrole)
        {
            var gasPostContent = new GASPOST(rownum, columnnum, nextrole);

            return JsonConvert.SerializeObject(gasPostContent);
        }
    }
}

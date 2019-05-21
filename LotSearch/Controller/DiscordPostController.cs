using LotSearch.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Controller
{
    class DiscordPostController
    {
        public async Task<string> SendToDiscord(string sentence)
        {
            var composer = new JsonComposer();
            string json = composer.GetDiscordContentJson(sentence);

            var poster = new HttpHelper();
            var res = await poster.DoPostAsync(json, new StringStocker().GetDiscordAPIUrl(STRINGSTOCK.CHANNELID_HONGKONGOMEGA_GOYOTEI.GetStringValue()), true);

            return res;
        }
    }
}

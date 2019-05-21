using System.Collections.Generic;

namespace LotSearch.Util
{
    // CONST STRING変数の代わり
    public enum STRINGSTOCK
    {
        [StringValue("")]
        KEY_WORD_SEARCH = 0,

        [StringValue("")]
        KEY_WORD_DICE,

        [StringValue("")]
        KEY_WORD_LOT,

        [StringValue("")]
        CHANNELID_HONGKONGOMEGA_GOYOTEI,

        [StringValue("")]
        CHANNELID_ALPHA_GOYOTEI,

        [StringValue("")]
        CHANNELID_50KOTEI_GOYOTEI,

        [StringValue(@"")]
        URL_LOTSEARCH,

        [StringValue("Bot ")]
        AUTH_CODE_ALFRED,

        [StringValue("")]
        URL_LOTMANAGE_GAS,

        [StringValue(@"")]
        PATH_LOG_FILE,
    }

    class StringStocker
    {
        public string GetDiscordAPIUrl(string id) => @"https://discordapp.com/api/channels/" + id + "/messages";

        public Dictionary<string, string> Users = new Dictionary<string, string>()
        {
            {"T1", "Warrior"},
            {"T2", "Knight"},
            {"M1", "Dragoon"},
            {"M2", "Ninja"},
            {"R1", "Bard"},
            {"C1", "BlackMage"},
            {"H1", "WhiteMage"},
            {"H2", "Scholar"}
        };
    }
}

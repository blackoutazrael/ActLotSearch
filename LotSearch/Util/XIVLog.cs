using Advanced_Combat_Tracker;
using System;

namespace LotSearch.Util
{
    class XIVLog
    {
        public XIVLog(LogLineEventArgs logInfo)
        {
            if (logInfo == null ||
                string.IsNullOrEmpty(logInfo.logLine))
            {
                return;
            }

            this.LogInfo = logInfo;

            // ログの書式の例
            /*
            [08:20:19.383] 00:0000:clear stacks of Loading....
            */

            var line = this.LogInfo.logLine;

            // 18文字未満のログは書式エラーになるため無視する
            if (line.Length < 18)
            {
                return;
            }

            var timeString = line.Substring(1, 12);

            var timestampString = DateTime.Now.ToString("yyyy-MM-dd") + " " + timeString;
            DateTime d;
            if (DateTime.TryParse(timestampString, out d))
            {
                this.Timestamp = d;
            }
            else
            {
                // タイムスタンプ書式が不正なものは無視する
                return;
            }

            this.LogType = line.Substring(15, 2);
            this.Log = line.Substring(15);
            this.Log = this.Log.Substring(this.Log.LastIndexOf(":") + 1);
            this.ZoneName = !string.IsNullOrEmpty(logInfo.detectedZone) ?
                logInfo.detectedZone :
                "NO DATA";

            if (currentNo >= int.MaxValue)
            {
                currentNo = 0;
            }

            currentNo++;
            this.No = currentNo;
            
            this.Log = RemoveTooltipSymbols(this.Log);
            //this.Log = new Util().RemoveUnicode(this.Log);
        }

        private static volatile int currentNo = 0;

        public int No { get; private set; }

        public DateTime Timestamp { get; private set; }

        public bool IsImport { get; private set; }

        public string LogType { get; private set; }

        public string ZoneName { get; private set; }

        public string Log { get; private set; }

        public LogLineEventArgs LogInfo { get; set; }

        /// <summary>
        /// ツールチップのサフィックス
        /// </summary>
        /// <remarks>
        /// ツールチップは計4charsで構成されるが先頭1文字目が可変で残り3文字が固定となっている</remarks>
        public const string TooltipSuffix = "\u0001\u0001\uFFFD";

        /// <summary>
        /// ツールチップで残るリプレースメントキャラ
        /// </summary>
        public const string TooltipReplacementChar = "\uFFFD";

        /// <summary>
        /// ツールチップシンボルを除去する
        /// </summary>
        /// <param name="logLine"></param>
        /// <returns>編集後のLogLine</returns>
        public static string RemoveTooltipSymbols(
            string logLine)
        {
            var result = logLine;

            // エフェクトに付与されるツールチップ文字を除去する
            if (Settings.Default.RemoveTooltipSymbols)
            {
                // 4文字分のツールチップ文字を除去する
                int index;
                if ((index = result.IndexOf(
                    TooltipSuffix,
                    0,
                    StringComparison.Ordinal)) > -1)
                {
                    const int removeLength = 4;
                    var startIndex = index - 1;

                    if (startIndex >= 0)
                    {
                        result = result.Remove(startIndex, removeLength);
                    }
                }

                // 残ったReplacementCharを除去する
                result = result.Replace(TooltipReplacementChar, string.Empty);
            }

            return result;
        }
    }
}

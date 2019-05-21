using System;
using System.IO;
using System.Text.RegularExpressions;
using LotSearch.Util;

namespace LotSearch.Util
{
    public static class Util
    {
        public static string SubstrALine(this string value, int startPosition, string endWord)
        {
            int stringlocation;
            if ((stringlocation = value.IndexOf(endWord)) >= 0)
            {
                return value.Substring(startPosition, stringlocation - startPosition).Trim().Trim('').Trim('');
            }

            return value;
        }

        public static string RemoveUnicode(this string logLine)
        {
            return Regex.Replace(logLine, @"[\u0000-\u007F]", String.Empty);
        }

        public static void OutputLog(this string s)
        {
            //第1引数：ファイルパス
            //第2引数：追記するテキスト 
            File.AppendAllText(STRINGSTOCK.PATH_LOG_FILE.GetStringValue(), s + "\n");
        }

        public static int GetRandomInt(int[] last)
        {
            Random rnd = new System.Random();
            Array.IndexOf(last, 1);

            int random;
            if (last[0] == 0){
                random = rnd.Next(1, 100);
            }
            else {
                while (Array.IndexOf(last, (random = rnd.Next(1, 100))) > -1)
                {
                    continue;
                }
            }

            return random;
        }

        /// <summary>
        /// 文字列の指定した位置から指定した長さを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(this string str, int start, int len)
        {
            if (start <= 0)
            {
                throw new ArgumentException("引数'start'は1以上でなければなりません。");
            }
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null || str.Length < start)
            {
                return "";
            }
            if (str.Length < (start + len))
            {
                return str.Substring(start - 1);
            }
            return str.Substring(start - 1, len);
        }

        /// <summary>
        /// 文字列の指定した位置から末尾までを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(this string str, int start)
        {
            return Mid(str, start, str.Length);
        }

        /// <summary>
        /// 文字列の先頭から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Left(this string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }

        /// <summary>
        /// 文字列の末尾から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Right(this string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(str.Length - len, len);
        }
    }
}

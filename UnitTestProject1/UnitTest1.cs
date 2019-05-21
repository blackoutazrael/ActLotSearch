using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LotSearch.Util;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIdentifer()
        {
            ConvertActParam converter = new ConvertActParam();
            Assert.AreEqual(converter.GetJobNames("ディフェンダー"), "V");
            Assert.AreEqual(converter.GetJobNames("アタッカー"), "St");
            Assert.AreEqual(converter.GetJobNames("レンジャー"), "Dr");
            Assert.AreEqual(converter.GetJobNames("ヒーラー"), "M");

            // 頭
            Assert.AreEqual(converter.GetItemNames("サークレット"), "頭");
            Assert.AreEqual(converter.GetItemNames("アイマスク"), "頭");
            Assert.AreEqual(converter.GetItemNames("キャップ"), "頭");
            Assert.AreEqual(converter.GetItemNames("ヘルム"), "頭");
            Assert.AreEqual(converter.GetItemNames("ヘッドギア"), "頭");
            Assert.AreEqual(converter.GetItemNames("バイザー"), "頭");
            Assert.AreEqual(converter.GetItemNames("マスク"), "頭");
            Assert.AreEqual(converter.GetItemNames("ハット"), "頭");
            Assert.AreEqual(converter.GetItemNames("眼帯"), "頭");
            Assert.AreEqual(converter.GetItemNames("面"), "頭");
            Assert.AreEqual(converter.GetItemNames("冠"), "頭");
            Assert.AreEqual(converter.GetItemNames("麺"), "");

            // 胴
            Assert.AreEqual(converter.GetItemNames("ガンビスン"), "胴");
            Assert.AreEqual(converter.GetItemNames("コート"), "胴");
            Assert.AreEqual(converter.GetItemNames("ジャケット"), "胴");
            Assert.AreEqual(converter.GetItemNames("アーマー"), "胴");
            Assert.AreEqual(converter.GetItemNames("タパード"), "胴");
            Assert.AreEqual(converter.GetItemNames("道着"), "胴");
            Assert.AreEqual(converter.GetItemNames("羽織"), "胴");
            Assert.AreEqual(converter.GetItemNames("袈裟"), "胴");
            Assert.AreEqual(converter.GetItemNames("ベスト"), "胴");

            // 手
            Assert.AreEqual(converter.GetItemNames("アームガード"), "手");
            Assert.AreEqual(converter.GetItemNames("グローブ"), "手");
            Assert.AreEqual(converter.GetItemNames("ガントレット"), "手");
            Assert.AreEqual(converter.GetItemNames("籠手"), "手");
            Assert.AreEqual(converter.GetItemNames("手甲"), "手");

            // 帯
            Assert.AreEqual(converter.GetItemNames("タセット"), "帯");
            Assert.AreEqual(converter.GetItemNames("ベルト"), "帯");
            Assert.AreEqual(converter.GetItemNames("帯"), "帯");

            // 脚
            Assert.AreEqual(converter.GetItemNames("トラウザー"), "脚");
            Assert.AreEqual(converter.GetItemNames("ボトム"), "脚");
            Assert.AreEqual(converter.GetItemNames("袴"), "脚");
            Assert.AreEqual(converter.GetItemNames("スカート"), "脚");

            // 足
            Assert.AreEqual(converter.GetItemNames("シューズ"), "足");
            Assert.AreEqual(converter.GetItemNames("ブーツ"), "足");
            Assert.AreEqual(converter.GetItemNames("グリーヴ"), "足");
            Assert.AreEqual(converter.GetItemNames("脛当"), "足");
            Assert.AreEqual(converter.GetItemNames("草履"), "足");

            // 耳
            Assert.AreEqual(converter.GetItemNames("イヤーカフ"), "耳");
            Assert.AreEqual(converter.GetItemNames("耳飾"), "耳");
            Assert.AreEqual(converter.GetItemNames("イヤリング"), "耳");

            // 首
            Assert.AreEqual(converter.GetItemNames("チョーカー"), "首");
            Assert.AreEqual(converter.GetItemNames("首飾"), "首");
            Assert.AreEqual(converter.GetItemNames("ネックレス"), "首");

            // 腕
            Assert.AreEqual(converter.GetItemNames("ブレスレット"), "腕");
            Assert.AreEqual(converter.GetItemNames("腕輪"), "腕");
            Assert.AreEqual(converter.GetItemNames("数珠"), "腕");
            Assert.AreEqual(converter.GetItemNames("アルミラ"), "腕");
            Assert.AreEqual(converter.GetItemNames("アミュレット"), "腕");

            // 指
            Assert.AreEqual(converter.GetItemNames("リング"), "指");
            Assert.AreEqual(converter.GetItemNames("指輪"), "指");
        }
    }
}

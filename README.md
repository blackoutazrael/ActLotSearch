# ActLotSearch
ACTを使って、固定メンバーのロットを楽ちん管理

### 【概要】
FF14（オンラインゲーム）のプレイ環境改善を目的に作成したACTのPluginです。<br>
FF14では難関コンテンツをクリアすると、週１回制限でレアアイテムが入手できます。<br>
それをチームメンバー内で公平に配分する必要があるのですが、<br>
『「次は誰が何を優先取得できるのか」の管理が非常に面倒問題』は、<br>
多くの人が経験する悩みだと思います。<br>
そこで、ACTから取得したログでロット権利者の検索から、<br>
取得情報更新までを一貫して行えるPluginを作りました（身内用）。

### 【流れ】
1. Google Spreadsheet上に、アイテム取得希望順と取得状況を表で管理<br>
![LotManageSheetImage.png](https://raw.githubusercontent.com/blackoutazrael/VoiceLotSearch/images/WS000003.BMP "LotManageSheetImage")

2. ACTを起動し、Pluginを有効化<br>
![DefaultImage.png](https://raw.githubusercontent.com/blackoutazrael/VoiceLotSearch/images/DEFAULT.BMP "DefaultImage")

3. コンテンツをクリアして宝箱を開けると、ロット対象のアイテムが検知され、<br> Spreadsheetの内容と併せてロット権利者を表示<br>
![ITEMDETECTEDImage.png](https://raw.githubusercontent.com/blackoutazrael/VoiceLotSearch/images/ITEMDETECTED.BMP "ITEMDETECTEDImage")

4. ゲーム内でロット（アイテム取得希望者同士のダイス勝負）が行われると、結果を表示<br>
![LOTDETECTEDImage.png](https://raw.githubusercontent.com/blackoutazrael/VoiceLotSearch/images/LOTDETECTED.BMP "LOTDETECTEDImage")

5. 「○」ボタンを押下すると、Spreadsheetに「アイテム取得済み」という意味の「○」を、該当セルに書き込む<br>
![CONFIRMATIONImage.png](https://raw.githubusercontent.com/blackoutazrael/VoiceLotSearch/images/CONFIRMATION.BMP "CONFIRMATIONImage")

### 【環境】
ローカル ACT（Active Combat Tracker https://advancedcombattracker.com/）実行環境
さくらサーバのPHP実行環境

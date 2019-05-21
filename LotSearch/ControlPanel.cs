using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;
using LotSearch.Container;
using LotSearch.Controller;
using LotSearch.Util;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace LotSearch
{

    public partial class ControlPanel : UserControl, IActPluginV1
    {
        LotController controller;
        ListViewBindController listViewBindController;

        public ControlPanel()
        {
            InitializeComponent();
            controller = new LotController();
            listViewBindController = new ListViewBindController();
        }

        public void DeInitPlugin()
        {
            //throw new NotImplementedException();
            ActGlobals.oFormActMain.OnLogLineRead -= this.OnLogLineReadAsync;
            this.btn_commit_1.Click -= this.BtnCommitClickAsync;
            this.btn_commit_2.Click -= this.BtnCommitClickAsync;
            this.btn_commit_3.Click -= this.BtnCommitClickAsync;
            this.btn_commit_4.Click -= this.BtnCommitClickAsync;
            this.btn_commit_5.Click -= this.BtnCommitClickAsync;
            this.btn_commit_6.Click -= this.BtnCommitClickAsync;
            this.btn_commit_7.Click -= this.BtnCommitClickAsync;
            this.btn_commit_8.Click -= this.BtnCommitClickAsync;

            this.lbl_item_1.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_2.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_3.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_4.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_5.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_6.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_7.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_8.TextChanged -= this.OnWhoLabelTextChanged;
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginScreenSpace.Controls.Add(this);
            this.Dock = DockStyle.Fill;
            //throw new NotImplementedException();

            ActGlobals.oFormActMain.OnLogLineRead -= this.OnLogLineReadAsync;
            ActGlobals.oFormActMain.OnLogLineRead += this.OnLogLineReadAsync;

            this.btn_commit_1.Click -= this.BtnCommitClickAsync;
            this.btn_commit_2.Click -= this.BtnCommitClickAsync;
            this.btn_commit_3.Click -= this.BtnCommitClickAsync;
            this.btn_commit_4.Click -= this.BtnCommitClickAsync;
            this.btn_commit_5.Click -= this.BtnCommitClickAsync;
            this.btn_commit_6.Click -= this.BtnCommitClickAsync;
            this.btn_commit_7.Click -= this.BtnCommitClickAsync;
            this.btn_commit_8.Click -= this.BtnCommitClickAsync;
            this.btn_commit_1.Click += this.BtnCommitClickAsync;
            this.btn_commit_2.Click += this.BtnCommitClickAsync;
            this.btn_commit_3.Click += this.BtnCommitClickAsync;
            this.btn_commit_4.Click += this.BtnCommitClickAsync;
            this.btn_commit_5.Click += this.BtnCommitClickAsync;
            this.btn_commit_6.Click += this.BtnCommitClickAsync;
            this.btn_commit_7.Click += this.BtnCommitClickAsync;
            this.btn_commit_8.Click += this.BtnCommitClickAsync;

            this.lbl_item_1.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_2.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_3.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_4.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_5.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_6.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_7.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_8.TextChanged -= this.OnWhoLabelTextChanged;
            this.lbl_item_1.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_2.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_3.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_4.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_5.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_6.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_7.TextChanged += this.OnWhoLabelTextChanged;
            this.lbl_item_8.TextChanged += this.OnWhoLabelTextChanged;
        }

        private void ControlPanel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void OnLogLineReadAsync(bool isImport, LogLineEventArgs logInfo)
        {
            var xivlog = new XIVLog(logInfo);
            if (string.IsNullOrEmpty(xivlog.Log))
            {
                return;
            }

            // 戦利品追加
            if (xivlog.Log.IndexOf(STRINGSTOCK.KEY_WORD_SEARCH.GetStringValue()) > -1)
            {
                try
                {
                    xivlog.Log.OutputLog();
                    //// ロット権利者の検索
                    await JustCallingAsync(xivlog.Log);

                } catch(InvalidOperationException error)
                {
                    //MessageBox.Show(error.Message,
                    //                   "エラー",
                    //                   MessageBoxButtons.OK,
                    //                   MessageBoxIcon.Error);
                }
            }

            // ロット終了
            if (xivlog.Log.IndexOf(STRINGSTOCK.KEY_WORD_DICE.GetStringValue()) > -1 &&
                xivlog.Log.IndexOf(STRINGSTOCK.KEY_WORD_LOT.GetStringValue()) > -1)
            {
                try
                {
                    xivlog.Log.OutputLog();
                    await JustCallingLotAsync(xivlog.Log);

                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message,
                    //                   "エラー",
                    //                   MessageBoxButtons.OK,
                    //                   MessageBoxIcon.Error);
                }

            }
        }

        private async Task JustCallingAsync(string logline) =>await controller.CommitAsync(logline, this);

        private async Task JustCallingLotAsync(string logline) => await listViewBindController.SetListDataAsync(logline, this);

        private void OnWhoLabelTextChanged(object sender, EventArgs e)
        {
            string objectNumber = ((Label)sender).Name.Right(1);

            if(((Label)sender).Text.IndexOf("フリー") > -1)
            {
                GetCommitButtonObject(objectNumber).Visible = false;
            }
        }

        private async void BtnCommitClickAsync(object sender, EventArgs e)
        {
            string equipName;
            string objectNumber = ((Button)sender).Name.Right(1);

            // ロット可能者が空なら、内容をリセットして離脱
            string who = GetTextBoxObject("lv_lbl_item_" + objectNumber).Text;
            if(string.IsNullOrEmpty(who))
            {
                ResetContents(objectNumber);
                return;
            }

            if (this.Confirm(string.Format("{0} さんが取得済みとして登録を実行します", who)))
            {
                ConvertActParam convertActParam = new ConvertActParam();
                var lotContainer = new LotContainer()
                {
                    EQUIPNAME = (equipName = GetItemLabelObject(objectNumber).Text),
                    USER = GetTextBoxObject("lv_lbl_item_" + objectNumber).Text,
                    ITEM = convertActParam.GetItemNames(equipName),
                    JOB = convertActParam.GetJobNames(equipName),
                    IS_FIRST_PRIORITY = (GetResultLabelObject("lbl_item_" + objectNumber).Text.IndexOf("第一希望") > -1)
                };

                try
                {
                    await new GASPostController().RegisterAsync(lotContainer, sender);
                    ResetContents(objectNumber);

                    MessageBox.Show("Done!",
                                       "おけまる",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);

                }
                catch (InvalidOperationException error)
                {
                    MessageBox.Show(error.Message,
                                       "エラー",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                }
            }
            else
            {
                if (this.Confirm("リセットしますか？"))
                {
                    ResetContents(objectNumber);
                }
            }
        }

        private void ResetContents(string objectNumber)
        { 
            GetListViewObject("lbl_item_" + objectNumber).Items.Clear();
            GetTextBoxObject("lv_lbl_item_" + objectNumber).ResetText();
            GetResultLabelObject("lbl_item_" + objectNumber).Text = "WHO?";
            GetItemLabelObject(objectNumber).Text = "ITEM?";
        }

        public bool Confirm(string msg)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(this, msg, "Confirm", buttons, MessageBoxIcon.Question);

            return (result == DialogResult.Yes);
        }
        
        public void SetItemOnLabel(string item, string who)
        {
            List<Label> labels = GetAllControls<Label>(this);
            
            foreach(var lbl in labels)
            {
                if (lbl.Text.Equals("ITEM?")) {
                    lbl.Text = item;

                    GetResultLabelObject(lbl.Name).Text = who;

                    return;
                }
            }
        }

        /// <summary>
        /// 指定のコントロール上の全てのジェネリック型 Tコントロールを取得する。
        /// </summary>
        /// <typeparam name="T">対象となる型</typeparam>
        /// <param name="top">指定のコントロール</param>
        /// <returns>指定のコントロール上の全てのジェネリック型 Tコントロールのインスタンス</returns>
        public List<T> GetAllControls<T>(Control top) where T : Control
        {
            List<T> buf = new List<T>();
            foreach (Control ctrl in top.Controls)
            {
                if (ctrl is T) buf.Add((T)ctrl);
                buf.AddRange(GetAllControls<T>(ctrl));
            }
            return buf;
        }

        public TextBox GetTextBoxObject(string lv_name)
        {
            switch (lv_name)
            {
                case "lv_lbl_item_1":
                    return this.txt_lv_lbl_item_1;
                case "lv_lbl_item_2":
                    return this.txt_lv_lbl_item_2;
                case "lv_lbl_item_3":
                    return this.txt_lv_lbl_item_3;
                case "lv_lbl_item_4":
                    return this.txt_lv_lbl_item_4;
                case "lv_lbl_item_5":
                    return this.txt_lv_lbl_item_5;
                case "lv_lbl_item_6":
                    return this.txt_lv_lbl_item_6;
                case "lv_lbl_item_7":
                    return this.txt_lv_lbl_item_7;
                case "lv_lbl_item_8":
                    return this.txt_lv_lbl_item_8;
                default:
                    return null;
            }
        }

        public ListView GetListViewObject(string itemLbl_name)
        {
            switch (itemLbl_name)
            {
                case "lbl_item_1":
                    return this.lv_lbl_item_1;
                case "lbl_item_2":
                    return this.lv_lbl_item_2;
                case "lbl_item_3":
                    return this.lv_lbl_item_3;
                case "lbl_item_4":
                    return this.lv_lbl_item_4;
                case "lbl_item_5":
                    return this.lv_lbl_item_5;
                case "lbl_item_6":
                    return this.lv_lbl_item_6;
                case "lbl_item_7":
                    return this.lv_lbl_item_7;
                case "lbl_item_8":
                    return this.lv_lbl_item_8;
                default:
                    return null;
            }
        }

        public Label GetResultLabelObject(string itemLbl_name)
        {
            switch (itemLbl_name)
            {
                case "lbl_item_1":
                    return this.lbl_lot_1;
                case "lbl_item_2":
                    return this.lbl_lot_2;
                case "lbl_item_3":
                    return this.lbl_lot_3;
                case "lbl_item_4":
                    return this.lbl_lot_4;
                case "lbl_item_5":
                    return this.lbl_lot_5;
                case "lbl_item_6":
                    return this.lbl_lot_6;
                case "lbl_item_7":
                    return this.lbl_lot_7;
                case "lbl_item_8":
                    return this.lbl_lot_8;
                default:
                    return null;
            }
        }

        public Label GetItemLabelObject(string objectNumber)
        {
            switch (objectNumber)
            {
                case "1":
                    return this.lbl_item_1;
                case "2":
                    return this.lbl_item_2;
                case "3":
                    return this.lbl_item_3;
                case "4":
                    return this.lbl_item_4;
                case "5":
                    return this.lbl_item_5;
                case "6":
                    return this.lbl_item_6;
                case "7":
                    return this.lbl_item_7;
                case "8":
                    return this.lbl_item_8;
                default:
                    return null;
            }
        }

        public Button GetCommitButtonObject(string objectNumber)
        {
            switch (objectNumber)
            {
                case "1":
                    return this.btn_commit_1;
                case "2":
                    return this.btn_commit_2;
                case "3":
                    return this.btn_commit_3;
                case "4":
                    return this.btn_commit_4;
                case "5":
                    return this.btn_commit_5;
                case "6":
                    return this.btn_commit_6;
                case "7":
                    return this.btn_commit_7;
                case "8":
                    return this.btn_commit_8;
                default:
                    return null;
            }
        }
    }
}

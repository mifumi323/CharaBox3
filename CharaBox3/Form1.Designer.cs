namespace CharaBox3
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.miMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miMainOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miMainEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miMainAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miMainDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miMainRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miMainExitNoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miMainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewABC = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewAge = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameABC = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameAge = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameSex = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGameGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSex = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexABC = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexAge = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSexGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsABC = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsAge = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewGraphicsSex = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFind = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindABC = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindAge = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindSize = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindSex = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewFindGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.ssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tvChara = new System.Windows.Forms.TreeView();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlInfoUpper = new System.Windows.Forms.Panel();
            this.cmbInfo = new System.Windows.Forms.ComboBox();
            this.cmbGame = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblGame = new System.Windows.Forms.Label();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.msMain.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlInfoUpper.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMain,
            this.miView});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msMain.Size = new System.Drawing.Size(457, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // miMain
            // 
            this.miMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMainFile,
            this.miMainOpen,
            this.toolStripMenuItem3,
            this.miMainEdit,
            this.miMainAdd,
            this.miMainDelete,
            this.toolStripMenuItem1,
            this.miMainRandom,
            this.toolStripMenuItem2,
            this.miMainExitNoSave,
            this.miMainExit});
            this.miMain.Name = "miMain";
            this.miMain.Size = new System.Drawing.Size(60, 20);
            this.miMain.Text = "メイン(&M)";
            // 
            // miMainFile
            // 
            this.miMainFile.Name = "miMainFile";
            this.miMainFile.Size = new System.Drawing.Size(195, 22);
            this.miMainFile.Text = "ファイル切り替え";
            // 
            // miMainOpen
            // 
            this.miMainOpen.Name = "miMainOpen";
            this.miMainOpen.Size = new System.Drawing.Size(195, 22);
            this.miMainOpen.Text = "直接開く(&O)";
            this.miMainOpen.Click += new System.EventHandler(this.miMainOpen_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
            // 
            // miMainEdit
            // 
            this.miMainEdit.Name = "miMainEdit";
            this.miMainEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.miMainEdit.Size = new System.Drawing.Size(195, 22);
            this.miMainEdit.Text = "編集(&E)";
            this.miMainEdit.Click += new System.EventHandler(this.miMainEdit_Click);
            // 
            // miMainAdd
            // 
            this.miMainAdd.Name = "miMainAdd";
            this.miMainAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.miMainAdd.Size = new System.Drawing.Size(195, 22);
            this.miMainAdd.Text = "追加(&A)";
            this.miMainAdd.Click += new System.EventHandler(this.miMainAdd_Click);
            // 
            // miMainDelete
            // 
            this.miMainDelete.Name = "miMainDelete";
            this.miMainDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.miMainDelete.Size = new System.Drawing.Size(195, 22);
            this.miMainDelete.Text = "削除(&D)";
            this.miMainDelete.Click += new System.EventHandler(this.miMainDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
            // 
            // miMainRandom
            // 
            this.miMainRandom.Name = "miMainRandom";
            this.miMainRandom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.miMainRandom.Size = new System.Drawing.Size(195, 22);
            this.miMainRandom.Text = "ランダムセレクト(&R)";
            this.miMainRandom.Click += new System.EventHandler(this.miMainRandom_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // miMainExitNoSave
            // 
            this.miMainExitNoSave.Name = "miMainExitNoSave";
            this.miMainExitNoSave.Size = new System.Drawing.Size(195, 22);
            this.miMainExitNoSave.Text = "保存せず終了(&Q)";
            this.miMainExitNoSave.Click += new System.EventHandler(this.miMainExitNoSave_Click);
            // 
            // miMainExit
            // 
            this.miMainExit.Name = "miMainExit";
            this.miMainExit.Size = new System.Drawing.Size(195, 22);
            this.miMainExit.Text = "終了(&X)";
            this.miMainExit.Click += new System.EventHandler(this.miMainExit_Click);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewABC,
            this.miViewAge,
            this.miViewSize,
            this.miViewUpdate,
            this.miViewDescription,
            this.miViewGame,
            this.miViewSex,
            this.miViewGraphics,
            this.miViewFind});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(57, 20);
            this.miView.Text = "表示(&V)";
            // 
            // miViewABC
            // 
            this.miViewABC.Name = "miViewABC";
            this.miViewABC.Size = new System.Drawing.Size(136, 22);
            this.miViewABC.Text = "50音順";
            this.miViewABC.Click += new System.EventHandler(this.miViewABC_Click);
            // 
            // miViewAge
            // 
            this.miViewAge.Name = "miViewAge";
            this.miViewAge.Size = new System.Drawing.Size(136, 22);
            this.miViewAge.Text = "年齢順";
            this.miViewAge.Click += new System.EventHandler(this.miViewAge_Click);
            // 
            // miViewSize
            // 
            this.miViewSize.Name = "miViewSize";
            this.miViewSize.Size = new System.Drawing.Size(136, 22);
            this.miViewSize.Text = "大きさ順";
            this.miViewSize.Click += new System.EventHandler(this.miViewSize_Click);
            // 
            // miViewUpdate
            // 
            this.miViewUpdate.Name = "miViewUpdate";
            this.miViewUpdate.Size = new System.Drawing.Size(136, 22);
            this.miViewUpdate.Text = "更新日順";
            this.miViewUpdate.Click += new System.EventHandler(this.miViewUpdate_Click);
            // 
            // miViewDescription
            // 
            this.miViewDescription.Name = "miViewDescription";
            this.miViewDescription.Size = new System.Drawing.Size(136, 22);
            this.miViewDescription.Text = "説明の長さ順";
            this.miViewDescription.Click += new System.EventHandler(this.miViewDescription_Click);
            // 
            // miViewGame
            // 
            this.miViewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewGameABC,
            this.miViewGameAge,
            this.miViewGameSize,
            this.miViewGameUpdate,
            this.miViewGameDescription,
            this.miViewGameSex,
            this.miViewGameGraphics});
            this.miViewGame.Name = "miViewGame";
            this.miViewGame.Size = new System.Drawing.Size(136, 22);
            this.miViewGame.Text = "登場作品別";
            // 
            // miViewGameABC
            // 
            this.miViewGameABC.Name = "miViewGameABC";
            this.miViewGameABC.Size = new System.Drawing.Size(202, 22);
            this.miViewGameABC.Text = "登場作品別-50音順";
            this.miViewGameABC.Click += new System.EventHandler(this.miViewGame_Click);
            // 
            // miViewGameAge
            // 
            this.miViewGameAge.Name = "miViewGameAge";
            this.miViewGameAge.Size = new System.Drawing.Size(202, 22);
            this.miViewGameAge.Text = "登場作品別-年齢順";
            this.miViewGameAge.Click += new System.EventHandler(this.miViewGameAge_Click);
            // 
            // miViewGameSize
            // 
            this.miViewGameSize.Name = "miViewGameSize";
            this.miViewGameSize.Size = new System.Drawing.Size(202, 22);
            this.miViewGameSize.Text = "登場作品別-大きさ順";
            this.miViewGameSize.Click += new System.EventHandler(this.miViewGameSize_Click);
            // 
            // miViewGameUpdate
            // 
            this.miViewGameUpdate.Name = "miViewGameUpdate";
            this.miViewGameUpdate.Size = new System.Drawing.Size(202, 22);
            this.miViewGameUpdate.Text = "登場作品別-更新日順";
            this.miViewGameUpdate.Click += new System.EventHandler(this.miViewGameUpdate_Click);
            // 
            // miViewGameDescription
            // 
            this.miViewGameDescription.Name = "miViewGameDescription";
            this.miViewGameDescription.Size = new System.Drawing.Size(202, 22);
            this.miViewGameDescription.Text = "登場作品別-説明の長さ順";
            this.miViewGameDescription.Click += new System.EventHandler(this.miViewGameDescription_Click);
            // 
            // miViewGameSex
            // 
            this.miViewGameSex.Name = "miViewGameSex";
            this.miViewGameSex.Size = new System.Drawing.Size(202, 22);
            this.miViewGameSex.Text = "登場作品別-性別";
            this.miViewGameSex.Click += new System.EventHandler(this.miViewGameSex_Click);
            // 
            // miViewGameGraphics
            // 
            this.miViewGameGraphics.Name = "miViewGameGraphics";
            this.miViewGameGraphics.Size = new System.Drawing.Size(202, 22);
            this.miViewGameGraphics.Text = "登場作品別-画像別";
            this.miViewGameGraphics.Click += new System.EventHandler(this.miViewGameGraphics_Click);
            // 
            // miViewSex
            // 
            this.miViewSex.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewSexABC,
            this.miViewSexAge,
            this.miViewSexSize,
            this.miViewSexUpdate,
            this.miViewSexDescription,
            this.miViewSexGame,
            this.miViewSexGraphics});
            this.miViewSex.Name = "miViewSex";
            this.miViewSex.Size = new System.Drawing.Size(136, 22);
            this.miViewSex.Text = "性別";
            // 
            // miViewSexABC
            // 
            this.miViewSexABC.Name = "miViewSexABC";
            this.miViewSexABC.Size = new System.Drawing.Size(166, 22);
            this.miViewSexABC.Text = "性別-50音順";
            this.miViewSexABC.Click += new System.EventHandler(this.miViewSex_Click);
            // 
            // miViewSexAge
            // 
            this.miViewSexAge.Name = "miViewSexAge";
            this.miViewSexAge.Size = new System.Drawing.Size(166, 22);
            this.miViewSexAge.Text = "性別-年齢順";
            this.miViewSexAge.Click += new System.EventHandler(this.miViewSexAge_Click);
            // 
            // miViewSexSize
            // 
            this.miViewSexSize.Name = "miViewSexSize";
            this.miViewSexSize.Size = new System.Drawing.Size(166, 22);
            this.miViewSexSize.Text = "性別-大きさ順";
            this.miViewSexSize.Click += new System.EventHandler(this.miViewSexSize_Click);
            // 
            // miViewSexUpdate
            // 
            this.miViewSexUpdate.Name = "miViewSexUpdate";
            this.miViewSexUpdate.Size = new System.Drawing.Size(166, 22);
            this.miViewSexUpdate.Text = "性別-更新日順";
            this.miViewSexUpdate.Click += new System.EventHandler(this.miViewSexUpdate_Click);
            // 
            // miViewSexDescription
            // 
            this.miViewSexDescription.Name = "miViewSexDescription";
            this.miViewSexDescription.Size = new System.Drawing.Size(166, 22);
            this.miViewSexDescription.Text = "性別-説明の長さ順";
            this.miViewSexDescription.Click += new System.EventHandler(this.miViewSexDescription_Click);
            // 
            // miViewSexGame
            // 
            this.miViewSexGame.Name = "miViewSexGame";
            this.miViewSexGame.Size = new System.Drawing.Size(166, 22);
            this.miViewSexGame.Text = "性別-登場作品別";
            this.miViewSexGame.Click += new System.EventHandler(this.miViewSexGame_Click);
            // 
            // miViewSexGraphics
            // 
            this.miViewSexGraphics.Name = "miViewSexGraphics";
            this.miViewSexGraphics.Size = new System.Drawing.Size(166, 22);
            this.miViewSexGraphics.Text = "性別-画像別";
            this.miViewSexGraphics.Click += new System.EventHandler(this.miViewSexGraphics_Click);
            // 
            // miViewGraphics
            // 
            this.miViewGraphics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewGraphicsABC,
            this.miViewGraphicsAge,
            this.miViewGraphicsSize,
            this.miViewGraphicsUpdate,
            this.miViewGraphicsDescription,
            this.miViewGraphicsGame,
            this.miViewGraphicsSex});
            this.miViewGraphics.Name = "miViewGraphics";
            this.miViewGraphics.Size = new System.Drawing.Size(136, 22);
            this.miViewGraphics.Text = "画像別";
            // 
            // miViewGraphicsABC
            // 
            this.miViewGraphicsABC.Name = "miViewGraphicsABC";
            this.miViewGraphicsABC.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsABC.Text = "画像別-50音順";
            this.miViewGraphicsABC.Click += new System.EventHandler(this.miViewGraphics_Click);
            // 
            // miViewGraphicsAge
            // 
            this.miViewGraphicsAge.Name = "miViewGraphicsAge";
            this.miViewGraphicsAge.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsAge.Text = "画像別-年齢順";
            this.miViewGraphicsAge.Click += new System.EventHandler(this.miViewGraphicsAge_Click);
            // 
            // miViewGraphicsSize
            // 
            this.miViewGraphicsSize.Name = "miViewGraphicsSize";
            this.miViewGraphicsSize.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsSize.Text = "画像別-大きさ順";
            this.miViewGraphicsSize.Click += new System.EventHandler(this.miViewGraphicsSize_Click);
            // 
            // miViewGraphicsUpdate
            // 
            this.miViewGraphicsUpdate.Name = "miViewGraphicsUpdate";
            this.miViewGraphicsUpdate.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsUpdate.Text = "画像別-更新日順";
            this.miViewGraphicsUpdate.Click += new System.EventHandler(this.miViewGraphicsUpdate_Click);
            // 
            // miViewGraphicsDescription
            // 
            this.miViewGraphicsDescription.Name = "miViewGraphicsDescription";
            this.miViewGraphicsDescription.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsDescription.Text = "画像別-説明の長さ順";
            this.miViewGraphicsDescription.Click += new System.EventHandler(this.miViewGraphicsDescription_Click);
            // 
            // miViewGraphicsGame
            // 
            this.miViewGraphicsGame.Name = "miViewGraphicsGame";
            this.miViewGraphicsGame.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsGame.Text = "画像別-登場作品別";
            this.miViewGraphicsGame.Click += new System.EventHandler(this.miViewGraphicsGame_Click);
            // 
            // miViewGraphicsSex
            // 
            this.miViewGraphicsSex.Name = "miViewGraphicsSex";
            this.miViewGraphicsSex.Size = new System.Drawing.Size(178, 22);
            this.miViewGraphicsSex.Text = "画像別-性別";
            this.miViewGraphicsSex.Click += new System.EventHandler(this.miViewGraphicsSex_Click);
            // 
            // miViewFind
            // 
            this.miViewFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewFindABC,
            this.miViewFindAge,
            this.miViewFindSize,
            this.miViewFindUpdate,
            this.miViewFindDescription,
            this.miViewFindGame,
            this.miViewFindSex,
            this.miViewFindGraphics});
            this.miViewFind.Name = "miViewFind";
            this.miViewFind.Size = new System.Drawing.Size(136, 22);
            this.miViewFind.Text = "検索";
            // 
            // miViewFindABC
            // 
            this.miViewFindABC.Name = "miViewFindABC";
            this.miViewFindABC.Size = new System.Drawing.Size(166, 22);
            this.miViewFindABC.Text = "検索-50音順";
            this.miViewFindABC.Click += new System.EventHandler(this.miViewFindABC_Click);
            // 
            // miViewFindAge
            // 
            this.miViewFindAge.Name = "miViewFindAge";
            this.miViewFindAge.Size = new System.Drawing.Size(166, 22);
            this.miViewFindAge.Text = "検索-年齢順";
            this.miViewFindAge.Click += new System.EventHandler(this.miViewFindAge_Click);
            // 
            // miViewFindSize
            // 
            this.miViewFindSize.Name = "miViewFindSize";
            this.miViewFindSize.Size = new System.Drawing.Size(166, 22);
            this.miViewFindSize.Text = "検索-大きさ順";
            this.miViewFindSize.Click += new System.EventHandler(this.miViewFindSize_Click);
            // 
            // miViewFindUpdate
            // 
            this.miViewFindUpdate.Name = "miViewFindUpdate";
            this.miViewFindUpdate.Size = new System.Drawing.Size(166, 22);
            this.miViewFindUpdate.Text = "検索-更新日順";
            this.miViewFindUpdate.Click += new System.EventHandler(this.miViewindUpdate_Click);
            // 
            // miViewFindDescription
            // 
            this.miViewFindDescription.Name = "miViewFindDescription";
            this.miViewFindDescription.Size = new System.Drawing.Size(166, 22);
            this.miViewFindDescription.Text = "検索-説明の長さ順";
            this.miViewFindDescription.Click += new System.EventHandler(this.miViewFindDescription_Click);
            // 
            // miViewFindGame
            // 
            this.miViewFindGame.Name = "miViewFindGame";
            this.miViewFindGame.Size = new System.Drawing.Size(166, 22);
            this.miViewFindGame.Text = "検索-登場作品別";
            this.miViewFindGame.Click += new System.EventHandler(this.miViewFindGame_Click);
            // 
            // miViewFindSex
            // 
            this.miViewFindSex.Name = "miViewFindSex";
            this.miViewFindSex.Size = new System.Drawing.Size(166, 22);
            this.miViewFindSex.Text = "検索-性別";
            this.miViewFindSex.Click += new System.EventHandler(this.miViewFindSex_Click);
            // 
            // miViewFindGraphics
            // 
            this.miViewFindGraphics.Name = "miViewFindGraphics";
            this.miViewFindGraphics.Size = new System.Drawing.Size(166, 22);
            this.miViewFindGraphics.Text = "検索-画像別";
            this.miViewFindGraphics.Click += new System.EventHandler(this.miViewFindGraphics_Click);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssLabel});
            this.ssBottom.Location = new System.Drawing.Point(0, 244);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(457, 22);
            this.ssBottom.TabIndex = 7;
            this.ssBottom.Text = "statusStrip1";
            this.ssBottom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ssBottom_MouseDoubleClick);
            // 
            // ssLabel
            // 
            this.ssLabel.Name = "ssLabel";
            this.ssLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // scMain
            // 
            this.scMain.BackColor = System.Drawing.SystemColors.Control;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 24);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tvChara);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlInfo);
            this.scMain.Panel2.Controls.Add(this.pnlImage);
            this.scMain.Panel2.Resize += new System.EventHandler(this.scMain_Panel2_Resize);
            this.scMain.Size = new System.Drawing.Size(457, 220);
            this.scMain.SplitterDistance = 152;
            this.scMain.TabIndex = 8;
            this.scMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scMain_SplitterMoved);
            // 
            // tvChara
            // 
            this.tvChara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvChara.Location = new System.Drawing.Point(0, 0);
            this.tvChara.Name = "tvChara";
            this.tvChara.Size = new System.Drawing.Size(152, 220);
            this.tvChara.TabIndex = 1;
            this.tvChara.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvChara_AfterSelect);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.txtDescription);
            this.pnlInfo.Controls.Add(this.pnlInfoUpper);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(144, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(157, 220);
            this.pnlInfo.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDescription.Location = new System.Drawing.Point(0, 68);
            this.txtDescription.MaxLength = 2147483647;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(157, 152);
            this.txtDescription.TabIndex = 7;
            // 
            // pnlInfoUpper
            // 
            this.pnlInfoUpper.Controls.Add(this.cmbInfo);
            this.pnlInfoUpper.Controls.Add(this.cmbGame);
            this.pnlInfoUpper.Controls.Add(this.lblName);
            this.pnlInfoUpper.Controls.Add(this.cmbName);
            this.pnlInfoUpper.Controls.Add(this.lblInfo);
            this.pnlInfoUpper.Controls.Add(this.lblGame);
            this.pnlInfoUpper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoUpper.Location = new System.Drawing.Point(0, 0);
            this.pnlInfoUpper.Name = "pnlInfoUpper";
            this.pnlInfoUpper.Size = new System.Drawing.Size(157, 68);
            this.pnlInfoUpper.TabIndex = 6;
            // 
            // cmbInfo
            // 
            this.cmbInfo.FormattingEnabled = true;
            this.cmbInfo.Location = new System.Drawing.Point(61, 42);
            this.cmbInfo.Name = "cmbInfo";
            this.cmbInfo.Size = new System.Drawing.Size(79, 20);
            this.cmbInfo.TabIndex = 3;
            // 
            // cmbGame
            // 
            this.cmbGame.FormattingEnabled = true;
            this.cmbGame.Location = new System.Drawing.Point(61, 21);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(79, 20);
            this.cmbGame.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(-2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "名前";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(61, 0);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(79, 20);
            this.cmbName.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(-2, 41);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(57, 20);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "その他";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGame
            // 
            this.lblGame.Location = new System.Drawing.Point(-2, 21);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(57, 20);
            this.lblGame.TabIndex = 1;
            this.lblGame.Text = "登場作品";
            this.lblGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.picImage);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Padding = new System.Windows.Forms.Padding(2);
            this.pnlImage.Size = new System.Drawing.Size(144, 220);
            this.pnlImage.TabIndex = 8;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(2, 2);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(140, 216);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 7;
            this.picImage.TabStop = false;
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            // 
            // ofdFile
            // 
            this.ofdFile.DefaultExt = "dat";
            this.ofdFile.Filter = "データ|*.dat|その他|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 266);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "Form1";
            this.Text = "CharaBox3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlInfoUpper.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem miMain;
        private System.Windows.Forms.ToolStripMenuItem miMainEdit;
        private System.Windows.Forms.ToolStripMenuItem miMainAdd;
        private System.Windows.Forms.ToolStripMenuItem miMainDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miMainExit;
        private System.Windows.Forms.ToolStripMenuItem miMainRandom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miViewABC;
        private System.Windows.Forms.ToolStripMenuItem miViewAge;
        private System.Windows.Forms.ToolStripMenuItem miViewSex;
        private System.Windows.Forms.ToolStripMenuItem miViewSize;
        private System.Windows.Forms.ToolStripMenuItem miViewUpdate;
        private System.Windows.Forms.ToolStripMenuItem miViewDescription;
        private System.Windows.Forms.ToolStripMenuItem miMainFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TreeView tvChara;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlInfoUpper;
        private System.Windows.Forms.ComboBox cmbInfo;
        private System.Windows.Forms.ComboBox cmbGame;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ToolStripStatusLabel ssLabel;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphics;
        private System.Windows.Forms.ToolStripMenuItem miViewGame;
        private System.Windows.Forms.ToolStripMenuItem miViewGameABC;
        private System.Windows.Forms.ToolStripMenuItem miViewGameSex;
        private System.Windows.Forms.ToolStripMenuItem miViewGameAge;
        private System.Windows.Forms.ToolStripMenuItem miViewGameSize;
        private System.Windows.Forms.ToolStripMenuItem miViewGameUpdate;
        private System.Windows.Forms.ToolStripMenuItem miViewGameDescription;
        private System.Windows.Forms.ToolStripMenuItem miViewGameGraphics;
        private System.Windows.Forms.ToolStripMenuItem miViewSexABC;
        private System.Windows.Forms.ToolStripMenuItem miViewSexGame;
        private System.Windows.Forms.ToolStripMenuItem miViewSexAge;
        private System.Windows.Forms.ToolStripMenuItem miViewSexSize;
        private System.Windows.Forms.ToolStripMenuItem miViewSexUpdate;
        private System.Windows.Forms.ToolStripMenuItem miViewSexDescription;
        private System.Windows.Forms.ToolStripMenuItem miViewSexGraphics;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsABC;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsAge;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsSize;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsUpdate;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsDescription;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsGame;
        private System.Windows.Forms.ToolStripMenuItem miViewGraphicsSex;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.ToolStripMenuItem miMainOpen;
        private System.Windows.Forms.ToolStripMenuItem miViewFind;
        private System.Windows.Forms.ToolStripMenuItem miViewFindABC;
        private System.Windows.Forms.ToolStripMenuItem miViewFindAge;
        private System.Windows.Forms.ToolStripMenuItem miViewFindSize;
        private System.Windows.Forms.ToolStripMenuItem miViewFindUpdate;
        private System.Windows.Forms.ToolStripMenuItem miViewFindDescription;
        private System.Windows.Forms.ToolStripMenuItem miViewFindGame;
        private System.Windows.Forms.ToolStripMenuItem miViewFindSex;
        private System.Windows.Forms.ToolStripMenuItem miViewFindGraphics;
        private System.Windows.Forms.ToolStripMenuItem miMainExitNoSave;
    }
}


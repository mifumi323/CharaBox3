namespace CharaBox3
{
    partial class FormEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHint = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabEdit = new System.Windows.Forms.TabControl();
            this.tpName = new System.Windows.Forms.TabPage();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tpGame = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtGame = new System.Windows.Forms.TextBox();
            this.lstGame = new System.Windows.Forms.ListBox();
            this.tpDescription = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tpGraphic = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvGraphic = new System.Windows.Forms.TreeView();
            this.picGraphic = new System.Windows.Forms.PictureBox();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.tlpOther = new System.Windows.Forms.TableLayoutPanel();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.tpName.SuspendLayout();
            this.tpGame.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tpDescription.SuspendLayout();
            this.tpGraphic.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphic)).BeginInit();
            this.tpOther.SuspendLayout();
            this.tlpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtHint);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 38);
            this.panel1.TabIndex = 3;
            // 
            // txtHint
            // 
            this.txtHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHint.Location = new System.Drawing.Point(0, 0);
            this.txtHint.Multiline = true;
            this.txtHint.Name = "txtHint";
            this.txtHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHint.Size = new System.Drawing.Size(372, 38);
            this.txtHint.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(372, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 38);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(449, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 38);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.tpName);
            this.tabEdit.Controls.Add(this.tpGame);
            this.tabEdit.Controls.Add(this.tpDescription);
            this.tabEdit.Controls.Add(this.tpGraphic);
            this.tabEdit.Controls.Add(this.tpOther);
            this.tabEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEdit.Location = new System.Drawing.Point(0, 0);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.SelectedIndex = 0;
            this.tabEdit.Size = new System.Drawing.Size(526, 318);
            this.tabEdit.TabIndex = 4;
            // 
            // tpName
            // 
            this.tpName.Controls.Add(this.txtName);
            this.tpName.Location = new System.Drawing.Point(4, 21);
            this.tpName.Name = "tpName";
            this.tpName.Padding = new System.Windows.Forms.Padding(3);
            this.tpName.Size = new System.Drawing.Size(518, 293);
            this.tpName.TabIndex = 0;
            this.tpName.Text = "名前";
            this.tpName.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(3, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtName.Size = new System.Drawing.Size(512, 287);
            this.txtName.TabIndex = 3;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // tpGame
            // 
            this.tpGame.Controls.Add(this.splitContainer1);
            this.tpGame.Location = new System.Drawing.Point(4, 21);
            this.tpGame.Name = "tpGame";
            this.tpGame.Padding = new System.Windows.Forms.Padding(3);
            this.tpGame.Size = new System.Drawing.Size(518, 293);
            this.tpGame.TabIndex = 1;
            this.tpGame.Text = "登場作品";
            this.tpGame.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtGame);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstGame);
            this.splitContainer1.Size = new System.Drawing.Size(512, 287);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtGame
            // 
            this.txtGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGame.Location = new System.Drawing.Point(0, 0);
            this.txtGame.Multiline = true;
            this.txtGame.Name = "txtGame";
            this.txtGame.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGame.Size = new System.Drawing.Size(281, 287);
            this.txtGame.TabIndex = 5;
            this.txtGame.Enter += new System.EventHandler(this.txtGame_Enter);
            // 
            // lstGame
            // 
            this.lstGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGame.FormattingEnabled = true;
            this.lstGame.ItemHeight = 12;
            this.lstGame.Location = new System.Drawing.Point(0, 0);
            this.lstGame.Name = "lstGame";
            this.lstGame.Size = new System.Drawing.Size(227, 280);
            this.lstGame.TabIndex = 0;
            this.lstGame.DoubleClick += new System.EventHandler(this.lstGame_DoubleClick);
            this.lstGame.Enter += new System.EventHandler(this.lstGame_Enter);
            // 
            // tpDescription
            // 
            this.tpDescription.Controls.Add(this.txtDescription);
            this.tpDescription.Location = new System.Drawing.Point(4, 21);
            this.tpDescription.Name = "tpDescription";
            this.tpDescription.Size = new System.Drawing.Size(518, 293);
            this.tpDescription.TabIndex = 0;
            this.tpDescription.Text = "説明";
            this.tpDescription.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.MaxLength = 2147483647;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(518, 293);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            // 
            // tpGraphic
            // 
            this.tpGraphic.Controls.Add(this.splitContainer2);
            this.tpGraphic.Location = new System.Drawing.Point(4, 21);
            this.tpGraphic.Name = "tpGraphic";
            this.tpGraphic.Padding = new System.Windows.Forms.Padding(3);
            this.tpGraphic.Size = new System.Drawing.Size(518, 293);
            this.tpGraphic.TabIndex = 2;
            this.tpGraphic.Text = "画像";
            this.tpGraphic.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvGraphic);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.picGraphic);
            this.splitContainer2.Size = new System.Drawing.Size(512, 287);
            this.splitContainer2.SplitterDistance = 170;
            this.splitContainer2.TabIndex = 2;
            // 
            // tvGraphic
            // 
            this.tvGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGraphic.Location = new System.Drawing.Point(0, 0);
            this.tvGraphic.Name = "tvGraphic";
            this.tvGraphic.Size = new System.Drawing.Size(170, 287);
            this.tvGraphic.TabIndex = 0;
            this.tvGraphic.Enter += new System.EventHandler(this.tvGraphic_Enter);
            this.tvGraphic.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGraphic_AfterSelect);
            // 
            // picGraphic
            // 
            this.picGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraphic.Location = new System.Drawing.Point(0, 0);
            this.picGraphic.Name = "picGraphic";
            this.picGraphic.Size = new System.Drawing.Size(338, 287);
            this.picGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGraphic.TabIndex = 2;
            this.picGraphic.TabStop = false;
            this.picGraphic.Resize += new System.EventHandler(this.picGraphic_Resize);
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.tlpOther);
            this.tpOther.Location = new System.Drawing.Point(4, 21);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(518, 293);
            this.tpOther.TabIndex = 0;
            this.tpOther.Text = "その他";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // tlpOther
            // 
            this.tlpOther.ColumnCount = 2;
            this.tlpOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOther.Controls.Add(this.txtSize, 1, 2);
            this.tlpOther.Controls.Add(this.lblSize, 0, 2);
            this.tlpOther.Controls.Add(this.lblAge, 0, 1);
            this.tlpOther.Controls.Add(this.lblSex, 0, 0);
            this.tlpOther.Controls.Add(this.cmbSex, 1, 0);
            this.tlpOther.Controls.Add(this.txtAge, 1, 1);
            this.tlpOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOther.Location = new System.Drawing.Point(0, 0);
            this.tlpOther.Name = "tlpOther";
            this.tlpOther.RowCount = 4;
            this.tlpOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpOther.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOther.Size = new System.Drawing.Size(518, 293);
            this.tlpOther.TabIndex = 2;
            // 
            // txtSize
            // 
            this.txtSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSize.Location = new System.Drawing.Point(83, 53);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(432, 19);
            this.txtSize.TabIndex = 5;
            this.txtSize.Enter += new System.EventHandler(this.txtSize_Enter);
            // 
            // lblSize
            // 
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Location = new System.Drawing.Point(3, 50);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(74, 25);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "大きさ";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAge
            // 
            this.lblAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAge.Location = new System.Drawing.Point(3, 25);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(74, 25);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "年齢";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSex
            // 
            this.lblSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSex.Location = new System.Drawing.Point(3, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(74, 25);
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "性別";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSex
            // 
            this.cmbSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(83, 3);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(432, 20);
            this.cmbSex.TabIndex = 1;
            this.cmbSex.Enter += new System.EventHandler(this.cmbSex_Enter);
            // 
            // txtAge
            // 
            this.txtAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAge.Location = new System.Drawing.Point(83, 28);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(432, 19);
            this.txtAge.TabIndex = 3;
            this.txtAge.Enter += new System.EventHandler(this.txtAge_Enter);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(526, 356);
            this.Controls.Add(this.tabEdit);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEdit";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.tpName.ResumeLayout(false);
            this.tpName.PerformLayout();
            this.tpGame.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tpDescription.ResumeLayout(false);
            this.tpDescription.PerformLayout();
            this.tpGraphic.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGraphic)).EndInit();
            this.tpOther.ResumeLayout(false);
            this.tlpOther.ResumeLayout(false);
            this.tlpOther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtHint;
        private System.Windows.Forms.TabControl tabEdit;
        private System.Windows.Forms.TabPage tpName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tpGame;
        private System.Windows.Forms.TabPage tpDescription;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtGame;
        private System.Windows.Forms.ListBox lstGame;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TableLayoutPanel tlpOther;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TabPage tpGraphic;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvGraphic;
        private System.Windows.Forms.PictureBox picGraphic;


    }
}
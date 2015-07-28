namespace CharaBox3
{
    partial class FormFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFind));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHint = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkGame = new System.Windows.Forms.CheckBox();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.chkGraphics = new System.Windows.Forms.CheckBox();
            this.chkSex = new System.Windows.Forms.CheckBox();
            this.chkAgeMin = new System.Windows.Forms.CheckBox();
            this.chkAgeMax = new System.Windows.Forms.CheckBox();
            this.chkSizeMin = new System.Windows.Forms.CheckBox();
            this.chkSizeMax = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGame = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtGraphics = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.txtAgeMin = new System.Windows.Forms.TextBox();
            this.txtAgeMax = new System.Windows.Forms.TextBox();
            this.txtSizeMin = new System.Windows.Forms.TextBox();
            this.txtSizeMax = new System.Windows.Forms.TextBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.cmbGame = new System.Windows.Forms.ComboBox();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.cmbGraphics = new System.Windows.Forms.ComboBox();
            this.cmbSex2 = new System.Windows.Forms.ComboBox();
            this.cmbAgeMin = new System.Windows.Forms.ComboBox();
            this.cmbAgeMax = new System.Windows.Forms.ComboBox();
            this.cmbSizeMin = new System.Windows.Forms.ComboBox();
            this.cmbSizeMax = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtHint);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 38);
            this.panel1.TabIndex = 4;
            // 
            // txtHint
            // 
            this.txtHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHint.Location = new System.Drawing.Point(0, 0);
            this.txtHint.Multiline = true;
            this.txtHint.Name = "txtHint";
            this.txtHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHint.Size = new System.Drawing.Size(340, 38);
            this.txtHint.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(340, 0);
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
            this.btnCancel.Location = new System.Drawing.Point(417, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 38);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkGame, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkDescription, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkGraphics, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkSex, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkAgeMin, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkAgeMax, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkSizeMin, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkSizeMax, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGame, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGraphics, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbSex, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtAgeMin, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtAgeMax, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtSizeMin, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtSizeMax, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmbName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbGame, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbDescription, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbGraphics, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbSex2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbAgeMin, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbAgeMax, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbSizeMin, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbSizeMax, 2, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 281);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkName.Location = new System.Drawing.Point(3, 3);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(94, 20);
            this.chkName.TabIndex = 0;
            this.chkName.Text = "名前";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // chkGame
            // 
            this.chkGame.AutoSize = true;
            this.chkGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGame.Location = new System.Drawing.Point(3, 29);
            this.chkGame.Name = "chkGame";
            this.chkGame.Size = new System.Drawing.Size(94, 20);
            this.chkGame.TabIndex = 1;
            this.chkGame.Text = "登場作品";
            this.chkGame.UseVisualStyleBackColor = true;
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDescription.Location = new System.Drawing.Point(3, 55);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Size = new System.Drawing.Size(94, 20);
            this.chkDescription.TabIndex = 2;
            this.chkDescription.Text = "説明";
            this.chkDescription.UseVisualStyleBackColor = true;
            // 
            // chkGraphics
            // 
            this.chkGraphics.AutoSize = true;
            this.chkGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGraphics.Location = new System.Drawing.Point(3, 81);
            this.chkGraphics.Name = "chkGraphics";
            this.chkGraphics.Size = new System.Drawing.Size(94, 20);
            this.chkGraphics.TabIndex = 3;
            this.chkGraphics.Text = "画像";
            this.chkGraphics.UseVisualStyleBackColor = true;
            // 
            // chkSex
            // 
            this.chkSex.AutoSize = true;
            this.chkSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSex.Location = new System.Drawing.Point(3, 107);
            this.chkSex.Name = "chkSex";
            this.chkSex.Size = new System.Drawing.Size(94, 20);
            this.chkSex.TabIndex = 4;
            this.chkSex.Text = "性別";
            this.chkSex.UseVisualStyleBackColor = true;
            // 
            // chkAgeMin
            // 
            this.chkAgeMin.AutoSize = true;
            this.chkAgeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAgeMin.Location = new System.Drawing.Point(3, 133);
            this.chkAgeMin.Name = "chkAgeMin";
            this.chkAgeMin.Size = new System.Drawing.Size(94, 20);
            this.chkAgeMin.TabIndex = 5;
            this.chkAgeMin.Text = "年齢下限";
            this.chkAgeMin.UseVisualStyleBackColor = true;
            // 
            // chkAgeMax
            // 
            this.chkAgeMax.AutoSize = true;
            this.chkAgeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAgeMax.Location = new System.Drawing.Point(3, 159);
            this.chkAgeMax.Name = "chkAgeMax";
            this.chkAgeMax.Size = new System.Drawing.Size(94, 20);
            this.chkAgeMax.TabIndex = 6;
            this.chkAgeMax.Text = "年齢上限";
            this.chkAgeMax.UseVisualStyleBackColor = true;
            // 
            // chkSizeMin
            // 
            this.chkSizeMin.AutoSize = true;
            this.chkSizeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSizeMin.Location = new System.Drawing.Point(3, 185);
            this.chkSizeMin.Name = "chkSizeMin";
            this.chkSizeMin.Size = new System.Drawing.Size(94, 20);
            this.chkSizeMin.TabIndex = 7;
            this.chkSizeMin.Text = "大きさ下限";
            this.chkSizeMin.UseVisualStyleBackColor = true;
            // 
            // chkSizeMax
            // 
            this.chkSizeMax.AutoSize = true;
            this.chkSizeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSizeMax.Location = new System.Drawing.Point(3, 211);
            this.chkSizeMax.Name = "chkSizeMax";
            this.chkSizeMax.Size = new System.Drawing.Size(94, 20);
            this.chkSizeMax.TabIndex = 8;
            this.chkSizeMax.Text = "大きさ上限";
            this.chkSizeMax.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(103, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 19);
            this.txtName.TabIndex = 9;
            // 
            // txtGame
            // 
            this.txtGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGame.Location = new System.Drawing.Point(103, 29);
            this.txtGame.Name = "txtGame";
            this.txtGame.Size = new System.Drawing.Size(288, 19);
            this.txtGame.TabIndex = 10;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(103, 55);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(288, 19);
            this.txtDescription.TabIndex = 11;
            // 
            // txtGraphics
            // 
            this.txtGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGraphics.Location = new System.Drawing.Point(103, 81);
            this.txtGraphics.Name = "txtGraphics";
            this.txtGraphics.Size = new System.Drawing.Size(288, 19);
            this.txtGraphics.TabIndex = 12;
            // 
            // cmbSex
            // 
            this.cmbSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(103, 107);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(288, 20);
            this.cmbSex.TabIndex = 13;
            // 
            // txtAgeMin
            // 
            this.txtAgeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAgeMin.Location = new System.Drawing.Point(103, 133);
            this.txtAgeMin.Name = "txtAgeMin";
            this.txtAgeMin.Size = new System.Drawing.Size(288, 19);
            this.txtAgeMin.TabIndex = 14;
            // 
            // txtAgeMax
            // 
            this.txtAgeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAgeMax.Location = new System.Drawing.Point(103, 159);
            this.txtAgeMax.Name = "txtAgeMax";
            this.txtAgeMax.Size = new System.Drawing.Size(288, 19);
            this.txtAgeMax.TabIndex = 15;
            // 
            // txtSizeMin
            // 
            this.txtSizeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSizeMin.Location = new System.Drawing.Point(103, 185);
            this.txtSizeMin.Name = "txtSizeMin";
            this.txtSizeMin.Size = new System.Drawing.Size(288, 19);
            this.txtSizeMin.TabIndex = 16;
            // 
            // txtSizeMax
            // 
            this.txtSizeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSizeMax.Location = new System.Drawing.Point(103, 211);
            this.txtSizeMax.Name = "txtSizeMax";
            this.txtSizeMax.Size = new System.Drawing.Size(288, 19);
            this.txtSizeMax.TabIndex = 17;
            // 
            // cmbName
            // 
            this.cmbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Items.AddRange(new object[] {
            "に一致する",
            "を含む",
            "を含まない"});
            this.cmbName.Location = new System.Drawing.Point(397, 3);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(94, 20);
            this.cmbName.TabIndex = 18;
            // 
            // cmbGame
            // 
            this.cmbGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGame.FormattingEnabled = true;
            this.cmbGame.Items.AddRange(new object[] {
            "に一致する",
            "を含む",
            "を含まない"});
            this.cmbGame.Location = new System.Drawing.Point(397, 29);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(94, 20);
            this.cmbGame.TabIndex = 19;
            // 
            // cmbDescription
            // 
            this.cmbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Items.AddRange(new object[] {
            "に一致する",
            "を含む",
            "を含まない"});
            this.cmbDescription.Location = new System.Drawing.Point(397, 55);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(94, 20);
            this.cmbDescription.TabIndex = 20;
            // 
            // cmbGraphics
            // 
            this.cmbGraphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGraphics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraphics.FormattingEnabled = true;
            this.cmbGraphics.Items.AddRange(new object[] {
            "に一致する",
            "を含む",
            "を含まない"});
            this.cmbGraphics.Location = new System.Drawing.Point(397, 81);
            this.cmbGraphics.Name = "cmbGraphics";
            this.cmbGraphics.Size = new System.Drawing.Size(94, 20);
            this.cmbGraphics.TabIndex = 21;
            // 
            // cmbSex2
            // 
            this.cmbSex2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSex2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex2.FormattingEnabled = true;
            this.cmbSex2.Items.AddRange(new object[] {
            "に一致する",
            "に一致しない"});
            this.cmbSex2.Location = new System.Drawing.Point(397, 107);
            this.cmbSex2.Name = "cmbSex2";
            this.cmbSex2.Size = new System.Drawing.Size(94, 20);
            this.cmbSex2.TabIndex = 22;
            // 
            // cmbAgeMin
            // 
            this.cmbAgeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAgeMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeMin.FormattingEnabled = true;
            this.cmbAgeMin.Items.AddRange(new object[] {
            "以上",
            "より大きい"});
            this.cmbAgeMin.Location = new System.Drawing.Point(397, 133);
            this.cmbAgeMin.Name = "cmbAgeMin";
            this.cmbAgeMin.Size = new System.Drawing.Size(94, 20);
            this.cmbAgeMin.TabIndex = 23;
            // 
            // cmbAgeMax
            // 
            this.cmbAgeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAgeMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeMax.FormattingEnabled = true;
            this.cmbAgeMax.Items.AddRange(new object[] {
            "以下",
            "未満"});
            this.cmbAgeMax.Location = new System.Drawing.Point(397, 159);
            this.cmbAgeMax.Name = "cmbAgeMax";
            this.cmbAgeMax.Size = new System.Drawing.Size(94, 20);
            this.cmbAgeMax.TabIndex = 24;
            // 
            // cmbSizeMin
            // 
            this.cmbSizeMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSizeMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeMin.FormattingEnabled = true;
            this.cmbSizeMin.Items.AddRange(new object[] {
            "以上",
            "より大きい"});
            this.cmbSizeMin.Location = new System.Drawing.Point(397, 185);
            this.cmbSizeMin.Name = "cmbSizeMin";
            this.cmbSizeMin.Size = new System.Drawing.Size(94, 20);
            this.cmbSizeMin.TabIndex = 25;
            // 
            // cmbSizeMax
            // 
            this.cmbSizeMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSizeMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeMax.FormattingEnabled = true;
            this.cmbSizeMax.Items.AddRange(new object[] {
            "以下",
            "未満"});
            this.cmbSizeMax.Location = new System.Drawing.Point(397, 211);
            this.cmbSizeMax.Name = "cmbSizeMax";
            this.cmbSizeMax.Size = new System.Drawing.Size(94, 20);
            this.cmbSizeMax.TabIndex = 26;
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 319);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFind";
            this.Text = "FormFind";
            this.Load += new System.EventHandler(this.FormFind_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtHint;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.CheckBox chkGame;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.CheckBox chkGraphics;
        private System.Windows.Forms.CheckBox chkSex;
        private System.Windows.Forms.CheckBox chkAgeMin;
        private System.Windows.Forms.CheckBox chkAgeMax;
        private System.Windows.Forms.CheckBox chkSizeMin;
        private System.Windows.Forms.CheckBox chkSizeMax;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGame;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtGraphics;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox txtAgeMin;
        private System.Windows.Forms.TextBox txtAgeMax;
        private System.Windows.Forms.TextBox txtSizeMin;
        private System.Windows.Forms.TextBox txtSizeMax;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.ComboBox cmbGame;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.ComboBox cmbGraphics;
        private System.Windows.Forms.ComboBox cmbSex2;
        private System.Windows.Forms.ComboBox cmbAgeMin;
        private System.Windows.Forms.ComboBox cmbAgeMax;
        private System.Windows.Forms.ComboBox cmbSizeMin;
        private System.Windows.Forms.ComboBox cmbSizeMax;
    }
}
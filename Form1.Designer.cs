namespace BmpConverter {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnReadBmp = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkKeepRatio = new System.Windows.Forms.CheckBox();
            this.numWSize = new System.Windows.Forms.NumericUpDown();
            this.numHSize = new System.Windows.Forms.NumericUpDown();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.chkLargeEndian = new System.Windows.Forms.CheckBox();
            this.chkRevByte = new System.Windows.Forms.CheckBox();
            this.cmbPreset = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "画像ファイル";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(82, 10);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(252, 19);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.Text = "C:\\Users\\hisay\\Pictures\\work\\breakout.jpg";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(340, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(22, 19);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pnlImage
            // 
            this.pnlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImage.Controls.Add(this.picImage);
            this.pnlImage.Location = new System.Drawing.Point(15, 53);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(514, 294);
            this.pnlImage.TabIndex = 15;
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(514, 294);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // btnReadBmp
            // 
            this.btnReadBmp.Location = new System.Drawing.Point(385, 10);
            this.btnReadBmp.Name = "btnReadBmp";
            this.btnReadBmp.Size = new System.Drawing.Size(75, 23);
            this.btnReadBmp.TabIndex = 16;
            this.btnReadBmp.Text = "読み込み";
            this.btnReadBmp.UseVisualStyleBackColor = true;
            this.btnReadBmp.Click += new System.EventHandler(this.btnReadBmp_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(537, 350);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(218, 23);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "label2";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "変換後のサイズ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "X";
            // 
            // chkKeepRatio
            // 
            this.chkKeepRatio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkKeepRatio.AutoSize = true;
            this.chkKeepRatio.Location = new System.Drawing.Point(639, 78);
            this.chkKeepRatio.Name = "chkKeepRatio";
            this.chkKeepRatio.Size = new System.Drawing.Size(81, 16);
            this.chkKeepRatio.TabIndex = 22;
            this.chkKeepRatio.Text = "比率を維持";
            this.chkKeepRatio.UseVisualStyleBackColor = true;
            // 
            // numWSize
            // 
            this.numWSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numWSize.Location = new System.Drawing.Point(644, 53);
            this.numWSize.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numWSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWSize.Name = "numWSize";
            this.numWSize.Size = new System.Drawing.Size(41, 19);
            this.numWSize.TabIndex = 23;
            this.numWSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWSize.ValueChanged += new System.EventHandler(this.txtWSize_TextChanged);
            // 
            // numHSize
            // 
            this.numHSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numHSize.Location = new System.Drawing.Point(710, 53);
            this.numHSize.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numHSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHSize.Name = "numHSize";
            this.numHSize.Size = new System.Drawing.Size(41, 19);
            this.numHSize.TabIndex = 24;
            this.numHSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHSize.ValueChanged += new System.EventHandler(this.txtHSize_TextChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "bytemap: 24bit-3bytes",
            "bytemap: RGB555-2bytes",
            "bytemap: RGB565-2bytes",
            "bitmap : B/W"});
            this.cmbColor.Location = new System.Drawing.Point(570, 150);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(181, 20);
            this.cmbColor.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "色数";
            // 
            // cmbDirection
            // 
            this.cmbDirection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "左上→右下",
            "右上→左下",
            "左下→右上",
            "右下→左上"});
            this.cmbDirection.Location = new System.Drawing.Point(570, 218);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(181, 20);
            this.cmbDirection.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "方向";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(680, 324);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 29;
            this.btnConvert.Text = "変換";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "形式";
            // 
            // cmbStyle
            // 
            this.cmbStyle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Items.AddRange(new object[] {
            "ベタファイル",
            "Cソース(byte配列)",
            "Cソース(word配列)"});
            this.cmbStyle.Location = new System.Drawing.Point(570, 243);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(181, 20);
            this.cmbStyle.TabIndex = 30;
            // 
            // chkLargeEndian
            // 
            this.chkLargeEndian.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkLargeEndian.AutoSize = true;
            this.chkLargeEndian.Location = new System.Drawing.Point(639, 176);
            this.chkLargeEndian.Name = "chkLargeEndian";
            this.chkLargeEndian.Size = new System.Drawing.Size(105, 16);
            this.chkLargeEndian.TabIndex = 32;
            this.chkLargeEndian.Text = "ラージエンディアン";
            this.chkLargeEndian.UseVisualStyleBackColor = true;
            // 
            // chkRevByte
            // 
            this.chkRevByte.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkRevByte.AutoSize = true;
            this.chkRevByte.Location = new System.Drawing.Point(639, 196);
            this.chkRevByte.Name = "chkRevByte";
            this.chkRevByte.Size = new System.Drawing.Size(112, 16);
            this.chkRevByte.TabIndex = 33;
            this.chkRevByte.Text = "バイト順を逆にする";
            this.chkRevByte.UseVisualStyleBackColor = true;
            // 
            // cmbPreset
            // 
            this.cmbPreset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreset.FormattingEnabled = true;
            this.cmbPreset.Items.AddRange(new object[] {
            "None",
            "LCD_ShowPicture(Sipeed)",
            "LCD_WR_DATA8(Sipeed)",
            "LCD_WR_DATA(Sipeed)"});
            this.cmbPreset.Location = new System.Drawing.Point(570, 100);
            this.cmbPreset.Name = "cmbPreset";
            this.cmbPreset.Size = new System.Drawing.Size(181, 20);
            this.cmbPreset.TabIndex = 34;
            this.cmbPreset.SelectedIndexChanged += new System.EventHandler(this.cmbPreset_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(535, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 12);
            this.label7.TabIndex = 35;
            this.label7.Text = "セット";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 371);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPreset);
            this.Controls.Add(this.chkRevByte);
            this.Controls.Add(this.chkLargeEndian);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStyle);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.numHSize);
            this.Controls.Add(this.numWSize);
            this.Controls.Add(this.chkKeepRatio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnReadBmp);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "画像ベタファイル変換";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnReadBmp;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkKeepRatio;
        private System.Windows.Forms.NumericUpDown numWSize;
        private System.Windows.Forms.NumericUpDown numHSize;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.CheckBox chkLargeEndian;
        private System.Windows.Forms.CheckBox chkRevByte;
        private System.Windows.Forms.ComboBox cmbPreset;
        private System.Windows.Forms.Label label7;
    }
}


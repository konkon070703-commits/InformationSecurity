namespace AesEncryption
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblKeyStatus = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKeyHex = new System.Windows.Forms.TextBox();
            this.lblIV = new System.Windows.Forms.Label();
            this.txtIVHex = new System.Windows.Forms.TextBox();
            this.btnGenKey = new System.Windows.Forms.Button();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnLoadKey = new System.Windows.Forms.Button();
            this.lblInputText = new System.Windows.Forms.Label();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.btnEncryptText = new System.Windows.Forms.Button();
            this.lblOutputText = new System.Windows.Forms.Label();
            this.txtOutputText = new System.Windows.Forms.TextBox();

            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.txtStep1Info = new System.Windows.Forms.TextBox();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.txtStep2Info = new System.Windows.Forms.TextBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.txtStep3Info = new System.Windows.Forms.TextBox();

            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();

            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 540);

            this.tabPage1.Controls.Add(this.lblKeyStatus);
            this.tabPage1.Controls.Add(this.lblKey);
            this.tabPage1.Controls.Add(this.txtKeyHex);
            this.tabPage1.Controls.Add(this.lblIV);
            this.tabPage1.Controls.Add(this.txtIVHex);
            this.tabPage1.Controls.Add(this.btnGenKey);
            this.tabPage1.Controls.Add(this.btnSaveKey);
            this.tabPage1.Controls.Add(this.btnLoadKey);
            this.tabPage1.Controls.Add(this.lblInputText);
            this.tabPage1.Controls.Add(this.txtInputText);
            this.tabPage1.Controls.Add(this.btnEncryptText);
            this.tabPage1.Controls.Add(this.lblOutputText);
            this.tabPage1.Controls.Add(this.txtOutputText);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(732, 511);
            this.tabPage1.Text = "1. Quan ly Khoa & Van ban";
            this.tabPage1.UseVisualStyleBackColor = true;

            this.lblKeyStatus.AutoSize = true;
            this.lblKeyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblKeyStatus.Location = new System.Drawing.Point(20, 15);
            this.lblKeyStatus.Size = new System.Drawing.Size(221, 18);
            this.lblKeyStatus.Text = "Trang thai: CHUA CO KHOA";

            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(20, 45);
            this.lblKey.Size = new System.Drawing.Size(142, 16);
            this.lblKey.Text = "AES Key (256-bit Hex):";

            this.txtKeyHex.Location = new System.Drawing.Point(20, 65);
            this.txtKeyHex.ReadOnly = true;
            this.txtKeyHex.Size = new System.Drawing.Size(690, 22);

            this.lblIV.AutoSize = true;
            this.lblIV.Location = new System.Drawing.Point(20, 95);
            this.lblIV.Size = new System.Drawing.Size(130, 16);
            this.lblIV.Text = "AES IV (128-bit Hex):";

            this.txtIVHex.Location = new System.Drawing.Point(20, 115);
            this.txtIVHex.ReadOnly = true;
            this.txtIVHex.Size = new System.Drawing.Size(690, 22);

            this.btnGenKey.Location = new System.Drawing.Point(20, 150);
            this.btnGenKey.Size = new System.Drawing.Size(210, 40);
            this.btnGenKey.Text = "1. Sinh khoa AES";
            this.btnGenKey.UseVisualStyleBackColor = true;
            this.btnGenKey.Click += new System.EventHandler(this.btnGenKey_Click);

            this.btnSaveKey.Location = new System.Drawing.Point(260, 150);
            this.btnSaveKey.Size = new System.Drawing.Size(210, 40);
            this.btnSaveKey.Text = "2. Luu khoa ra file";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);

            this.btnLoadKey.Location = new System.Drawing.Point(500, 150);
            this.btnLoadKey.Size = new System.Drawing.Size(210, 40);
            this.btnLoadKey.Text = "3. Import khoa tu file";
            this.btnLoadKey.UseVisualStyleBackColor = true;
            this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);

            this.lblInputText.AutoSize = true;
            this.lblInputText.Location = new System.Drawing.Point(20, 210);
            this.lblInputText.Size = new System.Drawing.Size(102, 16);
            this.lblInputText.Text = "Van ban nguon:";

            this.txtInputText.Location = new System.Drawing.Point(20, 230);
            this.txtInputText.Multiline = true;
            this.txtInputText.Size = new System.Drawing.Size(690, 50);
            this.txtInputText.Text = "Van ban mau. Sua tuy y";

            this.btnEncryptText.Location = new System.Drawing.Point(20, 290);
            this.btnEncryptText.Size = new System.Drawing.Size(690, 35);
            this.btnEncryptText.Text = "4. Ma hoa van ban -> Xuat ket qua";
            this.btnEncryptText.UseVisualStyleBackColor = true;
            this.btnEncryptText.Click += new System.EventHandler(this.btnEncryptText_Click);

            this.lblOutputText.AutoSize = true;
            this.lblOutputText.Location = new System.Drawing.Point(20, 335);
            this.lblOutputText.Size = new System.Drawing.Size(155, 16);
            this.lblOutputText.Text = "Ket qua ma hoa (Base64):";

            this.txtOutputText.Location = new System.Drawing.Point(20, 355);
            this.txtOutputText.Multiline = true;
            this.txtOutputText.ReadOnly = true;
            this.txtOutputText.Size = new System.Drawing.Size(690, 60);

            this.tabPage2.Controls.Add(this.btnEncryptFile);
            this.tabPage2.Controls.Add(this.lblStep1);
            this.tabPage2.Controls.Add(this.txtStep1Info);
            this.tabPage2.Controls.Add(this.lblStep2);
            this.tabPage2.Controls.Add(this.txtStep2Info);
            this.tabPage2.Controls.Add(this.lblStep3);
            this.tabPage2.Controls.Add(this.txtStep3Info);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(732, 511);
            this.tabPage2.Text = "2. Xu ly File lon (>1GB)";
            this.tabPage2.UseVisualStyleBackColor = true;

            this.btnEncryptFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEncryptFile.Location = new System.Drawing.Point(20, 15);
            this.btnEncryptFile.Size = new System.Drawing.Size(690, 45);
            this.btnEncryptFile.Text = "Chon File trong Downloads de Ma hoa / Giai ma";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);

            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStep1.Location = new System.Drawing.Point(20, 70);
            this.lblStep1.Text = "Buoc 1: Thong tin File Nguon";

            this.txtStep1Info.Location = new System.Drawing.Point(20, 90);
            this.txtStep1Info.Multiline = true;
            this.txtStep1Info.ReadOnly = true;
            this.txtStep1Info.Size = new System.Drawing.Size(690, 50);
            this.txtStep1Info.Text = "Chua chon file nguon...";

            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStep2.Location = new System.Drawing.Point(20, 150);
            this.lblStep2.Text = "Buoc 2: Trang thai Dong chay Pipeline (Encryption / Decryption Stream)";

            this.txtStep2Info.Location = new System.Drawing.Point(20, 170);
            this.txtStep2Info.Multiline = true;
            this.txtStep2Info.ReadOnly = true;
            this.txtStep2Info.Size = new System.Drawing.Size(690, 60);
            this.txtStep2Info.Text = "He thong san sang xu ly file qua CryptoStream...";

            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStep3.Location = new System.Drawing.Point(20, 240);
            this.lblStep3.Text = "Buoc 3: So lieu Do luong Thoi gian & Kiem tra Toan ven Bytes";

            this.txtStep3Info.Location = new System.Drawing.Point(20, 260);
            this.txtStep3Info.Multiline = true;
            this.txtStep3Info.ReadOnly = true;
            this.txtStep3Info.Size = new System.Drawing.Size(690, 190);
            this.txtStep3Info.Text = "Ket qua thuc nghiem se hien thi tai day sau khi chay Pipeline...";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 540);
            this.Controls.Add(this.tabControl1);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AesEncryption";

            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblKeyStatus;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKeyHex;
        private System.Windows.Forms.Label lblIV;
        private System.Windows.Forms.TextBox txtIVHex;
        private System.Windows.Forms.Button btnGenKey;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Button btnLoadKey;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.Button btnEncryptText;
        private System.Windows.Forms.Label lblOutputText;
        private System.Windows.Forms.TextBox txtOutputText;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.TextBox txtStep1Info;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.TextBox txtStep2Info;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.TextBox txtStep3Info;
    }
}
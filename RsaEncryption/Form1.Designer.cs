namespace RsaEncryption
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImportPem = new System.Windows.Forms.Button();
            this.btnExportPem = new System.Windows.Forms.Button();
            this.btnGenerateRsa = new System.Windows.Forms.Button();
            this.txtPrivateKeyPem = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublicKeyPem = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSignPss = new System.Windows.Forms.Button();
            this.txtHashOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHashInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImportPem);
            this.tabPage1.Controls.Add(this.btnExportPem);
            this.tabPage1.Controls.Add(this.btnGenerateRsa);
            this.tabPage1.Controls.Add(this.txtPrivateKeyPem);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtPublicKeyPem);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(892, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Quan ly Khoa, PEM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImportPem
            // 
            this.btnImportPem.Location = new System.Drawing.Point(348, 20);
            this.btnImportPem.Name = "btnImportPem";
            this.btnImportPem.Size = new System.Drawing.Size(150, 35);
            this.btnImportPem.TabIndex = 6;
            this.btnImportPem.Text = "4. Nhap file PEM";
            this.btnImportPem.UseVisualStyleBackColor = true;
            // 
            // btnExportPem
            // 
            this.btnExportPem.Location = new System.Drawing.Point(180, 20);
            this.btnExportPem.Name = "btnExportPem";
            this.btnExportPem.Size = new System.Drawing.Size(150, 35);
            this.btnExportPem.TabIndex = 5;
            this.btnExportPem.Text = "2. Xuat khoa ra file PEM";
            this.btnExportPem.UseVisualStyleBackColor = true;
            // 
            // btnGenerateRsa
            // 
            this.btnGenerateRsa.Location = new System.Drawing.Point(12, 20);
            this.btnGenerateRsa.Name = "btnGenerateRsa";
            this.btnGenerateRsa.Size = new System.Drawing.Size(150, 35);
            this.btnGenerateRsa.TabIndex = 4;
            this.btnGenerateRsa.Text = "1. Sinh cap khoa RSA";
            this.btnGenerateRsa.UseVisualStyleBackColor = true;
            // 
            // txtPrivateKeyPem
            // 
            this.txtPrivateKeyPem.Location = new System.Drawing.Point(450, 95);
            this.txtPrivateKeyPem.Name = "txtPrivateKeyPem";
            this.txtPrivateKeyPem.Size = new System.Drawing.Size(420, 410);
            this.txtPrivateKeyPem.TabIndex = 3;
            this.txtPrivateKeyPem.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Private Key (PEM):";
            // 
            // txtPublicKeyPem
            // 
            this.txtPublicKeyPem.Location = new System.Drawing.Point(12, 95);
            this.txtPublicKeyPem.Name = "txtPublicKeyPem";
            this.txtPublicKeyPem.Size = new System.Drawing.Size(420, 410);
            this.txtPublicKeyPem.TabIndex = 1;
            this.txtPublicKeyPem.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Public Key (PEM):";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBenchmark);
            this.tabPage2.Controls.Add(this.btnDecrypt);
            this.tabPage2.Controls.Add(this.btnEncrypt);
            this.tabPage2.Controls.Add(this.txtOutput);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtInput);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(892, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Ma hoa, Benchmark";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBenchmark
            // 
            this.btnBenchmark.Location = new System.Drawing.Point(340, 260);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(200, 40);
            this.btnBenchmark.TabIndex = 6;
            this.btnBenchmark.Text = "7. Danh gia toc do (Benchmark)";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(180, 260);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(140, 40);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "6. Giai ma du lieu";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(20, 260);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(140, 40);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "5. Ma hoa du lieu";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 336);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(850, 160);
            this.txtOutput.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ket qua / Log thao tac:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(20, 40);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(850, 190);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Nhap du lieu van ban can ma hoa (< 190 bytes)...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Du lieu dau vao:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSignPss);
            this.tabPage3.Controls.Add(this.txtHashOutput);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtHashInput);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(892, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. SHA-256, Chu ky so PSS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSignPss
            // 
            this.btnSignPss.Location = new System.Drawing.Point(20, 240);
            this.btnSignPss.Name = "btnSignPss";
            this.btnSignPss.Size = new System.Drawing.Size(220, 40);
            this.btnSignPss.TabIndex = 4;
            this.btnSignPss.Text = "9. Ky so RSA-PSS (Dam bao doi moi)";
            this.btnSignPss.UseVisualStyleBackColor = true;
            // 
            // txtHashOutput
            // 
            this.txtHashOutput.Location = new System.Drawing.Point(20, 320);
            this.txtHashOutput.Multiline = true;
            this.txtHashOutput.Name = "txtHashOutput";
            this.txtHashOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHashOutput.Size = new System.Drawing.Size(850, 170);
            this.txtHashOutput.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ma bam SHA-256, Chu ky:";
            // 
            // txtHashInput
            // 
            this.txtHashInput.Location = new System.Drawing.Point(20, 40);
            this.txtHashInput.Multiline = true;
            this.txtHashInput.Name = "txtHashInput";
            this.txtHashInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHashInput.Size = new System.Drawing.Size(850, 180);
            this.txtHashInput.TabIndex = 1;
            this.txtHashInput.Text = "Nhap du lieu kiem tra hieu ung tuyet lo (Avalanche Effect)...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Du lieu dau vao (SHA-256):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "RSA Security";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnImportPem;
        private System.Windows.Forms.Button btnExportPem;
        private System.Windows.Forms.Button btnGenerateRsa;
        private System.Windows.Forms.RichTextBox txtPrivateKeyPem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtPublicKeyPem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSignPss;
        private System.Windows.Forms.TextBox txtHashOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHashInput;
        private System.Windows.Forms.Label label5;
    }
}
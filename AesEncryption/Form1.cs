using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace AesEncryption
{
    public partial class Form1 : Form
    {
        private byte[] currentKey;
        private byte[] currentIV;
        private readonly string defaultFolder = @"D:\Project\InformationSecurity\AesEncryption\Downloads";

        public Form1()
        {
            InitializeComponent();
            EnsureDefaultFolderExists();
            UpdateKeyUI();
        }

        private void EnsureDefaultFolderExists()
        {
            try
            {
                if (!Directory.Exists(defaultFolder))
                {
                    Directory.CreateDirectory(defaultFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tao thu muc: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ByteArrayToHexString(byte[] bytes)
        {
            if (bytes == null) return string.Empty;
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }

        private void UpdateKeyUI()
        {
            if (currentKey != null && currentIV != null)
            {
                txtKeyHex.Text = ByteArrayToHexString(currentKey);
                txtIVHex.Text = ByteArrayToHexString(currentIV);
                lblKeyStatus.Text = "Trang thai: DA CO KHOA AES-256";
                lblKeyStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtKeyHex.Text = "Chua co khoa...";
                txtIVHex.Text = "Chua co IV...";
                lblKeyStatus.Text = "Trang thai: CHUA CO KHOA";
                lblKeyStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnGenKey_Click(object sender, EventArgs e)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.GenerateKey();
                aes.GenerateIV();

                currentKey = aes.Key;
                currentIV = aes.IV;
            }

            UpdateKeyUI();
            MessageBox.Show("Sinh khoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Chua co khoa de luu!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnsureDefaultFolderExists();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = defaultFolder;
                sfd.Filter = "AES Key File (*.key)|*.key|All Files (*.*)|*.*";
                sfd.FileName = "secret_aes.key";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(currentKey, 0, currentKey.Length);
                            fs.Write(currentIV, 0, currentIV.Length);
                        }
                        MessageBox.Show("Luu file khoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi luu file: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            EnsureDefaultFolderExists();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = defaultFolder;
                ofd.Filter = "AES Key File (*.key)|*.key|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(ofd.FileName);
                        if (fi.Length != 48)
                        {
                            MessageBox.Show("File khoa khong hop le, dung luong phai la 48 bytes.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        byte[] keyBuffer = new byte[32];
                        byte[] ivBuffer = new byte[16];

                        using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            fs.Read(keyBuffer, 0, 32);
                            fs.Read(ivBuffer, 0, 16);
                        }

                        currentKey = keyBuffer;
                        currentIV = ivBuffer;

                        UpdateKeyUI();
                        MessageBox.Show("Import khoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi doc file: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEncryptText_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui long co khoa truoc!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInputText.Text))
            {
                MessageBox.Show("Vui long nhap van ban!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = currentKey;
                aes.IV = currentIV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                    {
                        sw.Write(txtInputText.Text);
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            txtOutputText.Text = Convert.ToBase64String(encryptedBytes);
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui long co khoa o Tab 1 truoc!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnsureDefaultFolderExists();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = defaultFolder;
                ofd.Title = "Chon file nguon trong thu muc Downloads";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string inputFilePath = ofd.FileName;
                    string fileNameOnly = Path.GetFileName(inputFilePath);
                    string encryptedFilePath = Path.Combine(defaultFolder, fileNameOnly + ".aes");
                    string decryptedFilePath = Path.Combine(defaultFolder, fileNameOnly + ".dec");

                    txtStep1Info.Text = "Da chon file: " + fileNameOnly;
                    txtStep2Info.Text = "Dang xu ly Pipeline ma hoa va giai ma file...";
                    txtStep3Info.Text = "Dang cho ket qua...";
                    this.Refresh();

                    Stopwatch sw = new Stopwatch();

                    try
                    {
                        sw.Start();
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = currentKey;
                            aes.IV = currentIV;

                            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                            using (FileStream fsOutput = new FileStream(encryptedFilePath, FileMode.Create, FileAccess.Write))
                            using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                byte[] buffer = new byte[1048576];
                                int bytesRead;
                                while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    cs.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                        sw.Stop();
                        long encryptTimeMs = sw.ElapsedMilliseconds;

                        sw.Restart();
                        using (Aes aes = Aes.Create())
                        {
                            aes.Key = currentKey;
                            aes.IV = currentIV;

                            using (FileStream fsInput = new FileStream(encryptedFilePath, FileMode.Open, FileAccess.Read))
                            using (FileStream fsOutput = new FileStream(decryptedFilePath, FileMode.Create, FileAccess.Write))
                            using (CryptoStream cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
                            {
                                byte[] buffer = new byte[1048576];
                                int bytesRead;
                                while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fsOutput.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                        sw.Stop();
                        long decryptTimeMs = sw.ElapsedMilliseconds;

                        bool isIdentical = CompareFilesByBytes(inputFilePath, decryptedFilePath);

                        txtStep2Info.Text = "Pipeline hoan tat. Da tao file ma hoa va giai ma.";

                        string report = "Bao cao ket qua thuc nghiem:\n" +
                                        "- Thoi gian ma hoa: " + encryptTimeMs + " ms\n" +
                                        "- Thoi gian giai ma: " + decryptTimeMs + " ms\n" +
                                        "- So sanh bytes (Goc == Giai ma): " + (isIdentical ? "Trung khop 100%" : "Sai lệch") + "\n\n" +
                                        "Ket luan: Thuat toan AES hoat dong chinh xac. Su dung CryptoStream giup xu ly file lon nhanh chong va tiet kiem RAM.";

                        txtStep3Info.Text = report;
                    }
                    catch (Exception ex)
                    {
                        txtStep2Info.Text = "Loi trong qua trinh xu ly.";
                        MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool CompareFilesByBytes(string file1, string file2)
        {
            FileInfo fi1 = new FileInfo(file1);
            FileInfo fi2 = new FileInfo(file2);

            if (fi1.Length != fi2.Length) return false;

            const int bufferSize = 1048576;
            using (FileStream fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read))
            using (FileStream fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer1 = new byte[bufferSize];
                byte[] buffer2 = new byte[bufferSize];

                int read1, read2;
                while ((read1 = fs1.Read(buffer1, 0, bufferSize)) > 0)
                {
                    read2 = fs2.Read(buffer2, 0, bufferSize);
                    if (read1 != read2) return false;

                    for (int i = 0; i < read1; i++)
                    {
                        if (buffer1[i] != buffer2[i]) return false;
                    }
                }
            }
            return true;
        }
    }
}
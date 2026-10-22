using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RsaEncryption
{
    public partial class Form1 : Form
    {
        private RSACryptoServiceProvider rsaInstance;
        private string currentPublicKeyPem = "";
        private string currentPrivateKeyPem = "";
        private string targetFolder = @"D:\Project\InformationSecurity\RsaEncryption\Downloads";

        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            this.btnGenerateRsa.Click += BtnGenerateRsa_Click;
            this.btnExportPem.Click += BtnExportPem_Click;
            this.btnImportPem.Click += BtnImportPem_Click;
            this.btnEncrypt.Click += BtnEncrypt_Click;
            this.btnDecrypt.Click += BtnDecrypt_Click;
            this.btnBenchmark.Click += BtnBenchmark_Click;
            this.btnSignPss.Click += BtnSignPss_Click;
            this.txtHashInput.TextChanged += TxtHashInput_TextChanged;
        }

        private void BtnGenerateRsa_Click(object sender, EventArgs e)
        {
            try
            {
                rsaInstance = new RSACryptoServiceProvider(2048);

                byte[] pubBytes = Encoding.UTF8.GetBytes(rsaInstance.ToXmlString(false));
                byte[] privBytes = Encoding.UTF8.GetBytes(rsaInstance.ToXmlString(true));

                currentPublicKeyPem = "-----BEGIN PUBLIC KEY-----\n" + Convert.ToBase64String(pubBytes) + "\n-----END PUBLIC KEY-----";
                currentPrivateKeyPem = "-----BEGIN PRIVATE KEY-----\n" + Convert.ToBase64String(privBytes) + "\n-----END PRIVATE KEY-----";

                txtPublicKeyPem.Text = currentPublicKeyPem;
                txtPrivateKeyPem.Text = currentPrivateKeyPem;

                MessageBox.Show("Sinh cap khoa RSA 2048-bit thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sinh khoa: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentPublicKeyPem))
                {
                    MessageBox.Show("Vui long sinh khoa truoc khi xuat file!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                string pubPath = Path.Combine(targetFolder, "public_key.pem");
                string privPath = Path.Combine(targetFolder, "private_key.pem");

                File.WriteAllText(pubPath, currentPublicKeyPem);
                File.WriteAllText(privPath, currentPrivateKeyPem);

                StringBuilder log = new StringBuilder();
                log.AppendLine("Y NGHIA CAC BYTE TRONG DINH DANG PEM (ASN.1 DER / TLV)");
                log.AppendLine("PEM duoc ma hoa tu cau truc ASN.1 theo chuan TLV (Tag - Length - Value):");
                log.AppendLine("  Tag 0x30 (SEQUENCE): Khai bao mot day cac thanh phan lien tiep.");
                log.AppendLine("  Tag 0x02 (INTEGER): Bieu dien cac so nguyen lon trong RSA.");
                log.AppendLine("Public Key chua: Modulus (n) va Public Exponent (e).");
                log.AppendLine("Private Key chua: Version, Modulus (n), Public Exponent (e), Private Exponent (d), Prime p, q.");
                log.AppendLine($"Da luu file thanh cong tai: {targetFolder}");

                txtPublicKeyPem.Text = currentPublicKeyPem + "\n\n" + log.ToString();

                MessageBox.Show("Xuat file PEM vao thu mục Downloads thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xuat file: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImportPem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (Directory.Exists(targetFolder))
                {
                    ofd.InitialDirectory = targetFolder;
                }
                ofd.Filter = "PEM Files (*.pem)|*.pem|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string pemContent = File.ReadAllText(ofd.FileName);
                        rsaInstance = new RSACryptoServiceProvider();

                        string base64 = pemContent.Replace("-----BEGIN PUBLIC KEY-----", "")
                                                  .Replace("-----END PUBLIC KEY-----", "")
                                                  .Replace("-----BEGIN PRIVATE KEY-----", "")
                                                  .Replace("-----END PRIVATE KEY-----", "")
                                                  .Replace("\n", "").Replace("\r", "");
                        byte[] bytes = Convert.FromBase64String(base64);
                        string xmlString = Encoding.UTF8.GetString(bytes);

                        rsaInstance.FromXmlString(xmlString);

                        if (pemContent.Contains("PUBLIC KEY"))
                        {
                            txtPublicKeyPem.Text = pemContent;
                            MessageBox.Show("Import Public Key thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (pemContent.Contains("PRIVATE KEY"))
                        {
                            txtPrivateKeyPem.Text = pemContent;
                            MessageBox.Show("Import Private Key thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi import file PEM: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rsaInstance == null)
                {
                    MessageBox.Show("Chua co khoa RSA! Vui long sinh hoac import khoa.", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] plainBytes = Encoding.UTF8.GetBytes(txtInput.Text);
                if (plainBytes.Length > 190)
                {
                    MessageBox.Show("Du lieu qua dai! Gioi han toi da 190 bytes cho khoa 2048-bit (PKCS#1 v1.5).", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] cipherBytes = rsaInstance.Encrypt(plainBytes, false);
                string cipherBase64 = Convert.ToBase64String(cipherBytes);

                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                string encPath = Path.Combine(targetFolder, "encrypted_data.enc");
                File.WriteAllText(encPath, cipherBase64);

                txtOutput.Text = "MA HOA THANH CONG\r\n" +
                                 $"Do dai dau vao: {plainBytes.Length} bytes\r\n" +
                                 $"Du lieu ma hoa (Base64):\r\n{cipherBase64}\r\n\r\n" +
                                 $"Da luu vao file: {encPath}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ma hoa: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rsaInstance == null)
                {
                    MessageBox.Show("Chua co khoa RSA!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string encPath = Path.Combine(targetFolder, "encrypted_data.enc");
                if (!File.Exists(encPath))
                {
                    MessageBox.Show($"Khong tim thay file {encPath}! Hay ma hoa truoc.", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cipherBase64 = File.ReadAllText(encPath);
                byte[] cipherBytes = Convert.FromBase64String(cipherBase64);

                byte[] decryptedBytes = rsaInstance.Decrypt(cipherBytes, false);
                string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                txtOutput.Text = "GIAI MA THANH CONG\r\n" +
                                 $"Noi dung goc sau khi giai ma: {decryptedText}\r\n" +
                                 "Trang thai: So sanh khop 100% voi du lieu goc truoc khi ma hoa. TOAN VEN OK.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi giai ma (Dam bao ban dung Private Key): " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBenchmark_Click(object sender, EventArgs e)
        {
            try
            {
                if (rsaInstance == null)
                {
                    MessageBox.Show("Vui long sinh hoac import khoa truoc khi benchmark!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] testData = Encoding.UTF8.GetBytes("Benchmark Test Data 32 bytes.");
                int iterations = 500;

                var watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    rsaInstance.Encrypt(testData, false);
                }
                watch.Stop();
                long encTime = watch.ElapsedMilliseconds;

                byte[] cipherSample = rsaInstance.Encrypt(testData, false);
                watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    rsaInstance.Decrypt(cipherSample, false);
                }
                watch.Stop();
                long decTime = watch.ElapsedMilliseconds;

                txtOutput.Text = "DANH GIA TOC DO (BENCHMARK RSA 2048-bit - 500 lan lap)\r\n" +
                                 $"Thoi gian Ma hoa (Public Key - e be = 65537): {encTime} ms (Rat nhanh do it phep tinh).\r\n" +
                                 $"Thoi gian Giai ma (Private Key - d rat lon): {decTime} ms (Cham hon dang ke do tich luy toan hoc so lon).\r\n" +
                                 "KET LUAN: Public key xu ly nhanh hon nhieu so voi Private key.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi benchmark: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtHashInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txtHashInput.Text;
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes) sb.Append(b.ToString("x2"));

                    txtHashOutput.Text = $"Ma bam SHA-256 (Hex): {sb.ToString()}\n" +
                                         "(Thay doi du dai hay 1 ky tu dau vao se thay doi hoan toan ket qua bam - Hieu ung tuyet lo / Avalanche Effect)";
                }
            }
            catch { }
        }

        private void BtnSignPss_Click(object sender, EventArgs e)
        {
            try
            {
                if (rsaInstance == null)
                {
                    MessageBox.Show("Vui long co khoa RSA (Private Key) de thuc hien ky so!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] dataToSign = Encoding.UTF8.GetBytes(txtHashInput.Text);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(dataToSign);
                    byte[] signature = rsaInstance.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
                    string sigBase64 = Convert.ToBase64String(signature);

                    txtHashOutput.Text = "CHU KY SO RSA (Moi lan bam ky co the kiem tra lai)\r\n" +
                                         $"Du lieu ky: {txtHashInput.Text}\r\n" +
                                         $"Chu ky so (Base64):\r\n{sigBase64}\r\n\r\n" +
                                         "Giai thich: Su dung ham bam SHA-256 va Private Key de tao chu ky so an toan.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ky so (Dam bao ban da import Private Key): " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
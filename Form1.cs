﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BmpConverter {

    public partial class Form1 : Form {
        Image im;
        double aspectRatio;
        String strFilename;

        int spColR;
        int spColG;
        int spColB;
        int spColor;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPreset.SelectedIndex = 1;
 

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                strFilename = openFileDialog1.FileName;
                txtFilename.Text = strFilename;
            }
            btnReadBmp_Click(sender, e);
        }

        static int MSG_BMPSIZENOTVALID = 0;
        static int MSG_BMPNOTSUPPORTED = 1;
        static int MSG_FILENOTFOUND = 2;
        static int MSG_NOTLOADDED = 3;
        static int MSG_NONENOTSUPPORTED = 4;
        static string[] strErrorMsg = { "サイズが12800の倍数になっていません。\r\nLCD_ShowPictureを使う場合、引数の矩形にかかわらず一回の関数呼び出しでは\r\n必ず12800バイト転送されます。\r\n現在のサイズは12800の倍数になっていないため、LCD＿ShowPicture関数は正しく動作しません\r\n\r\n本当に実行しますか？" ,
                                        "ファイルのイメージ形式が無効、もしくはGDI+ファイルのピクセル形式はサポートされていません",
                                        "ファイルがみつかりません",
                                        "画像が読み込まれていません\r\n読み込みボタンをクリックして画像を読み込んでから操作してください",
                                        "プリセットにNoneは指定できません。"};

        private void btnReadBmp_Click(object sender, EventArgs e)
        {
            strFilename = txtFilename.Text;
            
            try {
                im = Image.FromFile(strFilename);
            } catch (OutOfMemoryException ex) {
                MessageBox.Show(this,strErrorMsg[MSG_BMPNOTSUPPORTED], "エラー");
                return;
            } catch (FileNotFoundException ex) {
                MessageBox.Show(this, strErrorMsg[MSG_FILENOTFOUND], "エラー");
                return;
            } catch (Exception ex) {
                MessageBox.Show(this, "その他のエラー（"+ex.Message + ")\r\n" + ex.StackTrace, "エラー");
                return;
            }
            picImage.Image = im;
            String txtInfo = im.Width.ToString() + "X" + im.Height.ToString() + " " + Image.GetPixelFormatSize(im.PixelFormat).ToString()+"bit";
            lblInfo.Text = txtInfo;
            aspectRatio  = (double)picImage.Image.Width / (double)picImage.Image.Height;
            numWSize.Value = im.Width;
            numHSize.Value = im.Height;
            


        }

        private void txtHSize_TextChanged(object sender, EventArgs e)
        {
            if (chkKeepRatio.Checked) {
                if (sender == numHSize) {
                    if (((NumericUpDown)sender).Focused) {
                        double dh = (double)numHSize.Value * aspectRatio;
                        if ((int)dh > numWSize.Minimum) {
                            numWSize.Value = (int)dh;
                        }
                    }
                }
            }
        }

        private void txtWSize_TextChanged(object sender, EventArgs e)
        {
            if (chkKeepRatio.Checked) {
                if (sender == numWSize) {
                    if (((NumericUpDown)sender).Focused) {
                        double dh = (double)numWSize.Value / aspectRatio;
                        if ((int)dh > numHSize.Minimum) {
                            numHSize.Value = (int)dh;
                        }
                    }
                }
            }
        }

        //５ビットのビット反転
        private byte swapbit5(byte xb, int byteLen)
        {
            byte ans=0;
            int x = xb;

            for (int i = 0; i < byteLen; i++) {
                ans = (byte)(ans << 1);
                ans = (byte)(ans | (xb & (byte)1));
                xb = (byte)(xb >> 1);
            }
            return ans;
        }

        private byte[] GetColor(Color c,  int bitCnt)
        {
            if (bitCnt == 24) {
                byte[] ans = new byte[3];
                ans[0] = c.R;
                ans[1] = c.G;
                ans[2] = c.B;
                return ans;
            } else if (bitCnt == 15) {
                byte[] ans = new byte[2];
                byte revR=0;
                byte revB=0;
                byte revG=0;



                Int16 col;
                if (c.R == spColR && c.G == spColG && c.B == spColB) {
                    ans[0] = (byte)(spColor >> 8);
                    ans[1] = (byte)(spColor & 0xFF);
                } else {
                    if (chkLargeEndian.Checked) {
                        if (cmbColor.SelectedIndex == 2) { // RGB565
                            revR = (byte)(c.R >> 3);
                            revG = (byte)(c.G >> 2);
                            revB = (byte)(c.B >> 3);
                            revR = swapbit5(revR, 5);
                            revG = swapbit5(revG, 6);
                            revB = swapbit5(revB, 5);
                        } else if (cmbColor.SelectedIndex == 1) {   //RGB555
                            revR = (byte)(c.R >> 3);
                            revB = (byte)(c.B >> 3);
                            revG = (byte)(c.G >> 3);
                            revR = swapbit5(revR, 5);
                            revG = swapbit5(revG, 5);
                            revB = swapbit5(revB, 5);
                        }
                    } else {
                        if (cmbColor.SelectedIndex == 2) { // RGB565
                            revR = (byte)(c.R >> 3);
                            revG = (byte)(c.G >> 2);
                            revB = (byte)(c.B >> 3);
                        } else if (cmbColor.SelectedIndex == 1) {   //RGB555
                            revR = (byte)(c.R >> 3);
                            revB = (byte)(c.B >> 3);
                            revG = (byte)(c.G >> 3);

                        }
                    }
                    if (cmbColor.SelectedIndex == 2) { // RGB565
                        col = (Int16)(revR << 11);
                        col |= (Int16)(revG << 5);
                        col |= (Int16)(revB);
                    } else {
                        col = (Int16)(revR << 10);
                        col |= (Int16)(revG << 5);
                        col |= (Int16)(revB);
                    }



                    if (chkRevByte.Checked) {
                        ans[1] = (byte)(col >> 8);
                        ans[0] = (byte)(col & 0xFF);
                    } else {
                        ans[0] = (byte)(col >> 8);
                        ans[1] = (byte)(col & 0xFF);
                    }
                }
                return ans;
            } else {
                return null;
            }
            
        }


        private void btnConvert_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap;
            if (im == null) {
                MessageBox.Show(this, strErrorMsg[MSG_NOTLOADDED], "エラー");
                return;
            }
            spColR = int.Parse(txtSPColorR.Text);
            spColG = int.Parse(txtSPColorG.Text);
            spColB = int.Parse(txtSPColorB.Text);
            spColor = int.Parse(txtSpecialColor.Text);

            try {
                myBitmap = new Bitmap((int)numWSize.Value, (int)numHSize.Value/*, System.Drawing.Imaging.PixelFormat.Format16bppRgb555*/);

                using (Graphics g = Graphics.FromImage(myBitmap)) {
                    g.PageUnit = GraphicsUnit.Pixel;
                    g.DrawImage(im, new Rectangle(0, 0, (int)numWSize.Value, (int)numHSize.Value));
                    //,(im,new Point(0,0,)    ,DrawImage(im,  Unscaled(new Bitmap(im, new Size((int)numWSize.Value, (int)numHSize.Value)), 0, 0);
                };
            } catch (Exception ex) {
                MessageBox.Show(this, "その他のエラー（" + ex.Message + ")\r\n" + ex.StackTrace, "エラー");
                return;
            }
            //　警告の表示

            if (cmbPreset.SelectedIndex == 1) {         // LCD_ShowPictureは12800の単位である必要がある
                if (((myBitmap.Width * myBitmap.Height)*2) % 12800 != 0) {
                    DialogResult dr = MessageBox.Show(this, strErrorMsg[MSG_BMPSIZENOTVALID], "警告", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel) return;
                }
            }

            String strSaveFn;
            if (cmbPreset.SelectedIndex == 4) { 
                strSaveFn = Path.GetDirectoryName(strFilename) + "\\" + Path.GetFileNameWithoutExtension(strFilename) + ".bin";
            } else {
                strSaveFn = Path.GetDirectoryName(strFilename) + "\\" + Path.GetFileNameWithoutExtension(strFilename) + ".c";

            }
            //myBitmap.Save(strSaveFn);

            int iStartX, iEndX, dx;
            int iStartY, iEndY, dy;




            switch (cmbDirection.SelectedIndex) {
                case 0: {
                    iStartX = 0;
                    iEndX = myBitmap.Width;
                    iStartY = 0;
                    iEndY = myBitmap.Height;
                    dx = 1;
                    dy = 1;
                    break;
                }
                case 1: {
                    iStartX = myBitmap.Width - 1;
                    iEndX = -1;
                    iStartY = 0;
                    iEndY = myBitmap.Height;
                    dx = -1;
                    dy = 1;
                    break;
                }
                case 2: {
                    iStartX = 0;
                    iEndX = myBitmap.Width;
                    iStartY = myBitmap.Height - 1;
                    iEndY = -1;
                    dx = 1;
                    dy = -1;
                    break;
                }
                case 3: {
                    iStartX = myBitmap.Width - 1;
                    iEndX = -1;
                    iStartY = myBitmap.Height - 1;
                    iEndY = -1;
                    dx = -1;
                    dy = -1;
                    break;
                }
                case 4: {
                    iStartX = myBitmap.Width - 1;
                    iEndX = -1;
                    iStartY = myBitmap.Height - 1;
                    iEndY = -1;
                    dx = -1;
                    dy = -1;
                    break;
                }
                default: {
                    return;
                }
            }
            int colBits = 1;
            if (cmbColor.SelectedIndex == 0) {
                colBits = 24;
            } else {
                colBits = 15;
            }
            int y = iStartY;

            List<byte[]> bitmaps = new List<byte[]>();


            do {
                int x = iStartX;
                do {
                    Color c = myBitmap.GetPixel(x, y);
                    byte[] ColInfo = GetColor(c, colBits);
                    bitmaps.Add(ColInfo);
                    x += dx;
                } while (x != iEndX);
                y += dy;
            } while (y != iEndY);





            if (cmbPreset.SelectedIndex == 4) {                  // ベタファイルの時はそのまま書く
                using (FileStream fs = new FileStream(strSaveFn, FileMode.Create)) {
                    using (BinaryWriter sw = new BinaryWriter(fs)) {
                        foreach (byte[] data in bitmaps) {
                            sw.Write(data);
                        }
                    }


                    /*
                     bool ReadNShow()
                    {
                        FATFS fs;
                        unsigned char bmp[1728];
                        FRESULT fr;
                        fr = f_mount(&fs, "", 1);
                        if (fr != FR_OK) {
                            return FALSE;           // Mout Error
                        }

                        FIL fil;
                        UINT br = 0;
                        fr = f_open(&fil, "apple.bin", FA_READ);
                        if (fr != FR_OK) {
                            return FALSE;           // Open Error
                        }
                        f_lseek(&fil, 0);
                        fr = f_read(&fil, bmp, sizeof(bmp), &br);
                        if (br != 1728) {
                            f_close(&fil);
                            return FALSE;           // Read Error
                        }
                        LCD_Address_Set(0,0,26,31);
                        for (int i = 0; i < 1728 ; i++) {
                            LCD_WR_DATA8(bmp[i]);
                        }
                        f_close(&fil);
                        return TRUE;
                    }
                     */




                }
                String strSampleCode = "";

                strSampleCode = "bool ReadNShow()\r\n{\r\n";
                strSampleCode += "  FATFS fs;\r\nFRESULT fr;\r\n";
                strSampleCode += "  unsigned char bmp[" + bitmaps.Count*2 + "];\r\n";
                strSampleCode += "  fr = f_mount(&fs, \"\", 1);\r\n";
                strSampleCode += "  if (fr != FR_OK) {return FALSE;}  // Mount Error\r\n";
                strSampleCode += "  FIL fil;\r\n  UINT br = 0;\r\n";
                strSampleCode += "  fr = f_open(&fil, \"" + Path.GetFileNameWithoutExtension(strFilename) +".bin" + "\" , FA_READ);\r\n";
                strSampleCode += "  if (fr != FR_OK) {return FALSE;}  // Open Error \r\n";
                strSampleCode += "  f_lseek(&fil, 0);\r\n";
                strSampleCode += "  fr = f_read(&fil, bmp, sizeof(bmp), &br);\r\n";
                strSampleCode += "  if (br != sizeof(bmp)) {f_close(&fil);return FALSE;}  // Read Error\r\n";
                strSampleCode += "  LCD_Address_Set(0, 0," + (myBitmap.Width - 1).ToString() + "," + (myBitmap.Height - 1).ToString() + ");\r\n";
                strSampleCode += "  for (int i = 0; i < sizeof(bmp); i++) {\r\n";
                strSampleCode += "    LCD_WR_DATA8(bmp[i]);\r\n";
                strSampleCode += "  }\r\n";
                strSampleCode += "  f_close(&fil);\r\n";
                strSampleCode += "  return TRUE;\r\n";
                strSampleCode += "}\r\n";

                String strSampleFn = Path.GetDirectoryName(strFilename) + "\\" + Path.GetFileNameWithoutExtension(strFilename) + ".c";

                File.WriteAllText(strSampleFn, strSampleCode);
                DialogResult dr = MessageBox.Show(this, "ベタファイルへの変換が完了しました\r\nバイナリ：" + strSaveFn + "\r\nサンプル：" + strSampleFn +"に保存されています\r\n読み込み用のコード例をエディタで開きますか？", "成功", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(strSampleFn);
                }

            } else if (cmbPreset.SelectedIndex == 2 || cmbPreset.SelectedIndex == 1) {                                        // バイト配列ソースコード

                using (StreamWriter sw = new StreamWriter(strSaveFn)) {
                    int lineCount = 0;
                    int wrapCount = 0;
                    int writtenBytes = 0;
                    bool isEOLDone = false;
                    foreach (byte[] data in bitmaps) {
                        if (lineCount == 0 && wrapCount == 0) {
                            if (cmbPreset.SelectedIndex == 1) {
                                sw.Write("unsigned char image[]={");

                            } else {
                                sw.Write("const u8 bmp[]={");
                            }
                        } else if (wrapCount == 0) {
                            isEOLDone = false;
                        }



                        for (int i = 0; i < data.Length; i++) {
                            sw.Write("0x{0}", data[i].ToString("X2"));
                            if (i != (data.Length - 1)) sw.Write(",");
                        }
                        writtenBytes++;
                        wrapCount++;
                        if (wrapCount == 16) {
                            wrapCount = 0;
                            lineCount++;
                            isEOLDone = true;
                            if (writtenBytes < bitmaps.Count) {
                                sw.Write(",\r\n");
                            } else {
                                isEOLDone = false;
                                sw.Write("\r\n");
                            }

                        } else if (writtenBytes == bitmaps.Count) {
                        } else {
                            sw.Write(",");
                        }
                    }
                    if (isEOLDone) {
                    } else {
                        sw.Write("};\r\n");
                    }

                    sw.Write("// Bytes:{0}  ({1},{2})-({3},{4}) \r\n", writtenBytes.ToString(), iStartX, iStartY, iEndX-1, iEndY-1);
                    if (cmbPreset.SelectedIndex == 1) {
                        sw.Write(
                            "// LCD_ShowPicture(0,0,{1},{2});\r\n", writtenBytes.ToString(), myBitmap.Width-1, myBitmap.Height-1);

                    } else if (cmbPreset.SelectedIndex == 2) {
                        sw.Write("//LCD_Address_Set(0,0,{0},{1});\r\n//for (int i = 0; i < {2}*2 ; i++) {{\r\n//    LCD_WR_DATA8(bmp[i]);\r\n//}}\r\n", myBitmap.Width-1, myBitmap.Height-1, writtenBytes.ToString());
                    }
                }
                DialogResult dr = MessageBox.Show(this, "バイト配列（Cソースコード形式）への変換が完了しました\r\n" + strSaveFn + "に保存されています\r\nエディタで開きますか？", "成功", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(strSaveFn);
                }
            } else if (cmbPreset.SelectedIndex == 3){                                                                    //　それ以外。今のところワード配列
                using (StreamWriter sw = new StreamWriter(strSaveFn)) {
                    int lineCount = 0;
                    int wrapCount = 0;
                    int writtenBytes = 0;
                    bool isEOLDone = false;
                    foreach (byte[] data in bitmaps) {
                        if (lineCount == 0 && wrapCount == 0) {
                            sw.Write("const u16 bmp[]={");
                        } else if (wrapCount == 0) {
                            isEOLDone = false;
                        }
                        sw.Write("0x{0}", data[0].ToString("X2") + data[1].ToString("X2"));
                        writtenBytes++;
                        wrapCount++;
                        if (wrapCount == 8) {
                            wrapCount = 0;
                            lineCount++;
                            isEOLDone = true;
                            if (writtenBytes < bitmaps.Count) {
                                sw.Write(",\r\n");
                            } else {
                                isEOLDone = false;
                                sw.Write("\r\n");
                            }

                        } else if (writtenBytes == bitmaps.Count) {
                        } else {
                            sw.Write(",");
                        }
                    }
                    if (isEOLDone) {
                    } else {
                        sw.Write("};\r\n");
                    }

                    sw.Write("// WORD:{0}  ({1},{2})-({3},{4}) \r\n", writtenBytes.ToString(), iStartX, iStartY, iEndX-1, iEndY-1);
                    sw.Write("//LCD_Address_Set(0,0,{0},{1});\r\n//for (int i = 0; i < {2} ; i++) {{\r\n//    LCD_WR_DATA(bmp[i]);\r\n//}}\r\n", myBitmap.Width-1, myBitmap.Height-1, writtenBytes.ToString());
                }
                DialogResult dr = MessageBox.Show(this, "ワード配列（Cソースコード形式）への変換が完了しました\r\n" + strSaveFn + "に保存されています\r\nエディタで開きますか？", "成功", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) {
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(strSaveFn);
                }

            } else {
                MessageBox.Show(this, strErrorMsg[MSG_NONENOTSUPPORTED], "エラー");
            }
        }
        private void cmbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPreset.SelectedIndex == 0) {
            } else if (cmbPreset.SelectedIndex == 1) {
                cmbColor.SelectedIndex = 2;
                cmbDirection.SelectedIndex = 0;
                chkLargeEndian.Checked = false;
                chkRevByte.Checked = false;
            } else if (cmbPreset.SelectedIndex == 2) {
                cmbColor.SelectedIndex = 2;
                cmbDirection.SelectedIndex = 0;
                chkLargeEndian.Checked = false;
                chkRevByte.Checked = false;
            } else if (cmbPreset.SelectedIndex == 3) {
                cmbColor.SelectedIndex = 2;
                cmbDirection.SelectedIndex = 0;
                chkLargeEndian.Checked = false;
                chkRevByte.Checked = false;
            }
        }
    }
}

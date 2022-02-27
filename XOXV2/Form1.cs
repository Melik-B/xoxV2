using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOXV2
{
    public partial class Form1 : Form
    {
        #region Form kenar yuvarlaklaştırma
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );

        public Point mouseLocation;
        #endregion
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        string isaret = "X";
        private void xoxForm_Load(object sender, EventArgs e)
        {
            pXoxOyuncuAdi.Location = new Point(400, 2);

        }

        #region Form Sürükleme
        private void xoxForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void xoxForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        #endregion
        private void tbKullaniciAdi_MouseClick(object sender, MouseEventArgs e)
        {
            lbXoxOyuncuAdi1.Visible = false;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            lbXoxOyuncuAdi2.Visible = false;
        }

        bool Oyuncu1X = false;
        bool Oyuncu1O = false;
        bool Oyuncu2X = false;
        bool Oyuncu2O = false;
        private void btXoxOyna_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbXoxOyuncuAdi1.Text) && tbXoxOyuncuAdi1.TextLength >= 3 && tbXoxOyuncuAdi1.TextLength <= 8 && !string.IsNullOrWhiteSpace(tbXoxOyuncuAdi2.Text) && tbXoxOyuncuAdi2.TextLength >= 3 && tbXoxOyuncuAdi2.TextLength <= 8 && (Oyuncu1O || Oyuncu1X) && (Oyuncu2O || Oyuncu2X))
            {
                pXox.Location = new Point(419, 90);
                pXox.Visible = true;
                pXoxOyuncuAdi.Visible = false;
                lbOynayanIsim.Location = new Point(453, 32);
                lbXoxOyuncuAdi1Buyuk.Text = tbXoxOyuncuAdi1.Text;
                lbXoxOyuncuAdi2Buyuk.Text = tbXoxOyuncuAdi2.Text;
                lbXoxOyuncuAdi1Buyuk.Visible = true;
                lbXoxOyuncuAdi2Buyuk.Visible = true;
                lbOynayanIsim.Visible = true;
                lbOyuncu1Skor.Visible = true;
                lbOyuncu2Skor.Visible = true;

                if (Oyuncu1X)
                {
                    lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Oynuyor...";
                }
                else
                {
                    lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Oynuyor...";
                }

                if (Oyuncu1X)
                {
                    lbXoxOyuncuAdi1Buyuk.Text += "-X";
                }
                else
                {
                    lbXoxOyuncuAdi1Buyuk.Text += "-O";
                }

                if (Oyuncu2X)
                {
                    lbXoxOyuncuAdi2Buyuk.Text += "-X";
                }
                else
                {
                    lbXoxOyuncuAdi2Buyuk.Text += "-O";
                }

                if (tbXoxOyuncuAdi2.TextLength == 5)
                {
                    lbXoxOyuncuAdi2Buyuk.Location = new Point(1070, 9);
                }
                if (tbXoxOyuncuAdi2.TextLength == 6)
                {
                    lbXoxOyuncuAdi2Buyuk.Location = new Point(1050, 9);
                }
                if (tbXoxOyuncuAdi2.TextLength == 7)
                {
                    lbXoxOyuncuAdi2Buyuk.Location = new Point(1020, 9);
                }
                if (tbXoxOyuncuAdi2.TextLength == 8)
                {
                    lbXoxOyuncuAdi2Buyuk.Location = new Point(1000, 9);
                }
            }

            if (string.IsNullOrWhiteSpace(tbXoxOyuncuAdi1.Text))
            {
                lbHata1.Text = "Oyuncu Adı boş bırakılamaz!";
                lbHata1.Visible = true;
            }

            if (tbXoxOyuncuAdi1.TextLength < 3 && tbXoxOyuncuAdi1.TextLength > 0)
            {
                lbHata1.Text = "Oyuncu Adı 3 karakterden kısa olamaz!";
                lbHata1.Visible = true;
            }

            if (tbXoxOyuncuAdi1.TextLength > 8)
            {
                lbHata1.Text = "Oyuncu Adı 8 karakterden uzun olamaz!";
                lbHata1.Visible = true;
            }

            if (string.IsNullOrWhiteSpace(tbXoxOyuncuAdi2.Text))
            {
                lbHata2.Text = "2. Oyuncu Adı boş bırakılamaz!";
                lbHata2.Visible = true;
            }

            if (tbXoxOyuncuAdi2.TextLength < 3 && tbXoxOyuncuAdi2.TextLength > 0)
            {
                lbHata2.Text = "2. Oyuncu Adı 3 karakterden kısa olamaz!";
                lbHata2.Visible = true;
            }

            if (tbXoxOyuncuAdi2.TextLength > 8)
            {
                lbHata2.Text = "2. Oyuncu Adı 8 karakterden uzun olamaz!";
                lbHata2.Visible = true;
            }
        }

        private void btOyuncu1O_Click(object sender, EventArgs e)
        {
            Oyuncu1O = true;
            Oyuncu1X = false;
            lbOyuncu1OTik.Visible = true;
            lbOyuncu1XTik.Visible = false;

            if (Oyuncu2O)
            {
                lbOyuncu2OTik.Visible = false;
                lbOyuncu2XTik.Visible = true;
                Oyuncu2O = false;
                Oyuncu2X = true;
            }
        }

        private void btOyuncu1X_Click(object sender, EventArgs e)
        {
            Oyuncu1X = true;
            Oyuncu1O = false;
            lbOyuncu1XTik.Visible = true;
            lbOyuncu1OTik.Visible = false;

            if (Oyuncu2X)
            {
                lbOyuncu2XTik.Visible = false;
                lbOyuncu2OTik.Visible = true;
                Oyuncu2X = false;
                Oyuncu2O = true;
            }
        }

        private void btOyuncu2O_Click(object sender, EventArgs e)
        {
            Oyuncu2O = true;
            Oyuncu2X = false;
            lbOyuncu2OTik.Visible = true;
            lbOyuncu2XTik.Visible = false;

            if (Oyuncu1O)
            {
                lbOyuncu1OTik.Visible = false;
                lbOyuncu1XTik.Visible = true;
                Oyuncu1O = false;
                Oyuncu1X = true;
            }
        }

        private void btOyuncu2X_Click(object sender, EventArgs e)
        {
            Oyuncu2X = true;
            Oyuncu2O = false;
            lbOyuncu2XTik.Visible = true;
            lbOyuncu2OTik.Visible = false;

            if (Oyuncu1X)
            {
                lbOyuncu1XTik.Visible = false;
                lbOyuncu1OTik.Visible = true;
                Oyuncu1X = false;
                Oyuncu1O = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            label.Text = isaret;
            label.Enabled = false;

            if (isaret == "X" && Oyuncu1X)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Oynuyor...";
                isaret = "O";
            }
            else if (isaret == "X" && Oyuncu1O)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Oynuyor...";
                isaret = "O";
            }
            else if (isaret == "O" && Oyuncu1O)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Oynuyor...";
                isaret = "X";
            }
            else if (isaret == "O" && Oyuncu1X)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Oynuyor...";
                isaret = "X";
            }

            int skor = 0;
            if (label4.Text == "X" && label5.Text == "X" && label6.Text == "X" || label7.Text == "X" && label8.Text == "X" && label9.Text == "X"
            || label10.Text == "X" && label11.Text == "X" && label12.Text == "X" || label10.Text == "X" && label7.Text == "X" && label10.Text == "X" ||
            label5.Text == "X" && label8.Text == "X" && label11.Text == "X" || label6.Text == "X" && label9.Text == "X" && label12.Text == "X"
            || label6.Text == "X" && label8.Text == "X" && label10.Text == "X" || label4.Text == "X" && label8.Text == "X" && label12.Text == "X")
            {
                if (Oyuncu1X)
                {
                    //lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Kazandı!";
                    //skor++;
                    //lbOyuncu1Skor.Text = skor.ToString();
                    //Tekrar();

                    skor = int.Parse(lbOyuncu1Skor.Text);
                    lbOyuncu1Skor.Text = Convert.ToString(skor + 1);
                    Tekrar();
                }
                else if (Oyuncu2X)
                {
                    //lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Kazandı!";
                    //skor++;
                    //lbOyuncu2Skor.Text = skor.ToString();
                    //Tekrar();

                    skor = int.Parse(lbOyuncu2Skor.Text);
                    lbOyuncu2Skor.Text = Convert.ToString(skor + 1);
                    Tekrar();
                }
            }

            if (label4.Text == "O" && label5.Text == "O" && label6.Text == "O" || label7.Text == "O" && label8.Text == "O" && label9.Text == "O"
            || label10.Text == "O" && label11.Text == "O" && label12.Text == "O" || label10.Text == "O" && label7.Text == "O" && label10.Text == "O" ||
            label5.Text == "O" && label8.Text == "O" && label11.Text == "O" || label6.Text == "O" && label9.Text == "O" && label12.Text == "O"
            || label6.Text == "O" && label8.Text == "O" && label10.Text == "O" || label4.Text == "O" && label8.Text == "O" && label12.Text == "O")
            {
                if (Oyuncu1O)
                {
                    //lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Kazandı!";
                    //skor++;
                    //lbOyuncu1Skor.Text = skor.ToString();
                    //Tekrar();

                    skor = int.Parse(lbOyuncu1Skor.Text);
                    lbOyuncu1Skor.Text = Convert.ToString(skor + 1);
                    Tekrar();
                }
                else if (Oyuncu2O)
                {
                    //lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Kazandı!";
                    //skor++;
                    //lbOyuncu2Skor.Text = skor.ToString();
                    //Tekrar();

                    skor = int.Parse(lbOyuncu2Skor.Text);
                    lbOyuncu2Skor.Text = Convert.ToString(skor + 1);
                    Tekrar();
                }
            }

            if (lbOyuncu1Skor.Text == nudElSayisi.Value.ToString())
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Kazandı!";

                pXox.Visible = false;
            }

            if (lbOyuncu2Skor.Text == nudElSayisi.Value.ToString())
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Kazandı!";

                pXox.Visible = false;
            }

            if (label4.Text != "" && label5.Text != "" && label6.Text != "" && label7.Text != "" && label8.Text != "" && label9.Text != "" && label10.Text != "" && label11.Text != "" && label12.Text != "")
            {
                //lbOynayanIsim.Text = "Berabere";
                Tekrar();
            }
        }

        public void Tekrar()
        {
            isaret = "X";

            if (Oyuncu1X)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi1.Text + " Oynuyor...";
            }
            else if (Oyuncu1O)
            {
                lbOynayanIsim.Text = tbXoxOyuncuAdi2.Text + " Oynuyor...";
            }

            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";

            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label12.Enabled = true;
        }
    }
}
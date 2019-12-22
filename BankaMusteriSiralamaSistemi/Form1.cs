using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaMusteriSiralamaSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] musteriler = new int[20, 2];
        CircularQueue cq = new CircularQueue(20);
        PriorityQueue pq = new PriorityQueue(20);
        PriorityQueue2 pq2 = new PriorityQueue2(20);

        public void KarsilastirKontrolu()
        {
            if (btnOrtHesapDaire.Enabled == true && btnOrtHesapOncelikBK.Enabled == true && btnOrtHesapOncelikKB.Enabled == true)
            {
                btnKarsilastirDaireKB.Enabled = true;
                btnKarsilastirDaireBK.Enabled = true;
                btnBeklemeDaire.Enabled = true;
                btnBeklemeOncelik.Enabled = true;
                btnBeklemeOncelik2.Enabled = true;
            }
        }

        private void btnMusterileriAta_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                int musteriIslemSuresi = r.Next(60, 601);
                musteriler[i, 0] = i + 1;
                musteriler[i, 1] = musteriIslemSuresi;
                lstMusteriler.Items.Add(i + 1 + ".Müşterinin işlem süresi" + musteriler[i, 1]);
            }
            btnDaireAta.Enabled = true;
            btnOncelikAtaBK.Enabled = true;
            btnOncelikAtaKB.Enabled = true;
            btnMusterileriAta.Enabled = false;
        }

        private void btnDaireAta_Click(object sender, EventArgs e)
        {
            btnOrtHesapDaire.Enabled = true;
            btnDaireAta.Enabled = false;
            KarsilastirKontrolu();
            for (int i = 0; i < 20; i++)
            {
                cq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            while (cq.IsEmpty() != true)
            {
                j++;
                object okunanDeger;
                okunanDeger = cq.Peek();
                lstDaire.Items.Add(j + ".Müşterinin işlem süresi" + okunanDeger + "saniyede bitmiştir");
                cq.Remove();
            }
        }

        private void btnOncelikAtaKB_Click(object sender, EventArgs e)
        {
            btnOrtHesapOncelikKB.Enabled = true;
            btnOncelikAtaKB.Enabled = false;
            KarsilastirKontrolu();
            for (int i = 0; i < 20; i++)
            {
                pq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int a = 1;
            while (pq.IsEmpty() != true)
            {
                object okunanDeger;
                okunanDeger = pq.Peek();
                int oncekiSira = 0;
                for (int k = 0; k < 20; k++)
                {

                    if (Convert.ToInt32(okunanDeger) == musteriler[k, 1])
                        oncekiSira = musteriler[k, 0];
                }
                lstOncelikKB.Items.Add("Önceden" + oncekiSira + ".Olan müşteri şu an" + a + ".Müşteri olarak işlem süresi" + okunanDeger + "saniyede bitmiştir");
                pq.Remove();
                j++;
                a++;
            }
        }

        private void btnOncelikAtaBK_Click(object sender, EventArgs e)
        {
            btnOrtHesapOncelikBK.Enabled = true;
            btnOncelikAtaBK.Enabled = false;
            KarsilastirKontrolu();
            for (int i = 0; i < 20; i++)
            {
                pq2.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int a = 1;
            while (pq2.IsEmpty() != true)
            {
                object okunanDeger;
                okunanDeger = pq2.Peek();
                int oncekiSira = 0;
                for (int k = 0; k < 20; k++)
                {
                    if (Convert.ToInt32(okunanDeger) == musteriler[k, 1])
                        oncekiSira = musteriler[k, 0];
                }
                lstOncelikBK.Items.Add("Önceden" + oncekiSira + ".Olan müşteri şu an" + a + ".Müşteri olarak işlem süresi" + okunanDeger + "saniyede bitmiştir");
                pq2.Remove();
                j++;
                a++;
            }
        }

        private void btnOrtHesapDaire_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                cq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            double okunanDeger = 0;
            while (cq.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(cq.Peek());
                cq.Remove();
            }
            txtOrt1.Text = "Dairesel Kuyruğun Ortalama İşlem Süresi" + okunanDeger / 20;
        }

        private void btnOrtHesapOncelikKB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            double okunanDeger = 0;
            while (pq.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(pq.Peek());
                pq.Remove();
            }
            txtOrt2.Text = "Öncelik Kuyruğunda Ortalama İşlem Süresi" + okunanDeger / 20;
        }

        private void btnOrtHesapOncelikBK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq2.Insert(musteriler[i, 1]);
            }
            int j = 0;
            double okunanDeger = 0;
            while (pq2.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(pq2.Peek());
                pq2.Remove();
            }
            txtOrt3.Text = "Öncelik Kuyruğunda 2'de Ortalama İşlem Süresi" + okunanDeger / 20;
        }

        private void btnBeklemeDaire_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                cq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int okunanDeger = 0;
            int oncekiSira = 0;
            while (cq.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(cq.Peek());
                int degisenDeger = Convert.ToInt32(cq.Peek());
                for (int k = 0; k < 20; k++)
                {
                    if (Convert.ToInt32(degisenDeger) == musteriler[k, 1])
                        oncekiSira = musteriler[k, 0];
                }
                lstBekleme1.Items.Add("Onceden" + oncekiSira + "da Olan Ve şu An" + j + ". Sırada Olan Müşteri Sırada Bekleme Dahil Toplam" + okunanDeger + "Saniye'de İşlemlerini tamamladı");
                cq.Remove();
            }
            btnBeklemeDaire.Enabled = false;
        }

        private void btnBeklemeOncelik_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int okunanDeger = 0;
            int oncekiSira = 0;
            while (pq.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(pq.Peek());
                int degisenDeger = Convert.ToInt32(pq.Peek());
                for (int k = 0; k < 20; k++)
                {

                    if (Convert.ToInt32(degisenDeger) == musteriler[k, 1])
                        oncekiSira = musteriler[k, 0];
                }
                lstBekleme2.Items.Add("Onceden" + oncekiSira + "da Olan Ve şu An" + j + ". Sırada Olan Müşteri Sırada Bekleme Dahil Toplam" + okunanDeger + "Saniye'de İşlemlerini tamamladı");
                pq.Remove();
            }
            btnBeklemeOncelik.Enabled = false;
        }

        private void btnBeklemeOncelik2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq2.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int okunanDeger = 0;
            int oncekiSira = 0;
            while (pq2.IsEmpty() != true)
            {
                j++;
                okunanDeger += Convert.ToInt32(pq2.Peek());
                int degisenDeger = Convert.ToInt32(pq2.Peek());
                for (int k = 0; k < 20; k++)
                {

                    if (Convert.ToInt32(degisenDeger) == musteriler[k, 1])
                        oncekiSira = musteriler[k, 0];
                }
                lstBekleme3.Items.Add("Onceden" + oncekiSira + "da Olan Ve şu An" + j + ". Sırada Olan Müşteri Sırada Bekleme Dahil Toplam" + okunanDeger + "Saniye'de İşlemlerini tamamladı");
                pq2.Remove();
            }
            btnBeklemeOncelik2.Enabled = false;
        }

        private void btnKarsilastirDaireKB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int toplamDegerOncelik = 0;
            int siraDegiskeni1 = 0;
            while (pq.IsEmpty() != true)
            {
                int siraDegiskeni2 = 0;
                int okunanDegerOncelik = 0;
                int okunanDegerDaire = 0;
                siraDegiskeni1++;
                toplamDegerOncelik += Convert.ToInt32(pq.Peek());
                okunanDegerOncelik = Convert.ToInt32(pq.Peek());
                for (j = 0; j < 20; j++)
                {
                    siraDegiskeni2++;
                    okunanDegerDaire += musteriler[j, 1];
                    if (okunanDegerOncelik == musteriler[j, 1])
                        break;
                }
                int degisken = 0;
                double kar = 0;
                if (toplamDegerOncelik < okunanDegerDaire)
                {
                    degisken = okunanDegerDaire - toplamDegerOncelik;
                    kar = (okunanDegerDaire * 100) / toplamDegerOncelik;
                    lstKarsilastirDaireKB.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup toplam" + degisken + "süre kazandı ve %" + kar + "kar etti");
                }
                else if (toplamDegerOncelik > okunanDegerDaire)
                {
                    kar = (toplamDegerOncelik * 100) / okunanDegerDaire;
                    degisken = toplamDegerOncelik - okunanDegerDaire;
                    lstKarsilastirDaireKB.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup toplam" + degisken + "süre kaybetti ve %" + kar + "zarar etti");
                }
                else
                {
                    lstKarsilastirDaireKB.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup aynı sürede işini bitirdi");
                }
                pq.Remove();
            }
            btnKarsilastirDaireKB.Enabled = false;
        }

        private void btnKarsilastirDaireBK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                pq2.Insert(musteriler[i, 1]);
            }
            int j = 0;
            int toplamDegerOncelik = 0;
            int siraDegiskeni1 = 0;
            while (pq2.IsEmpty() != true)
            {
                int siraDegiskeni2 = 0;
                int okunanDegerOncelik = 0;
                int okunanDegerDaire = 0;
                siraDegiskeni1++;
                toplamDegerOncelik += Convert.ToInt32(pq2.Peek());
                okunanDegerOncelik = Convert.ToInt32(pq2.Peek());
                for (j = 0; j < 20; j++)
                {
                    siraDegiskeni2++;
                    okunanDegerDaire += musteriler[j, 1];
                    if (okunanDegerOncelik == musteriler[j, 1])
                        break;
                }
                int degisken = 0;
                double kar = 0;
                if (toplamDegerOncelik < okunanDegerDaire)
                {
                    degisken = okunanDegerDaire - toplamDegerOncelik;
                    kar = (okunanDegerDaire * 100) / toplamDegerOncelik;
                    lstKarsilastirDaireBK.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup toplam" + degisken + "süre kazandı ve %" + kar + "kar etti");
                }
                else if (toplamDegerOncelik > okunanDegerDaire)
                {
                    kar = (toplamDegerOncelik * 100) / okunanDegerDaire;
                    degisken = toplamDegerOncelik - okunanDegerDaire;
                    lstKarsilastirDaireBK.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup toplam" + degisken + "süre kaybetti ve %" + kar + "zarar etti");
                }
                else
                {
                    lstKarsilastirDaireKB.Items.Add("Önceden" + siraDegiskeni2 + "de olan müşteri şu an" + siraDegiskeni1 + "de olup aynı sürede işini bitirdi");
                }
                pq2.Remove();
                btnKarsilastirDaireBK.Enabled = false;
            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            btnMusterileriAta.Enabled = true;
            lstBekleme1.Items.Clear();
            lstBekleme2.Items.Clear();
            lstBekleme3.Items.Clear();
            lstDaire.Items.Clear();
            lstKarsilastirDaireBK.Items.Clear();
            lstKarsilastirDaireKB.Items.Clear();
            lstMusteriler.Items.Clear();
            lstOncelikBK.Items.Clear();
            lstOncelikKB.Items.Clear();
            btnBeklemeDaire.Enabled = false;
            btnBeklemeOncelik.Enabled = false;
            btnBeklemeOncelik2.Enabled = false;
            btnDaireAta.Enabled = false;
            btnKarsilastirDaireBK.Enabled = false;
            btnKarsilastirDaireKB.Enabled = false;
            btnOncelikAtaBK.Enabled = false;
            btnOncelikAtaKB.Enabled = false;
            btnOrtHesapDaire.Enabled = false;
            btnOrtHesapOncelikBK.Enabled = false;
            btnOrtHesapOncelikKB.Enabled = false;
            txtOrt1.Text = "";
            txtOrt2.Text="";
            txtOrt3.Text="";
        }
    }
}

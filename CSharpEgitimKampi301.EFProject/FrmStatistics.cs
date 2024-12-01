using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyon Sasyısı

            lblLocationCount.Text = db.Location.Count().ToString();

            #endregion

            #region Toplam Kapasite

            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();

            #endregion

            #region Rehber Sayısı

            lblGuideCount.Text = db.Guide.Count().ToString();

            #endregion

            #region Ortalama Kapasite

            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();

            #endregion

            #region Ortalama Tur Fiyatı

            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price)?.ToString("0.00") + "₺";

            #endregion

            #region Eklenen Son Ülke Adı

            int lastCountryId = db.Location.Max(x => x.LocationId);

            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            #endregion

            #region Kapadokya Kapasite

            lblCappdociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            #endregion

            #region Türkiye Turları Ortalama Kapasite

            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            #endregion

            #region Roma Gezi Rehberi Adı

            var romeGuideId = db.Location.Where(x => x.City == "Roma").Select(y => y.GuideId).FirstOrDefault();

            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            #endregion

            #region En Yüksek Kapasiteli Tur

            var maxCapacity = db.Location.Max(x => x.Capacity);

            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

            #endregion

            #region En Pahalı Tur

            var maxPrice = db.Location.Max(x => x.Price);

            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            #endregion

            #region Ayşegül Çınar Tur Sayısı

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y =>y.GuideId).FirstOrDefault();

            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();

            #endregion
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

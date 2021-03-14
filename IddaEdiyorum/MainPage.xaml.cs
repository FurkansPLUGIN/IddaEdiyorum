using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Realms;
using PusulaCompass.Data;

namespace PusulaCompass
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            
          
        }

        private async void iddaGir_Clicked(object sender, EventArgs e)
        {
            if(kisiler.Text==null || iddaNe.Text== null || bahis.Text == null)
            {
                await DisplayAlert("Uyarı", "Boş Bırakmayınız", "Tamam");
            }

            if(kisiler.Text != null && iddaNe.Text != null && bahis.Text != null)
            {

                var realmDb = Realm.GetInstance();
                var datam = realmDb.All<Kullanici>().ToList();
                var maxID = 0;
                if (datam.Count != 0)
                {
                    maxID = datam.Max(m => m.ID) + 1;
                }
                var kullanan = new Kullanici
                {
                    ID = maxID,
                    iddaciİsim ="İddacılar: "+ kisiler.Text,
                    idda ="İdda nedir?: "+ iddaNe.Text,
                    bahis ="Bahis: "+ bahis.Text,
                    kazandı="Kazanan: "+bahisVer.Text
                };
                realmDb.Write(() =>
                {
                    realmDb.Add(kullanan);
                });
                var dataList = realmDb.All<Kullanici>().ToList();
                listem.ItemsSource = dataList;
                await DisplayAlert("Uyarı", "İdda kaydedildi", "Tamam");

            }
           
        }

        private async void gor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Silme_());
        }

        private async void listem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new Silme_());
        }

        private void listem_Refreshing(object sender, EventArgs e)
        {
            var realmDb = Realm.GetInstance();
            var datam = realmDb.All<Kullanici>().ToList();
            listem.ItemsSource = datam;
            listem.IsRefreshing = false;
        }

       
    }
}

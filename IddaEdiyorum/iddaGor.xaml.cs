using PusulaCompass.Data;
using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PusulaCompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class iddaGor : Rg.Plugins.Popup.Pages.PopupPage
    {
        string realKisiId;
        public iddaGor(string KisiId)
        {
            InitializeComponent();
            realKisiId = KisiId;
        }

        private async void sil_Clicked(object sender, EventArgs e)
        {
            var realmDb = Realm.GetInstance();
            var seciliKisi = realmDb.All<Kullanici>().First(s => s.ID == Convert.ToInt32(realKisiId));
            try
            {
                using(var db = realmDb.BeginWrite())
                {
                    realmDb.Remove(seciliKisi);
                    db.Commit();
                }
                await DisplayAlert("Uyarı", "Silindi", "tamam");
                await Navigation.PopPopupAsync();
               
            }
            catch
            {
                await DisplayAlert("Uyarı", "Silinemedi", "tamam");
            }
        }

        private async void guncelle_Clicked(object sender, EventArgs e)
        {
            var realmDb = Realm.GetInstance();
            var seciliKisi = realmDb.All<Kullanici>().First(s => s.ID == Convert.ToInt32(realKisiId));

            try
            {
                using (var db = realmDb.BeginWrite())
                {
                    seciliKisi.kazandı ="Kazanan:"+ kazananSec.Text;
                    
                    db.Commit();
                }
                await DisplayAlert("Uyarı", "Güncellendi", "tamam");
                await Navigation.PopPopupAsync();
            }
            catch
            {
                await DisplayAlert("Uyarı", "Güncellenemedi", "tamam");
            }
        }

        private async void geri_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}
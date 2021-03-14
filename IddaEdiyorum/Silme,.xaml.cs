using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PusulaCompass.Data;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
namespace PusulaCompass
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Silme_ : ContentPage
    {
        public Silme_()
        {
            InitializeComponent();
            var realmDb = Realm.GetInstance();
            var myItemSource = realmDb.All<Kullanici>().ToList();
            silmeList.ItemsSource = myItemSource;
        }

        private async void silmeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var selectKisi = (Kullanici)e.SelectedItem;
            var lv = (ListView)sender;

            await Navigation.PushPopupAsync(new iddaGor(selectKisi.ID.ToString()));
            lv.SelectedItem = null;
        }

        private void silmeList_Refreshing(object sender, EventArgs e)
        {
            
            var realmDb = Realm.GetInstance();
            var myItemSource = realmDb.All<Kullanici>().ToList();
            silmeList.ItemsSource = myItemSource;
            silmeList.IsRefreshing = false;   
        }
    }
}
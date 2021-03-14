using System;
using System.Collections.Generic;
using System.Text;
using Realms;
namespace PusulaCompass.Data
{
    public class Kullanici:RealmObject
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string iddaciİsim { get; set; }
        public string idda { get; set; }
        public string bahis { get; set; }
        public string kazandı { get; set; }
    }
}

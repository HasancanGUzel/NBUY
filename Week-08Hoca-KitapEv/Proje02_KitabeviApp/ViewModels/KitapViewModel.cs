using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje02_KitabeviApp.Models;

namespace Proje02_KitabeviApp.ViewModels
{
    public class KitapViewModel
    {
        public Kitap Kitap { get; set; }//model klasöründeki Kitap tipinde Kitap tanımladık
        public List<Yazar> Yazarlar { get; set; }// yazarlar olduğu için list tipinde tanımladık
        public List<Kategori> Kategoriler { get; set; }// kategoriler olduğu için list tipinde tanımladık
    }
}
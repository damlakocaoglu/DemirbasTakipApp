using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DemirbasTakipApp.API.Models
{
    public partial class Insanlar
    {
        public Insanlar()
        {
            Urunler = new HashSet<Urunler>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Tel { get; set; }
        public string Sehir { get; set; }
        public string MedeniDurum { get; set; }
        public int Yas { get; set; }

        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}

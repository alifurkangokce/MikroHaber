using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Model
{
   public class Haberler:BaseEntity
    {
        [Display(Name ="Haber Başlığı")]
        public string HaberBaslik{ get; set; }
        [Display(Name = "Haber Detayı")]
        public string HaberDetay { get; set; }
        [Display(Name = "Haber Görseli")]
        public string HaberPhoto { get; set; }
        [Display(Name = "Sıra No")]
        public int HaberSirano { get; set; }
        [Display(Name = "Haber Durumu")]
        public bool IsActive { get; set; }


    }
}

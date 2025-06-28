using System.ComponentModel.DataAnnotations;

namespace projeodev.Models
{
    public class Detay
    {
        [Key]
        public int MyProperty { get; set; }
        public int Yıldız { get; set; }
        public string Acıklama { get; set; }
        public decimal Günlükfiyat { get; set; }
        
        public ICollection<Oda> odas { get; set; }
        public ICollection<Detay> Detays { get; set; }

    }
}

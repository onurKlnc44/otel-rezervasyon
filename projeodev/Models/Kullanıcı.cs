using System.ComponentModel.DataAnnotations;

namespace projeodev.Models
{
    public class Kullanıcı
    {
        [Key]
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyadi { get; set; }
        public string Mail { get; set; }
        public string Sifre{ get; set; }
        public string Telno{ get; set; }
        public ICollection<Rezervasyon> rezervasyons { get; set; }
    }
}

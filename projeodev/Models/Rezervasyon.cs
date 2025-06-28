using System.ComponentModel.DataAnnotations;

namespace projeodev.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }

        public DateTime BaslangıcTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        
        public int? KullanıcıId { get; set; }
        public Kullanıcı kullanıcı {  get; set; }
        public int? OdaID { get; set; }
        public Oda oda { get; set; }

    }
}

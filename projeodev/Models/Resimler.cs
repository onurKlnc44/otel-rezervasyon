using System.ComponentModel.DataAnnotations;

namespace projeodev.Models
{
    public class Resimler
    {
        [Key]
        public int ID { get; set; }
  
        public string Resimyolu { get; set; }

        public int? OdaId { get; set; }
        public Oda oda { get; set; }

        public int? DetayID { get; set; }
        public Detay detay { get; set; }
    }
}

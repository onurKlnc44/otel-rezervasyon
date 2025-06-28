using System.ComponentModel.DataAnnotations;

namespace projeodev.Models
{
    public class Oda
    {
      [Key]
        public int Id { get; set; }
        public string Odano { get; set; }
        public string Odaismi { get; set; }
        
   
        public int? DetayID { get; set; }
        public Detay Detay { get; set; }

     public ICollection<Rezervasyon> Rezervasyons { get; set; }

       public ICollection<Resimler> resimlers { get;set; } 

    }
}

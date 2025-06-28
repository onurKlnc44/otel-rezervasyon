using projeodev.Models;

namespace projeodev.ViewModels
{
    public class indexVM
    {
        public IEnumerable <Resimler> resimlers { get; set; }

        public IEnumerable<Oda> oda { get; set; }   
    
        public IEnumerable<Detay> detay { get; set; }
   
    }
}

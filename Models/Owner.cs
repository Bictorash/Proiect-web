namespace Inchiriere_Instrumente.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public ICollection<Instrument>? Instruments { get; set; } //navigation property
    }
}

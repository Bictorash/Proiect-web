namespace Inchiriere_Instrumente.Models
{
    public class InstrumentData
    {
        public IEnumerable<Instrument> Instruments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<InstrumentCategory> InstrumentCategories { get; set; }
    }
}

namespace Inchiriere_Instrumente.Models
{
    public class InstrumentCategory
    {
        public int ID { get; set; }
        public int InstrumentID { get; set; }
        public Instrument Instrument { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

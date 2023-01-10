using System.ComponentModel.DataAnnotations;

namespace Inchiriere_Instrumente.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? InstrumentID { get; set; }
        public Instrument? Instrument { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}

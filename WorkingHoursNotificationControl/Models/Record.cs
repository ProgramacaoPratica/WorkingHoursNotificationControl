using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotifyControl.Models
{
    public class Record
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public DateTime CheckIn1 { get; set; }
        public bool NotifiedCheckIn1 { get; set; }
        public DateTime? CheckOut1 { get; set; }
        public bool NotifiedCheckOut1 { get; set; }
        public DateTime? CheckIn2 { get; set; }
        public bool NotifiedCheckIn2 { get; set; }
        public DateTime? CheckOut2 { get; set; }
        public bool NotifiedCheckOut2 { get; set; }
        public DateTime? PredictionCheckOut2 { get; set; }
    }
}
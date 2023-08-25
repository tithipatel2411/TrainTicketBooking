using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.Model.EntityBase;

namespace TrainBooking.Model
{
    public class BookingModel : EntityBase<int>
    {
        public int UserMapId { get; set; }
        public int TrainId { get; set; }
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

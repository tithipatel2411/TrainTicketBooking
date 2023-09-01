using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.Model.EntityBase;

namespace TrainBooking.Model
{
    class TrainDetailModel : EntityBase<int>
    {
        public int TrainNo { get; set; }
        public string TrainName { get; set; }
        public int TrainSourceId { get; set; }
        public int TrainDestinationId { get; set; }
        public string Availibility { get; set; }
        public int TotalSeat { get; set; }
    }
}

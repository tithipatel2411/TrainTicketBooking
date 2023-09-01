using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.Model.EntityBase;

namespace TrainBooking.Model
{
    class UserMappingModel : EntityBase<int>
    {
        public int UserId { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public int NoOfSeat { get; set; }

    }
}

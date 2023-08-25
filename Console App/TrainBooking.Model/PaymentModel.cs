using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.Model.EntityBase;

namespace TrainBooking.Model
{
    class PaymentModel : EntityBase<int>
    {
        public string PaymentType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.Model.EntityBase;

namespace TrainBooking.Model
{
    public class UserDetailModel : EntityBase<int>
    {
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Wallet { get; set; }

    }

}

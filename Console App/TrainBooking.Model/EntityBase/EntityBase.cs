using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBooking.Model.EntityBase
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
    }
}

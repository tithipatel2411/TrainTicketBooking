using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    public class GenericClass
    {
        public static void Main(string[] args)
        {
            TrainList trainList = new TrainList()
            {
                TrainName = "rajdhani",
                Id = 1,
                CreatedAt = DateTime.Now
            };
            UserDetails userDetails = new UserDetails()
            {
                Id=6,
                UserName="Tithi",
                UserEmailId="tithi123@gmail.com",
                UpdatedAt = DateTime.Now
            };
            
            Console.WriteLine("CreatedAt:"+trainList.CreatedAt+" Id: "+trainList.Id);
            Console.WriteLine("ID:" + userDetails.Id + " UserName: " + userDetails.UserName + " EmailId:" + userDetails.UserEmailId + " UpdatedAt: " + userDetails.UpdatedAt);

        }

    }
        public class BaseClass<T , A>
        {
            public T Id { get; set; }

            public A CreatedAt { get; set; }

            public A UpdatedAt { get; set; }


        }

        

        public class UserDetails :BaseClass<int,DateTime>
        { 

            public string UserName { get; set; }

            public string UserEmailId { get; set; }
        }

        public class Booking : BaseClass<int, DateTime>
        {
            public int UserId { get; set; }

            public DateTime BookingDate { get; set; }
        }

        public class Payment : BaseClass<int, DateTime>
        {
            public string PaymentType { get; set; }
        }

        public class TrainList : BaseClass<int, DateTime>
        {

            public string TrainNumber { get; set; }
            public string TrainName { get; set; }
            public int NoOfSeat { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
            public string ArrivalTime { get; set; }
            public string DeputureTime { get; set; }
        }
        public class Staff : BaseClass<int, DateTime>
        {
            public string StaffName { get; set; }

            public float StaffSalary { get; set; }

            public string StaffDepartment { get; set; }

        }

        public class WatingUser : BaseClass<int, DateTime>
        {

            public int UserId { get; set; }

            public int TrainListId { get; set; }

        }

        public class History : BaseClass<int, DateTime>
        {

            public int UserId { get; set; }

            public int PaymentId { get; set; }

            public int TrainID { get; set; }

            public int StaffId { get; set; }

        }

    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBooking.DataAccess;
using TrainBooking.Model;

namespace TrainBooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookingModel bookingModel = new BookingModel();
            //bookingModel.Amount = 2000;
            //Console.WriteLine(bookingModel.Amount);

            //new AdoNetExample().InsertUserDetail();
            //new UserDetailDataAccess().InsertUserDetail1();
            // new UserMappingDataAccess().InsertUserMapping();
            //new LocationMapDataAccess().InsertLocationMap();
            //new TrainDetailDataAccess().InserTrainDetail();
            //new PaymentDataAccess().InsertPayment();
            new BookingDataAccess().InsertBooking();
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User 
            {
                UserId=2,
                FirstName="Doğu",
                LastName="Bey",
                Email="fhdjfdjf",
                Password="jdfjdfg"
            }
            );
           /* CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {   
                CarId=5,
                BrandId=1,
                ColorId=2,
                ModelYear=1999,
                DailyPrice=4500,
                Description="Kullanıma uygun"
            }
            );
            Console.WriteLine("Eklendi");
           */
        }
/*
        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailDto())
            {
                Console.WriteLine(car.CarId + "/" + car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }*/
    }
}

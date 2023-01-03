using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId =1, BrandId= 1, ColorId =4, ModelYear=1999, DailyPrice=115, Description="Kullanıma uygun"},
                new Car{CarId =2, BrandId= 1, ColorId =1, ModelYear=2016, DailyPrice=220, Description="Kullanıma uygun değil"},
                new Car{CarId =3, BrandId= 2, ColorId =2, ModelYear=2005, DailyPrice=2200, Description="Kullanıma uygun"},
                new Car{CarId =4, BrandId= 1, ColorId =5, ModelYear=1989, DailyPrice=150, Description="Kullanıma uygun değil"},
                new Car{CarId =5, BrandId= 3, ColorId =2, ModelYear=2020, DailyPrice=1900, Description="Kullanıma uygun"},
                new Car{CarId =6, BrandId= 2, ColorId =3, ModelYear=2022, DailyPrice=115, Description="Kullanıma uygun değil"},
                new Car{CarId =7, BrandId= 1, ColorId =2, ModelYear=2021, DailyPrice=560, Description="Kullanıma uygun"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarBy(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.ModelYear = car.ModelYear;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.Description = car.Description;

        }

        List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }
    }
}

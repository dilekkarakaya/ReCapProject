using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //ICarService içerisindeki bütün işlemleri içermek zorundadır.
        //Business katmanı veri erişimde hangi frameworke bağlımlı oldugunu minimize ediyorum ICarDal kullanarak.
        ICarDal _carDal;
        public CarManager(ICarDal carDal)//veri erişim katmanına bir interface üzerinden bağlanıyorum.
        {
            _carDal = carDal; //bağımlılığı constructor injector ile yapıyorum.
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                return new SuccesResult(Messages.CarAdded);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDto());
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.BrandId == id));

        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == id));
        }
    }
}

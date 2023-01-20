using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(CheckIfColorNameExist(color.ColorName));
            if (result!=null)
            {
                return new ErrorResult(Messages.ColorNotAdded);
            }
            _colorDal.Add(color);
            return new SuccesResult(Messages.ColorAdded);
        }

        private IResult CheckIfColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccesResult();
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult();
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        ////IValidator validator,mesela productValidator buraya gelecek. 
        ///object hepsinin base'i buraya her şey gelebilir.
        {
            var context = new ValidationContext<object>(entity);
            //bir doğrulama contexti oluşturuyorum.
            var result = validator.Validate(context);
            //context buradaki entity
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect: MethodInterception //burada intherit ettim. bunun bir methodinterception olduğunu söylemek için 
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//validator type'ı veriyoruz
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
                //Eğer bir IValidator yani bir validatör verilmediyse uyarı verir.
                //Yani gönderilen validatortype bir IValidator değilse uyarı veriliyor.
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //reflection:çalışma anında bir şeyleri  çalıştırabilmemi sağlıyor.
            //Çalışma anında newleme yapmak istiyorsam bunu sağlar.
            //Burada bir validator instanceı oluşturuyorum.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //validator'ın basetype'ını bul, onun geneceric argumanlarından 0.cısını yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //metodun argümanlarını gez.
            //eğer ki oradaki tip benim entity tipim yani product türünde ise onları aşağıda validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

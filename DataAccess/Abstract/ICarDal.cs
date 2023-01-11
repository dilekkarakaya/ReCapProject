using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>//IentityRepositoy'i Car için yapılandırdın dermek
    {
        //Car'ın interface'ini oluşturdum.
        //Yani burada ben Car tablosunun Dal'ını yazıyorum(Data Accsess Layer)
        //ICarDal= yani bu benim car ile ilgili veri tabanında yapacağım
        //operasyonları içeren Interface. Operasyon(ekle çıkar sil güncelle listele getir vs.)
        List<CarDetailDto> GetCarDetailDto();
    }
}

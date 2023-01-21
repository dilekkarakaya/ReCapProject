using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using( ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result= from ca in context.Car
                            join b in context.Brand
                            on ca.BrandId equals b.BrandId
                            join re in context.Rentals
                            on ca.CarId equals re.CarId
                            join co in context.Color
                            on ca.ColorId equals co.ColorId
                            from u in context.Users
                            join cu in context.Customer
                            on u.UserId equals cu.UserId
                            select new RentalDetailDto
                            {
                                CarId = ca.CarId,
                                BrandId = b.BrandId,
                                ColorName = co.ColorName,
                                BrandName = b.BrandName,
                                ModelName = ca.ModelName,
                                RentalId = re.RentalId,
                                RentDate = re.RentDate,
                                ReturnDate = re.ReturnDate,
                                CustomerName = u.FirstName,
                                CustomerLastname = u.LastName

                            };
                return result.ToList();
            }
        }
    }
}

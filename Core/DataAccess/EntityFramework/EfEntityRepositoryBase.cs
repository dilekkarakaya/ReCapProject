using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
        // bana bir tane Entity tipi ver bir tanede context tipi ver.
        // TEntity= çalışacağım tablonun ne olduğunu söyle,
        // TContext=bir tane context tipi ver.ben ona göre çalışıcam
    {
        //Bana bir entity ver ve bunu hangi veritabanında işleme sokmak istiyosun onu söyle ki operasyonları tekrarlamıyım.
        //bir tabloyu ilgilendiren bütün operasyonalrı ttoplicaz
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //referasnı yakalama
                addedEntity.State = EntityState.Added;//ekle
                context.SaveChanges();//değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //referasnı yakalama
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)//tek data getirecek
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                // Db setimle product a bağlanıyorum(set) SingleOrDefault=> tek bir eleman bulmaya yarar
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Veri tabanındaki bütün veriyi listeye çevir ve onu bana getir.
                //(Select * from Products)
                return filter == null ? context.Set<TEntity>().ToList() //Set<>.()=>>>Bağlamda ve temeldeki depoda verilen türdeki
                                                                        //varlıklara erişim için bir DbSet<TEntity> örneği döndürür.

                    : context.Set<TEntity>().Where(filter).ToList();   //Buraya parametre göndereceğim şey lambda.
                                                                       //ben oraya neyazarsam yazayım onu getirecektir.
            }
        }

        public List<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //referasnı yakalama
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

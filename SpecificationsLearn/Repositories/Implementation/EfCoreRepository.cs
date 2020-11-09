using Microsoft.EntityFrameworkCore;
using SpecificationsLearn.Models;
using SpecificationsLearn.Options;
using SpecificationsLearn.RelationalDatabase;
using System;
using System.Linq;

namespace SpecificationsLearn.Repositories.Implementation
{
    public class EfCoreRepository<TModel> : IApplicationRepository<TModel>
        where TModel : ModelBase
    {
        private static ApplicationDbContext ApplicationDbContext
        {
            get
            {
                if(_applicationDbContext == default)
                {
                    var options = DataSourceOptions.ReadFromFile();
                    var dataProvider = (DataProvider)Enum.Parse(typeof(DataProvider), options.EfCoreDataProvider.DataProvider);

                    _applicationDbContext = ApplicationDbContextFactory.CreateNew(dataProvider, options.EfCoreDataProvider.ConnectionString);
                }

                return _applicationDbContext;
            }
        }

        private static ApplicationDbContext _applicationDbContext;

        public IQueryable<TModel> AsQueryable()
        {
            return ApplicationDbContext.Set<TModel>();
        }

        public void Delete(params TModel[] entities)
        {
            ApplicationDbContext.Set<TModel>().RemoveRange(entities);
            ApplicationDbContext.SaveChanges();
        }

        public void Insert(params TModel[] entities)
        {
            ApplicationDbContext.Set<TModel>().AddRange(entities);
            ApplicationDbContext.SaveChanges();
        }

        public void Update(params TModel[] entities)
        {
            foreach (var model in entities)
                ApplicationDbContext.Entry(model).State = EntityState.Modified;

            ApplicationDbContext.SaveChanges();
        }
    }
}

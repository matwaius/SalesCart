﻿using dotnet_api.Context;
using dotnet_api.Repository.Interfaces;
using System.Threading.Tasks;
namespace dotnet_api.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly dotnet_apiContext _context;

        public BaseRepository(dotnet_apiContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //using var transaction = _context.Database.BeginTransaction();
            //Task<int> ret= null;
            //try 
            //{
            //    transaction.CreateSavepoint("Begin");
            //    ret = _context.SaveChangesAsync();
            //    transaction.Commit();
            //}
            //catch (Exception)
            //{
            //    transaction.RollbackToSavepoint("BeforeMoreBlogs");
            //}

            return await _context.SaveChangesAsync() > 0;
        }

    }
}

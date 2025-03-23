﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Repositories
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>> selector);
       
        
        //IQueryable<TEntity> GetAllQueryable();


        TEntity? GetById(int id);
        int Update(TEntity entity);
    }
}

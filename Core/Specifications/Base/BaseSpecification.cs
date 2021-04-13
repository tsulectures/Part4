using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Base;
using Core.Interfaces.Specifications;

namespace Core.Specifications.Base
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        { 
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take {get; private set;}
        public int Skip {get; private set;}
        public bool IsPagingEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }

        protected void AddOrderBy(Expression<Func<T, object>> experssion)
        {
            OrderBy = experssion;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> experssion)
        {
            OrderByDescending = experssion;
        }

         protected void ApplyPaging(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }



    }
}
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

        protected void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }
    }
}
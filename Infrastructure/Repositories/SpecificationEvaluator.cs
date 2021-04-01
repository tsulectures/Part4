using System.Linq;
using Core.Entities.Base;
using Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SpecificationEvaluator<TEntity> where TEntity : Entity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> iQuery, ISpecification<TEntity> spec)
        {
            var query = iQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
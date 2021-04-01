using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Base;

namespace Core.Interfaces.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes {get; }
    }
}
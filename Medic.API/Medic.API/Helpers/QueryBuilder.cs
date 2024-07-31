using Medic.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Helpers
{
    public static class QueryBuilder
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (page < 1) page = 1;

            if (pageSize < 1) pageSize = 5;

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<User> ApplyChaining(this IQueryable<User> query)
        {
            return query.Include(x => x.Role);
        }
    }
}

using Api.Domain.Entities;
using Presistence.Repositories.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;


namespace Presistence.Repositories.Extensions
{
    public static class RepositoryProductExtensions
    {
        public static IQueryable<Product> FilterProductss(this IQueryable<Product>
            products, uint minPrice, uint maxPrice) =>
            products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

        public static IQueryable<Product> Search(this IQueryable<Product> products,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            var result = products.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
            return result;
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> products,
            string orderByQueryString)
        {
            // ?orderBy = name,age desc   => orderByQueryString = "name,age desc"
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(e => e.Price);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);


            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(e => e.Name);

            return products.OrderBy(orderQuery); // "Dynamic Query" => Library ==> System.Linq.Dynamic.Core"
        }
    }
}

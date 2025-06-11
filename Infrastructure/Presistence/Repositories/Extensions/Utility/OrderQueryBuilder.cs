using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories.Extensions.Utility
{
    public class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(','); // ["name", "age desc"]
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public |
                    BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0]; // "name"
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;

        }
    }
}

using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Market.Services
{
    static public class SortForNameAndPrice
    {

        static public List<Product> Sort<TKey>(List<Product> list, Func<Product, TKey> sorter, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                list = list.OrderBy(sorter).ToList();
            }
            else
            {
                list = list.OrderByDescending(sorter).ToList();
            }

            return list;
        }
    }
}
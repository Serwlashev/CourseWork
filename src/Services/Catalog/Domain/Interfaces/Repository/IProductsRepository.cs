﻿using ServicesShared.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Domain.Interfaces.Repository
{
    public interface IProductsRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> FindProductsAsync(string searchText);
    }
}
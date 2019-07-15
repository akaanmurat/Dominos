using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using Dominos.Data.Models;
using Dominos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Dominos.Common.Constants;

namespace Dominos.Business.ProductService
{
    public class ProductService : IProductService
    {
        public ProductService(IRepository<Product> productRepository,
                              IRepository<ProductType> productTypeRepository,
                              IMemoryCache cache)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _cache = cache;
        }

        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IMemoryCache _cache;

        public async Task<ResponseEntity<List<ProductOutputDTO>>> GetPizzas()
        {
            var response = new ResponseEntity<List<ProductOutputDTO>>();

            try
            {
                var products = await GetProductsFromCache();
                response.Result = products.Where(x => x.Type == "Pizza").ToList();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        private async Task<List<ProductOutputDTO>> GetProductsFromCache()
        {
            var products = _cache.Get<List<ProductOutputDTO>>(CacheKey.Products);

            if (products == null || !products.Any())
            {
                products = await (from p in _productRepository.Table
                                  join t in _productTypeRepository.Table on p.TypeId equals t.Id
                                  select new ProductOutputDTO
                                  {
                                      ImagePath = p.ImagePath,
                                      TypeId = p.TypeId,
                                      Price = p.Price,
                                      ProductId = p.Id,
                                      ProductName = p.ProductName,
                                      Type = t.Name,
                                      Description = p.Description
                                  })
                                 .AsNoTracking()
                                 .ToListAsync();

                if (products != null && products.Any())
                {
                    _cache.Set(CacheKey.Products, products);
                }
            }

            return products.Select(x => x.Clone()).ToList();
        }
    }
}
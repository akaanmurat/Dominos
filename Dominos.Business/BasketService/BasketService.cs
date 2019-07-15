using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using Dominos.Data.Models;
using Dominos.Data.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Dominos.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Dominos.Business.OrderService;
using Dominos.Common.DTO.Input;

namespace Dominos.Business.BasketService
{
    public class BasketService : IBasketService
    {
        public BasketService(IRepository<Basket> basketRepository,
                             IRepository<BasketDetail> basketDetailRepository,
                             IOrderService orderRepository,
                             IRepository<Product> productRepository)
        {
            _basketRepository = basketRepository;
            _basketDetailRepository = basketDetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<BasketDetail> _basketDetailRepository;
        private readonly IOrderService _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public async Task<ResponseEntity<BasketOutputDTO>> GetCustomerBasket(int? customerId, string basketKey)
        {
            var response = new ResponseEntity<BasketOutputDTO>();

            try
            {
                List<BasketDetailOutputDTO> basketdetails = await GetBasketDetails(customerId, basketKey);

                if (basketdetails != null || basketdetails.Any())
                {
                    return response;
                }

                var totalPrice = basketdetails.Sum(x => x.Price * x.Quantity);
                var discountPrice = default(double);

                if (customerId != null)
                {
                    var customerOrders = await _orderRepository.GetOrderList(customerId.Value);
                    discountPrice = customerOrders?.Result?.Any() == true ? discountPrice : totalPrice * 5 / 100;
                }

                totalPrice = totalPrice - discountPrice;

                response.Result = new BasketOutputDTO
                {
                    BasketDetails = basketdetails,
                    DiscountPrice = discountPrice,
                    TotalPrice = totalPrice
                };
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        private async Task<List<BasketDetailOutputDTO>> GetBasketDetails(int? customerId, string basketKey)
        {
            return await (from b in _basketRepository.Table
                                                            .WhereIf(customerId != null, x => x.CustomerId == customerId)
                                                            .WhereIf(customerId == null, x => x.BasketKey == basketKey)
                          join d in _basketDetailRepository.Table on b.Id equals d.BasketId
                          join p in _productRepository.Table on d.ProductId equals p.Id
                          where p.IsActive
                          select new BasketDetailOutputDTO
                          {
                              Price = p.Price,
                              ProductId = p.Id,
                              ProductName = p.ProductName,
                              Quantity = d.Quantity
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<ResponseEntity<bool>> AddProductToBasket(EditProductToBasketInputDTO input)
        {
            var response = new ResponseEntity<bool>();

            try
            {
                var basketDetail = await (from b in _basketRepository.Table
                                          join d in _basketDetailRepository.Table on b.Id equals d.BasketId
                                          where d.ProductId == input.ProductId && (b.CustomerId == input.CustomerId || b.BasketKey == input.BasketKey)
                                          select d)
                                          .FirstOrDefaultAsync();
                if (basketDetail != null)
                {
                    basketDetail.Quantity++;
                    await _basketDetailRepository.UpdateAsync(basketDetail);
                    response.Result = true;
                    return response;
                }

                var basket = await _basketRepository.Table.FirstAsync(x => x.CustomerId == input.CustomerId || x.BasketKey == input.BasketKey);
                if (basket == null)
                {
                    basket = new Basket
                    {
                        CustomerId = input.CustomerId,
                        BasketKey = input.BasketKey
                    };
                    await _basketRepository.InsertAsync(basket);
                }

                await _basketDetailRepository.InsertAsync(new BasketDetail
                {
                    BasketId = basket.Id,
                    ProductId = input.ProductId,
                    Quantity = (int)decimal.One
                });
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<ResponseEntity<bool>> DecreaseProductFromBasket(EditProductToBasketInputDTO input)
        {
            var response = new ResponseEntity<bool>();

            try
            {
                var basketDetail = await (from b in _basketRepository.Table
                                          join d in _basketDetailRepository.Table on b.Id equals d.BasketId
                                          where d.ProductId == input.ProductId && (b.CustomerId == input.CustomerId || b.BasketKey == input.BasketKey)
                                          select d)
                                          .FirstOrDefaultAsync();

                if (basketDetail != null && basketDetail.Quantity > (int)decimal.One)
                {
                    basketDetail.Quantity--;
                    await _basketDetailRepository.UpdateAsync(basketDetail);
                }
                else if (basketDetail != null && basketDetail.Quantity == (int)decimal.One)
                {
                    await _basketDetailRepository.DeleteAsync(basketDetail);
                }

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<ResponseEntity<bool>> DeleteProductFromBasket(EditProductToBasketInputDTO input)
        {
            var response = new ResponseEntity<bool>();

            try
            {
                var basketDetail = await (from b in _basketRepository.Table
                                          join d in _basketDetailRepository.Table on b.Id equals d.BasketId
                                          where d.ProductId == input.ProductId && (b.CustomerId == input.CustomerId || b.BasketKey == input.BasketKey)
                                          select d)
                                          .FirstOrDefaultAsync();

                if (basketDetail != null)
                {
                    await _basketDetailRepository.DeleteAsync(basketDetail);
                }

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Exception = ex;
                response.HttpCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
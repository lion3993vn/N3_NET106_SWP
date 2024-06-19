﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET1806_LittleJoy.API.ViewModels.RequestModels;
using NET1806_LittleJoy.API.ViewModels.ResponeModels;
using NET1806_LittleJoy.Repository.Commons;
using NET1806_LittleJoy.Service.BusinessModels;
using NET1806_LittleJoy.Service.Services;
using NET1806_LittleJoy.Service.Services.Interface;
using Newtonsoft.Json;

namespace NET1806_LittleJoy.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetListProductPagingAsync([FromQuery] PaginationParameter paginationParameter)
        {
            try
            {
                var result = await _productService.GetAllProductPagingAsync(paginationParameter);

                if (result != null)
                {
                    var metadata = new
                    {
                        result.TotalCount,
                        result.PageSize,
                        result.CurrentPage,
                        result.TotalPages,
                        result.HasNext,
                        result.HasPrevious
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModels
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product is empty"
                    });
                }
            }
            catch (Exception ex)
            {
                var responseModel = new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(responseModel);
            }
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductByIdAsync(int Id)
        {
            try
            {
                var productDetailModel = await _productService.GetProductByIdAsync(Id);
                if (productDetailModel == null)
                {
                    return NotFound(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product does not exist"
                    });
                }
                return Ok(productDetailModel);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }


        [HttpPost]
        //[Authorize(Roles = "STAFF,ADMIN")]
        public async Task<IActionResult> AddNewProductAsync([FromBody] ProductRequestModel productRequestModel)
        {
            try
            {
                // validation
                if (string.IsNullOrEmpty(productRequestModel.ProductName))
                {
                    return BadRequest(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "The product name is required."
                    });
                }

                if (productRequestModel.Price <= 0)
                {
                    return BadRequest(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "The price must be valid."
                    });
                }

                ProductModel productModel = new ProductModel()
                {
                    ProductName = productRequestModel.ProductName,
                    Price = productRequestModel.Price,
                    Description = productRequestModel.Description,
                    Weight = productRequestModel.Weight,
                    Quantity = productRequestModel.Quantity,
                    Image = productRequestModel.Image,
                    AgeId = productRequestModel.AgeId,
                    OriginId = productRequestModel.OriginId,
                    BrandId = productRequestModel.BrandId,
                    CateId = productRequestModel.CateId,
                };

                var result = await _productService.AddNewProductAsync(productModel);

                if (result)
                {
                    return Ok(new ResponseModels
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Product added successfully"
                    });
                }
                else
                {
                    return NotFound(new ResponseModels
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Failed to add the Product"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }


        [HttpDelete]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> RemoveProductByIdAsync(int Id)
        {
            try
            {
                var result = await _productService.DeleteProductByIdAsync(Id);
                if (result)
                {
                    return Ok(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status200OK,
                        Message = "Remove product success"
                    });
                }
                else
                {
                    return NotFound(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "The product is not exist"
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }


        [HttpPut]
        //[Authorize(Roles = "STAFF,ADMIN")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductModel productModel)
        {
            try
            {

                if (productModel.Price <= 0)
                {
                    return BadRequest(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status400BadRequest,
                        Message = "The price must be valid."
                    });
                }

                ProductModel productModelChange = new ProductModel()
                {
                    Id = productModel.Id,
                    ProductName = productModel.ProductName,
                    Price = productModel.Price,
                    Description = productModel.Description,
                    Weight = productModel.Weight,
                    Quantity = productModel.Quantity,
                    Image = productModel.Image,
                    IsActive = productModel.IsActive,
                    AgeId = productModel.AgeId,
                    OriginId = productModel.OriginId,
                    BrandId = productModel.BrandId,
                    CateId = productModel.CateId,
                    UnsignProductName = productModel.UnsignProductName,
                };

                var result = await _productService.UpdateProductAsync(productModelChange);

                if (result == null)
                {
                    return NotFound(new ResponseModels()
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "The product does not exist."
                    });
                }

                return Ok(new ResponseModels()
                {
                    HttpCode = StatusCodes.Status200OK,
                    Message = "Update product success"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                });
            }
        }


        /// <summary>
        /// Sort Order:
        ///     1 - Hàng mới |
        ///     2 - Giá tiền Cao đến thấp |
        ///     3 - Giá tiền Thấp đến cao
        /// </summary>
        [HttpGet("filter")]
        public async Task<IActionResult> FilterProductPagingAsync([FromQuery] PaginationParameter paging, [FromQuery] ProductFilterModel model)
        {
            try
            {
                var result = await _productService.FilterProductPagingAsync(paging, model);

                if (result != null)
                {
                    var metadata = new
                    {
                        result.TotalCount,
                        result.PageSize,
                        result.CurrentPage,
                        result.TotalPages,
                        result.HasNext,
                        result.HasPrevious
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModels
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product is empty"
                    });
                }
            }
            catch (Exception ex)
            {
                var responseModel = new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(responseModel);
            }
        }


        [HttpGet("product-out-of-stock")]
        public async Task<IActionResult> GetListProductOutOfStockPagingAsync([FromQuery] PaginationParameter paginationParameter)
        {
            try
            {
                var result = await _productService.GetAllProductOutOfStockPagingAsync(paginationParameter);

                if (result != null)
                {
                    var metadata = new
                    {
                        result.TotalCount,
                        result.PageSize,
                        result.CurrentPage,
                        result.TotalPages,
                        result.HasNext,
                        result.HasPrevious
                    };

                    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                    return Ok(result);
                }
                else
                {
                    return NotFound(new ResponseModels
                    {
                        HttpCode = StatusCodes.Status404NotFound,
                        Message = "Product is empty"
                    });
                }
            }
            catch (Exception ex)
            {
                var responseModel = new ResponseModels()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message.ToString()
                };
                return BadRequest(responseModel);
            }
        }


    }
}

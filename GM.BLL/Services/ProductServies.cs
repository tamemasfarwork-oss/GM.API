using GM.BLL.DTOs.ProductDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GM.BLL.Services
{
    public class ProductServies : IproductServies
    {
        private readonly IPrductRepo _repo;
        private readonly IFileService _fileService;

        public ProductServies(IPrductRepo repo, IFileService fileService)
        {
            _repo = repo;
            _fileService = fileService;
        }

        public async Task<int> AddProductServies(AddProductDto dto)
        {
            string? imageUrl = null;

            if (dto.Image != null)
                imageUrl = await _fileService.SaveImageAsync(dto.Image, "products");

            var product = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Quantity = dto.Quantity,
                CostPrice = dto.CostPrice,
                describetion=dto.describe,
                ImageUrl = imageUrl
            };

            try
            {
                return await _repo.AddProduct(product);
            }
            catch
            {
                _fileService.DeleteFile(imageUrl);
                throw;
            }
        }

        public async Task<List<GetItemsDto>> GetItemsServies(int pagenumber,int pagesize)
        {


            return await _repo.GetProducts(pagenumber, pagesize, p => new GetItemsDto
            {
                ProductId = p.ProductId,
                Price = p.Price,
                CostPrice = p.CostPrice,
                describetion = p.describetion,
                ImageUrl = p.ImageUrl,
                ProductName = p.ProductName,
                Quantity = p.Quantity
            });
        }

        public async Task<GetItemsDto> GetProductByIDServies(int productsid)
        {

            var result = await _repo.GetProductsByidRepo(productsid);

            return new GetItemsDto
            {
                Price = result.Price,
                CostPrice = result.CostPrice,
                describetion = result.describetion,
                ImageUrl = result.ImageUrl,
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                Quantity = result.Quantity
            };
        }
    }
}

using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using AutoMapper;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);


            unitOfWork.Product.Create(product);
            var result = await unitOfWork.CompleteAsync();
            Console.WriteLine(result);
            return productDto; 

        }

        public async Task DeleteProduct(int id)
        {
            var product = await unitOfWork.Product.GetProductByIdAsync(id, trackChanges: true);

            unitOfWork.Product.DeleteProduct(product);

            await unitOfWork.CompleteAsync();
            return;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await unitOfWork.Product.GetAllProductsAsync(trackChanges);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;

        }

        public async Task<ProductDto> GetByIdAsync(int id, bool trackChanges)
        {
            var product = await unitOfWork.Product.GetProductByIdAsync(id, trackChanges);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            unitOfWork.Product.Update(product);
            await unitOfWork.CompleteAsync();
            return;
        }
    }
}

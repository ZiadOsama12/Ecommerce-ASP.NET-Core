using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Domain.Responses;
using Api.Services.Contracts;
using AutoMapper;
using Shared.DTOs;
using Shared.RequestFeatures;
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

        public async Task<(ApiBaseResponse response, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await unitOfWork.Product.GetAllProductsAsync(productParameters ,trackChanges);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return (new ApiOkResponse<IEnumerable<ProductDto>>(productsDto), products.MetaData);

        }

        public async Task<ApiBaseResponse> GetByIdAsync(int id, bool trackChanges)
        {
            var product = await unitOfWork.Product.GetProductByIdAsync(id, trackChanges);
            var productDto = mapper.Map<ProductDto>(product);
            return new ApiOkResponse<ProductDto>(productDto);
        }

        

        public async Task<(ApiBaseResponse response, MetaData metaData)> GetProductsByCategoryId(int id, ProductParameters productParameters,
            bool trackChanges)
        {
            var products = await unitOfWork.Product.GetProductsByCategoryAsync(productParameters ,id);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            
            return (new ApiOkResponse<IEnumerable<ProductDto>>(productsDto), products.MetaData);
        }

        public async Task<(ProductDto productToPatch, Product product)> GetProductByIdToPatchAsync(int id, bool trackChanges)
        {
            var product = await unitOfWork.Product.GetProductByIdAsync(id, trackChanges);
            var productDto = mapper.Map<ProductDto>(product);
            await unitOfWork.CompleteAsync();

            return (productDto, product);
        }
        public async Task SaveChangesForPatch(ProductDto productToPatch, Product productEntity)
        {
            mapper.Map(productToPatch, productEntity);
            var result = await unitOfWork.CompleteAsync();
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

using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public void AddProduct(ProductViewModel productViewModel)
        {
            var mapProduct = _mapper.Map<Domain.Entities.Product>(productViewModel);
            _productRepository.Add(mapProduct);
        }

        public void DeleteProduct(int? id)
        {
            var result =  _productRepository.GetById(id.Value).Result;
            _productRepository.Delete(result);
        }

        public async Task<ProductViewModel> GetProductById(int? id)
        {
            var result = await _productRepository.GetById(id.Value);
            return _mapper.Map<ProductViewModel>(result);
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var result = await _productRepository.GetProducts();
            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        public  Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
        {
            var result = _mapper.Map<Domain.Entities.Product>(productViewModel);
            return Task.FromResult(_mapper.Map<ProductViewModel>(_productRepository.Update(result)));
        }
    }
}

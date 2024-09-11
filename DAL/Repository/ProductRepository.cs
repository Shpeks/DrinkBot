using API.Repository;
using Core.DTO;
using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductDto> GetAllProducts()
        {
            var productEntity = _context.Products.ToList();
            if (productEntity == null) return null;

            return productEntity.Select(b => new ProductDto
            {
                Id = b.Id,
                BrandId = b.BrandId,
                ImagePath = b.ImagePath,
                Name = b.Name,
                Price = b.Price,
                Count = b.Count
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            var productEntity = _context.Products.Find(id);
            if (productEntity == null) return null;

            return new ProductDto
            {
                Id = productEntity.Id,
                BrandId = productEntity.BrandId,
                ImagePath = productEntity.ImagePath,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Count = productEntity.Count
            };
        }
        public void UpdateProductAsync(ProductDto productDto)
        {
            var productEntity = _context.Products.FirstOrDefault(b => b.Id == productDto.Id);
            if (productEntity == null) return;

            productEntity.BrandId = productDto.BrandId;
            productEntity.ImagePath = productDto.ImagePath;
            productEntity.Name = productDto.Name;
            productEntity.Price = productDto.Price;
            productEntity.Count = productDto.Count;

            _context.SaveChanges();
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            var productEntity = new Product
            {
                BrandId = productDto.BrandId,
                ImagePath = productDto.ImagePath,
                Name = productDto.Name,
                Price = productDto.Price,
                Count = productDto.Count
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

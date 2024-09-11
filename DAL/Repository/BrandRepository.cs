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
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BrandDto> GetAllBrands()
        {
            var brandEntity = _context.Brands.ToList();
            if (brandEntity == null) return null;

            return brandEntity.Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();
        }

        public BrandDto GetBrandById(int id)
        {
            var brandEntity = _context.Brands.Find(id);
            if (brandEntity == null) return null;

            return new BrandDto
            {
                Id = brandEntity.Id,
                Name = brandEntity.Name
            };
        }
        public void UpdateBrandAsync(BrandDto brandDto)
        {
            var brandEntity = _context.Brands.FirstOrDefault(b => b.Id == brandDto.Id);
            if (brandEntity == null) return;

            brandEntity.Name = brandDto.Name;
            _context.SaveChanges();
        }

        public async Task CreateBrandAsync(BrandDto brandDto)
        {
            var brandEntity = new Brand
            {
                Name = brandDto.Name,
            };

            await _context.Brands.AddAsync(brandEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(int id)
        {
            var brandEntity = await _context.Brands.FindAsync(id);
            if (brandEntity != null)
            {
                _context.Brands.Remove(brandEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

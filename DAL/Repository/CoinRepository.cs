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
    public class CoinRepository : ICoinRepository
    {
        private readonly ApplicationDbContext _context;
        public CoinRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CoinDto> GetAllCoins()
        {
            var coinEntity = _context.Coins.ToList();
            if (coinEntity == null) return null;

            return coinEntity.Select(b => new CoinDto
            {
                Id = b.Id,
                Count = b.Count,
                ImagePath = b.ImagePath,
                Denomination = b.Denomination,
            }).ToList();
        }

        public CoinDto GetCointById(int id)
        {
            var coinEntity = _context.Coins.Find(id);
            if (coinEntity == null) return null;

            return new CoinDto
            {
                Id = coinEntity.Id,
                Count = coinEntity.Count,
                ImagePath = coinEntity.ImagePath,
                Denomination = coinEntity.Denomination
            };
        }
        public void UpdateCoinAsync(CoinDto coinDto)
        {
            var coinEntity = _context.Coins.FirstOrDefault(b => b.Id == coinDto.Id);
            if (coinEntity == null) return;

            coinEntity.Count = coinDto.Count;
            coinEntity.ImagePath = coinDto.ImagePath;
            coinEntity.Denomination = coinDto.Denomination;
            _context.SaveChanges();
        }

        public async Task CreateCoinAsync(CoinDto coinDto)
        {
            var coinEntity = new Coin
            {
                Count = coinDto.Count,
                ImagePath = coinDto.ImagePath,
                Denomination = coinDto.Denomination
            };

            await _context.Coins.AddAsync(coinEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoinAsync(int id)
        {
            var coinEntity = await _context.Coins.FindAsync(id);
            if (coinEntity != null)
            {
                _context.Coins.Remove(coinEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

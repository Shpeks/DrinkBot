using Core.DTO;

namespace API.Repository
{
    public interface ICoinRepository
    {
        Task CreateCoinAsync(CoinDto coinDto);
        Task DeleteCoinAsync(int id);
        List<CoinDto> GetAllCoins();
        CoinDto GetCointById(int id);
        void UpdateCoinAsync(CoinDto coinDto);
    }
}
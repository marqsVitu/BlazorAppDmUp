using BlazorAppDmUp.Models;

namespace BlazorAppDmUp.Services
{
    public interface ISpendService
    {
        Task<List<Spend>> GetSpendsAsync();
        Task SaveSpends(List<Spend> spends);
    }
}

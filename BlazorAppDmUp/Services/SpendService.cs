using BlazorAppDmUp.Models;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorAppDmUp.Services
{
	//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
	public class SpendService : ISpendService
    {
        private readonly ILocalStorageService _storageService;
        public SpendService(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        private string _spendLocalSotorageKey = "spendKey";

        public async Task<List<Spend>> GetSpendsAsync()
        {
            var spendJson = await _storageService.GetItemAsync<string>(_spendLocalSotorageKey);
            if (string.IsNullOrEmpty(spendJson))
                return new();

            return JsonSerializer.Deserialize<List<Spend>>(spendJson);
        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendJson = JsonSerializer.Serialize(spends);

            await _storageService.SetItemAsync(_spendLocalSotorageKey, spendJson);
        }
    }
}

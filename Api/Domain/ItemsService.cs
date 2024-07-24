namespace Api.Domain;

public class ItemsService : IItemsService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;
    private readonly string _apiHeader = "X-Functions-Key";
    private readonly string _apiKey;
    public ItemsService(IConfiguration configuration)
    {
        _apiKey = configuration["ApiSettings:Key"];
        _baseAddress = configuration["ApiSettings:Url"];
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseAddress)
        };
    }
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        _httpClient.DefaultRequestHeaders.Add(_apiHeader, _apiKey);
        HttpResponseMessage response = await _httpClient.GetAsync(_baseAddress + "api/fetch");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<IEnumerable<ItemDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new InvalidOperationException("Failed to deserialize response to IEnumerable<ItemDto>.");
    }

    public async Task<IEnumerable<ItemDto>> PostItemsAsync(string[] itemIds)
    {
        IEnumerable<ItemDto> items = await GetItemsAsync();

        IEnumerable<ItemDto> selectedItems = items
            .Where(item => itemIds
            .Contains(item.Id))
            .ToList();

        return selectedItems;
    }
}

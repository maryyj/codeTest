namespace Api.Domain;

public interface IItemsService
{
    Task<IEnumerable<ItemDto>> GetItemsAsync();
    Task<IEnumerable<ItemDto>> PostItemsAsync(string[] itemIds);
}

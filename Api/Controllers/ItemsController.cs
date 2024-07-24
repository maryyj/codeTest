namespace Api.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemService;

    public ItemsController(IItemsService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
    {
        try
        {
            IEnumerable<ItemDto> items = await _itemService.GetItemsAsync();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ItemDto>>> Post([FromForm] string[] itemIds)
    {
        try
        {
        IEnumerable<ItemDto> selectedItems = await _itemService.PostItemsAsync(itemIds);
        return Ok(selectedItems);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
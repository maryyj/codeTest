using Api.Domain;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        public ItemsController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
        {
            // TODO: Return items fetched from external API
            return Array.Empty<ItemDto>();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Post([FromForm]string[] items)
        {
            // TODO: Return a list of the items selected based on the "items" array posted from the frontend
            return Array.Empty<ItemDto>();
        }
    }
}
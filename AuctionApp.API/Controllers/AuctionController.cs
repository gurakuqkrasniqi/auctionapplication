using AuctionApp.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {


        [HttpPost("createAuction")]
        public async Task<IActionResult> CreateAuction(CreateAuctionDto createAuctionDto)
        {
            var result = await _auctionService.CreateAuction(createAuctionDto);
            return Ok(result);
        }
    }
}

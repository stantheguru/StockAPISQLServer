using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAPISQL.DBOperations;
using StockAPISQL.Models;
using System.Net;

namespace StockAPISQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TickerController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetTickers")]
        public async Task<ActionResult<List<DBTicker>>> Get()
        {
            var List = await _context.tickers.Select(
                ticker => new DBTicker
                {
                    Id = ticker.Id,
                    StockName = ticker.StockName,
                    TickerName = ticker.TickerName
                }
                ).ToListAsync();

            if(List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpPost("InsertTicker")]
        public async Task<HttpStatusCode> InsertTicker(DBTicker ticker)
        {
            var entity = new Ticker()
            {
               
                StockName = ticker.StockName,
                TickerName = ticker.TickerName
            };

            _context.tickers.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;   
        }

        

}
}

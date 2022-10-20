using System.ComponentModel.DataAnnotations;

namespace StockAPISQL.DBOperations
{
    public class DBTicker
    {
        public int Id { get; set; }

       
        public string TickerName { get; set; }

        
        public string StockName { get; set; }
    }
}

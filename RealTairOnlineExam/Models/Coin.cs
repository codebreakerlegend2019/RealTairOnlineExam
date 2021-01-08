using System;
using System.Collections.Generic;
using System.Text;

namespace RealTairOnlineExam.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public CoinDescription Description { get; set; }
        public MarketData Market_Data { get; set; }
        public CoinImage Image { get; set; }
    }
}

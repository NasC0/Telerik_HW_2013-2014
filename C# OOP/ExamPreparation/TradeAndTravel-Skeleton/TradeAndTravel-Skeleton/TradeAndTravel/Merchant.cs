using System;

namespace TradeAndTravel
{
    public class Merchant : Person, IShopkeeper, ITraveller
    {
        public Merchant(string name, Location location)
            :base(name, location)
        {
            
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

        public int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }
    }
}

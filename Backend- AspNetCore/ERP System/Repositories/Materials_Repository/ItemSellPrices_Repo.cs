using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSellPrices_Repo 
    {
        Application_Identity_DbContext Db_Context;
        public ItemSellPrices_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public bool IsPriceSet(Item item_, TradeState TradeState_, ConsumeUnit ConsumeUnit_, SellType SellType_)
        {
            throw new NotImplementedException();
        }

        public bool SetItemPrice(Item item_, TradeState TradeState_, ConsumeUnit ConsumeUnit_, SellType SellType_, double price)
        {
            throw new NotImplementedException();
        }

        public bool UNSetItemPrice(Item item_, TradeState TradeState_, ConsumeUnit ConsumeUnit_, SellType SellType_)
        {
            throw new NotImplementedException();
        }

        public double? GetPrice(Item item, TradeState TradeState_, SellType SellType_, ConsumeUnit ConsumeUnit_)
        {
            throw new NotImplementedException();
        }
        public List<ItemSellPriceS> GetItemPrices(Item item_, TradeState TradeState_)
        {
            throw new NotImplementedException();

        }
        public List<ItemSellPriceS> GetItemPrices(Item item_)
        {
            throw new NotImplementedException();

        }
    }
}

using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemINSellPrice_Repo
    {
        Application_Identity_DbContext DbContext;
        public ItemINSellPrice_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public bool IsPriceSet(ItemIN ItemIN_, ConsumeUnit ConsumeUnit_, SellType SellType_)
        {
            throw new NotImplementedException();
        }
        public bool SetItemINPrice(ItemIN ItemIN_, ConsumeUnit ConsumeUnit_, SellType SellType_, double price)
        {
            throw new NotImplementedException();
        }
        public bool UNSetBuyOPRPrice(ItemIN ItemIN_, ConsumeUnit ConsumeUnit_, SellType SellType_)
        {
            throw new NotImplementedException();
        }
        public double? GetPrice(ItemIN ItemIN_, SellType SellType_, ConsumeUnit ConsumeUnit_)
        {
            throw new NotImplementedException();
        }
        public List<ItemINSellPrice> GetItemINPrices(ItemIN ItemIN_)
        {
            throw new NotImplementedException();
        }
        internal bool ClearINSellPrices(ItemIN ItemIN_)
        {
            throw new NotImplementedException();
        }
    }
}

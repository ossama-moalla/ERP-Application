using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemImage_Repo
    {
        Application_Identity_DbContext Db_Context;
        public ItemImage_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public byte[] GetItemImage(int ItemID)
        {
            byte[] image = { 0x00 };
            return image;
        }
        public void SetItemImage(int ItemID, byte[] Image_)
        {

        }
        public void UnSetItemImage(int ItemID)
        {

        }
    }
}

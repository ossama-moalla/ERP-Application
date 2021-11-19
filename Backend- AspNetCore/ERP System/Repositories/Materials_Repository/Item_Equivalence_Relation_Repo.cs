using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Item_Equivalence_Relation_Repo 
    {
        Application_Identity_DbContext Db_Context;
        public Item_Equivalence_Relation_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public bool Set_Item_Equivalence_Relation(Item Item_, Equivalence_Group Equivalence_Group_)
        {
            throw new NotImplementedException();
        }

        public List<Item_Equivalence_Relation> Get_Item_Equivalence_Relation_By_Item(Item item_)
        {
            throw new NotImplementedException();
        }

        public List<Item_Equivalence_Relation> Get_Item_Equivalence_Relation_By_Group(Equivalence_Group Equivalence_Group_)
        {
            throw new NotImplementedException();
        }

        public Item_Equivalence_Relation GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public bool UNSet_Item_Equivalence_Relation(int Itemid_, int Equivalence_Groupid_)
        {
            throw new NotImplementedException();

        }
        public void Delete_Item_Equivalence_Relation_For_Group(int Equivalence_GroupID)
        {
            throw new NotImplementedException();

        }
    }
}

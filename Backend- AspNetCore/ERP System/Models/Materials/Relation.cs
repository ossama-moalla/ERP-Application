using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    public class Relation
    {//public const uint ITEM_EQUAL = 0;
        public const uint ITEM_CONTAIN = 1;
        public const uint ITEM_FOUNDIN = 2;
        public  uint Value { get; set; }
        public  string Name { get; set; }
 
        public static List<Relation> GetRealtions()
        {
            List<Relation> RelationList = new List<Relation>();
            //RelationList.Add(new Relation(Relation.ITEM_EQUAL, "مكافىء"));
            RelationList.Add(new Relation { Value = Relation.ITEM_CONTAIN, Name = "يحتوي" });
            RelationList.Add(new Relation { Value = Relation.ITEM_FOUNDIN, Name = "موجود في" });
            return RelationList;
        }
        public static Relation GetRealtionByValue(uint value)
        {
            switch (value)
            {
                //case ITEM_EQUAL:
                //    return new Relation(ITEM_EQUAL, "مكافىء"); 
                case ITEM_CONTAIN:
                    return new Relation { Value = ITEM_CONTAIN, Name = "يحوي" };
                case ITEM_FOUNDIN:
                    return new Relation { Value = ITEM_FOUNDIN, Name = "موجود في" };
                default:
                    return null;
            }
        }

        //public static void FillComboBox(ref System.Windows.Forms.ComboBox combobox)
        //{
        //    if (combobox == null) combobox = new System.Windows.Forms.ComboBox();
        //    combobox.Items.Clear();

        //    combobox.Items.Add(new ComboboxItem("الكل", 0));
        //    List<Relation> RelationList = Relation.GetRealtions();
        //    for (int i = 0; i < RelationList.Count; i++)
        //    {
        //        ComboboxItem comboboxitem = new ComboboxItem(RelationList[i].Name, RelationList[i].Value);
        //        combobox.Items.Add(comboboxitem);
        //    }
        //    combobox.SelectedIndex = 0;
        //}
    }
}

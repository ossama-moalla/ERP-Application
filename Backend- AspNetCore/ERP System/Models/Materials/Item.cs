using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public ItemCategory Category { get; set; }
        public string MarketCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string DefaultConsumeUnit { get; set; }
        //public byte[] ItemImage;

       
        //public string GetItemFullName()
        //{
        //    return folder.FolderName + ":" + " [" + ItemCompany + "]-[" + ItemName + "]";
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemFile
    {
        public Item Item_ { get; set; }
        [Key]
        public UInt32 FileID { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public long FileSize { get; set; }
        public DateTime AddDate { get; set; }
    

    }

}

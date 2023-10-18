using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANGIAY.Models
{
    [Table("ItemInfo")]
    public class ItemInfo
    {
        [Key]
        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public int Size { get; set; }
 
        public string Color { get; set; }
        public int StockQuantity { get; set; }

        public int Price { get; set; }

        public string MoreInfo { get; set; }

        public string ImagePath { get; set; }
    }
}

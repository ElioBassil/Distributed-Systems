using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }

        public DateTime TimeStamp { get; set; } 


        
        public string Amount { get; set; }

        public string Description { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
        
    }
}

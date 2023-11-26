using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 


        public string price { get; set; }

        //public int StoreId { get; set; }
        //public Store Store { get; set; }    

    }
}

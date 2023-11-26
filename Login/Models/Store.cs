using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }

        //public virtual ICollection<Product>? Products { get; set; }


    }
}

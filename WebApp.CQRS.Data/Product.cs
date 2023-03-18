using System;

namespace WebApp.CQRS.Data
{
    public class Product
    {
        public Product()
        {
            AddedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; private set; }
    }
}

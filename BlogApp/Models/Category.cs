// Models/Category.cs
using System;

namespace BlogApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDescription { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}


using System;

namespace AA_API.Sites.Models
{
    public class Site
    {
        public int id { get; set; }
        
        public string nombre { get; set; }

        public string user { get; set; }

        public DateTime createdAt { get; set; }

        public string password { get; set; }

        public string description { get; set; }

        public int idCategory { get; set; }

    }
}

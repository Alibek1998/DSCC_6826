using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWarehouse.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

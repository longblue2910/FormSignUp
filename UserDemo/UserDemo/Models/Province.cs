using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserDemo.Models
{
    [Table("province")]
    public class Province
    {
        public int id { get; set; }
        public string _name { get; set; }

    }
}

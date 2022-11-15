using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP.Data
{
    public class DataModel
    {
        [Key]
        public int ID { get; set; }
        public string IP { get; set; }
        public string Data { get; set; }
    }
}

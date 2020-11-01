using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Cevap.Models
{
    public class PersonViewModel
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Models
{
    public class Card
    {
        public Guid CardNumber { get; set; }
        public string Password {  get; set; }
        public decimal Balance { get; set; }

    }
}

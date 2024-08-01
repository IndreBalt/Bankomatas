using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Models
{
    internal class Transaction
    {
        public Guid CardNumber { get; set; }
        public DateTime DateMade { get; set; }
        public decimal Amount { get; set; }
    }
}

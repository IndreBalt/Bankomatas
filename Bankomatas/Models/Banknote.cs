using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Models
{
    internal class Banknote
    {
        public int Value { get; set; }
        public int Count { get; set; }
        public Banknote(int value, int count) 
        {
            Value = value;
            Count = count;
        }

      
    }
}

using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Services
{
    internal interface ITransactinService
    {
        public string AddTransactionToCsv(Card card, decimal amount);
        public List<Transaction> GetTransactionFromCsv();
    }
}

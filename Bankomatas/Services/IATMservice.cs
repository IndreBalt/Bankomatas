using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Bankomatas.Services
{
    public interface IATMservice
    {   
        public decimal GetBalance(Card card);
        public List<string> GetFiveTransaction(Card card);
        public decimal TakeMoney(Card card, decimal amount);
        public Card CardInsertValidation(Guid cardNumber);
        public Card CardPasswordValidation(string password, Card card);
    }
}

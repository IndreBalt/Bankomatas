using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Services
{
    internal interface ICardInfoService
    {
        public List<string> AddCardsInfoToCsv(List<Card> cards);
        public List<Card> GetCardsListFromCsv();
    }
}

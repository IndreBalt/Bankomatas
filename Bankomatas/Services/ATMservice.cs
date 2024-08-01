using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Services
{
    public class ATMservice(string filePathTrans, string filePathCards) : IATMservice
    {
        private string _filePathCards = filePathCards;
        private string _filePathTrans = filePathTrans;
        private CardInfoService _cardInfoService;
        private TransactionService _transactionService;
        private CashRegisterService _cashRegisterService;
     

        public decimal GetBalance(Card card)
        {
            return card.Balance;
        }     
        public decimal TakeMoney(Card card, decimal amount)//išima pinigus iš bankomato, įrašo transakciją, atnaujina balansą
        {
            if(card.Balance > amount)
            {
                _cashRegisterService = new CashRegisterService();
                List<Banknote> dispensedBanknotes = _cashRegisterService.TakeBanknotesFromCashregister(amount);
                if(dispensedBanknotes.Count != 0)
                {
                    _transactionService = new TransactionService(_filePathTrans);
                    _transactionService.AddTransactionToCsv(card, -amount);                    
                    _cardInfoService = new CardInfoService(_filePathCards);
                    List<Card> cardsListFromCSV = _cardInfoService.GetCardsListFromCsv();
                    cardsListFromCSV.RemoveAt(cardsListFromCSV.FindIndex(x => x.CardNumber == card.CardNumber));//pasalinam kortele is saraso
                    card.Balance-= amount;
                    cardsListFromCSV.Add(card);// įdeda kortelę į sąrašą su atnaujintu balansu
                    _cardInfoService.AddCardsInfoToCsv(cardsListFromCSV); //perrašo csv su naujais duomenim  
                }              
                return amount;
            }
            else
            {
                Console.WriteLine("Sąskaitos likutis per mažas");
                return 0;
            }
        }
        public List<string> GetFiveTransaction(Card card)
        {
            int iterator = 0;
            _transactionService = new TransactionService(_filePathTrans);
            List<Transaction> transactionsList = _transactionService.GetTransactionFromCsv().OrderByDescending(x => x.DateMade).ToList();
            
            List<string> fiveLastTransactions = new List<string>();
            foreach (Transaction transaction in transactionsList)
            {
                List<Transaction> transactionStringList = new List<Transaction>();               
                if ((card.CardNumber).Equals(transaction.CardNumber))
                {
                    string transactionString = $" {transaction.DateMade}, {transaction.Amount}";
                    fiveLastTransactions.Add(transactionString);
                    Console.WriteLine(transactionString);
                    iterator++;
                    if (iterator == 5)
                    {                       
                        break;
                    }
                }
            }
            if(fiveLastTransactions.Count == 0) 
            {
                Console.WriteLine("Transakcijų nėra");
                Console.WriteLine();
            }
            
            return fiveLastTransactions;
        }
        public Card CardInsertValidation(Guid cardNumber)//kortelės numerio validacija
        {
            _cardInfoService = new CardInfoService(_filePathCards);

            List<Card>? cardsFromCsv = new List<Card>();
            Card validCard = new Card();
            Card notValidCard = new Card();
            if (cardNumber == Guid.Empty)
            {
                Console.WriteLine("Neteisingas kortelės numeris");
            }
            cardsFromCsv = _cardInfoService.GetCardsListFromCsv();
            foreach (var card in cardsFromCsv)
            {
                if (cardNumber == card.CardNumber)
                {
                    validCard = card;
                 
                    break;
                }
            }
            if (validCard.CardNumber != cardNumber)
            {
                Console.WriteLine("Tokio kortelės numerio nėra");
            }

            return validCard;
        } 
        public Card CardPasswordValidation(string password, Card card)//card atkeliauja is cardInserValidation() kuris grąžina Card kurios numeris atitiko
        {
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Slaptažodis neįvestas");
            }
            if (!password.Contains(card.Password.Trim()))
            {
                Console.WriteLine("Netinkamas slaptažodis");
            }
            else
            {
                Console.WriteLine("Slaptažodis teisingas");
            }
            return card;
        }

    }
}

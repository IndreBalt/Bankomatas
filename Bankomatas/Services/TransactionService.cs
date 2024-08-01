using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Services
{
    internal class TransactionService : ITransactinService
    {
        private readonly string _filePathTrans;        
        private Card Card;
        
        public TransactionService(string filePathTrans)
        {
            _filePathTrans = filePathTrans;            
        }
        public string AddTransactionToCsv(Card card, decimal amount)//Įdeda transakcijos stringą į csv failą
        {   
            Card = card;
            DateTime date = DateTime.Now;
            string transactionLine = $"{Card.CardNumber}, {date}, {amount}";
            File.AppendAllText(_filePathTrans, transactionLine + Environment.NewLine);
            return transactionLine;
        }
        public List<Transaction> GetTransactionFromCsv()//Grąžina visų transakcijų listą iš csv failo
        {
            List<string>? transactionListString= new List<string>();
            List<Transaction> transactionsList = new List<Transaction>();
            transactionListString = File.ReadAllLines(_filePathTrans).ToList();
            foreach (string transactionLine in transactionListString)
            {
                Transaction transaction = new Transaction();
                List<string> transactionLineSplited = transactionLine.Split(',').ToList();
                transaction.CardNumber = Guid.Parse(transactionLineSplited[0].Trim());
                transaction.DateMade = DateTime.Parse(transactionLineSplited[1].Trim());
                transaction.Amount = int.Parse(transactionLineSplited[2].Trim());
                transactionsList.Add(transaction);
            }            
            return transactionsList;
        }

        
    }
}

using Bankomatas.Models;
using Bankomatas.Services;


namespace Bankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Guid guid = Guid.NewGuid();
            //Console.WriteLine(guid);
            //Console.WriteLine(guid);
            //Console.WriteLine(guid);


            //Card card = new Card();
            //card.CardNumber = Guid.NewGuid();
            //card.Password = 123123123;
            //card.Balance = 1000;
            //Console.WriteLine($"{card.CardNumber}, {card.Password}, {card.Balance}");

            //Card card2 = new Card();
            //card2.CardNumber = Guid.NewGuid();
            //card2.Password = 123123123;
            //card2.Balance = 1000;
            //Console.WriteLine($"{card2.CardNumber}, {card2.Password}, {card2.Balance}");


            //CardInfoService cardInfoService = new CardInfoService();
            //cardInfoService.AddCardInfoToCsv(filePath, card);
            //cardInfoService.AddCardInfoToCsv(filePath, card);
            //Console.WriteLine("success");
            //cardInfoService.GetCardsListFromCsv(filePath).ForEach(x => Console.WriteLine($"{x.CardNumber}"));

            ATM aTM = new ATM();
            aTM.M_Main();

            //CashRegisterService cash = new CashRegisterService();
            //cash.TakeBanknotesFromCashregister(270);

            //TransactionService trans = new TransactionService("C:\\Code\\CodeAcademy\\Bankomatas\\Bankomatas\\Files\\Transactions.csv");
            //Card card2 = new Card();
            //card2.CardNumber = Guid.Parse("2884861ced5d4abf8eff9b59060d4bd2");
            //card2.Password = "123123123";
            //card2.Balance = 1000;
            //Console.WriteLine($"{card2.CardNumber}, {card2.Password}, {card2.Balance}");
            //Guid cardNr = Guid.Parse("2884861ced5d4abf8eff9b59060d4bd2");

            //trans.AddTransactionToCsv(card2, -1500);
            //trans.GetTransactionFromCsv();

            //ATMservice aTMservice = new ATMservice();
            //aTMservice.GetTransaction(card2, "C:\\Code\\CodeAcademy\\Bankomatas\\Bankomatas\\Files\\Transactions.csv").ForEach(x => Console.WriteLine(x));


        }
    }
}

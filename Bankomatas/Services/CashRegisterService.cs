using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Bankomatas.Models;


namespace Bankomatas.Services
{
    internal class CashRegisterService
    {  
        public List<Banknote> AddMoneyToCashRegister()
        {
            List<Banknote> banknotes = new List<Banknote>();
            banknotes.Add(new Banknote(5, 0));
            banknotes.Add(new Banknote(10, 0));
            banknotes.Add(new Banknote(20, 0));
            banknotes.Add(new Banknote(50, 5));
            banknotes.Add(new Banknote(100, 0));
            banknotes.Add(new Banknote(200, 0));
            banknotes.Add(new Banknote(500, 0));
            return banknotes;
        }
        public bool CheckingIsEnafBanknotes(decimal amount)//Validuoja ar užtektinai kupiūrų
        {
            List<Banknote> banknotes = AddMoneyToCashRegister().OrderByDescending(x => x.Value).ToList();
            decimal checkingBanknotesCount = amount;            
            foreach (Banknote banknote in banknotes)//prasuka per visas kupiuras ar uzteks 
            {
                int banknoteCount = banknote.Count;
                if (checkingBanknotesCount >= banknote.Value && checkingBanknotesCount != 0 && banknoteCount > 0)
                {
                    while (checkingBanknotesCount >= banknote.Value && checkingBanknotesCount != 0 && banknoteCount > 0)
                    {
                        checkingBanknotesCount -= banknote.Value;
                        banknoteCount--;
                    }
                }
            }
            
            if (checkingBanknotesCount > 0)//tikrina ar uzteks pinigu
            {                
                return false;
            }
            else
            {
                return true;
            }
        }       
        public List<Banknote> TakeBanknotesFromCashregister(decimal amount)//Išima pinigus iš bankomato
        {
            List<Banknote> banknotes = AddMoneyToCashRegister().OrderByDescending(x => x.Value).ToList();
            List<Banknote> dispensedBanknotes = new List<Banknote>();
            if (amount % 5 != 0) 
            {
                Console.WriteLine("Netinkama suma");
            }
            else
            {
                if (CheckingIsEnafBanknotes(amount) == false)
                {
                    Console.WriteLine("Bankomate nėra užtektinai kupiurų");
                }
                else
                {
                    foreach (Banknote banknote in banknotes)
                    {
                        int numberOfBanknotes = 0;
                        if (amount >= banknote.Value && amount != 0 && banknote.Count > 0)
                        {
                            while (amount >= banknote.Value && amount != 0 && banknote.Count > 0)
                            {
                                amount -= banknote.Value;
                                banknote.Count--;
                                numberOfBanknotes++;
                            }
                            dispensedBanknotes.Add(new Banknote(banknote.Value, numberOfBanknotes));
                        }

                    }
                    //Console.WriteLine("Banknotai liko");
                    //foreach (Banknote cash in banknotes)
                    //{
                    //    Console.WriteLine($"Value: {cash.Value}, count: {cash.Count}");
                    //}
                    if (dispensedBanknotes.Count != 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Išduoti banknotai:");
                        foreach (Banknote cash in dispensedBanknotes)
                        {
                            Console.WriteLine($"Nominalas: {cash.Value}eur, kiekis: {cash.Count}");
                        }
                    }

                }
            }
                     
            return dispensedBanknotes;
        }
    }
}

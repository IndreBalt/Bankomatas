using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas.Services
{
    public class ATM
    {
        private Card loggedCard = new Card();
        
        static string filePathCards = "C:\\Code\\CodeAcademy\\Bankomatas\\Bankomatas\\Files\\CardInformation.csv";
        static string filePathTransactions = "C:\\Code\\CodeAcademy\\Bankomatas\\Bankomatas\\Files\\Transactions.csv";
        private ATMservice AtmService = new ATMservice(filePathTransactions, filePathCards);
        public void Antraste()
        {
            Console.Clear();
            Console.WriteLine("#######################");
            Console.WriteLine("      BANKOMATAS");
            Console.WriteLine("#######################"); 
            Console.WriteLine();

        }
        public void ReturnToMeniu()
        {
            Console.WriteLine();
            Console.WriteLine("Norint grįžti į meniu, spauskite bet kokį mygtuką");
        }
        public int Menu()
        {
            Antraste();           
            Console.WriteLine("1. Balansas");
            Console.WriteLine("2. Paskutinės 5 transakcijos");
            Console.WriteLine("3. Pinigų išėmimas");
            Console.WriteLine("4. Grąžinti kortelę");
            Console.WriteLine();
            Console.WriteLine("Pasirinkite ką norite daryti");
            int choose = 0;
            do
            {
                int.TryParse(Console.ReadLine(), out choose);
                if (choose <= 0 || choose > 4)
                {
                    Console.WriteLine("Įvestis neteisinga, bandykit dar kartą");

                }
            } while (choose <= 0 || choose > 4);            
            return choose;
        }   
        public void HandleMeniu(int choose)
        {
            
            switch (choose)
            {
                case 1:
                    Antraste();
                    Console.WriteLine("BALANSAS");
                    Console.WriteLine();
                    Console.WriteLine($"Likutis: {AtmService.GetBalance(loggedCard)}");
                    ReturnToMeniu();
                    break;
                case 2:
                    Antraste();
                    Console.WriteLine("PASKUTINĖS 5 TRANSAKCIJOS");
                    Console.WriteLine();
                    AtmService.GetFiveTransaction(loggedCard);
                    ReturnToMeniu();
                    break;
                case 3:
                    Antraste();
                    Console.WriteLine("PINIGŲ IŠĖMIMAS");
                    Console.WriteLine();
                    Console.WriteLine("Įrašykite norimą sumą: ");
                    int.TryParse(Console.ReadLine(), out int amount);
                    AtmService.TakeMoney(loggedCard, amount);
                    ReturnToMeniu();
                    break;
                case 4:
                    Antraste();
                    Console.WriteLine("GRĄŽINTI KORTELĘ");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Operacija baigta");
                    Environment.Exit(0);
                    break;
            }
        }

        public void M_Main()
        {
            Antraste();          
            Guid cardNumber = default;            
            int iterator = 0;
            do
            {
                Console.WriteLine("Idekite kortele");
                Guid.TryParse(Console.ReadLine(), out cardNumber);                
                loggedCard = AtmService.CardInsertValidation(cardNumber) as Card;
            }while(loggedCard.CardNumber == Guid.Empty);
            string enterredPassword = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("Įveskite slaptažodį");
                enterredPassword = Console.ReadLine();
                Console.WriteLine();
                AtmService.CardPasswordValidation(enterredPassword, loggedCard);
                iterator++;
                if (iterator > 3) 
                {
                    Antraste();
                    Console.WriteLine("Slaptažodis įvestas 3 kartus");
                    Environment.Exit(0);
                }
                Console.ReadKey();
            } while (enterredPassword != loggedCard.Password.Trim() && iterator<3);
            while (true)
            {
                Antraste();
                int choose = Menu();
                HandleMeniu(choose);
                Console.ReadKey();
            }    

        }
       
    }
}

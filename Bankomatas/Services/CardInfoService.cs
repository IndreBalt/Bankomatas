using Bankomatas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bankomatas.Services
{
    public class CardInfoService:ICardInfoService
    {
        private string _filePathCards;
        public CardInfoService(string filePathCards)
        {
            
            _filePathCards = filePathCards;
        }       
        public List<string> AddCardsInfoToCsv(List<Card> cards)// Įdeda Card listą į csv
        { 
            List <string> newCardsCSV = new List<string>();
            foreach(Card card in cards)
            {
                string cardInfoTostring = $"{card.CardNumber}, {card.Password}, {card.Balance}";
                newCardsCSV.Add(cardInfoTostring);
                
            }            
            File.WriteAllLines(_filePathCards, newCardsCSV);
            return newCardsCSV;
        }
        public List<Card> GetCardsListFromCsv()//Grąžina Card sąrašą iš csv failo
        {
            List<string> cardStringList = new List<string>();
            cardStringList = File.ReadAllLines(_filePathCards).ToList();
            List<Card> cardsList = new List<Card>();
           foreach (string cardString in cardStringList)
            {
                Card card = new Card();
                List<string> cardStringSplited = cardString.Split(',').ToList();
                card.CardNumber = Guid.Parse(cardStringSplited[0]);
                card.Password = cardStringSplited[1].Trim();
                card.Balance = decimal.Parse(cardStringSplited[2]);
                cardsList.Add(card);                
            }
           return cardsList;
        }
    }
}

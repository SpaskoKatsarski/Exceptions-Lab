using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Cards
{
    internal class Program
    {
        class Card
        {
            private readonly IReadOnlyCollection<string> validCardFaces;

            private readonly IReadOnlyCollection<string> validCardSuits;

            private string face;
            private string suit;

            public Card(string face, string suit)
            {
                validCardFaces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
                validCardSuits = new List<string> { "S", "H", "D", "C" };

                this.Face = face;
                this.Suit = suit;
            }

            public string Face
            {
                get
                {
                    return this.face;
                }
                private set
                {
                    if (!this.validCardFaces.Contains(value))
                    {
                        throw new ArgumentException();
                    }

                    this.face = value;
                }
            }

            public string Suit
            {
                get
                {
                    return this.suit;
                }
                private set
                {
                    if (!this.validCardSuits.Contains(value))
                    {
                        throw new ArgumentException();
                    }

                    if (value == "S")
                    {
                        value = "\u2660";
                    }
                    else if (value == "H")
                    {
                        value = "\u2665";
                    }
                    else if (value == "D")
                    {
                        value = "\u2666";
                    }
                    else if (value == "C")
                    {
                        value = "\u2663";
                    }

                    this.suit = value;
                }
            }

            public override string ToString()
            {
                return $"[{this.Face}{this.Suit}]";
            }
        }

        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] cardDeck = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var cardInfo in cardDeck)
            {
                try
                {
                    string face = cardInfo.Split()[0];
                    string suit = cardInfo.Split()[1];

                    Card currCard = new Card(face, suit);
                    cards.Add(currCard);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}

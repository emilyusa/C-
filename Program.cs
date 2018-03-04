using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // a. Create an instance of your CardSet class, and name it myDeck.
            CardSet myDeck = new CardSet();
            int howManyCards = 5;
            int balance = 10;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //explain they have $10 to start and each hand is a $1 bet.
            Console.WriteLine("Welcome to Poker Game. You have $10, each hand is $1. Gook luck!");
            Console.WriteLine("Please press Enter key to continue...");
            Console.ReadLine();

            
            while (balance > 0) {
                myDeck.ResetUsage();
                SuperCard[] computerHand = myDeck.GetCards(howManyCards);
                SuperCard[] playersHand = myDeck.GetCards(howManyCards);

                Array.Sort(computerHand);  
                Array.Sort(playersHand); 

                DisplayHands(computerHand, playersHand);

                //draw one card from both sides
                PlayerDrawsOne(playersHand, myDeck);
                
                ComputerDrawsOne(computerHand, myDeck);

                //re-display playerhand and computerhand
                Array.Sort(computerHand);
                Array.Sort(playersHand);

                DisplayHands(computerHand, playersHand);


                bool won = CompareHands(computerHand, playersHand);
                
                if (won) {
                    balance++;
                    Console.WriteLine("You won!");
                } else {
                    balance--;
                    Console.WriteLine("You lose!");
                }

                if (balance == 0) {
                    Console.WriteLine("You have no money now.Game is over!");
                    break;
                }
                Console.WriteLine("Your balance is ${0}. Type Enter for another hand.",balance);
                Console.ReadLine();

            }
                        
            // end of program

            Console.ReadLine();

    }
        private static bool Flush(SuperCard[] hand)
        {
            for (var i = 0; i< hand.Length-1; i++)
            {
                if (!hand[i].Equals(hand[i + 1]))
                {
                    return false;
                }
                
            }
            return true;
        }

        public static void PlayerDrawsOne(SuperCard[] myhand, CardSet mydeck)
        {
            Random rand = new Random();
            bool DrawSuccess = false;
            Console.WriteLine("Which card would you like to draw? Choose number from 1 to 5. Input 0 to make no change.");            
            int drawIndex = Convert.ToInt32(Console.ReadLine());
            while (!DrawSuccess)
            {
                if (drawIndex <= 5 && drawIndex >= 1)
                {
                    myhand[drawIndex - 1].inplay = false;    
                    myhand[drawIndex - 1] = mydeck.GetOneCard();
                    
                    DrawSuccess = true;
                }else if (drawIndex == 0)
                {
                    DrawSuccess = true;
                }else
                {
                    Console.WriteLine("Please input the correct number from 0 to 5.");
                    drawIndex = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public static void ComputerDrawsOne(SuperCard[] myhand, CardSet mydeck)
        {
            int minRank=14 ;
            int minIndex=0;
            if (Flush(myhand))
            {
                
                return;
            }
            for (var i = 0; i < myhand.Length; i++)
            {
                int rank = Convert.ToInt32(myhand[i].CardRank);
                if (rank< minRank)
                {
                    minRank = rank;
                    minIndex = i;
                }
            }
            if (minRank < 8)
            {
                myhand[minIndex].inplay = false;
                myhand[minIndex]=mydeck.GetOneCard();
                myhand[minIndex].inplay = true;
            }
        }

        public static void DisplayHands(SuperCard[] computerHand,SuperCard[] playersHand) {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            

            Console.WriteLine("COMPUTER'S HAND:");
            for (int i = 0; i < computerHand.Length; i++) {
                computerHand[i].Display();
            }
            //reset background setting
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();

            Console.WriteLine("PLAYER'S HAND:");
            for (int i = 0; i < playersHand.Length; i++)
            {
                playersHand[i].Display();
            }
            //reset background setting
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine();
        }

        public static bool CompareHands(SuperCard[] computerHand, SuperCard[] playersHand) {
            int sumComputer=0;
            int sumPlayer=0;
            
            if (Flush(computerHand))
            {
                Console.WriteLine("Computer has a flush!");
                return false;
            }
            if (Flush(playersHand))
            {
                Console.WriteLine("Player has a flush!");
                return true;
            }
            

            for (int i = 0; i < computerHand.Length; i++) {
                sumComputer += (int)computerHand[i].CardRank;
                sumPlayer += (int)playersHand[i].CardRank;
            }
            if (sumPlayer > sumComputer)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

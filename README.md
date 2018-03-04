# C#
C# projects - Poker Game

1.	Player starts with $10, and the bet is $1 for each new hand played.  When Player gets to $0, the game is over.
2.	After a new hand is dealt, the player can choose to replace one card of their 5 cards.  They enter a 0 if they want to keep all cards, or a number from 1 to 5, indicating which of the 5 cards showing they want to replace.
3.	The dealer (the computer) also replaces one card using a simple algorithm; it replaces the lowest value card it has. If all of the cards are an 8 or higher, it keeps all its cards and does not replace one. It also does not choose to replace a card in an attempt to create a flush, but if it is dealt a flush, it keeps it and does not take any cards. (A flush is all cards are of the same suit, Spade, Club, Diamond, or Heart.)
4.	After both Player and Dealer have replaced cards (if they chose to), the program calculates a winner.  Player’s balance is increased by $1 if they win the hand, and it is decreased by $1 if they lose the hand.  If they lose all their money, the game is over.
5.	Here is how winning a hand is defined:
a.	A flush beats any other hand.
b.	Otherwise, the value of the 5 cards is added to create a score.  
i.	Deuces (a 2), count as 2 points, a 3 counts as 3 points, etc.  Jack is 11 points, Queen is 12 points, King is 13 points, and an Ace counts for 14 points.
c.	The Dealer wins all ties.

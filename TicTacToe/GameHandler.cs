using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using TicTacToe;

namespace tictactoe
{
    class GameHandler
    {

        private List<Player> players;
        private GameBoard gameBoard;
        private int turnIndex;

        public GameHandler()
        {
            this.players = new List<Player>();
            this.gameBoard = new GameBoard();
            this.turnIndex = 0;
        }

        public void initPlayers()
        {
            players.Add(new Player(1));
            players.Add(new Player(2));
        }

        public Player Winner{get;set;}


        

        
        public bool playTurn()

        {
                bool boardFull = false;
            foreach (var p in players)
            {
                if (gameBoard.BoardIsFull())
                {
                    boardFull = true;
                    break;
                }
                gameBoard.printGameBoard();
                Player playerInTurn = players.ElementAt(turnIndex);
                bool choiceSucceeded = false;
                int choice = 0;
                int x = 0;
                int y = 0;

                while (!choiceSucceeded)
                {
                    Console.WriteLine("{0} turn, please select a number between 0-8:", playerInTurn);
                    choiceSucceeded = int.TryParse(Console.ReadLine(), out choice);

                    if (!inRange(choice) || !choiceSucceeded)
                    {
                        choiceSucceeded = false;
                        Console.WriteLine("Choose number between 0-8");
                    }
                    x = GetXIndex(choice);
                    y = GetYIndex(choice);

                    if (gameBoard.board().ElementAt(x)[y].Number < 0)
                    {
                        choiceSucceeded = false;
                        Console.WriteLine("That slot was already taken. Please select another one.");
                    }

                }
                
                gameBoard.setSquareToPlayer(x, y, playerInTurn.getPlayerID() == 1 ? -1 : -2);
                ChangeTurn();
                
            }

            Player w = GetWinner();

            if ( w != null || boardFull)
            {
                Winner = w;
                return false;
            }
        

            return true;
        }

        public bool inRange(int i)
        {
            return i >= 0 && i <= 8;
        }

        public void ChangeTurn()
        {
            turnIndex = turnIndex == 0 ? 1 : 0;
        }

        public Player GetWinner()
        {
            int pID = gameBoard.getWinnerId(players.ElementAt(0), players.ElementAt(1));

            if (pID != -1)
            {
                foreach (Player p in players)
                {
                    if (p.getPlayerID() == pID)
                    {
                        return p;
                    }

                }
            }

            return null;
        }

        public int GetXIndex(int choice)
        {
            if (choice >= 0 && choice <= 2)
            {
                return 0;
            } else if (choice > 2 && choice <= 5)
            {
                return 1;
            } else if (choice > 5 && choice <= 8)
            {
                return 2;
            }

            return -1;

        }

        public int GetYIndex(int choice)
        {
            if (choice == 0 || choice == 3 || choice == 6)
            {
                return 0;
            }
            else if (choice == 1 || choice == 4 || choice == 7)
            {
                return 1;
            }
            else if (choice == 2 || choice == 5 || choice == 8)
            {
                return 2;
            }

            return -1;
        }

        public void GameOverPrint()
        {

            if (Winner != null)
            {

            Console.WriteLine("GAME OVER\n" +
                              "PLAYER {0} WON", Winner);

            }
            else
            {
                Console.WriteLine("ITS A TIE!");
            }
        }

    }


   
}

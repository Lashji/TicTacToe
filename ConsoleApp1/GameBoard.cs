using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp1;

namespace tictactoe
{
    class GameBoard
    {
        private List<Square[]> gameboard;


        public GameBoard()
        {
            this.gameboard = new List<Square[]>();
            AddArraysToGameBoard();
        }

        private void AddArraysToGameBoard()
        {

            Square[] row1 = new Square[3] {new Square(0), new Square(1), new Square(2)};
            Square[] row2 = new Square[3] { new Square(3), new Square(4), new Square(5) };
            Square[] row3 = new Square[3] { new Square(6), new Square(7), new Square(8) };
            gameboard.Add(row1);
            gameboard.Add(row2);
            gameboard.Add(row3);

        }
        public void printGameBoard()
        {
            int x = 0;
            int y= 0;
            foreach (Square[] sa in gameboard)
            {
                foreach (Square s in sa)
                {
                    s.tulosta(x, y);
                    y++;
                }
                Console.WriteLine("");
                y = 0;
                x++;
            }
        }

        public void setSquareToPlayer(int x, int y, int playerID)
        {

            if (gameboard.ElementAt(x)[y].Number >= 0)
            {
                gameboard.ElementAt(x)[y].Number = playerID;
            }

        }

        public List<Square[]> board()
        {
            return this.gameboard;
        }


        public bool BoardIsFull()
        {
            int vapaita = 0; 
            foreach (Square[] s in gameboard)
            {
                foreach (Square square in s)
                {
                    if (square.Number >= 0)
                    {
                        vapaita++;
                    }
                }
            };
                        Console.WriteLine("Vapaita: {0}", vapaita);

            return vapaita == 0;
        }

        public int getWinnerId(Player p1, Player p2)
        {

            int p1Points = 0;
            int p2Points = 0;

            p1Points = checkRows(p1);
            p2Points = checkRows(p2);

            if (p1Points == 1 && p2Points == 1)
            {
                return -1;
            } else if (p1Points == 1)
            {
                return p1.getPlayerID();
            }
            else if (p2Points == 1)
            {
                return p2.getPlayerID();
            }

           

            return -1;
        }

        public int checkRows(Player p)
        {
            int v = 0;
            v = checkHorizontalRows(p);
            if (v == 1)
                return v;

            v = checkVerticalRows(p);
            if (v == 1)
                return v;


            v = checkSlopingRows(p);

            return v;
        }

        private int checkSlopingRows(Player player)
        {
            int id = -player.getPlayerID();
            int count = 0;

            if (gameboard.ElementAt(0)[0].Number == id)
            {
                count++;
            }
            if (gameboard.ElementAt(1)[1].Number == id)
            {
                count++;
            }
            if (gameboard.ElementAt(2)[2].Number == id)
            {
                count++;
            }

            if (count == 3)
                return 1;

            count = 0;

            if (gameboard.ElementAt(0)[2].Number == id)
            {
                count++;
            }
            if (gameboard.ElementAt(1)[1].Number == id)
            {
                count++;
            }
            if (gameboard.ElementAt(2)[0].Number == id)
            {
                count++;
            }

            if (count == 3)
                return 1;

            return 0;
        }

        private int checkVerticalRows(Player player)
        {
            int id = -player.getPlayerID();

            for (int y = 0; y < 3; y++)
            {
                int count = 0;
                for (int x = 0; x < 3; x++)
                {
                    int n = gameboard.ElementAt(x)[y].Number;
                    if (n == id)
                    {
                        count++;
                    } 
                }

                if (count == 3)
                    return 1;

            }

            return 0;
        }

        private int checkHorizontalRows(Player player)
        {
            int id = -player.getPlayerID();

            foreach (Square[] s in gameboard)
            {
                int count = 0;
                foreach (Square i in s)
                {
                    if (i.Number == id)
                    {
                        count++;
                    }

                    if (count == 3)
                        return 1;
                }
            }

            return 0;

        }

    }
}

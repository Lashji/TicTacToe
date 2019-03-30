using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;

namespace tictactoe
{
    class Square
    {

        public Square(int number)
        {
            this.Number = number;
        }

        public int Number { get; set; }

        public Player Player
        {
            get => Player;
            set => Player = value;
        }

        public void tulosta(int x, int y)
        {
            StringBuilder s = new StringBuilder();
            s.Append(" ");
            
            if (Number > 0)
                s.Append(Number);
            else
                s.Append(Number == -1 ? "X" : "O");

            s.Append(" ");


            Console.Write(s.ToString());

        }
    }
}

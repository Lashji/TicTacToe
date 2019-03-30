using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Player
    {
        private int playerID;


        public Player(int id)
        {
            this.playerID = id;
        }

        public int getPlayerID()
        {
            return playerID;
        }

        public override string ToString()
        {
            return "Player " + this.playerID;
        }
    }
}

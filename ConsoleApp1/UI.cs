using System;
using System.Collections.Generic;
using System.Text;

namespace tictactoe
{
    class UI
    {
        private GameHandler handler;

        public UI()
        {
            handler = new GameHandler();
            handler.initPlayers();
        }

        public void start()
        {
            bool continueGame = true;
            while (continueGame)
            {

                continueGame = handler.playTurn();

            }

            handler.GameOverPrint();
            Console.ReadKey();
        }

    }

}

using BlackJack.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : BlackjackObserver
    {
      
        private model.Game a_game;
        private view.IView a_view;

        public PlayGame(model.Game A_game, view.IView A_view)
        {
            a_game = A_game;
            a_view = A_view;
        }

        public bool Play()
        {           
            a_view.DisplayWelcomeMessage();
            if (a_game.GetPlayerScore() != 0)
            {             
                a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
                a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
            }

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch (a_view.GetInput())
            {
                case view.Event.Quit:
                    return false;
                case view.Event.Hit: 
                    a_game.Hit();
                    break;
                case view.Event.Stand:
                    a_game.Stand();
                    break;
                case view.Event.Start:
                    a_game.NewGame();
                    break;
                default:
                    break;
            }
            return true;
        }

        public void cardDrawn(model.Card c)
        {
            Thread.Sleep(500);  
            a_view.DisplayCard(c);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanWinningStrategy : IwonRuleStrategy
    {
        private const int g_maxscore = 21;

        public bool IsDealerWinning(Dealer a_dealer, Player a_player)
        {
            if (a_player.CalcScore() > g_maxscore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxscore)
            {
                return false;
            }
            else if (a_dealer.CalcScore() == a_player.CalcScore())
            {
                return true;
            }
            else if (a_dealer.CalcScore() < a_player.CalcScore() && a_dealer.CalcScore() < g_maxscore && a_player.CalcScore() < g_maxscore)
            {
                return false;
            }
            return true;
        }
    }
}

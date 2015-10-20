using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftHit : IHitStrategy
    {
        private const int g_hitLimit = 17;
        private bool aceHit = false;
        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() == g_hitLimit && aceHit == false)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && a_dealer.CalcScore() == g_hitLimit)
                    {
                        aceHit = true;
                        return true;
                    }
                }
            }
            if (a_dealer.CalcScore() < g_hitLimit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

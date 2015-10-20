using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        private List<BlackjackObserver> m_observer;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IwonRuleStrategy m_wonRule;

        public Dealer(rules.RulesFactory a_rulesFactory)                                             
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_wonRule = a_rulesFactory.GetNewWonRule();                                                                                        
            m_observer = new List<BlackjackObserver>();
        }

        public void Subscribe(BlackjackObserver a_subscriber)
        {
            m_observer.Add(a_subscriber);
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                return m_newGameRule.NewGame(this, a_player);
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Deal(a_player, true);
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    Deal(this, true);

                }
            }

            return false;
        }

        public void Deal(Player person, Boolean value)
        {
            Card c = m_deck.GetCard();
            c.Show(value);
            person.DealCard(c);

            foreach (var observer in m_observer)
            {
                observer.cardDrawn(c);
            }
        }
        public bool IsDealerWinner(Player a_player)
        {
            if (m_wonRule.IsDealerWinning(this, a_player))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool IsGameOver()
        {
            if (m_deck != null && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}

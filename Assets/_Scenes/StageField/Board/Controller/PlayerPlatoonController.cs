using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.StageField.Object;
using Assets.Scenes.StageField;

namespace Assets.Scenes.StageField.Board.Controller
{
    public class PlayerPlatoonController
    {
        private Common.GameManager m_gameManager;
        private Player m_selectedPlayerPlatoon;
        private BoardManager m_boardManager;
        private OccupationPoint m_selectPoint;

        public void Initialize(BoardManager boardManager)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_boardManager = boardManager;
        }

        public Player SelectedPlayerPlatoon
        {
            get
            {
                return m_selectedPlayerPlatoon;
            }
            set
            {
                m_selectedPlayerPlatoon = value;
            }
        }

        public List<Player> GetPlayers()
        {
            var temp = GameObject.FindGameObjectsWithTag("Player");
            var players = new List<Player>();
            foreach (var item in temp)
            {
                players.Add(item.GetComponent<Player>());
            }

            return players;
        }

        public bool IsMoveFinish()
        {
            if (GetPlayers().Count > 0)
            {
                foreach (var item in GetPlayers())
                {
                    if (item.IsMoving())
                        return false;
                }
            }

            return true;
        }
    }
}
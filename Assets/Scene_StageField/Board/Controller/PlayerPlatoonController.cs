using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

namespace Assets.Scene_StageField.Board.Controller
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

        public int NumberOfPlayer()
        {
            var temp = GameObject.FindGameObjectsWithTag("Player");

            return temp.Length;
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
    }
}
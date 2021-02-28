using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

namespace Assets.Scene_StageField.Controller
{
    public class PlayerPlatoonController
    {
        private Common.GameManager m_gameManager;
        private Player m_selectedPlayerPlatoon;
        private StageFieldManager m_scene_StageField;
        private OccupationPoint m_selectPoint;

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_scene_StageField = stageFieldManager;
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
                Debug.Log("SetSelectedPlayerPlatoon : " + m_selectedPlayerPlatoon);
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
            foreach (var item in players)
            {
                players.Add(item.GetComponent<Player>());
            }

            return players;
        }
    }
}
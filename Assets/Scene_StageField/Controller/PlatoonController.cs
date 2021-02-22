using System;
using UnityEngine;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Controller
{
    public class PlatoonController
    {
        private PointController m_pointController;

        private Player m_selectedPlayer;

        public PlatoonController()
        {

        }

        public void Initialize(StageFieldManager manager)
        {
            m_pointController = manager.GetPointController();
        }

        public Player SelectedPlayer
        {
            get
            {
                return m_selectedPlayer;
            }
            set
            {
                m_selectedPlayer = value;
            }
        }

        public void MoveCharacter()
        {

        }
    }
}
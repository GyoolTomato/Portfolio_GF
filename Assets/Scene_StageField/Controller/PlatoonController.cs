using System;
using UnityEngine;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField
{
    public class PlatoonController
    {
        private PointController m_pointController;

        private Character m_selectedCharacter;

        public PlatoonController()
        {

        }

        public void Initialize(StageFieldManager manager)
        {
            m_pointController = manager.GetPointController();
        }

        public Character SelectedCharacter
        {
            get
            {
                return m_selectedCharacter;
            }
            set
            {
                m_selectedCharacter = value;
            }
        }

        public void MoveCharacter()
        {

        }
    }
}
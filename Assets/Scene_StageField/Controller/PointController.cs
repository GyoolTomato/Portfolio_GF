using System;
using UnityEngine;

namespace Assets.Scene_StageField
{
    public class PointController
    {
        private PlatoonController m_platoonController;

        public PointController()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_platoonController = manager.GetPlatoonController();
        }

        public void MoveCharacter()
        {
            
        }
    }
}
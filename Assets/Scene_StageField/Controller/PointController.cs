using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scene_StageField.Controller
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

        public void MoveCharacter(List<GameObject> linkedPoints)
        {
            
        }
    }
}
using System;
using UnityEngine;
using Assets.Resources.Object;
using Assets.Scene_StageField.Controller.SpawnPlatoon;

namespace Assets.Scene_StageField.Controller
{
    public class SpawnPlatoonController
    {
        private MenuController m_menuController;
        private PlatoonListController m_platoonListController;

        public void Initialize()
        {
            var canvas = GameObject.Find("Canvas");
            var spawnPlatoon = canvas.transform.Find("SpawnPlatoon").gameObject;

            m_menuController = new MenuController();
            m_menuController.Initialize(spawnPlatoon);
            m_platoonListController = new PlatoonListController();
            m_platoonListController.Initialize(spawnPlatoon);
        }
    }
}
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
        private StageFieldManager m_stageFieldManager;
        private GameObject m_map;

        public void Initialize(StageFieldManager manager)
        {
            var canvas = GameObject.Find("Canvas");
            var spawnPlatoon = canvas.transform.Find("SpawnPlatoon").gameObject;

            m_menuController = new MenuController();
            m_menuController.Initialize(spawnPlatoon);
            m_menuController.SetSpawnListener(SpawnPlayer);
            m_platoonListController = new PlatoonListController();
            m_platoonListController.Initialize(spawnPlatoon);
            m_stageFieldManager = manager;
            m_map = GameObject.Find("Map");
        }

        void SpawnPlayer()
        {            
            var player = UnityEngine.Resources.Load<GameObject>("StageField/Player");
            var selectedPoint = m_stageFieldManager.GetPointController().GetSelectedPoint();

            var platoon = MonoBehaviour.Instantiate(player, selectedPoint.transform.position, Quaternion.identity);
            platoon.transform.parent = m_map.transform;
            var playerScript = platoon.GetComponent<Assets.Resources.StageField.Player>();
            playerScript.SetValue(m_menuController.GetSelectedPlatoonNumber());

            selectedPoint.OnPlayer = playerScript;

            m_stageFieldManager.SetSpawnPlatoonActive(false);
        }
    }
}
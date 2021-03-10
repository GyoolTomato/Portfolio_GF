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
        private GameObject m_board;

        public void Initialize(StageFieldManager manager)
        {
            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            var spawnPlatoon = board.Find("SpawnPlatoon").gameObject;

            m_menuController = new MenuController();
            m_menuController.Initialize(spawnPlatoon);
            m_menuController.SetSpawnListener(SpawnPlayer);
            m_platoonListController = new PlatoonListController();
            m_platoonListController.Initialize(spawnPlatoon);
            m_stageFieldManager = manager;
            m_board = GameObject.Find("Board");
        }

        void SpawnPlayer()
        {            
            var player = UnityEngine.Resources.Load<GameObject>("StageField/Player");
            var selectedPoint = m_stageFieldManager.GetPointController().GetSelectedPoint();

            var platoon = MonoBehaviour.Instantiate(player, selectedPoint.transform.position, Quaternion.identity);
            platoon.transform.parent = m_board.transform;
            var playerScript = platoon.GetComponent<Assets.Resources.StageField.Player>();
            playerScript.Initialize(m_menuController.GetSelectedPlatoonNumber(), selectedPoint);

            m_stageFieldManager.SetSpawnPlatoonActive(false);
        }
    }
}
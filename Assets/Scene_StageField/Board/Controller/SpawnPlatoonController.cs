using System;
using UnityEngine;
using Assets.Resources.Object;
using Assets.Scene_StageField.Board.SpawnPlatoon;

namespace Assets.Scene_StageField.Board.Controller
{
    public class SpawnPlatoonController
    {
        private MenuController m_menuController;
        private PlatoonListController m_platoonListController;
        private BoardManager m_boardManager;
        private GameObject m_board;

        public void Initialize(BoardManager boardManager)
        {
            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            var spawnPlatoon = board.Find("SpawnPlatoon").gameObject;

            m_menuController = new MenuController();
            m_menuController.Initialize(spawnPlatoon);
            m_menuController.SetSpawnListener(SpawnPlayer);
            m_platoonListController = new PlatoonListController();
            m_platoonListController.Initialize(spawnPlatoon);
            m_boardManager = boardManager;
            m_board = GameObject.Find("Board");
        }

        void SpawnPlayer()
        {            
            var player = UnityEngine.Resources.Load<GameObject>("StageField/Player");
            var selectedPoint = m_boardManager.GetPointController().GetSelectedPoint();

            var platoon = MonoBehaviour.Instantiate(player, selectedPoint.transform.position, Quaternion.identity);
            platoon.transform.parent = m_board.transform;
            var playerScript = platoon.GetComponent<Assets.Resources.StageField.Player>();
            playerScript.Initialize(m_menuController.GetSelectedPlatoonNumber(), selectedPoint);

            m_boardManager.SetSpawnPlatoonActive(false);
        }
    }
}
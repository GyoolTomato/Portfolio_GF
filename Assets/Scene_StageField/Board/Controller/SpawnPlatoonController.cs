﻿using System;
using UnityEngine;
using Assets.Common;
using Assets.Resources.Object;
using Assets.Scene_StageField.Board.SpawnPlatoon;
using Assets.Character;
using Assets.Scene_StageField.Object;

namespace Assets.Scene_StageField.Board.Controller
{
    public class SpawnPlatoonController
    {
        private GameManager m_gameManager;
        private MenuController m_menuController;
        private PlatoonListController m_platoonListController;
        private BoardManager m_boardManager;
        private GameObject m_board;

        public void Initialize(BoardManager boardManager)
        {
            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            var spawnPlatoon = board.Find("SpawnPlatoon").gameObject;

            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            //Index를 맞추기 위해 -1 처리
            var platoonData = m_gameManager.GetUserDBController().UserFormation()[m_menuController.GetSelectedPlatoonNumber() - 1];
            var platoonObject = CharacterObject.DataCodeObject(m_gameManager.GetUserDBController().UserTDoll(platoonData.Member1).DataCode);
            var selectedPoint = m_boardManager.GetPointController().GetSelectedPoint();

            var platoon = MonoBehaviour.Instantiate(platoonObject, selectedPoint.transform.position, Quaternion.identity);
            platoon.transform.parent = m_board.transform;
            platoon.AddComponent<Player>();
            var playerScript = platoon.GetComponent<Player>();
            playerScript.Initialize(platoonData, selectedPoint);

            m_boardManager.SetSpawnPlatoonActive(false);
        }
    }
}
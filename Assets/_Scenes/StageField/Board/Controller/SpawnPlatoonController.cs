using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common;
using Assets.Resources.Object;
using Assets.Scenes.StageField.Board.SpawnPlatoon;
using Assets.Character;
using Assets.Scenes.StageField.Object;

namespace Assets.Scenes.StageField.Board.Controller
{
    public class SpawnPlatoonController
    {
        private ResourceManager m_resourceManager;
        private DB.DbManager m_dbManager;

        private MenuController m_menuController;
        private PlatoonListController m_platoonListController;        
        private BoardManager m_boardManager;
        private GameObject m_board;
        private GameObject m_spawnRefusal;
        private List<int> m_usedNumbers;

        public void Initialize(BoardManager boardManager)
        {
            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            var spawnPlatoon = board.Find("SpawnPlatoon").gameObject;

            m_resourceManager = GameObject.Find("GameManager").GetComponent<ResourceManager>();
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();

            m_menuController = new MenuController();
            m_menuController.Initialize(spawnPlatoon);
            m_menuController.SetSpawnListener(SpawnPlayer);
            m_platoonListController = new PlatoonListController();
            m_platoonListController.Initialize(spawnPlatoon);
            m_boardManager = boardManager;
            m_board = GameObject.Find("Board");
            m_spawnRefusal = spawnPlatoon.transform.Find("SpawnRefusal").gameObject;
            m_spawnRefusal.SetActive(false);
            m_usedNumbers = new List<int>();
        }

        void SpawnPlayer()
        {
            //Index를 맞추기 위해 -1 처리
            var platoonData = m_dbManager.GetUserDBController().UserFormation()[m_menuController.GetSelectedPlatoonNumber() - 1];
            var platoonObject = CharacterObject.DataCodeObject(m_dbManager.GetUserDBController().UserTDoll(platoonData.Member1).DataCode);
            var selectedPoint = m_boardManager.GetPointController().GetSelectedPoint();

            foreach (var item in m_usedNumbers)
            {
                if (item == m_menuController.GetSelectedPlatoonNumber())
                {
                    m_resourceManager.StartCoroutine(AlertMessage());
                    return;
                }
            }
            m_usedNumbers.Add(m_menuController.GetSelectedPlatoonNumber());

            var platoon = MonoBehaviour.Instantiate(platoonObject, selectedPoint.transform.position, Quaternion.identity);
            platoon.transform.parent = m_board.transform;
            platoon.AddComponent<Player>();
            var playerScript = platoon.GetComponent<Player>();
            playerScript.Initialize(platoonData, selectedPoint);            

            m_boardManager.SetSpawnPlatoonActive(false);
        }

        private IEnumerator AlertMessage()
        {
            m_spawnRefusal.SetActive(true);
            yield return new WaitForSeconds(2f);
            m_spawnRefusal.SetActive(false);
        }
    }
}
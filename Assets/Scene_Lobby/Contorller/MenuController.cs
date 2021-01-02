using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_Lobby.Controller
{
    public class MenuController
    {
        private Assets.GameManager.GameManager m_gameManager;

        private Button m_combat;
        private Button m_research;
        private Button m_restore;
        private Button m_formation;
        private Button m_factory;
        private Button m_dormitory;

        public MenuController()
        {
            m_gameManager = null;

            m_combat = null;
            m_research = null;
            m_restore = null;
            m_formation = null;
            m_factory = null;
            m_dormitory = null;
        }

        public void Initialize(Assets.GameManager.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var menu = canvas.transform.Find("Menu");
            m_combat = menu.Find("Combat").GetComponent<Button>();
            m_research = menu.Find("Research").GetComponent<Button>();
            m_restore = menu.Find("Restore").GetComponent<Button>();
            m_formation = menu.Find("Formation").GetComponent<Button>();
            m_factory = menu.Find("Factory").GetComponent<Button>();
            m_dormitory = menu.Find("Dormitory").GetComponent<Button>();

            ApplyAction();
        }

       private void ApplyAction()
        {
            m_combat.onClick.AddListener(Handle_CombatClick);
            m_research.onClick.AddListener(Handle_ResearchClick);
            m_restore.onClick.AddListener(Handle_RestoreClick);
            m_formation.onClick.AddListener(Handle_FormationClick);
            m_factory.onClick.AddListener(Handle_FactoryClick);
            m_dormitory.onClick.AddListener(Handle_DormitoryClick);
        }

        private void Handle_CombatClick()
        {
            SceneManager.LoadScene("Combat");
        }

        private void Handle_ResearchClick()
        {
            SceneManager.LoadScene("Research");
        }

        private void Handle_RestoreClick()
        {
            SceneManager.LoadScene("Restore");
        }

        private void Handle_FormationClick()
        {
            SceneManager.LoadScene("Formation");
        }

        private void Handle_FactoryClick()
        {
            SceneManager.LoadScene("Factory");
        }

        private void Handle_DormitoryClick()
        {
            SceneManager.LoadScene("Dormitory");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_Dormitory.Controller
{
    public class MenuController
    {
        private ViewPort_TDollController m_viewPort_TDollController;
        private ViewPort_EquipmentsController m_viewPort_EquipmentsController;

        private Assets.Project.GameManager m_gameManager;

        private Button m_buttonBack;
        private Button m_buttonTDoll;
        private Button m_buttonEquipments;

        private GameObject m_viewTDoll;
        private GameObject m_viewEquipments;

        public MenuController()
        {
            m_gameManager = null;

            m_buttonBack = null;
            m_buttonTDoll = null;
            m_buttonEquipments = null;

            m_viewTDoll = null;
            m_viewEquipments = null;
        }

        public void Initialize(Assets.Project.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var title = canvas.transform.Find("Title");
            m_buttonBack = title.Find("Back").GetComponent<Button>();

            var menu = canvas.transform.Find("Menu");
            m_buttonTDoll = menu.Find("TDoll").GetComponent<Button>();
            m_buttonTDoll = menu.Find("Equipments").GetComponent<Button>();

            var menuView = canvas.transform.Find("MenuView");
            m_viewTDoll = menuView.Find("TDoll").gameObject;
            m_viewEquipments = menuView.Find("Equipments").gameObject;

            ApplyAction();
            Handle_TDollClick();
        }

        private void ApplyAction()
        {
            m_buttonBack.onClick.AddListener(Handle_Back);
            m_buttonTDoll.onClick.AddListener(Handle_TDollClick);
            m_buttonEquipments.onClick.AddListener(Handle_EquipmentsClick);
        }

        private void Handle_Back()
        {
            SceneManager.LoadScene("Lobby");
        }

        private void Handle_TDollClick()
        {
            m_viewTDoll.SetActive(true);
            m_viewEquipments.SetActive(false);
        }

        private void Handle_EquipmentsClick()
        {
            m_viewTDoll.SetActive(false);
            m_viewEquipments.SetActive(true);
        }
    }
}

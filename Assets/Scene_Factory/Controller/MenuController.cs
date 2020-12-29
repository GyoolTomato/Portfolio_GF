using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Controller
{
    public class MenuController
    {
        private GameManager m_gameManager;

        private Button m_buttonProduceTDoll;
        private Button m_buttonDummyLinkNAnalyze;
        private Button m_buttonEnhanceNDevelop;
        private Button m_buttonTDollRetire;
        private Button m_buttonProduceEquipment;

        private GameObject m_viewProduceTDoll;
        private GameObject m_viewDummyLinkNAnalyze;
        private GameObject m_viewEnhanceNDevelop;
        private GameObject m_viewTDollRetire;
        private GameObject m_viewProduceEquipment;

        public MenuController()
        {
            m_gameManager = null;

            m_buttonProduceTDoll = null;
            m_buttonDummyLinkNAnalyze = null;
            m_buttonEnhanceNDevelop = null;
            m_buttonTDollRetire = null;
            m_buttonProduceEquipment = null;

            m_viewProduceTDoll = null;
            m_viewDummyLinkNAnalyze = null;
            m_viewEnhanceNDevelop = null;
            m_viewTDollRetire = null;
            m_viewProduceEquipment = null;
        }

        public void Initialize(GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var menu = canvas.transform.Find("Menu");
            m_buttonProduceTDoll = menu.Find("ProduceTDoll").GetComponent<Button>();
            m_buttonDummyLinkNAnalyze = menu.Find("DummyLinkNAnalyze").GetComponent<Button>();
            m_buttonEnhanceNDevelop = menu.Find("EnhanceNDevelop").GetComponent<Button>();
            m_buttonTDollRetire = menu.Find("TDollRetire").GetComponent<Button>();
            m_buttonProduceEquipment = menu.Find("ProduceEquipment").GetComponent<Button>();

            var menuView = canvas.transform.Find("MenuView");
            m_viewProduceTDoll = menuView.Find("ProduceTDoll").gameObject;
            m_viewDummyLinkNAnalyze = menuView.Find("DummyLinkNAnalyze").gameObject;
            m_viewEnhanceNDevelop = menuView.Find("EnhanceNDevelop").gameObject;
            m_viewTDollRetire = menuView.Find("TDollRetire").gameObject;
            m_viewProduceEquipment = menuView.Find("ProduceEquipment").gameObject;

            ApplyAction();
            Handle_ProduceTDollClick();
        }

        private void ApplyAction()
        {
            m_buttonProduceTDoll.onClick.AddListener(Handle_ProduceTDollClick);
            m_buttonDummyLinkNAnalyze.onClick.AddListener(Handle_DummyLinkNAnalyzeClick);
            m_buttonEnhanceNDevelop.onClick.AddListener(Handle_EnhanceNDevelopClick);
            m_buttonTDollRetire.onClick.AddListener(Handle_TDollRetireClick);
            m_buttonProduceEquipment.onClick.AddListener(Handle_ProduceEquipmentClick);
        }

        private void Handle_ProduceTDollClick()
        {
            Debug.Log("Produce T-Doll Click");
            m_viewProduceTDoll.SetActive(true);
            m_viewDummyLinkNAnalyze.SetActive(false);
            m_viewEnhanceNDevelop.SetActive(false);
            m_viewTDollRetire.SetActive(false);
            m_viewProduceEquipment.SetActive(false);
        }

        private void Handle_DummyLinkNAnalyzeClick()
        {
            Debug.Log("Dummy Link & Analyze Click");
            m_viewProduceTDoll.SetActive(false);
            m_viewDummyLinkNAnalyze.SetActive(true);
            m_viewEnhanceNDevelop.SetActive(false);
            m_viewTDollRetire.SetActive(false);
            m_viewProduceEquipment.SetActive(false);
        }

        private void Handle_EnhanceNDevelopClick()
        {
            Debug.Log("Enhance & Develop Click");
            m_viewProduceTDoll.SetActive(false);
            m_viewDummyLinkNAnalyze.SetActive(false);
            m_viewEnhanceNDevelop.SetActive(true);
            m_viewTDollRetire.SetActive(false);
            m_viewProduceEquipment.SetActive(false);
        }

        private void Handle_TDollRetireClick()
        {
            Debug.Log("Produce T-Doll Retire Click");
            m_viewProduceTDoll.SetActive(false);
            m_viewDummyLinkNAnalyze.SetActive(false);
            m_viewEnhanceNDevelop.SetActive(false);
            m_viewTDollRetire.SetActive(true);
            m_viewProduceEquipment.SetActive(false);
        }

        private void Handle_ProduceEquipmentClick()
        {
            Debug.Log("Produce Equipment Click");
            m_viewProduceTDoll.SetActive(false);
            m_viewDummyLinkNAnalyze.SetActive(false);
            m_viewEnhanceNDevelop.SetActive(false);
            m_viewTDollRetire.SetActive(false);
            m_viewProduceEquipment.SetActive(true);
        }
    }
}

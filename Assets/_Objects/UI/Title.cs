using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Objects.UI
{
    public class Title : MonoBehaviour
    {
        public delegate void BackAction();

        private Common.WorkResource.WorkResourceManager m_workResourceManager;
        private BackAction m_backAction;

        private Button m_buttonBack;
        private Text m_name;
        private GameObject m_workResourceInformation;
        private WorkResourceMonitor m_steel;
        private WorkResourceMonitor m_flower;
        private WorkResourceMonitor m_food;
        private WorkResourceMonitor m_leather;

        private bool m_isInit;

        public Title()
        {
            m_buttonBack = null;
            m_name = null;
            m_workResourceInformation = null;
            m_steel = null;
            m_flower = null;
            m_food = null;
            m_leather = null;
        }

        public void Initialize(string name, BackAction backAction)
        {
            m_workResourceManager = GameObject.Find("GameManager").GetComponent<Common.WorkResource.WorkResourceManager>();

            var canvas = GameObject.Find("Canvas");
            var title = canvas.transform.Find("Title");
            m_buttonBack = title.Find("Back").GetComponent<Button>();
            m_buttonBack.onClick.AddListener(Handle_Back);
            m_name = title.Find("Name").GetComponent<Text>();
            m_name.text = name;
            m_backAction = backAction;
            m_workResourceInformation = title.Find("WorkResourceInformation").gameObject;
            m_steel = m_workResourceInformation.transform.Find("Steel").GetComponent<WorkResourceMonitor>();
            m_flower = m_workResourceInformation.transform.Find("Flower").GetComponent<WorkResourceMonitor>();
            m_food = m_workResourceInformation.transform.Find("Food").GetComponent<WorkResourceMonitor>();
            m_leather = m_workResourceInformation.transform.Find("Leather").GetComponent<WorkResourceMonitor>();            
            m_isInit = true;
        }

        private void Update()
        {
            if (!m_isInit)
                return;

            ApplyWorkResourceData();
        }

        private void ApplyWorkResourceData()
        {
            m_steel.ApplyData(m_workResourceManager.Steel());
            m_flower.ApplyData(m_workResourceManager.Flower());
            m_food.ApplyData(m_workResourceManager.Food());
            m_leather.ApplyData(m_workResourceManager.Leather());
        }

        private void Handle_Back()
        {
            m_backAction();            
        }
    }
}

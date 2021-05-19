using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Resources.Object
{
    public class Title : MonoBehaviour
    {
        public delegate void BackAction();

        private Assets.Common.ResourceManager m_resourceManager;
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
            m_resourceManager = null;
            m_buttonBack = null;
            m_name = null;
            m_workResourceInformation = null;
            m_steel = null;
            m_flower = null;
            m_food = null;
            m_leather = null;
        }

        public void Initialize(Assets.Common.ResourceManager resourceManager, string name, BackAction backAction)
        {
            m_resourceManager = resourceManager;

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
            m_steel.ApplyData(m_resourceManager.GetResourceContorller().Steel());
            m_flower.ApplyData(m_resourceManager.GetResourceContorller().Flower());
            m_food.ApplyData(m_resourceManager.GetResourceContorller().Food());
            m_leather.ApplyData(m_resourceManager.GetResourceContorller().Leather());
        }

        private void Handle_Back()
        {
            m_backAction();            
        }
    }
}

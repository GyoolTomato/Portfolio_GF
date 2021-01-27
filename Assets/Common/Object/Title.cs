using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Common.Object
{
    public class Title : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private Button m_buttonBack;
        private Text m_name;
        private GameObject m_workResourceInformation;
        private WorkResourceMonitor m_manPower;
        private WorkResourceMonitor m_bullet;
        private WorkResourceMonitor m_food;
        private WorkResourceMonitor m_militarySupplies;

        private bool m_isInit;

        public Title()
        { 
            m_gameManager = null;
            m_buttonBack = null;
            m_name = null;
            m_workResourceInformation = null;
            m_manPower = null;
            m_bullet = null;
            m_food = null;
            m_militarySupplies = null;
        }

        public void Initialize(Assets.Common.GameManager gameManager, string name)
        {
            m_gameManager = gameManager;

            var canvas = GameObject.Find("Canvas");
            var title = canvas.transform.Find("Title");
            m_buttonBack = title.Find("Back").GetComponent<Button>();
            m_buttonBack.onClick.AddListener(Handle_Back);
            m_name = title.Find("Name").GetComponent<Text>();
            m_name.text = name;
            m_workResourceInformation = title.Find("WorkResourceInformation").gameObject;
            m_manPower = m_workResourceInformation.transform.Find("ManPower").GetComponent<WorkResourceMonitor>();
            m_bullet = m_workResourceInformation.transform.Find("Bullet").GetComponent<WorkResourceMonitor>();
            m_food = m_workResourceInformation.transform.Find("Food").GetComponent<WorkResourceMonitor>();
            m_militarySupplies = m_workResourceInformation.transform.Find("MilitarySupplies").GetComponent<WorkResourceMonitor>();            
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
            m_manPower.ApplyData(m_gameManager.WorkResource.ManPower);
            m_bullet.ApplyData(m_gameManager.WorkResource.Bullet);
            m_food.ApplyData(m_gameManager.WorkResource.Food);
            m_militarySupplies.ApplyData(m_gameManager.WorkResource.MilitarySupplies);
        }

        private void Handle_Back()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}

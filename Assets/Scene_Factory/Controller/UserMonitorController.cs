using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Object;

namespace Assets.Scene_Factory.Controller
{
    public class UserMonitorController
    {
        private Assets.Common.GameManager m_gameManager;
        private Text m_name;
        private GameObject m_workResourceInformation;
        private WorkResourceMonitor m_manPower;
        private WorkResourceMonitor m_bullet;
        private WorkResourceMonitor m_food;
        private WorkResourceMonitor m_militarySupplies;

        public UserMonitorController()
        {
            m_gameManager = null;

            m_manPower = null;
            m_bullet = null;
            m_food = null;
            m_militarySupplies = null;
        }

        public void Initialize(Assets.Common.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var title = canvas.transform.Find("Title");
            m_name = title.Find("Name").GetComponent<Text>();
            m_workResourceInformation = title.Find("WorkResourceInformation").gameObject;
            m_manPower = m_workResourceInformation.transform.Find("ManPower").GetComponent<WorkResourceMonitor>();
            m_bullet = m_workResourceInformation.transform.Find("Bullet").GetComponent<WorkResourceMonitor>();
            m_food = m_workResourceInformation.transform.Find("Food").GetComponent<WorkResourceMonitor>();
            m_militarySupplies = m_workResourceInformation.transform.Find("MilitarySupplies").GetComponent<WorkResourceMonitor>();
        }

        public void ApplyData()
        {
            m_manPower.ApplyData(m_gameManager.ResourceContorller.ManPower());
            m_bullet.ApplyData(m_gameManager.ResourceContorller.Bullet());
            m_food.ApplyData(m_gameManager.ResourceContorller.Food());
            m_militarySupplies.ApplyData(m_gameManager.ResourceContorller.MilitarySupplies());
        }
    }
}

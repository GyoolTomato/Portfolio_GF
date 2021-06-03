using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Resources.Object;

namespace Assets.Scenes.Lobby.Controller
{
    public class UserMonitorController
    {
        private Assets.Graphic.GraphicManager m_graphicManager;
        private GameObject m_workResourceInformation;

        private WorkResourceMonitor m_steel;
        private WorkResourceMonitor m_flower;
        private WorkResourceMonitor m_food;
        private WorkResourceMonitor m_leather;

        public UserMonitorController()
        {
            m_graphicManager = null;

            m_steel = null;
            m_flower = null;
            m_food = null;
            m_leather = null;
        }

        public void Initialize(Assets.Graphic.GraphicManager graphicManager, GameObject canvas)
        {
            m_graphicManager = graphicManager;

            var userMonitor = canvas.transform.Find("UserMonitor");
            m_workResourceInformation = userMonitor.Find("WorkResourceInformation").gameObject;
            m_steel = m_workResourceInformation.transform.Find("Steel").GetComponent<WorkResourceMonitor>();
            m_flower = m_workResourceInformation.transform.Find("Flower").GetComponent<WorkResourceMonitor>();
            m_food = m_workResourceInformation.transform.Find("Food").GetComponent<WorkResourceMonitor>();
            m_leather = m_workResourceInformation.transform.Find("Leather").GetComponent<WorkResourceMonitor>();
        }

        public void ApplyData()
        {
            m_steel.ApplyData(m_graphicManager.GetResourceContorller().Steel());
            m_flower.ApplyData(m_graphicManager.GetResourceContorller().Flower());
            m_food.ApplyData(m_graphicManager.GetResourceContorller().Food());
            m_leather.ApplyData(m_graphicManager.GetResourceContorller().Leather());
        }
    }
}

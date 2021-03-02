﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Resources.Object;

namespace Assets.Scene_Lobby.Controller
{
    public class UserMonitorController
    {
        private Assets.Common.GameManager m_gameManager;
        private GameObject m_workResourceInformation;

        private WorkResourceMonitor m_steel;
        private WorkResourceMonitor m_flower;
        private WorkResourceMonitor m_food;
        private WorkResourceMonitor m_leather;

        public UserMonitorController()
        {
            m_gameManager = null;

            m_steel = null;
            m_flower = null;
            m_food = null;
            m_leather = null;
        }

        public void Initialize(Assets.Common.GameManager gameManager, GameObject canvas)
        {
            m_gameManager = gameManager;

            var userMonitor = canvas.transform.Find("UserMonitor");
            m_workResourceInformation = userMonitor.Find("WorkResourceInformation").gameObject;
            m_steel = m_workResourceInformation.transform.Find("Steel").GetComponent<WorkResourceMonitor>();
            m_flower = m_workResourceInformation.transform.Find("Flower").GetComponent<WorkResourceMonitor>();
            m_food = m_workResourceInformation.transform.Find("Food").GetComponent<WorkResourceMonitor>();
            m_leather = m_workResourceInformation.transform.Find("Leather").GetComponent<WorkResourceMonitor>();
        }

        public void ApplyData()
        {
            m_steel.ApplyData(m_gameManager.ResourceContorller().Steel());
            m_flower.ApplyData(m_gameManager.ResourceContorller().Flower());
            m_food.ApplyData(m_gameManager.ResourceContorller().Food());
            m_leather.ApplyData(m_gameManager.ResourceContorller().Leather());
        }
    }
}

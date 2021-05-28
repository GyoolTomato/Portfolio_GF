﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scenes.Factory.Controller;

namespace Assets.Scenes.Factory.Base
{
    public class ProduceBase
    {
        protected FactoryManager m_factoryManager;
        protected Common.ResourceManager m_resourceManager;
        protected DB.DbManager m_dbManager;
        protected TicketResourceController m_ticketResourceController;

        protected List<Object.ProduceSlot> m_produceSlotList;
        protected GameObject m_messagePanel;

        public ProduceBase()
        {
        }

        public virtual void Initialize(FactoryManager factoryManager, Assets.Common.ResourceManager resourceManager, TicketResourceController ticketResourceController, string menuName)
        {
            m_factoryManager = factoryManager;
            m_resourceManager = resourceManager;
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();
            m_ticketResourceController = ticketResourceController;

            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var produceTDoll = menuView.Find(menuName);
            var content = produceTDoll.Find("Scroll View").Find("Viewport").Find("Content");
            m_produceSlotList = new List<Object.ProduceSlot>();
            m_produceSlotList.Add(content.transform.Find("ProduceSlot_0").GetComponent<Object.ProduceSlot>());
            m_produceSlotList.Add(content.transform.Find("ProduceSlot_1").GetComponent<Object.ProduceSlot>());          
            m_messagePanel = canvas.transform.Find("MessagePanel").gameObject;
        }

        protected virtual void OrderReceive(DB.User.Base.UserDataBase_Produce produceData, int steel, int flower, int food, int leather, out bool result)
        {
            if (m_resourceManager.GetResourceContorller().WorkResourceConsumption(steel, flower, food, leather))
            {
                m_messagePanel.SetActive(false);                
                result = true;
            }
            else
            {
                m_messagePanel.SetActive(true);
                m_resourceManager.StartCoroutine(OffMessagePanel());
                result = false;
            }
        }
        protected virtual void Complete(DB.User.Base.UserDataBase_Produce produceData) { }
        protected virtual void InsertData(int dataCode) { }

        protected private IEnumerator OffMessagePanel()
        {
            yield return new WaitForSeconds(2.0f);
            m_messagePanel.SetActive(false);
        }
    }
}

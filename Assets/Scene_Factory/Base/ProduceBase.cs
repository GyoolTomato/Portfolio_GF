﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scene_Factory.Base
{
    public class ProduceBase
    {
        protected Assets.Common.GameManager m_gameManager;
        protected TicketResourceController m_ticketResourceController;

        protected List<Object.ProduceSlot> m_produceSlotList;
        protected GameObject m_messagePanel;

        public ProduceBase()
        {
        }

        public virtual void Initialize(Assets.Common.GameManager gameManager, TicketResourceController ticketResourceController, string menuName)
        {
            m_gameManager = gameManager;
            m_ticketResourceController = ticketResourceController;

            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var produceTDoll = menuView.Find(menuName);
            m_produceSlotList = new List<Object.ProduceSlot>();
            m_produceSlotList.Add(produceTDoll.transform.Find("ProduceSlot_0").GetComponent<Object.ProduceSlot>());
            m_produceSlotList.Add(produceTDoll.transform.Find("ProduceSlot_1").GetComponent<Object.ProduceSlot>());          
            m_messagePanel = canvas.transform.Find("MessagePanel").gameObject;
        }

        protected virtual void OrderReceive(Common.DB.User.UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies, out bool result)
        {
            if (m_gameManager.ResourceContorller().WorkResourceConsumption(manPower, bullet, food, militarySupplies))
            {
                m_messagePanel.SetActive(false);                
                result = true;
            }
            else
            {
                m_messagePanel.SetActive(true);
                m_gameManager.StartCoroutine(OffMessagePanel());
                result = false;
            }
        }
        protected virtual void Complete(Common.DB.User.UserDataBase_Produce produceData) { }

        protected private IEnumerator OffMessagePanel()
        {
            yield return new WaitForSeconds(2.0f);
            m_messagePanel.SetActive(false);
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Common;
using Assets.DB.User;
using UnityEngine;

namespace Assets.Scenes.Factory.Controller
{
    public class ProduceTDollController : Base.ProduceBase
    {
        public ProduceTDollController()
        {
        }

        public override void Initialize(ResourceManager resourceManager, TicketResourceController ticketResourceController, string menuName)
        {
            base.Initialize(resourceManager, ticketResourceController, menuName);
            var produceDBIndex = 0;
            foreach (var item in m_produceSlotList)
            {
                item.Initialize(m_dbManager.GetUserDBController().UserProduceTDoll()[produceDBIndex], OrderReceive, Complete);
                produceDBIndex++;
            }
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int steel, int flower, int food, int leather, out bool result)
        { 
            if (m_resourceManager.GetResourceContorller().TDollTicket().Amount >= 0)
            {
                m_resourceManager.GetResourceContorller().OthersResourceAmountCal(Common.Controller.ResourceContorller.E_OthersResourceType.TDollTicket, -1);
                m_ticketResourceController.UpdateValue();
                base.OrderReceive(produceData, steel, flower, food, leather, out result);

                var list = new List<DB.Index.IndexDataBase_TDoll>();
                var selectNumber = 0;

                if (steel >= 400 &&
                    flower >= 400 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 100 &&
                    flower >= 400 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.Archer);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 400 &&
                    flower >= 100 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.Knight);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 400 &&
                    flower >= 400 &&
                    food >= 100 &&
                    leather >= 200)
                {
                    list = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.Magician);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else
                {
                    list = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }

                selectNumber = UnityEngine.Random.Range(0, list.Count);

                var tempList = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.All);
                var temp = new DB.Index.IndexDataBase_TDoll();
                foreach (var item in tempList)
                {
                    if (item.DataCode == list[selectNumber].DataCode)
                    {
                        temp = item;
                        break;
                    }
                }
                produceData.DataCode = temp.DataCode;
                produceData.CompleteTime = DateTime.Now.AddSeconds(temp.ManufacturingTime).ToString();

                m_dbManager.GetUserDBController().UpdateProduceTDoll(produceData);
            }
            else
                result = false;
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_dbManager.GetIndexDBController().TDoll(DB.Index.Controller.IndexDBController.E_TDoll.All);
            var temp = new DB.Index.IndexDataBase_TDoll();
            foreach (var item in tempList)
            {
                if (item.DataCode == produceData.DataCode)
                {
                    temp = item;
                    break;
                }
            }
            produceData.DataCode = 0;
            produceData.CompleteTime = string.Empty;

            m_dbManager.GetUserDBController().AddOwnership(temp);
            m_dbManager.GetUserDBController().UpdateProduceTDoll(produceData);
        }       
    }
}

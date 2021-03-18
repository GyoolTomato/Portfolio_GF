using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Common;
using Assets.Common.DB.User;
using UnityEngine;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceTDollController : Base.ProduceBase
    {
        public ProduceTDollController()
        {
        }

        public override void Initialize(GameManager gameManager, TicketResourceController ticketResourceController, string menuName)
        {
            base.Initialize(gameManager, ticketResourceController, menuName);
            var produceDBIndex = 0;
            foreach (var item in m_produceSlotList)
            {
                item.Initialize(m_gameManager.GetUserDBController().UserProduceTDoll()[produceDBIndex], OrderReceive, Complete);
                produceDBIndex++;
            }
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int steel, int flower, int food, int leather, out bool result)
        { 
            if (m_gameManager.GetResourceContorller().TDollTicket().Amount >= 0)
            {
                m_gameManager.GetResourceContorller().OthersResourceAmountCal(Common.Controller.ResourceContorller.E_OthersResourceType.TDollTicket, -1);
                m_ticketResourceController.UpdateValue();
                base.OrderReceive(produceData, steel, flower, food, leather, out result);

                var list = new List<Common.DB.Index.IndexDataBase_TDoll>();
                var selectNumber = 0;

                if (steel >= 400 &&
                    flower >= 400 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 100 &&
                    flower >= 400 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Archer);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 400 &&
                    flower >= 100 &&
                    food >= 400 &&
                    leather >= 200)
                {
                    list = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Knight);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 400 &&
                    flower >= 400 &&
                    food >= 100 &&
                    leather >= 200)
                {
                    list = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Magician);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else
                {
                    list = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }

                selectNumber = UnityEngine.Random.Range(0, list.Count);

                var tempList = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);
                var temp = new Common.DB.Index.IndexDataBase_TDoll();
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

                m_gameManager.GetUserDBController().UpdateProduceTDoll(produceData);
            }
            else
                result = false;
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_gameManager.GetIndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);
            var temp = new Common.DB.Index.IndexDataBase_TDoll();
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

            m_gameManager.GetUserDBController().AddOwnership(temp);
            m_gameManager.GetUserDBController().UpdateProduceTDoll(produceData);
        }       
    }
}

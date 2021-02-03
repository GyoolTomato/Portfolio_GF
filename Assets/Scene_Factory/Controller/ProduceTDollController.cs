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
                item.Initialize(m_gameManager.UserDBController().UserProduceTDoll()[produceDBIndex], OrderReceive, Complete);
                produceDBIndex++;
            }
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies, out bool result)
        {
            if (m_gameManager.ResourceContorller().TDollTicket().Amount >= 0)
            {
                m_gameManager.ResourceContorller().OthersResourceAmountCal(Common.Controller.ResourceContorller.E_OthersResourceType.TDollTicket, -1);
                m_ticketResourceController.UpdateValue();
                base.OrderReceive(produceData, manPower, bullet, food, militarySupplies, out result);

                var list = new List<Common.DB.Index.IndexDataBase_TDoll>();
                var selectNumber = 0;

                if (manPower >= 400 &&
                    bullet >= 400 &&
                    food >= 400 &&
                    militarySupplies >= 200)
                {
                    list = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (manPower >= 100 &&
                    bullet >= 400 &&
                    food >= 400 &&
                    militarySupplies >= 200)
                {
                    list = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Archer);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (manPower >= 400 &&
                    bullet >= 100 &&
                    food >= 400 &&
                    militarySupplies >= 200)
                {
                    list = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Knight);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (manPower >= 400 &&
                    bullet >= 400 &&
                    food >= 100 &&
                    militarySupplies >= 200)
                {
                    list = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.Magician);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else
                {
                    list = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }

                selectNumber = UnityEngine.Random.Range(0, list.Count);

                var tempList = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);
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

                m_gameManager.UserDBController().UpdateProduceTDoll(produceData);
            }
            else
                result = false;
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_gameManager.IndexDBController().TDoll(Common.Controller.IndexDBController.E_TDoll.All);
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

            m_gameManager.UserDBController().AddOwnership(temp);
            m_gameManager.UserDBController().UpdateProduceTDoll(produceData);
        }       
    }
}

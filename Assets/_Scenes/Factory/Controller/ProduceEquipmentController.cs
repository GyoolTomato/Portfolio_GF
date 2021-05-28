using System;
using System.Collections.Generic;
using Assets.Common;
using Assets.DB.User.Base;
using UnityEngine;

namespace Assets.Scenes.Factory.Controller
{
    public class ProduceEquipmentController : Base.ProduceBase
    {
        public ProduceEquipmentController()
        {
        }

        public override void Initialize(FactoryManager factoryManager, ResourceManager resourceManager, TicketResourceController ticketResourceController, string menuName)
        {
            base.Initialize(factoryManager, resourceManager, ticketResourceController, menuName);
            var produceDBIndex = 0;
            foreach (var item in m_produceSlotList)
            {
                item.Initialize(m_dbManager.GetUserDBController().UserProduceEquipment()[produceDBIndex], OrderReceive, Complete);
                produceDBIndex++;
            }
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int steel, int flower, int food, int leather, out bool result)
        {
            if (m_resourceManager.GetResourceContorller().EquipmentTicket().Amount >= 0)
            {
                m_resourceManager.GetResourceContorller().OthersResourceAmountCal(Common.Controller.ResourceContorller.E_OthersResourceType.EquipmentTicket, -1);
                m_ticketResourceController.UpdateValue();
                base.OrderReceive(produceData, steel, flower, food, leather, out result);

                var list = new List<DB.Index.IndexDataBase_Equipment>();
                var selectNumber = 0;

                if (steel >= 200 &&
                    flower >= 200 &&
                    food >= 200 &&
                    leather >= 100)
                {
                    list = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 100 &&
                    flower >= 200 &&
                    food >= 200 &&
                    leather >= 100)
                {
                    list = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.Weapon);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 200 &&
                    flower >= 100 &&
                    food >= 200 &&
                    leather >= 100)
                {
                    list = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.Armor);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else if (steel >= 200 &&
                    flower >= 200 &&
                    food >= 100 &&
                    leather >= 100)
                {
                    list = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.Tool);

                    Debug.Log("Order : " + selectNumber.ToString());
                }
                else
                {
                    list = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.All);

                    Debug.Log("Order : " + selectNumber.ToString());
                }

                selectNumber = UnityEngine.Random.Range(0, list.Count);

                var tempList = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.All);
                var temp = new DB.Index.IndexDataBase_Equipment();
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

                m_dbManager.GetUserDBController().UpdateProduceEquipment(produceData);
            }
            else
                result = false;
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_dbManager.GetIndexDBController().Equipment(DB.Index.Controller.IndexDBController.E_Equipment.All);
            var temp = new DB.Index.IndexDataBase_Equipment();
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
            m_dbManager.GetUserDBController().UpdateProduceEquipment(produceData);

            InsertData(temp.DataCode);            
        }

        protected override void InsertData(int dataCode)
        {
            var data = new UserDataBase_Equipment();
            data.DataCode = dataCode;
            data.Level = 1;
            data.LimitedPower = UnityEngine.Random.Range(10, 101);

            m_dbManager.GetUserDBController().AddOwnership(data);
            m_factoryManager.GetSpawnPopupController().Open(data);
        }
    }
}

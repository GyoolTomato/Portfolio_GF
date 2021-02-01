﻿using System;
using System.Collections.Generic;
using Assets.Common.DB.User;
using UnityEngine;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceEquipmentController : Base.ProduceBase
    {
        public ProduceEquipmentController()
        {
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies, out bool result)
        {
            base.OrderReceive(produceData, manPower, bullet, food, militarySupplies, out result);

            var list = new List<Common.DB.Index.IndexDataBase_Equipment>();
            var selectNumber = 0;

            if (manPower >= 200 &&
                bullet >= 200 &&
                food >= 200 &&
                militarySupplies >= 100)
            {
                list = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.All);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 100 &&
                bullet >= 200 &&
                food >= 200 &&
                militarySupplies >= 100)
            {
                list = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.Weapon);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 200 &&
                bullet >= 100 &&
                food >= 200 &&
                militarySupplies >= 100)
            {
                list = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.Armor);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 200 &&
                bullet >= 200 &&
                food >= 100 &&
                militarySupplies >= 100)
            {
                list = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.Tool);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else
            {
                list = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.All);

                Debug.Log("Order : " + selectNumber.ToString());
            }

            selectNumber = UnityEngine.Random.Range(0, list.Count);

            var tempList = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.All);
            var temp = new Common.DB.Index.IndexDataBase_Equipment();
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

            m_gameManager.DBControllerUser.UpdateProduceEquipment(produceData);
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_gameManager.DBControllerIndex.Equipment(Common.DB.Index.Manager.DBController_Index.E_Equipment.All);
            var temp = new Common.DB.Index.IndexDataBase_Equipment();
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

            m_gameManager.DBControllerUser.AddOwnership(temp);
            m_gameManager.DBControllerUser.UpdateProduceEquipment(produceData);
        }
    }
}

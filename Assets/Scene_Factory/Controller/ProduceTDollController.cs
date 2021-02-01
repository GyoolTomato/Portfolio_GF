using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Common.DB.User;
using UnityEngine;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceTDollController : Base.ProduceBase
    {
        public ProduceTDollController()
        {
        }

        protected override void OrderReceive(UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies, out bool result)
        {
            base.OrderReceive(produceData, manPower, bullet, food, militarySupplies, out result);

            var list = new List<Common.DB.Index.IndexDataBase_TDoll>();
            var selectNumber = 0;

            if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                list = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.All);

                Debug.Log("Order : " + selectNumber.ToString());
            }
                else if (manPower >= 100 &&
                    bullet >= 400 &&
                    food >= 400 &&
                    militarySupplies >= 200)
            {
                list = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.Archer);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 100 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                list = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.Knight);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 100 &&
                militarySupplies >= 200)
            {
                list = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.Magician);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else
            {
                list = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.All);

                Debug.Log("Order : " + selectNumber.ToString());
            }

            selectNumber = UnityEngine.Random.Range(0, list.Count);

            var tempList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.All);
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

            m_gameManager.DBControllerUser.UpdateProduceTDoll(produceData);
        }

        protected override void Complete(UserDataBase_Produce produceData)
        {
            base.Complete(produceData);

            var tempList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.Manager.DBController_Index.E_TDoll.All);
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

            m_gameManager.DBControllerUser.AddOwnership(temp);
            m_gameManager.DBControllerUser.UpdateProduceTDoll(produceData);
        }       
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceTDollController
    {
        private Object.ProduceSlot m_produceSlot_0;
        private Object.ProduceSlot m_produceSlot_1;

        private Assets.Common.GameManager m_gameManager;        

        public ProduceTDollController()
        {
        }

        public void Initialize(Assets.Common.GameManager gameManager)
        {
            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var produceTDoll = menuView.Find("ProduceTDoll");
            m_produceSlot_0 = produceTDoll.transform.Find("ProduceSlot_0").GetComponent<Object.ProduceSlot>();
            m_produceSlot_0.SetOrder(OrderReceive);
            m_produceSlot_1 = produceTDoll.transform.Find("ProduceSlot_1").GetComponent<Object.ProduceSlot>();
            m_produceSlot_1.SetOrder(OrderReceive);
            
            m_gameManager = gameManager;
        }

        public void OrderReceive(int manPower, int bullet, int food, int militarySupplies)
        {
            var tDollList = new List<Common.DB.IndexDataBase_TDoll>();
            var selectNumber = 0;

            if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DBController_Index.E_TDoll.All);
                selectNumber = UnityEngine.Random.Range(0, tDollList.Count);
                                
                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 100 &&
                bullet >= 400 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DBController_Index.E_TDoll.Archer);
                selectNumber = UnityEngine.Random.Range(0, tDollList.Count);

                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 100 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DBController_Index.E_TDoll.Knight);
                selectNumber = UnityEngine.Random.Range(0, tDollList.Count);

                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 100 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DBController_Index.E_TDoll.Magician);
                selectNumber = UnityEngine.Random.Range(0, tDollList.Count);

                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DBController_Index.E_TDoll.All);
                selectNumber = UnityEngine.Random.Range(0, tDollList.Count);

                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);

                Debug.Log("Order : " + selectNumber.ToString());
            }
        }

        
    }
}

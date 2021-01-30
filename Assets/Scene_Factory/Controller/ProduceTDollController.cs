using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Timeline.Actions;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceTDollController
    {
        private Assets.Common.GameManager m_gameManager;

        private List<Object.ProduceSlot> m_list_ProduceSlot;
        private GameObject m_messagePanel;              

        public ProduceTDollController()
        {
        }

        public void Initialize(Assets.Common.GameManager gameManager)
        {
            m_gameManager = gameManager;            

            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var produceTDoll = menuView.Find("ProduceTDoll");
            m_list_ProduceSlot = new List<Object.ProduceSlot>();
            m_list_ProduceSlot.Add(produceTDoll.transform.Find("ProduceSlot_0").GetComponent<Object.ProduceSlot>());
            m_list_ProduceSlot.Add(produceTDoll.transform.Find("ProduceSlot_1").GetComponent<Object.ProduceSlot>());
            var produceDBIndex = 0;
            foreach (var item in m_list_ProduceSlot)
            {
                item.Initialize(m_gameManager.DBControllerUser.UserProduceTDoll[produceDBIndex], OrderReceive, Complete);
                produceDBIndex++;
            }

            m_messagePanel = canvas.transform.Find("MessagePanel").gameObject;
        }

        public bool OrderReceive(Common.DB.User.UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies)
        {
            if (m_gameManager.WorkResource.WorkResourceConsumption(manPower, bullet, food, militarySupplies))
            {
                m_messagePanel.SetActive(false);
            }
            else
            {
                m_messagePanel.SetActive(true);
                m_gameManager.StartCoroutine(OffMessagePanel());
                return false;
            }

            var tDollList = new List<Common.DB.Index.IndexDataBase_TDoll>();
            var selectNumber = 0;

            if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.All);             

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 100 &&
                bullet >= 400 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.Archer);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 100 &&
                food >= 400 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.Knight);

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else if (manPower >= 400 &&
                bullet >= 400 &&
                food >= 100 &&
                militarySupplies >= 200)
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.Magician);       

                Debug.Log("Order : " + selectNumber.ToString());
            }
            else
            {
                tDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.All);                               

                Debug.Log("Order : " + selectNumber.ToString());
            }

            selectNumber = UnityEngine.Random.Range(0, tDollList.Count);            

            var tempTDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.All);
            var tempTDoll = new Common.DB.Index.IndexDataBase_TDoll();
            foreach (var item in tempTDollList)
            {
                if (item.DataCode == tDollList[selectNumber].DataCode)
                {
                    tempTDoll = item;
                    break;
                }
            }
            produceData.DataCode = tempTDoll.DataCode;
            produceData.CompleteTime = DateTime.Now.AddSeconds(tempTDoll.ManufacturingTime).ToString();

            m_gameManager.DBControllerUser.UpdateProduceTDoll(produceData);

            return true;
        }

        public bool Complete(Common.DB.User.UserDataBase_Produce produceData)
        {
            var tempTDollList = m_gameManager.DBControllerIndex.TDoll(Common.DB.Index.DBController_Index.E_TDoll.All);
            var tempTDoll = new Common.DB.Index.IndexDataBase_TDoll();
            foreach (var item in tempTDollList)
            {
                if (item.DataCode == produceData.DataCode)
                {
                    tempTDoll = item;
                    break;
                }
            }
            produceData.DataCode = 0;
            produceData.CompleteTime = string.Empty;

            m_gameManager.DBControllerUser.AddOwnership(tempTDoll);
            m_gameManager.DBControllerUser.UpdateProduceTDoll(produceData);

            return true;
        }

        private IEnumerator OffMessagePanel()
        {
            yield return new WaitForSeconds(2.0f);
            m_messagePanel.SetActive(false);
        }
    }
}

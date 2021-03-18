using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Interface;
using Assets.Common.DB.User;
using Assets.Common.DB.User.Manager;
using Assets.Common.DB.Common;

namespace Assets.Common.Controller
{
    public class ResourceContorller
    {
        public enum E_OthersResourceType
        {
            PassTicket,
            TDollTicket,
            EquipmentTicket,
            End,
        }

        private GameManager m_gameManager;
        private UserDBManager m_userDBManager;

        private bool m_collecting;
        private WorkResource m_steel;
        private WorkResource m_flower;
        private WorkResource m_food;
        private WorkResource m_leather;

        private OthersResource m_passTicket;
        private OthersResource m_tDollTicket;
        private OthersResource m_equipmentTicket;

        public ResourceContorller()
        {

        }

        public void Initialize(GameManager gameManager, UserDBManager userDBManager)
        {
            m_gameManager = gameManager;
            m_userDBManager = userDBManager;

            m_steel = new WorkResource();
            m_steel.Title = "강철";
            m_steel.DBName = "Steel";
            m_steel.Amount = 0;
            m_steel.ChargingVolume_Time = 3.0f;
            m_steel.ChargingVolume_Amount = 120;

            m_flower = new WorkResource();
            m_flower.Title = "약초";
            m_flower.DBName = "Flower";
            m_flower.Amount = 0;
            m_flower.ChargingVolume_Time = 3.0f;
            m_flower.ChargingVolume_Amount = 120;

            m_food = new WorkResource();
            m_food.Title = "식량";
            m_food.DBName = "Food";
            m_food.Amount = 0;
            m_food.ChargingVolume_Time = 3.0f;
            m_food.ChargingVolume_Amount = 120;

            m_leather = new WorkResource();
            m_leather.Title = "가죽";
            m_leather.DBName = "Leather";
            m_leather.Amount = 0;
            m_leather.ChargingVolume_Time = 3.0f;
            m_leather.ChargingVolume_Amount = 40;

            m_passTicket = new OthersResource();
            m_passTicket.Title = "쾌속 제조권";
            m_passTicket.Amount = 0;

            m_tDollTicket = new OthersResource();
            m_tDollTicket.Title = "인형 제조권";
            m_tDollTicket.Amount = 0;

            m_equipmentTicket = new OthersResource();
            m_equipmentTicket.Title = "장비 제조권";
            m_equipmentTicket.Amount = 0;
        }

        private void ReadUserWorkResource()
        {
            foreach (var item in m_gameManager.GetUserDBController().UserResource())
            {
                if (item.Name == "Steel")
                {
                    m_steel.Amount = item.Value;
                }
                else if (item.Name == "Flower")
                {
                    m_flower.Amount = item.Value;
                }
                else if (item.Name == "Food")
                {
                    m_food.Amount = item.Value;
                }
                else if (item.Name == "Leather")
                {
                    m_leather.Amount = item.Value;
                }
            }
        }

        public void ReadOthersResource()
        {
            var tempList = new ArrayList();
            var temp = new CommonDataBase_Resource();

            tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourcePassTicket);
            temp = tempList[0] as CommonDataBase_Resource;
            m_passTicket.Amount = temp.Value;

            tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourceTDollTicket);
            temp = tempList[0] as CommonDataBase_Resource;
            m_tDollTicket.Amount = temp.Value;

            tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourceEquipmentTicket);
            temp = tempList[0] as CommonDataBase_Resource;
            m_equipmentTicket.Amount = temp.Value;
        }

        public void StartCollectWorkResource()
        {
            if (!m_collecting)
            {
                m_gameManager.StartCoroutine(SteelCharger());
                m_gameManager.StartCoroutine(FlowerCharger());
                m_gameManager.StartCoroutine(FoodCharger());
                m_gameManager.StartCoroutine(LeatherCharger());
                m_collecting = true;
            }
        }        

        IEnumerator SteelCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_steel.ChargingVolume_Time);
                m_steel.Amount += m_steel.ChargingVolume_Amount;
                m_gameManager.GetUserDBController().UpdateResource(m_steel);
            }
        }
        IEnumerator FlowerCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_flower.ChargingVolume_Time);
                m_flower.Amount += m_flower.ChargingVolume_Amount;
                m_gameManager.GetUserDBController().UpdateResource(m_flower);
            }
        }
        IEnumerator FoodCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_food.ChargingVolume_Time);
                m_food.Amount += m_food.ChargingVolume_Amount;
                m_gameManager.GetUserDBController().UpdateResource(m_food);
            }
        }
        IEnumerator LeatherCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_leather.ChargingVolume_Time);
                m_leather.Amount += m_leather.ChargingVolume_Amount;
                m_gameManager.GetUserDBController().UpdateResource(m_leather);
            }
        }

        public bool WorkResourceConsumption(int steel, int flower, int food, int leather)
        {
            var result = false;

            if (m_steel.Amount >= steel &&
                m_flower.Amount >= flower &&
                m_food.Amount >= food &&
                m_leather.Amount >= leather)
            {
                m_steel.Amount -= steel;
                m_flower.Amount -= flower;
                m_food.Amount -= food;
                m_leather.Amount -= leather;
                m_gameManager.GetUserDBController().UpdateResource(m_steel);
                m_gameManager.GetUserDBController().UpdateResource(m_flower);
                m_gameManager.GetUserDBController().UpdateResource(m_food);
                m_gameManager.GetUserDBController().UpdateResource(m_leather);

                ReadUserWorkResource();
                result = true;
            }
            else
            {
                Debug.Log("WorkResourceConsu Lack of WorkResource");
            }

            return result;
        }

        public bool OthersResourceAmountCal(E_OthersResourceType type, int amount)
        {
            var tempList = new ArrayList();
            var temp = new CommonDataBase_Resource();

            try
            {
                switch (type)
                {
                    case E_OthersResourceType.PassTicket:
                        tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourcePassTicket);
                        break;
                    case E_OthersResourceType.TDollTicket:
                        tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourceTDollTicket);
                        break;
                    case E_OthersResourceType.EquipmentTicket:
                        tempList = m_userDBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResourceEquipmentTicket);
                        break;
                    default:
                        break;
                }
                temp = tempList[0] as CommonDataBase_Resource;

                if (temp.Value + amount >= 0)
                {
                    temp.Value += amount;

                    m_userDBManager.SQL(QuerySupport_User.UpdateResource(temp));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public WorkResource Steel()
        {
            return m_steel;
        }

        public WorkResource Flower()
        {
            return m_flower;
        }

        public WorkResource Food()
        {
            return m_food;
        }

        public WorkResource Leather()
        {
            return m_leather;
        }

        public OthersResource PassTicket()
        {
            return m_passTicket;
        }

        public OthersResource TDollTicket()
        {
            return m_tDollTicket;
        }

        public OthersResource EquipmentTicket()
        {
            return m_equipmentTicket;
        }        
    }
}

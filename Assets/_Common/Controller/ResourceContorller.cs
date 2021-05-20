using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Interface;
using Assets.DB;
using Assets.DB.User.Base;

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

        private ResourceManager m_resourceManager;
        private DbManager m_dbManager;

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

        public void Initialize(ResourceManager resourceManager)
        {
            m_resourceManager = resourceManager;
            m_dbManager = GameObject.Find("GameManager").GetComponent<DB.DbManager>();

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
            m_passTicket.ImageSprite = m_resourceManager.GetSpriteController().GetWorkResource("PassTicket");
            m_passTicket.Title = "쾌속 제조권";
            m_passTicket.Amount = 0;

            m_tDollTicket = new OthersResource();
            m_tDollTicket.ImageSprite = m_resourceManager.GetSpriteController().GetWorkResource("TDollTicket");
            m_tDollTicket.Title = "인형 제조권";
            m_tDollTicket.Amount = 0;

            m_equipmentTicket = new OthersResource();
            m_equipmentTicket.ImageSprite = m_resourceManager.GetSpriteController().GetWorkResource("EquipmentTicket");
            m_equipmentTicket.Title = "장비 제조권";
            m_equipmentTicket.Amount = 0;
        }

        private void ReadUserWorkResource()
        {
            foreach (var item in m_dbManager.GetUserDBController().UserResource())
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
            var temp = new DB.Common.CommonDataBase_Resource();

            tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourcePassTicket);
            temp = tempList[0] as DB.Common.CommonDataBase_Resource;
            m_passTicket.Amount = temp.Value;

            tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourceTDollTicket);
            temp = tempList[0] as DB.Common.CommonDataBase_Resource;
            m_tDollTicket.Amount = temp.Value;

            tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourceEquipmentTicket);
            temp = tempList[0] as DB.Common.CommonDataBase_Resource;
            m_equipmentTicket.Amount = temp.Value;
        }

        public void StartCollectWorkResource()
        {
            if (!m_collecting)
            {
                m_resourceManager.StartCoroutine(SteelCharger());
                m_resourceManager.StartCoroutine(FlowerCharger());
                m_resourceManager.StartCoroutine(FoodCharger());
                m_resourceManager.StartCoroutine(LeatherCharger());
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
                m_dbManager.GetUserDBController().UpdateResource(m_steel);
            }
        }
        IEnumerator FlowerCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_flower.ChargingVolume_Time);
                m_flower.Amount += m_flower.ChargingVolume_Amount;
                m_dbManager.GetUserDBController().UpdateResource(m_flower);
            }
        }
        IEnumerator FoodCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_food.ChargingVolume_Time);
                m_food.Amount += m_food.ChargingVolume_Amount;
                m_dbManager.GetUserDBController().UpdateResource(m_food);
            }
        }
        IEnumerator LeatherCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_leather.ChargingVolume_Time);
                m_leather.Amount += m_leather.ChargingVolume_Amount;
                m_dbManager.GetUserDBController().UpdateResource(m_leather);
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
                m_dbManager.GetUserDBController().UpdateResource(m_steel);
                m_dbManager.GetUserDBController().UpdateResource(m_flower);
                m_dbManager.GetUserDBController().UpdateResource(m_food);
                m_dbManager.GetUserDBController().UpdateResource(m_leather);

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
            var temp = new DB.Common.CommonDataBase_Resource();

            try
            {
                switch (type)
                {
                    case E_OthersResourceType.PassTicket:
                        tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourcePassTicket);
                        break;
                    case E_OthersResourceType.TDollTicket:
                        tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourceTDollTicket);
                        break;
                    case E_OthersResourceType.EquipmentTicket:
                        tempList = m_dbManager.GetUserDBManager().ReadDataBase(DB.User.UserDBManager.E_Table.Resource, QuerySupport.SelectResourceEquipmentTicket);
                        break;
                    default:
                        break;
                }
                temp = tempList[0] as DB.Common.CommonDataBase_Resource;

                if (temp.Value + amount >= 0)
                {
                    temp.Value += amount;

                    m_dbManager.GetUserDBManager().SQL(QuerySupport.UpdateResource(temp));
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

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
        private WorkResource m_manPower;
        private WorkResource m_bullet;
        private WorkResource m_food;
        private WorkResource m_militarySupplies;

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

            m_manPower = new WorkResource();
            m_manPower.Title = "인력";
            m_manPower.DBName = "ManPower";
            m_manPower.Amount = 0;
            m_manPower.ChargingVolume_Time = 3.0f;
            m_manPower.ChargingVolume_Amount = 120;

            m_bullet = new WorkResource();
            m_bullet.Title = "탄약";
            m_bullet.DBName = "Bullet";
            m_bullet.Amount = 0;
            m_bullet.ChargingVolume_Time = 3.0f;
            m_bullet.ChargingVolume_Amount = 120;

            m_food = new WorkResource();
            m_food.Title = "식량";
            m_food.DBName = "Food";
            m_food.Amount = 0;
            m_food.ChargingVolume_Time = 3.0f;
            m_food.ChargingVolume_Amount = 120;

            m_militarySupplies = new WorkResource();
            m_militarySupplies.Title = "부품";
            m_militarySupplies.DBName = "MilitarySupplies";
            m_militarySupplies.Amount = 0;
            m_militarySupplies.ChargingVolume_Time = 3.0f;
            m_militarySupplies.ChargingVolume_Amount = 40;

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
            foreach (var item in m_gameManager.UserDBController().UserResource())
            {
                if (item.Name == "ManPower")
                {
                    m_manPower.Amount = item.Value;
                    Debug.Log("DB MaPower : " + item.Value);
                }
                else if (item.Name == "Bullet")
                {
                    m_bullet.Amount = item.Value;
                }
                else if (item.Name == "Food")
                {
                    m_food.Amount = item.Value;
                }
                else if (item.Name == "MilitarySupplies")
                {
                    m_militarySupplies.Amount = item.Value;
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
                m_gameManager.StartCoroutine(ManPowerCharger());
                m_gameManager.StartCoroutine(BulletCharger());
                m_gameManager.StartCoroutine(FoodCharger());
                m_gameManager.StartCoroutine(MilitarySuppliesCharger());
                m_collecting = true;
            }
        }        

        IEnumerator ManPowerCharger()
        {
            while (true)
            {
                Debug.Log("MaPower : " + m_manPower.Amount);
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_manPower.ChargingVolume_Time);
                m_manPower.Amount += m_manPower.ChargingVolume_Amount;
                m_gameManager.UserDBController().UpdateResource(m_manPower);
            }
        }
        IEnumerator BulletCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_bullet.ChargingVolume_Time);
                m_bullet.Amount += m_bullet.ChargingVolume_Amount;
                m_gameManager.UserDBController().UpdateResource(m_bullet);
            }
        }
        IEnumerator FoodCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_food.ChargingVolume_Time);
                m_food.Amount += m_food.ChargingVolume_Amount;
                m_gameManager.UserDBController().UpdateResource(m_food);
            }
        }
        IEnumerator MilitarySuppliesCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_militarySupplies.ChargingVolume_Time);
                m_militarySupplies.Amount += m_militarySupplies.ChargingVolume_Amount;
                m_gameManager.UserDBController().UpdateResource(m_militarySupplies);
            }
        }

        public bool WorkResourceConsumption(int manPower, int bullet, int food, int militarySupplies)
        {
            var result = false;

            if (m_manPower.Amount >= manPower &&
                m_bullet.Amount >= bullet &&
                m_food.Amount >= food &&
                m_militarySupplies.Amount >= militarySupplies)
            {
                m_manPower.Amount -= manPower;
                m_bullet.Amount -= bullet;
                m_food.Amount -= food;
                m_militarySupplies.Amount -= militarySupplies;
                m_gameManager.UserDBController().UpdateResource(m_manPower);
                m_gameManager.UserDBController().UpdateResource(m_bullet);
                m_gameManager.UserDBController().UpdateResource(m_food);
                m_gameManager.UserDBController().UpdateResource(m_militarySupplies);

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

        public WorkResource ManPower()
        {
            return m_manPower;
        }

        public WorkResource Bullet()
        {
            return m_bullet;
        }

        public WorkResource Food()
        {
            return m_food;
        }

        public WorkResource MilitarySupplies()
        {
            return m_militarySupplies;
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

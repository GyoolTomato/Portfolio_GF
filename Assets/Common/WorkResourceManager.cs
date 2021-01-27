using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Interface;

namespace Assets.Common
{
    public class WorkResourceManager
    {
        private GameManager m_gameManager;

        private bool m_collecting;
        private WorkResource m_manPower;
        private WorkResource m_bullet;
        private WorkResource m_food;
        private WorkResource m_militarySupplies;

        public void Initialize(GameManager gameManager)
        {
            m_gameManager = gameManager;

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

        private void ReadUserWorkResource()
        {
            foreach (var item in m_gameManager.DBControllerUser.UserWorkResource)
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

        IEnumerator ManPowerCharger()
        {
            while (true)
            {
                Debug.Log("MaPower : " + m_manPower.Amount);
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_manPower.ChargingVolume_Time);                
                m_manPower.Amount += m_manPower.ChargingVolume_Amount;
                m_gameManager.DBControllerUser.ApplyWorkResource(m_manPower);                
            }
        }
        IEnumerator BulletCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_bullet.ChargingVolume_Time);                
                m_bullet.Amount += m_bullet.ChargingVolume_Amount;
                m_gameManager.DBControllerUser.ApplyWorkResource(m_bullet);                
            }
        }
        IEnumerator FoodCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_food.ChargingVolume_Time);                
                m_food.Amount += m_food.ChargingVolume_Amount;
                m_gameManager.DBControllerUser.ApplyWorkResource(m_food);                
            }
        }
        IEnumerator MilitarySuppliesCharger()
        {
            while (true)
            {
                ReadUserWorkResource();
                yield return new WaitForSeconds(m_militarySupplies.ChargingVolume_Time);                
                m_militarySupplies.Amount += m_militarySupplies.ChargingVolume_Amount;
                m_gameManager.DBControllerUser.ApplyWorkResource(m_militarySupplies);                
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
                m_gameManager.DBControllerUser.ApplyWorkResource(m_manPower);
                m_gameManager.DBControllerUser.ApplyWorkResource(m_bullet);
                m_gameManager.DBControllerUser.ApplyWorkResource(m_food);
                m_gameManager.DBControllerUser.ApplyWorkResource(m_militarySupplies);

                ReadUserWorkResource();
                result = true;
            }
            else
            {
                Debug.Log("WorkResourceConsu Lack of WorkResource");
            }

            return result;
        }

        public WorkResource ManPower
        {
            get
            {
                return m_manPower;
            }
        }

        public WorkResource Bullet
        {
            get
            {
                return m_bullet;
            }
        }

        public WorkResource Food
        {
            get
            {
                return m_food;
            }
        }

        public WorkResource MilitarySupplies
        {
            get
            {
                return m_militarySupplies;
            }
        }
    }
}
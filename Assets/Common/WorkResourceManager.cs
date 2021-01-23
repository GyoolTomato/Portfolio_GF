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
        private WorkResource m_manPower;
        private WorkResource m_bullet;
        private WorkResource m_food;
        private WorkResource m_militarySupplies;

        public void Initialize(GameManager gameManager)
        {
            m_gameManager = gameManager;

            m_manPower = new WorkResource();
            m_manPower.Title = "인력";
            m_manPower.Amount = 0;
            m_manPower.ChargingVolume_Time = 3.0f;
            m_manPower.ChargingVolume_Amount = 3;

            m_bullet = new WorkResource();
            m_bullet.Title = "탄약";
            m_bullet.Amount = 0;
            m_bullet.ChargingVolume_Time = 3.0f;
            m_bullet.ChargingVolume_Amount = 3;

            m_food = new WorkResource();
            m_food.Title = "식량";
            m_food.Amount = 0;
            m_food.ChargingVolume_Time = 3.0f;
            m_food.ChargingVolume_Amount = 3;

            m_militarySupplies = new WorkResource();
            m_militarySupplies.Title = "부품";
            m_militarySupplies.Amount = 0;
            m_militarySupplies.ChargingVolume_Time = 3.0f;
            m_militarySupplies.ChargingVolume_Amount = 1;

            m_gameManager.StartCoroutine(ManPowerCharger());
            m_gameManager.StartCoroutine(BulletCharger());
            m_gameManager.StartCoroutine(FoodCharger());
            m_gameManager.StartCoroutine(MilitarySuppliesCharger());
        }

        private void ApplySaveAmount()
        {
            

            m_manPower.Amount = 0;
            m_bullet.Amount = 0;
            m_food.Amount = 0;
            m_militarySupplies.Amount = 0;            
        }

        IEnumerator ManPowerCharger()
        {
            while (true)
            {
                m_manPower.Amount += m_manPower.ChargingVolume_Amount;
                ApplySaveAmount();
                yield return new WaitForSeconds(m_manPower.ChargingVolume_Time);
            }            
        }
        IEnumerator BulletCharger()
        {
            while (true)
            {
                m_bullet.Amount += m_bullet.ChargingVolume_Amount;
                ApplySaveAmount();
                yield return new WaitForSeconds(m_bullet.ChargingVolume_Time);
            }
        }
        IEnumerator FoodCharger()
        {
            while (true)
            {
                m_food.Amount += m_food.ChargingVolume_Amount;
                ApplySaveAmount();
                yield return new WaitForSeconds(m_food.ChargingVolume_Time);
            }
        }
        IEnumerator MilitarySuppliesCharger()
        {
            while (true)
            {
                m_militarySupplies.Amount += m_militarySupplies.ChargingVolume_Amount;
                ApplySaveAmount();
                yield return new WaitForSeconds(m_militarySupplies.ChargingVolume_Time);
            }
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
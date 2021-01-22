using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Interface;

namespace Assets.Common
{
    public class WorkResourceManager
    {
        private WorkResource m_manPower;
        private WorkResource m_bullet;
        private WorkResource m_food;
        private WorkResource m_militarySupplies;

        public void Initialize()
        {
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
        }

        public void ApplySaveAmount()
        {
            m_manPower.Amount = 0;
            m_bullet.Amount = 0;
            m_food.Amount = 0;
            m_militarySupplies.Amount = 0;
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
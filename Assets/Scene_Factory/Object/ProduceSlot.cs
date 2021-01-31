using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Object
{
    public class ProduceSlot : MonoBehaviour
    {
        private enum E_State
        {
            Stanby,
            Working,
            End,
        }

        public delegate void CompleteListener(Common.DB.User.UserDataBase_Produce produceData);
        public delegate void OrderListener(Common.DB.User.UserDataBase_Produce produceData, int manPower, int bullet, int food, int militarySupplies, out bool result);

        private E_State m_state;
        private OrderListener m_order;
        private CompleteListener m_complete;
        private Assets.Common.DB.User.UserDataBase_Produce m_userDataBase_Produce;          
        private TimeSpan m_diffTime;

        private GameObject m_orderState;
        private Button m_completeButton;
        private Text m_remainingTime;
        private GameObject m_orderPanel;
        private Button m_orderButton;
        private WorkResourceSlot m_manPower;
        private WorkResourceSlot m_bullet;
        private WorkResourceSlot m_food;
        private WorkResourceSlot m_militarySupplies;        

        // Start is called before the first frame update
        private void Start()
        {
            m_state = E_State.End;

            m_orderState = this.transform.Find("OrderState").gameObject;
            m_completeButton = m_orderState.transform.Find("Complete").GetComponent<Button>();
            m_completeButton.onClick.AddListener(Handle_Complete);
            m_remainingTime = m_completeButton.transform.Find("Text").GetComponent<Text>();
            m_orderPanel = this.transform.Find("OrderPanel").gameObject;
            m_orderButton = m_orderPanel.transform.Find("Order").GetComponent<Button>();
            m_orderButton.onClick.AddListener(Handle_Order);
            m_manPower = m_orderPanel.transform.Find("WorkResourceSlot_ManPower").GetComponent<WorkResourceSlot>();
            m_bullet = m_orderPanel.transform.Find("WorkResourceSlot_Bullet").GetComponent<WorkResourceSlot>();
            m_food = m_orderPanel.transform.Find("WorkResourceSlot_Food").GetComponent<WorkResourceSlot>();
            m_militarySupplies = m_orderPanel.transform.Find("WorkResourceSlot_MilitarySupplies").GetComponent<WorkResourceSlot>();
            
        }

        // Update is called once per frame
        private void Update()
        {
            if (m_state == E_State.Working)
            {
                m_diffTime = DateTime.Parse(m_userDataBase_Produce.CompleteTime) - DateTime.Now;

                if (m_diffTime.TotalSeconds > 0)
                {
                    m_remainingTime.text = m_diffTime.Hours.ToString("00") + ":" + m_diffTime.Minutes.ToString("00") + ":" + m_diffTime.Seconds.ToString("00");
                }
                else
                {
                    m_remainingTime.text = "00:00:00";
                }                
            }
        }

        public void Initialize(Assets.Common.DB.User.UserDataBase_Produce userDataBase_Produce, OrderListener order, CompleteListener complete)
        {
            m_userDataBase_Produce = userDataBase_Produce;
            m_order = order;
            m_complete = complete;

            if (m_userDataBase_Produce.DataCode == 0)
            {
                ChangeState(E_State.Stanby);
            }
            else
            {
                ChangeState(E_State.Working);
            }
        }

        public Assets.Common.DB.User.UserDataBase_Produce GetAppliedProduceData
        {
            get
            {
                return m_userDataBase_Produce;
            }
        }

        private void ChangeState(E_State state)
        {
            switch (state)
            {
                case E_State.Stanby:
                    m_orderState.SetActive(false);
                    m_orderPanel.SetActive(true);
                    m_state = state;
                    break;
                case E_State.Working:
                    m_orderState.SetActive(true);
                    m_orderPanel.SetActive(false);
                    m_state = state;
                    break;
                default:
                    break;
            }
        }

        private void Handle_Complete()
        {
            if (m_diffTime.TotalSeconds <= 0)
            {
                m_complete(m_userDataBase_Produce);                

                ChangeState(E_State.Stanby);
            }
        }

        private void Handle_Order()
        {
            var orderData = new object();
            var result = false;
            m_order(m_userDataBase_Produce, m_manPower.Value, m_bullet.Value, m_food.Value, m_militarySupplies.Value, out result);

            if (result)
            {
                ChangeState(E_State.Working);
            }
        }        
    }
}


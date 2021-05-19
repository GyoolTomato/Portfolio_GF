using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Factory.Object
{
    public class ProduceSlot : MonoBehaviour
    {
        private enum E_State
        {
            Stanby,
            Working,
            End,
        }

        public delegate void CompleteListener(DB.User.UserDataBase_Produce produceData);
        public delegate void OrderListener(DB.User.UserDataBase_Produce produceData, int steel, int flower, int food, int leather, out bool result);

        private E_State m_state;
        private OrderListener m_order;
        private CompleteListener m_complete;
        private DB.User.UserDataBase_Produce m_userDataBase_Produce;          
        private TimeSpan m_diffTime;

        private GameObject m_orderState;
        private Button m_completeButton;
        private Text m_remainingTime;
        private GameObject m_orderPanel;
        private Button m_orderButton;
        private WorkResourceSlot m_steel;
        private WorkResourceSlot m_flower;
        private WorkResourceSlot m_food;
        private WorkResourceSlot m_leather;

        private void Awake()
        {
            m_state = E_State.End;

            m_orderState = this.transform.Find("OrderState").gameObject;
            m_completeButton = m_orderState.transform.Find("Complete").GetComponent<Button>();
            m_completeButton.onClick.AddListener(Handle_Complete);
            m_remainingTime = m_completeButton.transform.Find("Text").GetComponent<Text>();
            m_orderPanel = this.transform.Find("OrderPanel").gameObject;
            m_orderButton = m_orderPanel.transform.Find("Order").GetComponent<Button>();
            m_orderButton.onClick.AddListener(Handle_Order);
            m_steel = m_orderPanel.transform.Find("WorkResourceSlot_Steel").GetComponent<WorkResourceSlot>();
            m_flower = m_orderPanel.transform.Find("WorkResourceSlot_Flower").GetComponent<WorkResourceSlot>();
            m_food = m_orderPanel.transform.Find("WorkResourceSlot_Food").GetComponent<WorkResourceSlot>();
            m_leather = m_orderPanel.transform.Find("WorkResourceSlot_Leather").GetComponent<WorkResourceSlot>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            SetResource();
            
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

        public void Initialize(DB.User.UserDataBase_Produce userDataBase_Produce, OrderListener order, CompleteListener complete)
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

        public DB.User.UserDataBase_Produce GetAppliedProduceData
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
            m_order(m_userDataBase_Produce, m_steel.Value, m_flower.Value, m_food.Value, m_leather.Value, out result);

            if (result)
            {
                ChangeState(E_State.Working);
            }
        }

        private void SetResource()
        {
            var gameManager = GameObject.Find("GameManager").GetComponent<Common.ResourceManager>();
            
            m_steel.SetImage(gameManager.GetSpriteController().GetWorkResource("Steel"));
            m_flower.SetImage(gameManager.GetSpriteController().GetWorkResource("Flower"));
            m_food.SetImage(gameManager.GetSpriteController().GetWorkResource("Food"));
            m_leather.SetImage(gameManager.GetSpriteController().GetWorkResource("Leather"));
        }
    }
}


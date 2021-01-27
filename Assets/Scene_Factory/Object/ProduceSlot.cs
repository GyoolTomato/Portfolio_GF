using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Object
{
    public class ProduceSlot : MonoBehaviour
    {
        public delegate bool CompleteListener();
        public delegate bool OrderListener(int manPower, int bullet, int food, int militarySupplies);

        private OrderListener m_order;
        private CompleteListener m_complete;

        private GameObject m_orderState;
        private Button m_completeButton;
        private GameObject m_orderPanel;
        private Button m_orderButton;
        private WorkResourceSlot m_manPower;
        private WorkResourceSlot m_bullet;
        private WorkResourceSlot m_food;
        private WorkResourceSlot m_militarySupplies;        

        // Start is called before the first frame update
        private void Start()
        {
            m_orderState = this.transform.Find("OrderState").gameObject;
            m_completeButton = m_orderState.transform.Find("Complete").GetComponent<Button>();
            m_completeButton.onClick.AddListener(Handle_Complete);
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

        }

        private void Handle_Complete()
        {
            if (m_complete())
            {
                m_orderState.SetActive(false);
                m_orderPanel.SetActive(true);
            }
        }

        private void Handle_Order()
        {
            if (m_order(m_manPower.Value, m_bullet.Value, m_food.Value, m_militarySupplies.Value))
            {
                m_orderState.SetActive(true);
                m_orderPanel.SetActive(false);
            }
        }

        public void SetOrder(OrderListener order, CompleteListener complete)
        {
            m_order = order;
            m_complete = complete;
        }
    }
}


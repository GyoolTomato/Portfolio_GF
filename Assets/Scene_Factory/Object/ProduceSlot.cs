using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Object
{
    public class ProduceSlot : MonoBehaviour
    {
        public delegate void OrderListener(int manPower, int bullet, int food, int militarySupplies);

        private OrderListener m_order;

        private Button m_orderButton;
        private WorkResourceSlot m_manPower;
        private WorkResourceSlot m_bullet;
        private WorkResourceSlot m_food;
        private WorkResourceSlot m_militarySupplies;        

        // Start is called before the first frame update
        private void Start()
        {
            var manufacturingCompany = this.transform.Find("ManufacturingCompany");
            m_orderButton = manufacturingCompany.Find("Order").GetComponent<Button>();
            m_orderButton.onClick.AddListener(Handle_Order);
            m_manPower = manufacturingCompany.Find("WorkResourceSlot_ManPower").GetComponent<WorkResourceSlot>();
            m_bullet = manufacturingCompany.Find("WorkResourceSlot_Bullet").GetComponent<WorkResourceSlot>();
            m_food = manufacturingCompany.Find("WorkResourceSlot_Food").GetComponent<WorkResourceSlot>();
            m_militarySupplies = manufacturingCompany.Find("WorkResourceSlot_MilitarySupplies").GetComponent<WorkResourceSlot>();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void Handle_Order()
        {
            m_order(m_manPower.Value, m_bullet.Value, m_food.Value, m_militarySupplies.Value);
        }

        public void SetOrder(OrderListener order)
        {
            m_order = order;
        }
    }
}
    

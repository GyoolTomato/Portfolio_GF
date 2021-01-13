using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Object
{
    public class ProduceSlot : MonoBehaviour
    {
        private FactoryManager m_factoryManager;

        private Button m_order;
        private WorkResourceSlot m_manPower;
        private WorkResourceSlot m_bullet;
        private WorkResourceSlot m_food;
        private WorkResourceSlot m_militarySupplies;        

        // Start is called before the first frame update
        private void Start()
        {
            m_factoryManager = GameObject.Find("Manager").GetComponent<FactoryManager>();

            var manufacturingCompany = this.transform.Find("ManufacturingCompany");
            m_order = manufacturingCompany.transform.Find("Order").GetComponent<Button>();
            m_order.onClick.AddListener(Order);
            m_manPower = manufacturingCompany.transform.Find("WorkResourceSlot_ManPower").GetComponent<WorkResourceSlot>();
            m_bullet = manufacturingCompany.transform.Find("WorkResourceSlot_Bullet").GetComponent<WorkResourceSlot>();
            m_food = manufacturingCompany.transform.Find("WorkResourceSlot_Food").GetComponent<WorkResourceSlot>();
            m_militarySupplies = manufacturingCompany.transform.Find("WorkResourceSlot_MilitarySupplies").GetComponent<WorkResourceSlot>();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void Order()
        {
            if (transform.tag.Equals("TDoll"))
            {
                m_factoryManager.ProduceTDollController.OrderReceive(m_manPower.Value, m_bullet.Value, m_food.Value, m_militarySupplies.Value);
            }
            else if (transform.tag.Equals("Equipment"))
            {
                m_factoryManager.ProduceEquipmentController.OrderReceive(m_manPower.Value, m_bullet.Value, m_food.Value, m_militarySupplies.Value);
            }
        }
    }
}
    

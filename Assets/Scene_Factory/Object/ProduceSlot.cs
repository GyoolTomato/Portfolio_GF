using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProduceSlot : MonoBehaviour
{
    private Button m_order;
    public WorkResourceSlot m_manPower;
    public WorkResourceSlot m_bullet;
    public WorkResourceSlot m_food;
    public WorkResourceSlot m_militarySupplies;

    // Start is called before the first frame update
    private void Start()
    {
        m_order = GameObject.Find("Order").GetComponent<Button>();
        m_order.onClick.AddListener(Order);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Order()
    {
        if (m_manPower.Value >= 400 &&
            m_bullet.Value >= 400 &&
            m_food.Value >= 400 &&
            m_militarySupplies.Value >= 200)
        {

        }
        else if (m_manPower.Value >= 100 &&
            m_bullet.Value >= 400 &&
            m_food.Value >= 400 &&
            m_militarySupplies.Value >= 200)
        {

        }
        else if (m_manPower.Value >= 400 &&
            m_bullet.Value >= 100 &&
            m_food.Value >= 400 &&
            m_militarySupplies.Value >= 200)
        {

        }
        else if (m_manPower.Value >= 400 &&
            m_bullet.Value >= 400 &&
            m_food.Value >= 100 &&
            m_militarySupplies.Value >= 200)
        {

        }        
        else
        {

        }
    }    
}

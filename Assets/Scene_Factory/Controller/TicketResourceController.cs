using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common;

public class TicketResourceController
{
    GameManager m_gameManager;
    FactoryResourceMonitor m_passTicket;
    FactoryResourceMonitor m_tDollTicket;
    FactoryResourceMonitor m_equipmentTicket;

    public TicketResourceController()
    {
    }

    public void Initialize(GameManager gameManager, GameObject canvas)
    {
        m_gameManager = gameManager;
        var factoryResourceInformation = canvas.transform.Find("FactoryResourceInformation");
        m_passTicket = factoryResourceInformation.Find("PassTicket").GetComponent<FactoryResourceMonitor>();
        m_tDollTicket = factoryResourceInformation.Find("TDollTicket").GetComponent<FactoryResourceMonitor>();
        m_equipmentTicket = factoryResourceInformation.Find("EquipmentTicket").GetComponent<FactoryResourceMonitor>();

        Debug.Log("gm : " + m_gameManager);
        UpdateValue();
    }

    public void UpdateValue()
    {
        m_gameManager.ResourceContorller().ReadOthersResource();
        m_passTicket.ApplyData(m_gameManager.ResourceContorller().PassTicket());
        m_tDollTicket.ApplyData(m_gameManager.ResourceContorller().TDollTicket());
        m_equipmentTicket.ApplyData(m_gameManager.ResourceContorller().EquipmentTicket());
    }
}

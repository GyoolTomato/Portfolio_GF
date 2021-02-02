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

        InitValue();
        RefreshAmount();
    }

    private void InitValue()
    {
        m_passTicket.InitValue(null, "쾌속 제조권");
        m_tDollTicket.InitValue(null, "인형 제조권");
        m_equipmentTicket.InitValue(null, "장비 제조권");
    }

    public void RefreshAmount()
    {
        m_passTicket.RefreshAmount(m_gameManager.ResourceContorller.PassTicketAmount());
        m_tDollTicket.RefreshAmount(m_gameManager.ResourceContorller.TDollTicketAmount());
        m_equipmentTicket.RefreshAmount(m_gameManager.ResourceContorller.EquipmentTicketAmount());
    }
}

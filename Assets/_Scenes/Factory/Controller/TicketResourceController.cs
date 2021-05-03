using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common;
using Assets.Scenes.Factory.Object;
namespace Assets.Scenes.Factory.Controller
{
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
            m_gameManager.GetResourceContorller().ReadOthersResource();
            m_passTicket.ApplyData(m_gameManager.GetResourceContorller().PassTicket());
            m_tDollTicket.ApplyData(m_gameManager.GetResourceContorller().TDollTicket());
            m_equipmentTicket.ApplyData(m_gameManager.GetResourceContorller().EquipmentTicket());
        }
    }
}
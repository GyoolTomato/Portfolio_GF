using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Common;
using Assets.Scenes.Factory.Object;
namespace Assets.Scenes.Factory.Controller
{
    public class TicketResourceController
    {
        ResourceManager m_resourceManager;
        FactoryResourceMonitor m_passTicket;
        FactoryResourceMonitor m_tDollTicket;
        FactoryResourceMonitor m_equipmentTicket;

        public TicketResourceController()
        {
        }

        public void Initialize(ResourceManager resourceManager, GameObject canvas)
        {
            m_resourceManager = resourceManager;
            var factoryResourceInformation = canvas.transform.Find("FactoryResourceInformation");
            m_passTicket = factoryResourceInformation.Find("PassTicket").GetComponent<FactoryResourceMonitor>();
            m_tDollTicket = factoryResourceInformation.Find("TDollTicket").GetComponent<FactoryResourceMonitor>();
            m_equipmentTicket = factoryResourceInformation.Find("EquipmentTicket").GetComponent<FactoryResourceMonitor>();

            Debug.Log("gm : " + m_resourceManager);
            UpdateValue();
        }

        public void UpdateValue()
        {
            m_resourceManager.GetResourceContorller().ReadOthersResource();
            m_passTicket.ApplyData(m_resourceManager.GetResourceContorller().PassTicket());
            m_tDollTicket.ApplyData(m_resourceManager.GetResourceContorller().TDollTicket());
            m_equipmentTicket.ApplyData(m_resourceManager.GetResourceContorller().EquipmentTicket());
        }
    }
}
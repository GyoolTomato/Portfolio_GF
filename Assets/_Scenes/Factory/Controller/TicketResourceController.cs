using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Graphic;
using Assets.Scenes.Factory.Object;
namespace Assets.Scenes.Factory.Controller
{
    public class TicketResourceController
    {
        GraphicManager m_graphicManager;
        FactoryResourceMonitor m_passTicket;
        FactoryResourceMonitor m_tDollTicket;
        FactoryResourceMonitor m_equipmentTicket;

        public TicketResourceController()
        {
        }

        public void Initialize(GraphicManager graphicManager, GameObject canvas)
        {
            m_graphicManager = graphicManager;
            var factoryResourceInformation = canvas.transform.Find("FactoryResourceInformation");
            m_passTicket = factoryResourceInformation.Find("PassTicket").GetComponent<FactoryResourceMonitor>();
            m_tDollTicket = factoryResourceInformation.Find("TDollTicket").GetComponent<FactoryResourceMonitor>();
            m_equipmentTicket = factoryResourceInformation.Find("EquipmentTicket").GetComponent<FactoryResourceMonitor>();

            Debug.Log("gm : " + m_graphicManager);
            UpdateValue();
        }

        public void UpdateValue()
        {
            m_graphicManager.GetResourceContorller().ReadOthersResource();
            m_passTicket.ApplyData(m_graphicManager.GetResourceContorller().PassTicket());
            m_tDollTicket.ApplyData(m_graphicManager.GetResourceContorller().TDollTicket());
            m_equipmentTicket.ApplyData(m_graphicManager.GetResourceContorller().EquipmentTicket());
        }
    }
}
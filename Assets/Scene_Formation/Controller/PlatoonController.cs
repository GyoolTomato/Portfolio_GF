using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Object;

namespace Assets.Scene_Formation.Controller
{
    public class PlatoonController
    {
        private Assets.Common.GameManager m_gameManager;
        private ViewPort_TDollController m_viewPort_TDollController;
        private ViewPort_EquipmentsController m_viewPort_EquipmentsController;

        private GameObject m_selectPlatoon;
        private GameObject m_menuView;
        private PlatoonWindow[] m_list_PlatoonWindow;


        public PlatoonController()
        {
        }

        public void Initailize(GameObject canvas)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_viewPort_TDollController = new ViewPort_TDollController();
            m_viewPort_TDollController.Initialize(this, "TDoll", "Album_TDoll");
            m_viewPort_EquipmentsController = new ViewPort_EquipmentsController();
            m_viewPort_EquipmentsController.Initialize(this, "Equipment", "Album_Equipment");

            m_selectPlatoon = canvas.transform.Find("SelectPlatoon").gameObject;
            m_menuView = canvas.transform.Find("MenuView").gameObject;
            m_list_PlatoonWindow = new PlatoonWindow[5];
            m_list_PlatoonWindow[0] = m_menuView.transform.Find("PlatoonWindow1").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[1] = m_menuView.transform.Find("PlatoonWindow2").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[2] = m_menuView.transform.Find("PlatoonWindow3").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[3] = m_menuView.transform.Find("PlatoonWindow4").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[4] = m_menuView.transform.Find("PlatoonWindow5").GetComponent<PlatoonWindow>();

            for (int i = 0; i < m_list_PlatoonWindow.Length; i++)
            {
                m_list_PlatoonWindow[i].BigAlbum_TDoll1().Initialize(i+1, 1, OpenTDollList, OpenEquipmentList);
                m_list_PlatoonWindow[i].BigAlbum_TDoll2().Initialize(i+1, 2, OpenTDollList, OpenEquipmentList);
                m_list_PlatoonWindow[i].BigAlbum_TDoll3().Initialize(i+1, 3, OpenTDollList, OpenEquipmentList);
                m_list_PlatoonWindow[i].BigAlbum_TDoll4().Initialize(i+1, 4, OpenTDollList, OpenEquipmentList);            
            }

            CloseDormitory();
        }

        private void Load()
        {
            var data = m_gameManager.UserDBController().UserFormation();

            for (int i = 0; i < m_list_PlatoonWindow.Length; i++)
            {
                foreach (var item in data)
                {
                    if (item.Number == i+1)
                    {
                        m_list_PlatoonWindow[i].BigAlbum_TDoll1().ApplyData(item.Member1);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll2().ApplyData(item.Member2);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll3().ApplyData(item.Member3);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll4().ApplyData(item.Member4);
                    }
                }                
            }
        }

        private void OpenTDollList(int platoonNumber, int sequence)
        { 
            OpenDormitory();
            m_viewPort_TDollController.OpenValue(platoonNumber, sequence);
            m_viewPort_TDollController.View().SetActive(true);
            m_viewPort_EquipmentsController.View().SetActive(false);
            
        }

        private void OpenEquipmentList(int tDollOwnershipCode, int sequence)
        {
            OpenDormitory();
            m_viewPort_EquipmentsController.OpenValue(tDollOwnershipCode, sequence);
            m_viewPort_TDollController.View().SetActive(false);
            m_viewPort_EquipmentsController.View().SetActive(true);            
        }

        private void OpenDormitory()
        {
            m_viewPort_TDollController.Load();
            m_viewPort_EquipmentsController.Load();
            m_selectPlatoon.SetActive(true);
            m_menuView.SetActive(false);
        }

        public void CloseDormitory()
        {
            Load();
            m_selectPlatoon.SetActive(false);
            m_menuView.SetActive(true);
        }
    }
}
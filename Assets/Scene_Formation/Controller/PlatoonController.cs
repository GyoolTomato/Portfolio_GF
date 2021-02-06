using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common.Object;

namespace Assets.Scene_Formation.Controller
{
    public class PlatoonController
    {
        private Assets.Common.GameManager m_gameManager;

        private PlatoonWindow[] m_list_PlatoonWindow;

        public PlatoonController()
        {
        }

        public void Initailize(GameObject canvas)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_list_PlatoonWindow = new PlatoonWindow[5];
            m_list_PlatoonWindow[0] = canvas.transform.Find("MenuView").Find("PlatoonWindow1").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[1] = canvas.transform.Find("MenuView").Find("PlatoonWindow2").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[2] = canvas.transform.Find("MenuView").Find("PlatoonWindow3").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[3] = canvas.transform.Find("MenuView").Find("PlatoonWindow4").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[4] = canvas.transform.Find("MenuView").Find("PlatoonWindow5").GetComponent<PlatoonWindow>();

            Load();
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
                        m_list_PlatoonWindow[i].BigAlbum_TDoll1().ApplyData(item.Platoon1);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll2().ApplyData(item.Platoon2);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll3().ApplyData(item.Platoon3);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll4().ApplyData(item.Platoon4);
                    }
                }                
            }
        }
    }
}
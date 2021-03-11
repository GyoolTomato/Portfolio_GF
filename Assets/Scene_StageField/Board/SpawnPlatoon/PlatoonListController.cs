using System;
using UnityEngine;
using Assets.Resources.Object;

namespace Assets.Scene_StageField.Board.SpawnPlatoon
{
    public class PlatoonListController
    {
        private Assets.Common.GameManager m_gameManager;

        private GameObject m_selectPlatoon;
        private GameObject m_menuView;
        private PlatoonWindow[] m_list_PlatoonWindow;


        public PlatoonListController()
        {
        }

        public void Initialize(GameObject spawnPlatoon)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();

            m_menuView = spawnPlatoon.transform.Find("MenuView").gameObject;
            m_list_PlatoonWindow = new PlatoonWindow[5];
            m_list_PlatoonWindow[0] = m_menuView.transform.Find("PlatoonWindow1").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[1] = m_menuView.transform.Find("PlatoonWindow2").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[2] = m_menuView.transform.Find("PlatoonWindow3").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[3] = m_menuView.transform.Find("PlatoonWindow4").GetComponent<PlatoonWindow>();
            m_list_PlatoonWindow[4] = m_menuView.transform.Find("PlatoonWindow5").GetComponent<PlatoonWindow>();

            for (int i = 0; i < m_list_PlatoonWindow.Length; i++)
            {
                m_list_PlatoonWindow[i].BigAlbum_TDoll1().Initialize(i + 1, 1, null, null);
                m_list_PlatoonWindow[i].BigAlbum_TDoll2().Initialize(i + 1, 2, null, null);
                m_list_PlatoonWindow[i].BigAlbum_TDoll3().Initialize(i + 1, 3, null, null);
                m_list_PlatoonWindow[i].BigAlbum_TDoll4().Initialize(i + 1, 4, null, null);
            }

            Load();
        }

        private void Load()
        {
            var data = m_gameManager.UserDBController().UserFormation();

            for (int i = 0; i < m_list_PlatoonWindow.Length; i++)
            {
                foreach (var item in data)
                {
                    if (item.Number == i + 1)
                    {
                        m_list_PlatoonWindow[i].BigAlbum_TDoll1().ApplyData(item.Member1);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll2().ApplyData(item.Member2);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll3().ApplyData(item.Member3);
                        m_list_PlatoonWindow[i].BigAlbum_TDoll4().ApplyData(item.Member4);
                    }
                }
            }
        }
    }
}
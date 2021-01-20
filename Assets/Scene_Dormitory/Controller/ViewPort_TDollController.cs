using System;
using UnityEngine;
using UnityEditor;
using Assets.Project;

namespace Assets.Scene_Dormitory.Controller
{
    public class ViewPort_TDollController
    {        
        GameObject m_viewPortContent;
        GameObject m_album;

        GameManager m_gameManager;

        public ViewPort_TDollController()
        {
        }

        public void Initialize(GameManager gameManager)
        {
            m_gameManager = gameManager;
            var canvas = GameObject.Find("Canvas");
            var menuView = canvas.transform.Find("MenuView");
            var tDoll = menuView.Find("TDoll");
            var scrollView = tDoll.Find("ScrollView");
            var viewPort = scrollView.Find("Viewport");
            m_viewPortContent = viewPort.Find("Content").gameObject;
            m_album = Resources.Load<GameObject>("Object/Album_TDoll");                
        }

        public void Load()
        {
            foreach (var item in m_gameManager.DBControllerUser.UserTDoll)
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;

                var albumScript = result.GetComponent<Album_TDoll>();
                albumScript.SetValue(m_gameManager.DBControllerIndex.TDoll(item.DataCode), item.Level, item.DummyLink, item.Platoon);
            }
        }
    }
}

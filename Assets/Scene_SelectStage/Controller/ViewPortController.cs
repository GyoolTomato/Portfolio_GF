using System;
using UnityEngine;
using UnityEditor;
using Assets.Resources.Object;
using Assets.Common;

namespace Assets.Scene_SelectStage.Controller
{
    public class ViewPortController
    {
        protected GameObject m_viewPortContent;
        protected GameObject m_album;

        protected GameManager m_gameManager;

        public ViewPortController()
        {
        }

        public void Initialize()
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            var canvas = GameObject.Find("Canvas");
            var stageList = canvas.transform.Find("StageList");
            var scrollView = stageList.Find("ScrollView");
            var viewPort = scrollView.Find("Viewport");
            m_viewPortContent = viewPort.Find("Content").gameObject;
            m_album = UnityEngine.Resources.Load<GameObject>("Object/Stage");
        }

        public void Load()
        {
            foreach (var item in m_gameManager.UserDBController().Stage())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;

                var script = result.GetComponent<Stage>();
                script.ApplyValue(item);
            }
        }
    }
}

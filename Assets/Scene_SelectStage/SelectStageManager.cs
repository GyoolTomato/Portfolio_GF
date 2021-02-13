using System;
using UnityEngine;

namespace Assets.Scene_SelectStage
{
    public class SelectStageManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private GameObject m_canvas;

        private Assets.Resources.Object.Title m_title;
        private Controller.ViewPortController m_viewPortController;

        public SelectStageManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_gameManager, "스테이지 선택");

            m_viewPortController = new Controller.ViewPortController();
            m_viewPortController.Initialize();
            m_viewPortController.Load();
        }

        private void Update()
        {

        }
    }
}
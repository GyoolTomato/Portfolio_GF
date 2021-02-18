using System;
using UnityEngine;
using Assets.Scene_StageField.Controller;

namespace Assets.Scene_StageField
{
    public class StageFieldManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private TouchController m_touchController;

        private GameObject m_canvas;
        private Assets.Resources.Object.Title m_title;

        public StageFieldManager()
        {

        }

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_touchController = new TouchController();
            m_touchController.Initialize();

            m_canvas = GameObject.Find("Canvas");
            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_gameManager, "스테이지");

            
        }

        private void Start()
        {
        }

        private void Update()
        {
            m_touchController.UpdateIsClick();
        }

        public TouchController GetTouchController()
        {
            return m_touchController;
        }
    }
}
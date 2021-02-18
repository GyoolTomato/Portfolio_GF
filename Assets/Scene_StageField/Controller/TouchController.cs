using System;
using UnityEngine;

namespace Assets.Scene_StageField.Controller
{
    public class TouchController
    {
        private bool m_isClick;

        private GameObject m_clickObject;
        private Camera m_mainCamera;
        private Vector2 m_mouseTouchPos;

        public TouchController()
        {
        }

        public void Initialize()
        {
            m_mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        public void UpdateIsClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_isClick = true;                
                SetClickObject();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_isClick = false;
            }
        }

        private void SetClickObject()
        {
            m_mouseTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var hit = Physics2D.RaycastAll(m_mouseTouchPos, Vector2.zero, 0.0f);

            m_clickObject = hit[hit.Length - 1].collider.gameObject;
        }

        public bool IsClick()
        {
            return m_isClick;
        }

        public GameObject GetClickObject()
        {
            return m_clickObject;
        }

        public Vector2 MouseTouchPos()
        {
            return m_mouseTouchPos;
        }
    }
}
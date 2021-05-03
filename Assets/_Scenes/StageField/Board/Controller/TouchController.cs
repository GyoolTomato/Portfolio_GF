using System;
using UnityEngine;

namespace Assets.Scenes.StageField.Board.Controller
{
    public class TouchController
    {
        private BoardManager m_boardManager;
        private bool m_isClick;

        private GameObject m_clickObject;
        private Vector2 m_mouseTouchPos;

        public TouchController()
        {
        }

        public void Initialize(BoardManager boardManager)
        {
            m_boardManager = boardManager;
        }

        public void UpdateIsClick()
        {
            if (!m_boardManager.GetSpawnPlatoonActive())
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
        }

        private void SetClickObject()
        {
            m_mouseTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var hit = Physics2D.Raycast(m_mouseTouchPos, Vector2.zero, 0.0f);

            m_clickObject = hit.collider.gameObject;
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
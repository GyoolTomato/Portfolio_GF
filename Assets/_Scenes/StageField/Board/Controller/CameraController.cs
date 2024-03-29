﻿using System;
using UnityEngine;

namespace Assets.Scenes.StageField.Board.Controller
{
    public class CameraController
    {
        private BoardManager m_boardManager;
        private TouchController m_touchController;

        private GameObject m_board;
        private GameObject m_field;
        private Vector2 m_beforeMousePosition;

        public CameraController()
        {
        }

        public void Initialize(BoardManager boardManager)
        {
            m_boardManager = boardManager;
            m_touchController = m_boardManager.GetTouchController();

            m_board = GameObject.Find("Board");
            m_field = m_board.transform.Find("Field").gameObject;
        }

        public void Update()
        {
            Debug.Log("isClick : " + m_touchController.IsClick());
            Debug.Log(m_touchController.GetClickObject() == m_field);

            if (m_touchController.IsClick() && m_touchController.GetClickObject() == m_field)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var move = mousePos - m_beforeMousePosition;
                var temp = new Vector3(move.x, move.y, 0);

                if (m_beforeMousePosition != Vector2.zero)
                {
                    Move(temp);
                }

                m_beforeMousePosition = mousePos;
            }
            else
            {
                m_beforeMousePosition = Vector2.zero;
            }
        }

        private void Move(Vector3 move)
        {
            var speed = 2.0f;

            var result = new Vector3();
            var cameraHeight = Camera.main.orthographicSize * 2;
            var cameraWidth = (Screen.width * cameraHeight) / Screen.height;
            var mapPosition = m_board.transform.position;
            var fieldSize = m_field.transform.localScale;

            result.x = mapPosition.x + move.x * speed;
            result.y = mapPosition.y + move.y * speed;
            result.z = move.z;

            if (fieldSize.x/2 - cameraWidth/2 <= result.x)
            {
                result.x = fieldSize.x/2 - cameraWidth/2;
            }
            else if (-(fieldSize.x/2) + cameraWidth/2 >= result.x)
            {
                result.x = -(fieldSize.x / 2) + cameraWidth / 2;
            }

            if (fieldSize.y/2 - cameraHeight/2 <= result.y)
            {
                result.y = fieldSize.y/2 - cameraHeight/2;
            }
            else if (-(fieldSize.y/2) + cameraHeight/2 >= result.y)
            {
                result.y = -(fieldSize.y/2) + cameraHeight/2;
            }

            m_board.transform.position = result;
        }
    }
}
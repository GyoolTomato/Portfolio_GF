using System;
using UnityEngine;

namespace Assets.Scene_StageField.Object
{
    public class Field : MonoBehaviour
    {
        private StageFieldManager m_stageFieldManager;
        private Controller.TouchController m_touchController;

        private GameObject m_map;
        private Vector2 m_beforeMousePosition;

        public Field()
        {
        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetTouchController();

            m_map = GameObject.Find("Map").gameObject;
        }

        private void FixedUpdate()
        {
            Debug.Log("ClickObject : " + m_touchController.GetClickObject());
            if (m_touchController.IsClick() && m_touchController.GetClickObject() == this.gameObject)
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

        private void OnMouseDown()
        {

        }

        private void Move(Vector3 move)
        {
            var speed = 2.0f;

            var result = new Vector3();
            var cameraHeight = Camera.main.orthographicSize * 2;
            var cameraWidth = (Screen.width * cameraHeight) / Screen.height;
            var mapPosition = m_map.transform.position;
            var fieldSize = this.transform.localScale;

            result.x = mapPosition.x + move.x * speed;
            result.y = mapPosition.y + move.y * speed;
            result.z = move.z;

            if (fieldSize.x/2 - cameraWidth/2 <= result.x)
            {
                result.x = fieldSize.x/2 - cameraWidth/2;
            }
            else if (-(fieldSize.x/2) + cameraWidth/2 >= result.x)
            {
                result.x = -(fieldSize.x/2) + cameraWidth/2;
            }

            if (fieldSize.y/2 - cameraHeight/2 <= result.y)
            {
                result.y = fieldSize.y/2 - cameraHeight/2;
            }
            else if (-(fieldSize.y/2) + cameraHeight/2 >= result.y)
            {
                result.y = -(fieldSize.y/2) + cameraHeight/2;
            }

            m_map.transform.position = result;
        }
    }
}
using UnityEngine;
using System.Collections;
using Assets.Common.DB.User;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Controller;

namespace Assets.Resources.StageField
{
    public class Player : MonoBehaviour
    {
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private CharacterController m_characterController;
        private int m_platoonNumber;
        private bool m_isMoving;
        private float m_moveDistance;
        private Vector3 m_moveDirection;

        // Use this for initialization
        void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetTouchController();
            m_characterController = m_stageFieldManager.GetCharacterController();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_touchController.IsClick() && m_touchController.GetClickObject() == gameObject)
            {
                m_characterController.SelectedPlayerPlatoon = this;
            }     
        }

        public void SetValue(int platoonNumber)
        {
            m_platoonNumber = platoonNumber;
        }

        public GameObject Object()
        {
            return gameObject;
        }

        public int PlatoonNumber()
        {
            return m_platoonNumber;
        }
        

        public bool IsMoving()
        {
            return m_isMoving;
        }

        //private void MovePoint()
        //{           
        //    gameObject.transform.Translate(m_moveDirection * Time.deltaTime);

        //    if (m_moveDistance <= 0)
        //    {
        //        gameObject.transform.position = m_stayPoint.transform.position;
        //        m_isMoving = false;
        //    }

        //}
    }
}
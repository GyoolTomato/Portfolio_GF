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
        private UserDataBase_Platoon m_platoonData;
        private OccupationPoint m_stayPoint;

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
            if (m_touchController.GetClickObject() == gameObject)
            {
                m_characterController.SetSelectedPlayerPlatoon(this);
            }

            if (m_isMoving)
            {
                MovePoint();
            }            
        }

        public void SetValue(UserDataBase_Platoon data, OccupationPoint createPoint)
        {
            m_platoonData = data;
            m_stayPoint = createPoint;
        }

        public GameObject Object()
        {
            return gameObject;
        }

        public UserDataBase_Platoon PlatoonData()
        {
            return m_platoonData;
        }
        
        public OccupationPoint GetStayPoint()
        {
            return m_stayPoint;                      
        }

        public bool IsMoving()
        {
            return m_isMoving;
        }

        public void SetStayPoint(OccupationPoint newPoint)
        {
            m_moveDirection = newPoint.gameObject.transform.position - m_stayPoint.gameObject.transform.position;
            m_moveDirection.Normalize();
            m_moveDistance = Vector3.Distance(newPoint.gameObject.transform.position, m_stayPoint.gameObject.transform.position);

            m_stayPoint = newPoint;
            m_isMoving = true;
        }

        private void MovePoint()
        {           
            gameObject.transform.Translate(m_moveDirection * Time.deltaTime);

            if (m_moveDistance <= 0)
            {
                gameObject.transform.position = m_stayPoint.transform.position;
                m_isMoving = false;
            }

        }
    }
}
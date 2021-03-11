using UnityEngine;
using System.Collections;
using Assets.Common.DB.User;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Board.Controller;

namespace Assets.Resources.StageField
{
    public class Player : MonoBehaviour
    {
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PlayerPlatoonController m_playerPlatoonController;
        private int m_platoonNumber;
        private bool m_isMoving;
        private float m_moveDistance;
        private Vector3 m_moveDirection;
        private OccupationPoint m_stayPoint;

        // Use this for initialization
        void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetBoardManager().GetTouchController();
            m_playerPlatoonController = m_stageFieldManager.GetBoardManager().GetPlayerPlatoonController();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_touchController.IsClick() && m_touchController.GetClickObject() == gameObject)
            {
                m_playerPlatoonController.SelectedPlayerPlatoon = this;
            }

            if (m_isMoving)
            {
                Move();
            }
        }

        public void Initialize(int platoonNumber, OccupationPoint spawnPoint)
        {
            m_platoonNumber = platoonNumber;
            m_stayPoint = spawnPoint;
        }

        public int GetPlatoonNumber()
        {
            return m_platoonNumber;
        }

        public OccupationPoint GetStayPoint()
        {
            return m_stayPoint;
        }

        public bool IsMoving()
        {
            return m_isMoving;
        }

        public void MovePoint(OccupationPoint point)
        {
            if (!m_isMoving)
            {
                m_stayPoint = point;
                m_moveDirection = m_stayPoint.transform.localPosition;
                m_isMoving = true;
            }            
        }

        private void Move()
        {
            var direction = m_moveDirection - transform.localPosition;
            direction.Normalize();
            transform.Translate(direction * Time.deltaTime * 2);

            var distance = Vector3.Distance(m_moveDirection, transform.localPosition);
            if (distance <= 0.05)
            {
                transform.localPosition = m_moveDirection;
                m_isMoving = false;
            }
        }
    }
}
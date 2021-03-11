using UnityEngine;
using System.Collections;
using Assets.Common.DB.User;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Board.Controller;
using Assets.Scene_StageField.Controller.EnemyData.Base;

namespace Assets.Resources.StageField
{
    public class Enemy : MonoBehaviour
    {
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PlayerPlatoonController m_playerPlatoonController;
        private EnemyParty m_enemyParty;
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
            if (m_isMoving)
            {
                Move();
            }
        }

        public void Initialize(EnemyParty enemyParty)
        {
            m_enemyParty = enemyParty;
            m_stayPoint = enemyParty.StartPoint;
            transform.localPosition = m_stayPoint.transform.localPosition;
        }

        public EnemyParty GetEnemyParty()
        {
            return m_enemyParty;
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
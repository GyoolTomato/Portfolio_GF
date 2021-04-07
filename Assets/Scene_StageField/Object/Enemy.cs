using UnityEngine;
using Assets.Scene_StageField.Board.Controller;
using Assets.Scene_StageField.Controller.EnemyData.Base;
using Assets.Character.Board;

namespace Assets.Scene_StageField.Object
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
        private CharacterBase m_characterBase;

        private void Awake()
        {
            var collider = transform.GetComponent<CapsuleCollider2D>();
            collider.enabled = false;
        }

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
            if (enemyParty != null)
            {
                m_enemyParty = enemyParty;
                m_stayPoint = enemyParty.StartPoint;
                transform.localPosition = m_stayPoint.transform.localPosition;
                transform.tag = "Enemy";
                var tempScale = transform.localScale;
                tempScale.x = tempScale.x * -1;
                transform.localScale = tempScale;
                m_characterBase = gameObject.AddComponent<CharacterBase>();
            }
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
                m_characterBase.SetAnim(CharacterBase.E_State.Run);
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
                m_characterBase.SetAnim(CharacterBase.E_State.Idle);
                m_isMoving = false;
            }
        }        
    }
}
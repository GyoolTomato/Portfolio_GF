 using UnityEngine;
using System.Collections;
using Assets.DB.User;
using Assets.Scenes.StageField.Board.Controller;
using Assets.Character.Board;

namespace Assets.Scenes.StageField.Object
{
    public class Player : MonoBehaviour
    {
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PlayerPlatoonController m_playerPlatoonController;
        private bool m_isMoving;
        private float m_moveDistance;
        private Vector3 m_moveDirection;
        private OccupationPoint m_stayPoint;
        private UserDataBase_Platoon m_platoonData;
        private CharacterBase m_characterBase;

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

        public void Initialize(UserDataBase_Platoon platoon, OccupationPoint spawnPoint)
        {
            m_platoonData = platoon;
            m_stayPoint = spawnPoint;
            transform.tag = "Player";
            m_characterBase = gameObject.AddComponent<CharacterBase>();
        }

        public OccupationPoint GetStayPoint()
        {
            return m_stayPoint;
        }

        public UserDataBase_Platoon GetPlatoonData()
        {
            return m_platoonData;
        }

        public bool IsMoving()
        {
            return m_isMoving;
        }

        public void MovePoint(OccupationPoint point)
        {
            var boardManager = m_stageFieldManager.GetBoardManager();
            var numberOfMovementAvailableValue = boardManager.GetNumberOfMovementAvailableValue();

            if (!m_isMoving && numberOfMovementAvailableValue > 0)
            {
                m_stayPoint = point;
                m_moveDirection = m_stayPoint.transform.localPosition;
                m_characterBase.SetAnim(CharacterBase.E_State.Run);
                m_isMoving = true;
                boardManager.SetNumberOfMovementAvailableValue(numberOfMovementAvailableValue - 1);
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
                m_stageFieldManager.GetBoardManager().GetBattleCheckController().CheckBattle();
            }
        }
    }
}
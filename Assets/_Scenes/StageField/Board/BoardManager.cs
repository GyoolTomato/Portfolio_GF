using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.StageField.Board.Controller;
using Assets.Scenes.StageField.Board.Turn;
using Assets.Scenes.StageField.Board.SpawnPlatoon;

namespace Assets.Scenes.StageField.Board
{
    public class BoardManager
    {
        public enum E_State
        {
            PlayerTurn,
            EnemyTurn,
            EnemyBattle,
            Occupation,
            End,
        }

        private GameObject m_board;
        private GameObject m_movePointMonitor;
        private GameObject m_turnButton;
        private GameObject m_spawnPlatoon;
        private GameObject m_turnStartBanner;
        private Button m_startButton;
        private Button m_endTurnButton;

        private Common.GameManager m_gameManager;
        private StageFieldManager m_stageFieldmanager;

        private TouchController m_touchController;
        private CameraController m_cameraController;
        private PlayerPlatoonController m_playerPlatoonController;
        private EnemyPlatoonController m_enemyPlatoonController;
        private PointController m_pointController;
        private SpawnPlatoonController m_spawnPlatoonController;
        private BattleCheckController m_battleCheckController;

        private PlayerTurn m_playerTurn;
        private EnemyTurn m_enemyTurn;
        private EnemyBattle m_enemyBattle;
        private Occupation m_occupation;

        private E_State m_state;       
        private int m_turnNumber;        

        public BoardManager()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_board = GameObject.Find("Board");
            var canvas = GameObject.Find("Canvas");
            var boardUI = canvas.transform.Find("BoardUI");
            m_movePointMonitor = boardUI.transform.Find("MovePointMonitor").gameObject;
            m_turnButton = boardUI.transform.Find("TurnButton").gameObject;
            m_spawnPlatoon = boardUI.transform.Find("SpawnPlatoon").gameObject;
            m_turnStartBanner = boardUI.Find("TurnStartBanner").gameObject;
            m_turnStartBanner.SetActive(false);
            var turnButton = boardUI.Find("TurnButton");
            m_startButton = turnButton.transform.Find("StartButton").GetComponent<Button>();
            m_startButton.onClick.AddListener(Handle_StartButton);
            m_startButton.gameObject.SetActive(true);
            m_endTurnButton = turnButton.transform.Find("EndTurnButton").GetComponent<Button>();
            m_endTurnButton.onClick.AddListener(Handle_EndTurnButton);
            m_endTurnButton.gameObject.SetActive(false);

            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_stageFieldmanager = manager;

            m_touchController = new TouchController();
            m_touchController.Initialize(this);
            m_cameraController = new CameraController();
            m_cameraController.Initialize(this);
            m_playerPlatoonController = new PlayerPlatoonController();
            m_playerPlatoonController.Initialize(this);
            m_enemyPlatoonController = new EnemyPlatoonController();
            m_enemyPlatoonController.Initialize(this);
            m_pointController = new PointController();
            m_pointController.Initialize(manager);
            m_spawnPlatoonController = new SpawnPlatoonController();
            m_battleCheckController = new BattleCheckController();
            m_battleCheckController.Initialize(manager);

            m_playerTurn = new PlayerTurn();
            m_playerTurn.Initialize(m_stageFieldmanager, m_turnStartBanner, m_movePointMonitor, m_endTurnButton.gameObject);
            m_enemyTurn = new EnemyTurn();
            m_enemyTurn.Initialize(m_stageFieldmanager, m_turnStartBanner, m_movePointMonitor, m_endTurnButton.gameObject);
            m_enemyBattle = new EnemyBattle();
            m_enemyBattle.Initialize(m_stageFieldmanager);
            m_occupation = new Occupation();
            m_occupation.Initialize(m_stageFieldmanager);

            m_state = E_State.End;
            m_turnNumber = 0;
        }

        public void Start()
        {
            SetSpawnPlatoonActive(false);
            m_spawnPlatoonController.Initialize(this);
        }

        public void Update()
        {
            if (!m_stageFieldmanager.GetPlayController().IsFinish())
            {
                m_touchController.UpdateIsClick();
                m_cameraController.Update();
                m_pointController.Update();
            }            
        }

        private void Handle_StartButton()
        {
            if (m_playerPlatoonController.GetPlayers().Count > 0)
            {
                m_stageFieldmanager.GetPlayController().StartPlay();
                m_startButton.gameObject.SetActive(false);
                m_endTurnButton.gameObject.SetActive(true);
                ChangeState(E_State.PlayerTurn);
            }
            else
            {
                Debug.Log("시작 실패");
            }
        }

        private void Handle_EndTurnButton()
        {
            if (m_playerPlatoonController.IsMoveFinish())
            {
                ChangeState(E_State.EnemyTurn);
            }            
        }

        public void ChangeState(E_State state)
        {
            m_state = state;

            switch (m_state)
            {
                case E_State.PlayerTurn:
                    m_turnNumber++;
                    m_playerTurn.StartTurn(m_turnNumber);
                    break;
                case E_State.EnemyTurn:
                    m_enemyTurn.StartTurn(m_turnNumber);
                    break;
                case E_State.EnemyBattle:
                    m_enemyBattle.StartTurn();
                    break;
                case E_State.Occupation:
                    m_occupation.StartTurn();
                    break;
                default:
                    break;
            }
        }

        public E_State GetNowState() => m_state;            
        public bool GetSpawnPlatoonActive() => m_spawnPlatoon.activeSelf;
        public void SetSpawnPlatoonActive(bool active)
        {
            if (active)
            {
                m_movePointMonitor.SetActive(false);
                m_turnButton.SetActive(false);
                m_spawnPlatoon.SetActive(true);
                m_board.SetActive(false);
            }
            else
            {
                m_movePointMonitor.SetActive(true);
                m_turnButton.SetActive(true);
                m_spawnPlatoon.SetActive(false);
                m_board.SetActive(true);
            }
        }

        public int GetNumberOfMovementAvailableValue()
        {
            var monitor = m_movePointMonitor.transform.Find("Number");
            var monitorText = monitor.GetComponent<Text>();

            return int.Parse(monitorText.text);
        }
        public void SetNumberOfMovementAvailableValue(int value)
        {
            var monitor = m_movePointMonitor.transform.Find("Number");
            var monitorText = monitor.GetComponent<Text>();
            monitorText.text = value.ToString();
        }
        public TouchController GetTouchController() => m_touchController;
        public PlayerPlatoonController GetPlayerPlatoonController() => m_playerPlatoonController;
        public EnemyPlatoonController GetEnemyPlatoonController() => m_enemyPlatoonController;
        public PointController GetPointController() => m_pointController;
        public BattleCheckController GetBattleCheckController() => m_battleCheckController;
        public StageFieldManager GetStageFieldManager() => m_stageFieldmanager;
    }
}
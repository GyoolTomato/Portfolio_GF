using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scene_StageField.Board.Controller;
using Assets.Scene_StageField.Board.Turn;
using Assets.Scene_StageField.Board.SpawnPlatoon;

namespace Assets.Scene_StageField.Board
{
    public class BoardManager
    {
        public enum E_State
        {
            PlayerTurn,
            EnemyTurn,
            Battle,
            Occupation,
            End,
        }

        private GameObject m_board;
        private GameObject m_turnMonitor;
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

        private PlayerTurn m_playerTurn;
        private EnemyTurn m_enemyTurn;
        private Battle m_battle;
        private Occupation m_occupation;

        private E_State m_state;
        private bool m_isStart;        
        private int m_turnNumber;        

        public BoardManager()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_board = GameObject.Find("Board");
            var canvas = GameObject.Find("Canvas");
            var boardUI = canvas.transform.Find("BoardUI");
            m_turnMonitor = boardUI.transform.Find("TurnMonitor").gameObject;
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
            m_pointController.Initialize(this);
            m_spawnPlatoonController = new SpawnPlatoonController();

            m_playerTurn = new PlayerTurn();
            m_playerTurn.Initialize(m_stageFieldmanager, m_turnStartBanner);
            m_enemyTurn = new EnemyTurn();
            m_enemyTurn.Initialize(m_stageFieldmanager, m_turnStartBanner);
            m_battle = new Battle();
            m_battle.Initialize(m_stageFieldmanager);
            m_occupation = new Occupation();
            m_occupation.Initialize(m_stageFieldmanager);

            m_state = E_State.End;
            m_isStart = false;
            m_turnNumber = 0;
        }

        public void Start()
        {
            SetSpawnPlatoonActive(false);
            m_spawnPlatoonController.Initialize(this);
        }

        public void Update()
        {
            m_touchController.UpdateIsClick();
            m_cameraController.Update();
            m_pointController.Update();
        }

        private void Handle_StartButton()
        {
            if (m_playerPlatoonController.NumberOfPlayer() > 0)
            {
                m_isStart = true;
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
            ChangeState(E_State.EnemyTurn);
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
                case E_State.Battle:
                    m_battle.StartTurn();
                    break;
                case E_State.Occupation:

                    break;
                default:
                    break;
            }
        }

        public E_State GetNowState() => m_state;
        public bool IsStart() => m_isStart;        
        public bool GetSpawnPlatoonActive() => m_spawnPlatoon.activeSelf;
        public void SetSpawnPlatoonActive(bool active)
        {
            if (active)
            {
                m_turnMonitor.SetActive(false);
                m_turnButton.SetActive(false);
                m_spawnPlatoon.SetActive(true);
                m_board.SetActive(false);
            }
            else
            {
                m_turnMonitor.SetActive(true);
                m_turnButton.SetActive(true);
                m_spawnPlatoon.SetActive(false);
                m_board.SetActive(true);
            }
        }

        public TouchController GetTouchController() => m_touchController;
        public PlayerPlatoonController GetPlayerPlatoonController() => m_playerPlatoonController;
        public EnemyPlatoonController GetEnemyPlatoonController() => m_enemyPlatoonController;
        public PointController GetPointController() => m_pointController;
        public StageFieldManager GetStageFieldManager() => m_stageFieldmanager;
    }
}
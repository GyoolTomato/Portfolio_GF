using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scene_StageField.Controller;

namespace Assets.Scene_StageField
{
    public class StageFieldManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private TouchController m_touchController;
        private CameraController m_cameraController;
        private PlayerPlatoonController m_playerPlatoonController;
        private EnemyPlatoonController m_enemyPlatoonController;
        private PointController m_pointController;
        private SpawnPlatoonController m_spawnPlatoonController;
        private BattleFieldController m_battleFieldController;

        private GameObject m_canvas;
        private GameObject m_turnMonitor;
        private GameObject m_turnButton;
        private GameObject m_spawnPlatoon;
        private GameObject m_exitAnswer;
        private Button m_exitAnswer_No;
        private Button m_exitAnswer_Yes;
        private GameObject m_map;        
        private Assets.Resources.Object.Title m_title;

        public StageFieldManager()
        {

        }

        private void Awake()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
            m_touchController = new TouchController();
            m_touchController.Initialize(this);
            m_cameraController = new CameraController();
            m_cameraController.Initialize();
            m_playerPlatoonController = new PlayerPlatoonController();
            m_playerPlatoonController.Initialize(this);
            m_enemyPlatoonController = new EnemyPlatoonController();
            m_enemyPlatoonController.Initialize(this);

            m_pointController = new PointController();
            m_pointController.Initialize(this);
            m_spawnPlatoonController = new SpawnPlatoonController();
            m_battleFieldController = new BattleFieldController();
            m_battleFieldController.Initialize(this);

            m_canvas = GameObject.Find("Canvas");
            m_turnMonitor = m_canvas.transform.Find("TurnMonitor").gameObject;
            m_turnButton = m_canvas.transform.Find("TurnButton").gameObject; 
            m_spawnPlatoon = m_canvas.transform.Find("SpawnPlatoon").gameObject;
            m_exitAnswer = m_canvas.transform.Find("ExitAnswer").gameObject;
            m_exitAnswer.SetActive(false);
            m_exitAnswer_No = m_exitAnswer.transform.Find("No").GetComponent<Button>();
            m_exitAnswer_No.onClick.AddListener(Handle_ExitCanel);
            m_exitAnswer_Yes = m_exitAnswer.transform.Find("Yes").GetComponent<Button>();
            m_exitAnswer_Yes.onClick.AddListener(Handle_Exit);
            m_map = GameObject.Find("Map");
            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_gameManager, "스테이지", BackAction);            
        }

        private void Start()
        {
            SetSpawnPlatoonActive(false);
            m_spawnPlatoonController.Initialize(this);
            LoadBackup();
        }

        private void Update()
        {
            m_touchController.UpdateIsClick();
            m_cameraController.Update();
            m_pointController.Update();
        }

        public TouchController GetTouchController()
        {
            return m_touchController;
        }

        public PlayerPlatoonController GetPlayerPlatoonController()
        {
            return m_playerPlatoonController;
        }

        public EnemyPlatoonController GetEnemyPlatoonController()
        {
            return m_enemyPlatoonController;
        }

        public PointController GetPointController()
        {
            return m_pointController;
        }

        public BattleFieldController GetBattleFieldController()
        {
            return m_battleFieldController;
        }

        private void BackAction()
        {
            if (m_spawnPlatoon.activeSelf)
            {
                SetSpawnPlatoonActive(false);
            }
            else
            {
                m_exitAnswer.SetActive(true);                
            }
        }

        private void Handle_Exit()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStage");
        }

        private void Handle_ExitCanel()
        {
            m_exitAnswer.SetActive(false);
        }

        public bool GetSpawnPlatoonActive()
        {
            return m_spawnPlatoon.activeSelf;
        }

        public void SetSpawnPlatoonActive(bool active)
        {
            if (active)
            {
                m_turnMonitor.SetActive(false);
                m_turnButton.SetActive(false);
                m_spawnPlatoon.SetActive(true);
                m_map.SetActive(false);
            }
            else
            {
                m_turnMonitor.SetActive(true);
                m_turnButton.SetActive(true);
                m_spawnPlatoon.SetActive(false);
                m_map.SetActive(true);
            }
        }

        private void LoadBackup()
        {
            
        }
    }
}
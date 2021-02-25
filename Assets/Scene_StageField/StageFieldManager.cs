using System;
using UnityEngine;
using Assets.Scene_StageField.Controller;

namespace Assets.Scene_StageField
{
    public class StageFieldManager : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private TouchController m_touchController;
        private CameraController m_cameraController;
        private CharacterController m_characterController;
        private PointController m_pointController;
        private SpawnPlatoonController m_spawnPlatoonController;
        private BattleFieldController m_battleFieldController;

        private GameObject m_canvas;
        private GameObject m_turnMonitor;
        private GameObject m_turnButton;
        private GameObject m_spawnPlatoon;
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
            m_characterController = new CharacterController();
            m_characterController.Initialize(this);
            m_pointController = new PointController();
            m_pointController.Initialize(this);
            m_spawnPlatoonController = new SpawnPlatoonController();
            m_battleFieldController = new BattleFieldController();
            m_battleFieldController.Initialize(this);

            m_canvas = GameObject.Find("Canvas");
            m_turnMonitor = m_canvas.transform.Find("TurnMonitor").gameObject;
            m_turnButton = m_canvas.transform.Find("TurnButton").gameObject; 
            m_spawnPlatoon = m_canvas.transform.Find("SpawnPlatoon").gameObject;
            m_map = GameObject.Find("Map");
            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_gameManager, "스테이지", BackAction);            
        }

        private void Start()
        {
            SetSpawnPlatoonActive(false);
            m_spawnPlatoonController.Initialize(this);
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

        public CharacterController GetCharacterController()
        {
            return m_characterController;
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
                UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStage");
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
    }
}
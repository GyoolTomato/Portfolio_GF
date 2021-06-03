using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scenes.StageField.Controller;
using Assets.Scenes.StageField.Board;
using Assets.Scenes.StageField.BattleField;

namespace Assets.Scenes.StageField
{
    public class StageFieldManager : MonoBehaviour
    {
        public enum E_State
        {
            Board,
            Battle,
            End,
        }

        private E_State m_state;
        private PlayController m_playController;
        private BoardManager m_boardManager;
        private BattleFieldManager m_battleFieldManager;

        private GameObject m_battleField;
        private GameObject m_board;        
        private GameObject m_canvas;
        private GameObject m_battleFieldUI;
        private GameObject m_boardUI;
        
        private GameObject m_exitAnswer;
        private Button m_exitAnswer_No;
        private Button m_exitAnswer_Yes;      
        private Assets.Objects.UI.Title m_title;

        public StageFieldManager()
        {

        }

        private void Awake()
        {
            m_state = E_State.End;
            m_playController = new PlayController();
            m_playController.Initialize(this);
            m_boardManager = new BoardManager();
            m_boardManager.Initialize(this);
            m_battleFieldManager = new BattleFieldManager();
            m_battleFieldManager.Initialize(this);

            m_battleField = GameObject.Find("BattleField");
            m_board = GameObject.Find("Board");
            m_canvas = GameObject.Find("Canvas");
            m_battleFieldUI = m_canvas.transform.Find("BattleFieldUI").gameObject;
            m_boardUI = m_canvas.transform.Find("BoardUI").gameObject;
            m_exitAnswer = m_boardUI.transform.Find("ExitAnswer").gameObject;
            m_exitAnswer.SetActive(false);
            m_exitAnswer_No = m_exitAnswer.transform.Find("No").GetComponent<Button>();
            m_exitAnswer_No.onClick.AddListener(Handle_ExitCanel);
            m_exitAnswer_Yes = m_exitAnswer.transform.Find("Yes").GetComponent<Button>();
            m_exitAnswer_Yes.onClick.AddListener(Handle_Exit);
            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("스테이지", BackAction);            
        }

        private void Start()
        {
            ChangeState(E_State.Board);
            switch (m_state)
            {
                case E_State.Board:
                    m_boardManager.Start();
                    break;
                case E_State.Battle:
                    break;
                default:
                    break;
            }            
        }

        private void Update()
        {
            switch (m_state)
            {
                case E_State.Board:
                    m_boardManager.Update();
                    break;
                case E_State.Battle:
                    break;
                default:
                    break;
            }            
        }

        public PlayController GetPlayController()
        {
            return m_playController;
        }

        public BoardManager GetBoardManager()
        {
            return m_boardManager;
        }

        public BattleFieldManager GetBattleFieldManager()
        {
            return m_battleFieldManager;
        }

        private void BackAction()
        {
            if (m_boardManager.GetSpawnPlatoonActive())
            {
                m_boardManager.SetSpawnPlatoonActive(false);
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

        public void ChangeState(E_State state)
        {
            m_state = state;
            switch (m_state)
            {
                case E_State.Board:
                    m_board.SetActive(true);
                    m_boardUI.SetActive(true);
                    m_battleField.SetActive(false);
                    m_battleFieldUI.SetActive(false);
                    break;
                case E_State.Battle:
                    m_board.SetActive(false);
                    m_boardUI.SetActive(false);
                    m_battleField.SetActive(true);
                    m_battleFieldUI.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
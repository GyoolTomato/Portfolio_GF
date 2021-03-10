using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Controller
{
    public class BoardController
    {
        public enum E_State
        {
            PlayerTurn,
            EnemyTurn,
            Battle,
            Occupation,
            End,
        }

        private Common.GameManager m_gameManager;
        private StageFieldManager m_manager;
        private bool m_isStart;
        private E_State m_state;
        private int m_turnNumber;

        private GameObject m_turnStartBanner;
        private Text m_turnStartBanner_Title;
        private Text m_turnStartBanner_Turn;
        private Button m_startButton;
        private Button m_endTurnButton;

        private List<Base.BattleData> m_battleDatas;

        public BoardController()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_manager = manager;
            m_isStart = false;
            m_turnNumber = 0;

            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            m_turnStartBanner = board.Find("TurnStartBanner").gameObject;
            m_turnStartBanner.SetActive(false);
            m_turnStartBanner_Title = m_turnStartBanner.transform.Find("Title").GetComponent<Text>();
            m_turnStartBanner_Turn = m_turnStartBanner.transform.Find("Turn").GetComponent<Text>();
            var turnButton = board.Find("TurnButton");
            m_startButton = turnButton.transform.Find("StartButton").GetComponent<Button>();
            m_startButton.onClick.AddListener(Handle_StartButton);
            m_startButton.gameObject.SetActive(true);
            m_endTurnButton = turnButton.transform.Find("EndTurnButton").GetComponent<Button>();
            m_endTurnButton.onClick.AddListener(Handle_EndTurnButton);
            m_endTurnButton.gameObject.SetActive(false);
        }

        private void Handle_StartButton()
        {
            if (m_manager.GetPlayerPlatoonController().NumberOfPlayer() > 0)
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
                    State_PlayerTurn();
                    break;
                case E_State.EnemyTurn:
                    State_EnemyTurn();
                    break;
                case E_State.Battle:
                    State_Battle();
                    break;
                case E_State.Occupation:
                    State_Occupation();
                    break;
                default:
                    break;
            }
        }

        private void State_PlayerTurn()
        {
            m_turnNumber++;
            m_turnStartBanner.SetActive(true);
            m_turnStartBanner_Title.text = "플레이어 차례";
            m_turnStartBanner_Turn.text = m_turnNumber + "턴";
            m_manager.StartCoroutine(OffTurnStartBanner());
        }

        private void State_EnemyTurn()
        {
            m_turnStartBanner.SetActive(true);
            m_turnStartBanner_Title.text = "적 차례";
            m_turnStartBanner_Turn.text = m_turnNumber + "턴";
            m_manager.StartCoroutine(OffTurnStartBanner());
            m_manager.GetEnemyPlatoonController().StartEnemyTurn();
            m_manager.StartCoroutine(MoveFinishCheck());
        }

        private void State_Battle()
        {
            m_manager.StartCoroutine(BattleAllFinishCheck());
        }

        private void State_Occupation()
        {

        }

        private IEnumerator OffTurnStartBanner()
        {
            yield return new WaitForSeconds(2.5f);
            m_turnStartBanner.SetActive(false);
        }

        private IEnumerator MoveFinishCheck()
        {
            var moving = true;
            var enemies = m_manager.GetEnemyPlatoonController().GetEnemies();

            while (moving)
            {
                if (enemies.Count > 0)
                {
                    foreach (var item in enemies)
                    {
                        if (item.IsMoving())
                            moving = true;
                        else
                            moving = false;
                    }
                }
                else
                {
                    yield return null;
                }
            }

            ChangeState(E_State.Battle);
            yield return null;
        }

        private IEnumerator BattleAllFinishCheck()
        {
            var notFinish = true;

            while (notFinish)
            {
                if (m_battleDatas.Count == 0)
                    notFinish = false;
            }

            yield return new WaitForSeconds(3);
            ChangeState(E_State.Occupation);
            yield return null;
        }

        public bool IsStart()
        {
            return m_isStart;
        }

        public E_State GetNowState()
        {
            return m_state;
        }
    }
}
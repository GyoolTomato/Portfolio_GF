﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Controller
{
    public class BattleFieldController
    {
        public enum E_Turn
        {
            Player,
            Enemy,
            End,
        }

        private StageFieldManager m_manager;
        private bool m_isStart;
        private E_Turn m_turn;
        private int m_turnNumber;

        private GameObject m_turnStartBanner;
        private Text m_turnStartBanner_Title;
        private Text m_turnStartBanner_Turn;
        private Button m_startButton;
        private Button m_endTurnButton;

        public BattleFieldController()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_manager = manager;
            m_isStart = false;
            m_turnNumber = 0;

            var canvas = GameObject.Find("Canvas");
            m_turnStartBanner = canvas.transform.Find("TurnStartBanner").gameObject;
            m_turnStartBanner.SetActive(false);
            m_turnStartBanner_Title = m_turnStartBanner.transform.Find("Title").GetComponent<Text>();
            m_turnStartBanner_Turn = m_turnStartBanner.transform.Find("Turn").GetComponent<Text>();
            var turnButton = canvas.transform.Find("TurnButton");
            m_startButton = turnButton.transform.Find("StartButton").GetComponent<Button>();
            m_startButton.onClick.AddListener(Handle_StartButton);
            m_startButton.gameObject.SetActive(true);
            m_endTurnButton = turnButton.transform.Find("EndTurnButton").GetComponent<Button>();
            m_endTurnButton.onClick.AddListener(Handle_EndTurnButton);
            m_endTurnButton.gameObject.SetActive(false);
        }

        private void Handle_StartButton()
        {
            if (m_manager.GetCharacterController().NumberOfPlayer() > 0)
            {
                m_isStart = true;
                m_startButton.gameObject.SetActive(false);
                m_endTurnButton.gameObject.SetActive(true);
                ChangeTurn(E_Turn.Player);
            }
            else
            {
                Debug.Log("시작 실패");
            }
        }

        private void Handle_EndTurnButton()
        {
            ChangeTurn(E_Turn.Enemy);
        }

        public void ChangeTurn(E_Turn turn)
        {
            m_turn = turn;

            switch (m_turn)
            {
                case E_Turn.Player:
                    m_turnNumber++;
                    m_turnStartBanner.SetActive(true);
                    m_turnStartBanner_Title.text = "플레이어 차례";
                    m_turnStartBanner_Turn.text = m_turnNumber + "턴";
                    m_manager.StartCoroutine(OffTurnStartBanner());
                    break;
                case E_Turn.Enemy:
                    m_turnStartBanner.SetActive(true);
                    m_turnStartBanner_Title.text = "적 차례";
                    m_turnStartBanner_Turn.text = m_turnNumber + "턴";
                    m_manager.StartCoroutine(OffTurnStartBanner());
                    break;
                default:
                    break;
            }
        }

        private IEnumerator OffTurnStartBanner()
        {
            yield return new WaitForSeconds(2.5f);
            m_turnStartBanner.SetActive(false);
        }

        public bool IsStart()
        {
            return m_isStart;
        }

        public E_Turn GetNowTurn()
        {
            return m_turn;
        }
    }
}
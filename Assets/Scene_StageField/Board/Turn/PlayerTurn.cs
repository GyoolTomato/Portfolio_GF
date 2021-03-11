using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Board.Turn
{
    public class PlayerTurn
    {
        private StageFieldManager m_stageFieldManager;
        private GameObject m_turnStartBanner;
        private Text m_turnStartBanner_Title;
        private Text m_turnStartBanner_Turn;

        public PlayerTurn()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager, GameObject turnStartBanner)
        {
            m_stageFieldManager = stageFieldManager;
            m_turnStartBanner = turnStartBanner;
            m_turnStartBanner_Title = m_turnStartBanner.transform.Find("Title").GetComponent<Text>();
            m_turnStartBanner_Turn = m_turnStartBanner.transform.Find("Turn").GetComponent<Text>();
        }

        public void TurnStart(int turnNumber)
        {
            m_turnStartBanner.SetActive(true);
            m_turnStartBanner_Title.text = "플레이어 차례";
            m_turnStartBanner_Turn.text = turnNumber + "턴";
            m_stageFieldManager.StartCoroutine(OffTurnStartBanner());
        }

        private IEnumerator OffTurnStartBanner()
        {
            yield return new WaitForSeconds(2.5f);
            m_turnStartBanner.SetActive(false);
        }
    }
}
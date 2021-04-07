using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Board.Turn
{
    public class EnemyTurn
    {
        private StageFieldManager m_stageFieldManager;
        private Controller.EnemyPlatoonController m_enemyPlatoonController;
        private GameObject m_turnStartBanner;
        private Text m_turnStartBanner_Title;
        private Text m_turnStartBanner_Turn;
        private GameObject m_movePointMonitor;
        private GameObject m_endTurnButton;

        public EnemyTurn()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager, GameObject turnStartBanner, GameObject movePointMonitor, GameObject endturnButton)
        {
            m_stageFieldManager = stageFieldManager;
            m_enemyPlatoonController = m_stageFieldManager.GetBoardManager().GetEnemyPlatoonController();
            m_turnStartBanner = turnStartBanner;
            m_turnStartBanner_Title = m_turnStartBanner.transform.Find("Title").GetComponent<Text>();
            m_turnStartBanner_Turn = m_turnStartBanner.transform.Find("Turn").GetComponent<Text>();
            m_movePointMonitor = movePointMonitor;
            m_endTurnButton = endturnButton;
        }

        public void StartTurn(int turnNumber)
        {
            if (m_stageFieldManager.GetPlayController().IsPlaying())
            {
                m_turnStartBanner.SetActive(true);
                m_turnStartBanner_Title.text = "적 차례";
                m_turnStartBanner_Turn.text = turnNumber + "턴";
                m_movePointMonitor.SetActive(false);
                m_endTurnButton.SetActive(false);
                m_enemyPlatoonController.StartEnemyTurn();
                m_stageFieldManager.StartCoroutine(OffTurnStartBanner());
                m_stageFieldManager.StartCoroutine(MoveFinishCheck());
            }
        }

        private IEnumerator OffTurnStartBanner()
        {
            yield return new WaitForSeconds(2.5f);
            m_turnStartBanner.SetActive(false);
        }

        private IEnumerator MoveFinishCheck()
        {
            while (!m_enemyPlatoonController.IsMoveFinish())
            {                
                yield return null;
            }

            m_stageFieldManager.GetBoardManager().ChangeState(BoardManager.E_State.EnemyBattle);
        }
    }
}

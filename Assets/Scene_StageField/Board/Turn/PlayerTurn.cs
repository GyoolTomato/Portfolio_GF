using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Board.Turn
{
    public class PlayerTurn
    {
        private StageFieldManager m_stageFieldManager;
        private Controller.PlayerPlatoonController m_playerPlatoonController;
        private BoardManager m_boardManager;
        private GameObject m_turnStartBanner;
        private Text m_turnStartBanner_Title;
        private Text m_turnStartBanner_Turn;
        private GameObject m_movePointMonitor;
        private GameObject m_endTurnButton;

        public PlayerTurn()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager, GameObject turnStartBanner, GameObject movePointMonitor, GameObject endturnButton)
        {
            m_stageFieldManager = stageFieldManager;
            m_boardManager = m_stageFieldManager.GetBoardManager();
            m_playerPlatoonController = m_boardManager.GetPlayerPlatoonController();
            m_turnStartBanner = turnStartBanner;
            m_turnStartBanner_Title = m_turnStartBanner.transform.Find("Title").GetComponent<Text>();
            m_turnStartBanner_Turn = m_turnStartBanner.transform.Find("Turn").GetComponent<Text>();
            m_movePointMonitor = movePointMonitor;
            m_endTurnButton = endturnButton;
        }

        public void StartTurn(int turnNumber)
        {
            m_stageFieldManager.GetPlayController().GameOverCheck();

            if (m_stageFieldManager.GetPlayController().IsPlaying())
            {               
                m_turnStartBanner.SetActive(true);
                m_turnStartBanner_Title.text = "플레이어 차례";
                m_turnStartBanner_Turn.text = turnNumber + "턴";
                m_movePointMonitor.SetActive(true);
                m_endTurnButton.SetActive(true);
                m_stageFieldManager.StartCoroutine(OffTurnStartBanner());
                InitNumberOFMovementAvailable();
            }
        }

        private IEnumerator OffTurnStartBanner()
        {
            yield return new WaitForSeconds(2.5f);
            m_turnStartBanner.SetActive(false);
        }

        private IEnumerator MoveFinishCheck()
        {
            while (!m_playerPlatoonController.IsMoveFinish())
            {
                yield return null;
            }

            m_stageFieldManager.GetBoardManager().ChangeState(BoardManager.E_State.EnemyBattle);
        }

        private void InitNumberOFMovementAvailable()
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            var points = GameObject.FindGameObjectsWithTag("Point");
            var addByPoints = 0;
            foreach (var item in points)
            {
                var occupationPoint = item.GetComponent<Object.OccupationPoint>();

                if (occupationPoint != null)
                {
                    if (occupationPoint.Owner == Object.OccupationPoint.E_Owner.Player)
                    {
                        addByPoints++;
                    }
                }                
            }

            var numberOfMovementAvailable = players.Length + addByPoints;
            m_boardManager.SetNumberOfMovementAvailableValue(numberOfMovementAvailable);
        }

        
    }
}
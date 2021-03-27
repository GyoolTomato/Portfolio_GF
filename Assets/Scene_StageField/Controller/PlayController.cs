using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Controller
{
    public class PlayController
    {
        private StageFieldManager m_stageFieldManager;
        private bool m_isPlaying;
        private GameObject m_gameOverBanner;
        private Transform m_gameOverBanner_Curtain;
        private Transform m_gameOverBanner_Banner;
        private Transform m_gameOverBanner_Banner_Win;
        private Transform m_gameOverBanner_Banner_Lose;

        public PlayController()
        {

        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
            m_gameOverBanner = GameObject.Find("GameOverBanner");
            m_gameOverBanner_Curtain = m_gameOverBanner.transform.Find("Curtain");
            m_gameOverBanner_Banner = m_gameOverBanner.transform.Find("Banner");
            m_gameOverBanner_Banner_Win = m_gameOverBanner_Banner.Find("Win");
            m_gameOverBanner_Banner_Lose = m_gameOverBanner_Banner.Find("Lose");
            m_gameOverBanner.SetActive(false);
        }

        public void StartPlay()
        {
            m_isPlaying = true;
        }

        public void GameOverCheck()
        {
            if (NotFoundPlayerMainPoints() || PlayerAllDie())
            {
                EnemyWinEvent();
                m_isPlaying = false;
            }

            if (NotFoundEnemyMainPoints())
            {
                PlayerWinEvent();
                m_isPlaying = false;
            }
        }

        public bool NotFoundPlayerMainPoints()
        {
            var pointController = m_stageFieldManager.GetBoardManager().GetPointController();

            foreach (var item in pointController.GetMainPoints())
            {
                if (item.Owner == Object.OccupationPoint.E_Owner.Player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool NotFoundEnemyMainPoints()
        {
            var pointController = m_stageFieldManager.GetBoardManager().GetPointController();

            foreach (var item in pointController.GetMainPoints())
            {
                if (item.Owner == Object.OccupationPoint.E_Owner.Player)
                {
                    return false;
                }
            }

            return true;
        }

        public bool PlayerAllDie()
        {
            var playerPlatoonController = m_stageFieldManager.GetBoardManager().GetPlayerPlatoonController();

            if (playerPlatoonController.GetPlayers().Count == 0)
            {
                return true;
            }

            return false;
        }

        public void PlayerWinEvent()
        {
            m_stageFieldManager.StartCoroutine(GameOverBannerAnimation(true));
        }

        public void EnemyWinEvent()
        {            
            m_stageFieldManager.StartCoroutine(GameOverBannerAnimation(false));
        }

        public bool IsPlaying()
        {
            return m_isPlaying;
        }

        IEnumerator GameOverBannerAnimation(bool playerWin)
        {
            m_gameOverBanner.SetActive(true);
            m_gameOverBanner_Curtain.gameObject.SetActive(true);
            m_gameOverBanner_Banner.gameObject.SetActive(true);
            m_gameOverBanner_Banner_Win.gameObject.SetActive(true);
            m_gameOverBanner_Banner_Lose.gameObject.SetActive(true);

            var curtainImage = m_gameOverBanner_Curtain.GetComponent<Image>();
            var winImage = m_gameOverBanner_Banner_Win.GetComponent<Image>();
            var loseImage = m_gameOverBanner_Banner_Lose.GetComponent<Image>();

            curtainImage.color = new Color(curtainImage.color.r, curtainImage.color.g, curtainImage.color.b, 0);
            winImage.color = new Color(winImage.color.r, winImage.color.g, winImage.color.b, 0);
            loseImage.color = new Color(loseImage.color.r, loseImage.color.g, loseImage.color.b, 0);

            while (curtainImage.color.a != 1)
            {

                yield return new WaitForSeconds(0.1f);
            }

            if (playerWin)
            {
                while (winImage.color.a != 1)
                {
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                while (loseImage.color.a != 1)
                {
                    yield return new WaitForSeconds(0.1f);
                }
            }            

            yield return null;
        }
    }
}
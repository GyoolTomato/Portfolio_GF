using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_StageField.Controller
{
    public class PlayController
    {
        private StageFieldManager m_stageFieldManager;
        private bool m_isPlaying;
        private bool m_isFinish;
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
            var button = m_gameOverBanner_Banner.GetComponent<Button>();
            button.onClick.AddListener(ReturnSelectStageScene);
            m_gameOverBanner_Banner_Win = m_gameOverBanner_Banner.Find("Win");
            m_gameOverBanner_Banner_Lose = m_gameOverBanner_Banner.Find("Lose");
            m_gameOverBanner.SetActive(false);
        }

        public void StartPlay()
        {
            m_isFinish = false;
            m_isPlaying = true;
        }

        public void GameOverCheck()
        {
            m_stageFieldManager.StartCoroutine(GameOver());
        }

        private IEnumerator GameOver()
        {           
            if (NotFoundPlayerMainPoints() || PlayerAllDie())
            {
                yield return new WaitForSeconds(3);
                m_stageFieldManager.StartCoroutine(GameOverBannerAnimation(false));
                SetIsFinish(true);
            }
            else if (NotFoundEnemyMainPoints())
            {
                yield return new WaitForSeconds(3);
                m_stageFieldManager.StartCoroutine(GameOverBannerAnimation(true));
                SetIsFinish(true);
            }

            yield return null;
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
                if (item.Owner == Object.OccupationPoint.E_Owner.Enemy)
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

        public bool IsPlaying()
        {
            return m_isPlaying;
        }

        public bool IsFinish()
        {           
            return m_isFinish;
        }

        private void SetIsFinish(bool value)
        {
            if (value)
            {
                m_isPlaying = false;
            }

            m_isFinish = value;
        }

        private IEnumerator GameOverBannerAnimation(bool playerWin)
        {
            m_gameOverBanner.SetActive(true);
            m_gameOverBanner_Curtain.gameObject.SetActive(true);
            m_gameOverBanner_Banner.gameObject.SetActive(true);
            m_gameOverBanner_Banner_Win.gameObject.SetActive(false);
            m_gameOverBanner_Banner_Lose.gameObject.SetActive(false);

            var curtainImage = m_gameOverBanner_Curtain.GetComponent<Image>();
            var bannerImage = m_gameOverBanner_Banner.GetComponent<Image>();
            var winImage = m_gameOverBanner_Banner_Win.GetComponent<Text>();
            var loseImage = m_gameOverBanner_Banner_Lose.GetComponent<Text>();

            curtainImage.color = new Color(curtainImage.color.r, curtainImage.color.g, curtainImage.color.b, 0);
            bannerImage.color = new Color(bannerImage.color.r, bannerImage.color.g, bannerImage.color.b, 0);
            winImage.color = new Color(winImage.color.r, winImage.color.g, winImage.color.b, 0);
            loseImage.color = new Color(loseImage.color.r, loseImage.color.g, loseImage.color.b, 0);

            while (curtainImage.color.a != 170f/255f)
            {
                curtainImage.color = new Color(curtainImage.color.r, curtainImage.color.g, curtainImage.color.b, curtainImage.color.a + 10f/255f);
                yield return new WaitForSeconds(0.01f);
            }

            if (playerWin)
            {
                m_gameOverBanner_Banner_Win.gameObject.SetActive(true);
                while (winImage.color.a < 200f/255f)
                {
                    bannerImage.color = new Color(curtainImage.color.r, curtainImage.color.g, curtainImage.color.b, curtainImage.color.a + 10f / 255f);
                    winImage.color = new Color(winImage.color.r, winImage.color.g, winImage.color.b, winImage.color.a + 10f / 255f);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                m_gameOverBanner_Banner_Lose.gameObject.SetActive(true);
                while (loseImage.color.a < 200f/255f)
                {
                    bannerImage.color = new Color(curtainImage.color.r, curtainImage.color.g, curtainImage.color.b, curtainImage.color.a + 10f / 255f);
                    loseImage.color = new Color(loseImage.color.r, loseImage.color.g, loseImage.color.b, loseImage.color.a + 10f / 255f);
                    yield return new WaitForSeconds(0.01f);
                }
            }            

            yield return null;
        }

        private void ReturnSelectStageScene()
        {
            SceneManager.LoadScene("SelectStage");
        }
    }
}
using System;
using UnityEngine;
using Assets.Objects.UI;

namespace Assets.Scenes.SelectStage
{
    public class SelectStageManager : MonoBehaviour
    {
        private GameObject m_canvas;

        private Title m_title;
        private Controller.ViewPortController m_viewPortController;

        public SelectStageManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {            
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Title>();
            m_title.Initialize("스테이지 선택", BackAction);

            m_viewPortController = new Controller.ViewPortController();
            m_viewPortController.Initialize();
            m_viewPortController.Load();
        }

        private void Update()
        {

        }

        private void BackAction()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        }
    }
}
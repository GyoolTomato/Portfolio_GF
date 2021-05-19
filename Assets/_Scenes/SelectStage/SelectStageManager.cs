using System;
using UnityEngine;

namespace Assets.Scenes.SelectStage
{
    public class SelectStageManager : MonoBehaviour
    {
        private Assets.Common.ResourceManager m_resourceManager;
        private GameObject m_canvas;

        private Assets.Resources.Object.Title m_title;
        private Controller.ViewPortController m_viewPortController;

        public SelectStageManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_resourceManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.ResourceManager>();
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
            m_title.Initialize(m_resourceManager, "스테이지 선택", BackAction);

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
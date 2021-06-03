using System;
using UnityEngine;

namespace Assets.Scenes.Restore
{
    public class RestoreManager : MonoBehaviour
    {
        private GameObject m_canvas;

        private Assets.Objects.UI.Title m_title;

        public RestoreManager()
        {
        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("수복", BackAction);
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
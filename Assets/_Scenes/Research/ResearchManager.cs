﻿using System;
using UnityEngine;

namespace Assets.Scenes.Research
{
    public class ResearchManager : MonoBehaviour
    {
        private Assets.Common.ResourceManager m_resourceManager;
        private GameObject m_canvas;

        private Assets.Resources.Object.Title m_title;
        //private MenuController m_menuController;

        public ResearchManager()
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
            m_title.Initialize(m_resourceManager, "연구", BackAction);
            //m_menuController = new Controller.MenuController();
            //m_menuController.Initialize(m_gameManager, m_canvas);
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
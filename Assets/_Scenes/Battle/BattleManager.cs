using System;
using UnityEngine;
using Assets.Scenes.Dormitory.Controller;

namespace Assets.Scenes.Battle
{
    public class BattleManager : MonoBehaviour
    {
        private GameObject m_canvas;

        private Assets.Objects.UI.Title m_title;
        private MenuController m_menuController;
        private ViewPort_TDollController m_viewPort_TDollController;
        private ViewPort_EquipmentsController m_viewPort_EquipmentsController;

        public BattleManager()
        {

        }

        private void Awake()
        {

        }

        private void Start()
        {
            m_canvas = GameObject.Find("Canvas");

            m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Objects.UI.Title>();
            m_title.Initialize("전투", BackAction);


            m_viewPort_TDollController.Load();
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

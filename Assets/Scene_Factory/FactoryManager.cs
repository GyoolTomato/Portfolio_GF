using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_Factory.Controller;

namespace Assets.Scene_Factory
{
    public class FactoryManager : MonoBehaviour
    {
        private Assets.GameManager.GameManager m_gameManager;
        private GameManager.IndexDBController m_indexDBController;
        private GameManager.UserDBController m_userDBController;
        private GameObject m_canvas;

        private MenuController m_menuController;

        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.GameManager.GameManager>();
            m_indexDBController = m_gameManager.IndexDBController;
            m_userDBController = m_gameManager.UserDBController;
            m_canvas = GameObject.Find("Canvas");

            m_menuController = new MenuController();
            m_menuController.Initialize(m_gameManager, m_canvas);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

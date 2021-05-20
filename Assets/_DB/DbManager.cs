using System;
using UnityEngine;

namespace Assets.DB
{
    public class DbManager : MonoBehaviour
    {
        private static DbManager m_instance;

        private Game.GameDBManager m_gameDBManager;
        private Index.Manager.IndexDBManager m_indexDBManager;
        private User.Manager.UserDBManager m_userDBManager;

        private Index.Controller.IndexDBController m_indexDBController;
        private User.Controller.UserDBController m_userDBController;

        public DbManager()
        {
            
        }

        private void Awake()
        {
            if (m_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
            DontDestroyOnLoad(gameObject);

            m_gameDBManager = new DB.Game.GameDBManager();
            m_gameDBManager.Initailize(this);
            m_indexDBManager = new DB.Index.Manager.IndexDBManager();
            m_indexDBManager.Initailize(this);
            m_userDBManager = new DB.User.Manager.UserDBManager();
            m_userDBManager.Initailize(this);

            m_indexDBController = new Index.Controller.IndexDBController();
            m_indexDBController.Initialize(m_indexDBManager);
            m_userDBController = new User.Controller.UserDBController();
            m_userDBController.Initialize(m_userDBManager);
        }

        public Index.Manager.IndexDBManager GetIndexDBManager() => m_indexDBManager;
        public User.Manager.UserDBManager GetUserDBManager() => m_userDBManager;

        public Index.Controller.IndexDBController GetIndexDBController() => m_indexDBController;
        public User.Controller.UserDBController GetUserDBController() => m_userDBController;
    }
}
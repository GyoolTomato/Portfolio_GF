using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common.Controller;

namespace Assets.Common
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_instance;

        private ResourceContorller m_resourceContorller;
        private DB.Game.GameDBManager m_gameDBManager;
        private DB.Index.Manager.IndexDBManager m_indexDBManager;
        private DB.User.Manager.UserDBManager m_userDBManager;    

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
            m_resourceContorller = new ResourceContorller();
            m_resourceContorller.Initialize(this, m_userDBManager);
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public ResourceContorller ResourceContorller
        {
            get
            {
                return m_resourceContorller;
            }
        }

        public DB.Index.Manager.DBController_Index DBControllerIndex
        {
            get
            {
                return m_indexDBManager.DBController;
            }
        }

        public DB.User.Manager.DBController_User DBControllerUser
        {
            get
            {
                return m_userDBManager.DBController;
            }
        }

        public DB.User.Manager.UserDBManager UserDBManager()
        {
            return m_userDBManager;
        }
    }
}

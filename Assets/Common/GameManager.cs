using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Common
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_instance;

        private WorkResourceManager m_workResourceManager;
        private DB.Game.GameDBManager m_gameDBManager;
        private DB.Index.IndexDBManager m_indexDBManager;
        private DB.User.UserDBManager m_userDBManager;    

        private void Awake()
        {
            if (m_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
            DontDestroyOnLoad(gameObject);

            m_workResourceManager = new WorkResourceManager();
            m_workResourceManager.Initialize();
            m_gameDBManager = new DB.Game.GameDBManager();
            m_gameDBManager.Initailize(this);
            m_indexDBManager = new DB.Index.IndexDBManager();
            m_indexDBManager.Initailize(this);
            m_userDBManager = new DB.User.UserDBManager();
            m_userDBManager.Initailize(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            m_workResourceManager.ApplySaveAmount();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public WorkResourceManager WorkResource
        {
            get
            {
                return m_workResourceManager;
            }
        }

        public DB.Index.DBController_Index DBControllerIndex
        {
            get
            {
                return m_indexDBManager.DBController;
            }
        }

        public DB.User.DBController_User DBControllerUser
        {
            get
            {
                return m_userDBManager.DBController;
            }
        }
    }
}

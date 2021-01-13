using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private WorkResourceManager m_workResourceManager;
        private DB.DBController m_dBController;
        private DBController_Index m_dBControllerIndex;
        private DBController_User m_dBControllerUser;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            m_workResourceManager = new WorkResourceManager();
            m_workResourceManager.Initialize();

            m_dBController = new DB.DBController();
            m_dBController.Initailize(this);

            m_dBControllerIndex = new DBController_Index();
            m_dBControllerIndex.Initialize(m_dBController);

            m_dBControllerUser = new DBController_User();
            m_dBControllerUser.Initialize(m_dBController);
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

        public DBController_Index DBControllerIndex
        {
            get
            {
                return m_dBControllerIndex;
            }
        }

        public DBController_User DBControllerUser
        {
            get
            {
                return m_dBControllerUser;
            }
        }
    }
}

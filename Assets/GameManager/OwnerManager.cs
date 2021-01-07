using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameManager.DB;

namespace Assets.GameManager
{
    public class OwnerManager : MonoBehaviour
    {
        private DBManager m_dbManager;
        private List<UserDataBase_TDoll> m_userTDoll;
        private List<UserDataBase_Equipment> m_userEquipment;

        private void Awake()
        {
            m_dbManager = null;
            m_userTDoll = null;
            m_userEquipment = null;
        }

        // Use this for initialization
        void Start()
        {
            m_dbManager = GameObject.Find("GameManager").gameObject.GetComponent<DBManager>();
            m_userTDoll = new List<UserDataBase_TDoll>();
            m_userEquipment = new List<UserDataBase_Equipment>();

            SupplyStartPack();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SupplyStartPack()
        {
            if (m_dbManager.ReadUserDataBase_TDoll(QuerySupport.SelectTDoll_All).Count == 0)
            {
                var startMemeber0 = new UserDataBase_TDoll();
                startMemeber0.DataCode = 4;
                startMemeber0.Level = 1;
                startMemeber0.DummyLink = 1;
                startMemeber0.EquipmentOwnershipNumber0 = 0;
                startMemeber0.EquipmentOwnershipNumber1 = 0;
                startMemeber0.EquipmentOwnershipNumber2 = 0;
                var startMemeber1 = new UserDataBase_TDoll();
                startMemeber1.DataCode = 7;
                startMemeber1.Level = 1;
                startMemeber1.DummyLink = 1;
                startMemeber1.EquipmentOwnershipNumber0 = 0;
                startMemeber1.EquipmentOwnershipNumber1 = 0;
                startMemeber1.EquipmentOwnershipNumber2 = 0;

                var startPack = new List<UserDataBase_TDoll>();
                startPack.Add(startMemeber0);
                startPack.Add(startMemeber1);

                m_dbManager.InsertUserDataBase(startPack);
            }
        }

        public void AddOwnership(UserDataBase_TDoll data)
        {
            var tempData = new List<UserDataBase_TDoll>();
            tempData.Add(data);

            m_dbManager.InsertUserDataBase(tempData);
        }

        public void AddOwnership(UserDataBase_Equipment data)
        {
            var tempData = new List<UserDataBase_Equipment>();
            tempData.Add(data);

            m_dbManager.InsertUserDataBase(tempData);
        }

        public void ReleaseOwnership(List<UserDataBase_TDoll> data)
        {
            m_dbManager.DeleteUserDataBase(data);
        }

        public void ReleaseOwnership(List<UserDataBase_Equipment> data)
        {
            m_dbManager.DeleteUserDataBase(data);
        }

        public void UpdateOwnership(UserDataBase_TDoll data)
        {
            m_dbManager.UpdateUserDataBase(data);
        }

        public void UpdateOwnership(UserDataBase_Equipment data)
        {
            m_dbManager.UpdateUserDataBase(data);
        }

        public bool IsMounted(UserDataBase_Equipment data)
        {
            var result = false;

            if (m_dbManager.ReadUserDataBase_TDoll(QuerySupport.SelectMountedCheck(data)).Count > 0)
                result = true;

            return result;
        }
    }
}
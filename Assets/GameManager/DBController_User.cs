using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameManager.DB;

namespace Assets.GameManager
{
    public class DBController_User
    {
        private DBController m_dBController;
        private List<UserDataBase_TDoll> m_userTDoll;
        private List<UserDataBase_Equipment> m_userEquipment;

        public void Initialize(DBController dBController)
        {
            m_dBController = dBController;
            m_userTDoll = new List<UserDataBase_TDoll>();
            m_userEquipment = new List<UserDataBase_Equipment>();

            SupplyStartPack();
        }

        private void SupplyStartPack()
        {
            if (m_dBController.ReadUserDataBase_TDoll(QuerySupport.SelectTDoll_All).Count == 0)
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

                m_dBController.InsertUserDataBase(startPack);
            }
        }

        public void AddOwnership(IndexDataBase_TDoll data)
        {            
            var conversionData = new UserDataBase_TDoll();
            conversionData.DataCode = data.DataCode;
            conversionData.Level = 1;
            conversionData.DummyLink = 1;
            conversionData.EquipmentOwnershipNumber0 = 0;
            conversionData.EquipmentOwnershipNumber1 = 0;
            conversionData.EquipmentOwnershipNumber2 = 0;

            var tempData = new List<UserDataBase_TDoll>();
            tempData.Add(conversionData);

            m_dBController.InsertUserDataBase(tempData);
        }

        public void AddOwnership(IndexDataBase_Equipment data)
        {
            var conversionData = new UserDataBase_Equipment();
            conversionData.DataCode = data.DataCode;
            conversionData.Level = 1;
            conversionData.LimitedPower = 50.0f;            

            var tempData = new List<UserDataBase_Equipment>();
            tempData.Add(conversionData);

            m_dBController.InsertUserDataBase(tempData);
        }

        public void ReleaseOwnership(List<UserDataBase_TDoll> data)
        {
            m_dBController.DeleteUserDataBase(data);
        }

        public void ReleaseOwnership(List<UserDataBase_Equipment> data)
        {
            m_dBController.DeleteUserDataBase(data);
        }

        public void UpdateOwnership(UserDataBase_TDoll data)
        {
            m_dBController.UpdateUserDataBase(data);
        }

        public void UpdateOwnership(UserDataBase_Equipment data)
        {
            m_dBController.UpdateUserDataBase(data);
        }

        public bool IsMounted(UserDataBase_Equipment data)
        {
            var result = false;

            if (m_dBController.ReadUserDataBase_TDoll(QuerySupport.SelectMountedCheck(data)).Count > 0)
                result = true;

            return result;
        }
    }
}
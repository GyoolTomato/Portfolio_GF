using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Common.DB;
using Assets.Common.DB.Common;

namespace Assets.Common.DB.User
{
    public class DBController_User
    {
        private UserDBManager m_dBManager;
        private List<UserDataBase_TDoll> m_userTDoll;
        private List<UserDataBase_Equipment> m_userEquipment;

        public void Initialize(UserDBManager dBManager)
        {
            m_dBManager = dBManager;
            m_userTDoll = new List<UserDataBase_TDoll>();
            m_userEquipment = new List<UserDataBase_Equipment>();

            //SupplyStartPack();
        }

        private void SupplyStartPack()
        {
            if (m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectTDoll_All).Count == 0)
            {
                var startMemeber0 = new UserDataBase_TDoll();
                startMemeber0.DataCode = 4;
                startMemeber0.Level = 1;
                startMemeber0.DummyLink = 1;
                startMemeber0.Platoon = 0;
                startMemeber0.EquipmentOwnershipNumber0 = 0;
                startMemeber0.EquipmentOwnershipNumber1 = 0;
                startMemeber0.EquipmentOwnershipNumber2 = 0;
                var startMemeber1 = new UserDataBase_TDoll();
                startMemeber1.DataCode = 7;
                startMemeber1.Level = 1;
                startMemeber1.DummyLink = 1;
                startMemeber1.Platoon = 0;
                startMemeber1.EquipmentOwnershipNumber0 = 0;
                startMemeber1.EquipmentOwnershipNumber1 = 0;
                startMemeber1.EquipmentOwnershipNumber2 = 0;

                var startPack = new List<UserDataBase_TDoll>();
                startPack.Add(startMemeber0);
                startPack.Add(startMemeber1);

                m_dBManager.SQL(QuerySupport_User.InsertTDoll(startPack));
            }
        }

        public List<UserDataBase_TDoll> UserTDoll
        {
            get
            {
                var result = new List<UserDataBase_TDoll>();

                foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectTDoll_All))
                {
                    result.Add(item as UserDataBase_TDoll);
                }
                
                return result;
            }
        }

        public List<UserDataBase_Equipment> UserEquipments
        {
            get
            {
                var result = new List<UserDataBase_Equipment>();

                foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Equipment, QuerySupport_User.SelectEquipment_All))
                {
                    result.Add(item as UserDataBase_Equipment);
                }
                
                return result;
            }
        }

        public List<CommonDataBase_WorkResource> UserWorkResource
        {
            get
            {
                var result = new List<CommonDataBase_WorkResource>();

                foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.WorkResource, QuerySupport_User.SelectWorkResource_All))
                {
                    result.Add(item as CommonDataBase_WorkResource);
                }

                return result;
            }
        }

        public void AddOwnership(DB.Index.IndexDataBase_TDoll data)
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

            m_dBManager.SQL(QuerySupport_User.InsertTDoll(tempData));
        }

        public void AddOwnership(DB.Index.IndexDataBase_Equipment data)
        {
            var conversionData = new UserDataBase_Equipment();
            conversionData.DataCode = data.DataCode;
            conversionData.Level = 1;
            conversionData.LimitedPower = 50.0f;            

            var tempData = new List<UserDataBase_Equipment>();
            tempData.Add(conversionData);

            m_dBManager.SQL(QuerySupport_User.InsertEquipment(tempData));
        }

        public void ReleaseOwnership(List<UserDataBase_TDoll> data)
        {
            m_dBManager.SQL(QuerySupport_User.DeleteTDoll(data));
        }

        public void ReleaseOwnership(List<UserDataBase_Equipment> data)
        {
            m_dBManager.SQL(QuerySupport_User.DeleteEquipment(data));
        }

        public void UpdateOwnership(UserDataBase_TDoll data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdateTDoll(data));
        }

        public void UpdateOwnership(UserDataBase_Equipment data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdateEquipment(data));
        }

        public bool IsMounted(UserDataBase_Equipment data)
        {
            var result = false;

            if (m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectMountedCheck(data)).Count > 0)
                result = true;

            return result;
        }

        public void ApplyWorkResource(Assets.Common.Interface.WorkResource workResource)
        {
            var temp = new CommonDataBase_WorkResource();

            temp.Name = workResource.DBName;
            temp.Value = workResource.Amount;

            m_dBManager.SQL(QuerySupport_User.UpdateWorkResource(temp));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.DB.Common;
using Assets.DB.User.Manager;

namespace Assets.DB.User.Controller
{
    public class UserDBController
    {
        private UserDBManager m_dBManager;

        public void Initialize(UserDBManager dBManager)
        {
            m_dBManager = dBManager;

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

        public List<UserDataBase_TDoll> UserTDoll()
        {
            var result = new List<UserDataBase_TDoll>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectTDoll_All))
            {
                result.Add(item as UserDataBase_TDoll);
            }

            return result;
        }
        public UserDataBase_TDoll UserTDoll(int ownershipCode)
        {
            var result = new UserDataBase_TDoll();
            var temp = m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectTDoll(ownershipCode));

            if (temp.Count > 0)
            {
                result = temp[0] as UserDataBase_TDoll;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public List<UserDataBase_Equipment> UserEquipments()
        {
            var result = new List<UserDataBase_Equipment>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Equipment, QuerySupport_User.SelectEquipment_All))
            {
                result.Add(item as UserDataBase_Equipment);
            }

            return result;
        }

        public UserDataBase_Equipment UserEquipment(int ownershipCode)
        {
            var result = new UserDataBase_Equipment();
            var temp = m_dBManager.ReadDataBase(UserDBManager.E_Table.Equipment, QuerySupport_User.SelectEquipment(ownershipCode));

            if (temp.Count > 0)
            {
                result = temp[0] as UserDataBase_Equipment;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public List<CommonDataBase_Resource> UserResource()
        {
            var result = new List<CommonDataBase_Resource>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Resource, QuerySupport_User.SelectResource_All))
            {
                result.Add(item as CommonDataBase_Resource);
            }

            return result;
        }

        public List<UserDataBase_Produce> UserProduceTDoll()
        {
            var result = new List<UserDataBase_Produce>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Produce, QuerySupport_User.SelectProduceTDoll))
            {
                result.Add(item as UserDataBase_Produce);
            }

            return result;
        }

        public List<UserDataBase_Produce> UserProduceEquipment()
        {
            var result = new List<UserDataBase_Produce>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Produce, QuerySupport_User.SelectProduceEquipment))
            {
                result.Add(item as UserDataBase_Produce);
            }

            return result;
        }
        public List<UserDataBase_Platoon> UserFormation()
        {
            var result = new List<UserDataBase_Platoon>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Platoon, QuerySupport_User.SelectPlatoon))
            {
                result.Add(item as UserDataBase_Platoon);
            }

            return result;
        }
        public List<UserDataBase_Stage> Stage()
        {
            var result = new List<UserDataBase_Stage>();

            foreach (var item in m_dBManager.ReadDataBase(UserDBManager.E_Table.Stage, QuerySupport_User.SelectStage))
            {
                result.Add(item as UserDataBase_Stage);
            }

            return result;
        }

        public int FormationNumber(int ownershipCode)
        {
            var result = 0;

            var tempList = m_dBManager.ReadDataBase(UserDBManager.E_Table.Platoon, QuerySupport_User.SelectPlatoon);
            var temp = new UserDataBase_Platoon();

            foreach (var item in tempList)
            {
                temp = item as UserDataBase_Platoon;
                if (temp.Member1 == ownershipCode ||
                    temp.Member2 == ownershipCode ||
                    temp.Member3 == ownershipCode ||
                    temp.Member4 == ownershipCode)
                {
                    result = temp.Number;
                    break;
                }
            }

            return result;
        }

        public void AddOwnership(DB.Index.IndexDataBase_TDoll data)
        {
            var conversionData = new UserDataBase_TDoll();
            conversionData.DataCode = data.DataCode;
            conversionData.Level = 1;
            conversionData.DummyLink = Random.Range(1, 6);
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
            conversionData.LimitedPower = Random.Range(10, 101);           

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

        public void UpdateResource(Assets.Common.Interface.WorkResource workResource)
        {
            var temp = new CommonDataBase_Resource();

            temp.Name = workResource.DBName;
            temp.Value = workResource.Amount;

            m_dBManager.SQL(QuerySupport_User.UpdateResource(temp));
        }

        public void UpdateProduceTDoll(UserDataBase_Produce data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdateProduceTDoll(data));
        }

        public void UpdateProduceEquipment(UserDataBase_Produce data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdateProduceEquipment(data));
        }

        public void UpdateItemAmount(UserDataBase_Item data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdateItem(data));
        }

        public void UpdatePlatoon(UserDataBase_Platoon data)
        {
            m_dBManager.SQL(QuerySupport_User.UpdatePlatoon(data));
        }

        public bool IsMounted(UserDataBase_Equipment data)
        {
            var result = false;

            if (m_dBManager.ReadDataBase(UserDBManager.E_Table.TDoll, QuerySupport_User.SelectMountedCheck(data)).Count > 0)
                result = true;

            return result;
        }
    }
}
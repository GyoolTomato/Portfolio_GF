﻿using System;
using System.Collections.Generic;

namespace Assets.Common.DB.User
{
    public static class QuerySupport_User
    {
        public static string SelectTDoll_All = "SELECT * FROM TDoll";
        public static string SelectEquipment_All = "SELECT * FROM Equipment";
        public static string SelectWorkResource_All = "SELECT * FROM WorkResource";

        public static string SelectMountedCheck(UserDataBase_Equipment data)
        {
            var result = string.Empty;

            result = "SELECT * FROM TDoll WHERE"
                + " EquipmentOwnershipNumber0=" + data.OwnershipCode
                + " EquipmentOwnershipNumber1=" + data.OwnershipCode
                + " EquipmentOwnershipNumber2=" + data.OwnershipCode;

            return result;
        }

        public static List<string> InsertTDoll(List<UserDataBase_TDoll> data)
        {
            var temp = string.Empty;
            var result = new List<string>();

            foreach (var item in data)
            {
                temp = string.Empty;
                temp = "Insert Into TDoll(DataCode, Level, DummyLink, Platoon, EquipmentOwnerShipNumber0, EquipmentOwnerShipNumber1, EquipmentOwnerShipNumber2) VALUES("
                        + item.DataCode.ToString() + ", "
                        + item.Level.ToString() + ", "
                        + item.DummyLink.ToString() + ", "
                        + item.Platoon.ToString() + ", "
                        + item.EquipmentOwnershipNumber0.ToString() + ", "
                        + item.EquipmentOwnershipNumber1.ToString() + ", "
                        + item.EquipmentOwnershipNumber2.ToString()
                        + ")";

                result.Add(temp);
            }

            return result;
        }
        public static List<string> InsertEquipment(List<UserDataBase_Equipment> data)
        {
            var temp = string.Empty;
            var result = new List<string>();

            foreach (var item in data)
            {
                temp = string.Empty;
                temp = "INSERT INTO TDoll VALUES ("
                         + item.DataCode.ToString()
                         + item.Level.ToString()
                         + item.LimitedPower.ToString()
                         + ")";

                result.Add(temp);
            }

            return result;
        }

        public static List<string> DeleteTDoll(List<UserDataBase_TDoll> data)
        {
            var temp = string.Empty;
            var result = new List<string>();

            foreach (var item in data)
            {
                temp = string.Empty;
                temp = "DELETE FROM TDoll WHERE OwnershipCode = "
                         + item.OwnershipCode.ToString();

                result.Add(temp);
            }

            return result;
        }
        public static List<string> DeleteEquipment(List<UserDataBase_Equipment> data)
        {
            var temp = string.Empty;
            var result = new List<string>();

            foreach (var item in data)
            {
                temp = string.Empty;
                temp = "DELETE FROM Equipment WHERE OwnershipCode = "
                     + item.OwnershipCode.ToString();

                result.Add(temp);
            }

            return result;
        }

        public static string UpdateTDoll(UserDataBase_TDoll data)
        {
            var result = string.Empty;

            result = "UPDATE TDoll SET"
                    + "Level=" + data.Level
                    + "DummyLink=" + data.DummyLink
                    + "EquipmentOwnershipNumber0=" + data.EquipmentOwnershipNumber0
                    + "EquipmentOwnershipNumber1=" + data.EquipmentOwnershipNumber1
                    + "EquipmentOwnershipNumber2=" + data.EquipmentOwnershipNumber2
                    + " WHERE OwnershipCode = "
                    + data.OwnershipCode.ToString();

            return result;
        }
        public static string UpdateEquipment(UserDataBase_Equipment data)
        {
            var result = string.Empty;

            result = "UPDATE Equipment SET "
                    + "Level=" + data.Level
                    + ", LimitedPower=" + data.LimitedPower
                    + " WHERE OwnershipCode = "
                    + data.OwnershipCode.ToString();

            return result;
        }
        public static string UpdateWorkResource(Common.CommonDataBase_WorkResource data)
        {
            var result = string.Empty;

            result = "UPDATE WorkResource SET "
                      + "Amount=" + data.Value
                      + " WHERE Name = \'"
                      + data.Name + "\'";

            return result;
        }

        public static string InsertProduceTDoll(UserDataBase_Produce data)
        {
            var result = string.Empty;

            result = "INSERT INTO ProduceTDoll(Slot, Active, CompleteTime, DataCode) VALUES ("
                + data.Slot
                + data.Active
                + data.CompleteTime
                + data.DataCode
                + ")";

            return result;
        }

        public static string UpdateProduceTDoll(UserDataBase_Produce data)
        {
            var result = string.Empty;

            result = "UPDATE ProduceTDoll SET "                    
                    + ", CompleteTime=" + data.CompleteTime
                    + ", DataCode=" + data.DataCode
                    + " WHERE Slot = "
                    + data.Slot.ToString()
                    + " and "
                    + "Active = "
                    + true;

            return result;
        }
    }
}

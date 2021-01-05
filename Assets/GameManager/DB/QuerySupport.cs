using System;
public static class QuerySupport
{
    public static string SelectTDoll_All = "SELECT * FROM T-Doll";
    public static string SelectTDoll_Magician = "SELECT * FROM TDoll where Type = \'Magician\'";
    public static string SelectTDoll_Archer = "SELECT * FROM TDoll where Type = \'Archer\'";
    public static string SelectTDoll_Knight = "SELECT * FROM TDoll where Type = \'Knight\'";
    public static string SelectEquipment_All = "SELECT * FROM Equipment";
    public static string SelectEquipment_Weapon = "SELECT * FROM Equipment where Type = \'Weapon\'";
    public static string SelectEquipment_Armor = "SELECT * FROM Equipment where Type = \'Armor\'";
    public static string SelectEquipment_Tool = "SELECT * FROM Equipment where Type = \'Tool\'";
}

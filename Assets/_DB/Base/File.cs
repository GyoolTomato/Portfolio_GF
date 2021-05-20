using System;
using System.IO;
using UnityEngine;

namespace Assets.DB
{
    public static class DbFile
    {
        public static readonly string GameDBFileName = "Game.db";
        public static readonly string IndexDBFileName = "Index.db";
        public static readonly string UserDataDBFileName = "UserData.db";

        public static readonly string GameDBPath_Android = Path.Combine(Application.persistentDataPath, GameDBFileName);
        public static readonly string IndexDBPath_Android = Path.Combine(Application.persistentDataPath, IndexDBFileName);
        public static readonly string UserDataDBPath_Android = Path.Combine(Application.persistentDataPath, UserDataDBFileName);

        public static readonly string GameDBPath_PC = Path.Combine(Application.dataPath, GameDBFileName);
        public static readonly string IndexDBPath_PC = Path.Combine(Application.dataPath, IndexDBFileName);
        public static readonly string UserDataDBPath_PC = Path.Combine(Application.dataPath, UserDataDBFileName);
        
    }
}
using System;
using System.IO;

namespace Assets.DB
{
    public class Server
    {
        private static readonly string Url = "http://gyooltomato.ipdisk.co.kr:8000/list/Project_GF/";
        private static readonly string DbPath = Path.Combine(Url, "DB/");
        public static readonly string GameData = Path.Combine(DbPath, "Game.db");
        public static readonly string IndexData = Path.Combine(DbPath, "Index.db");
    }
}
using System;
using System.IO;

namespace Assets.DB.Base
{
    public static class Server
    {
        private static readonly string Url = "http://gyooltomato.ipdisk.co.kr:8000/list/HDD1/Project_GF/DB/";
        public static readonly Uri GameDBUrl = new Uri(Path.Combine(Url, DbFile.GameDBFileName));
        public static readonly Uri IndexDBUrl = new Uri(Path.Combine(Url, DbFile.IndexDBFileName));
    }
}
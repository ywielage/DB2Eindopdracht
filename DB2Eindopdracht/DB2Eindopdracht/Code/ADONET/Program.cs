using MongoDB.Driver;
using System;

namespace DB2Eindopdracht.ADO.NET
{
    public class Program
    {
        
        public static void Main(String[] args)
        {
            ADONET ado = new ADONET();
            ado.Run(1);
        }
    }
}

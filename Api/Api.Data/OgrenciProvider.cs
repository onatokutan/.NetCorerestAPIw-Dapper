using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Api.Data
{
    public class OgrenciProvider : IOgrenciProvider
    {
        private readonly string connectionString;

        public OgrenciProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Ogrenci> Get()
        {
            IEnumerable<Ogrenci> ogrenci = null;

            using (var connection = new SqlConnection(connectionString))
            {
                ogrenci = connection.Query<Ogrenci>("select id, Name as name, Surname as surname from Ogrenci");
            }

            return ogrenci;
        }
    }
}
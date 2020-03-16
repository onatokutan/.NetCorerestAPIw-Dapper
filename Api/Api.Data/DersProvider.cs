using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Api.Data
{
    public class DersProvider : IDersProvider
    {
        private readonly string connectionString;

        public DersProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Ders> Get()
        {
            IEnumerable<Ders> ders = null;

            using (var connection = new SqlConnection(connectionString))
            {
                ders = connection.Query<Ders>("select id, Name as name , Description as descript from Ders");
            }

            return ders;
        }
    }
}
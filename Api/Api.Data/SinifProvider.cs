using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Api.Data
{
    public class SinifProvider : ISinifProvider
    {
        private readonly string connectionString;

        public SinifProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Sinif> Get()
        {
            IEnumerable<Sinif> sinif = null;

            using (var connection = new SqlConnection(connectionString))
            {
                sinif = connection.Query<Sinif>("select id, Name as name from Sinif");
            }

            return sinif;
        }
    }
}
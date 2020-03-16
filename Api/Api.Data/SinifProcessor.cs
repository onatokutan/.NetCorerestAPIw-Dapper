using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Api.Data
{
    public class SinifProcessor : ISinifProcessor
    {
        private readonly string connectionString;

        public SinifProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void EkleSinif(Sinif sinif)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("INSERT INTO Sinif (Name) VALUES (@name)",
                    new { sinif.name });
            }
        }
        public void SilSinif(int sinifid)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("DELETE FROM Sinif WHERE Id=@id",
                    new { id = sinifid });
            }
        }
        public void GuncelleSinif(Sinif sinif)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("UPDATE Sinif SET Name =@name WHERE Id=@id",
                    new { sinif.name, sinif.id });
            }
        }
    }
}

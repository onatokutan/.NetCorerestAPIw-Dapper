using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Api.Data
{
    public class DersProcessor : IDersProcessor
    {
        private readonly string connectionString;

        public DersProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int EkleDers(Ders ders)
        {
            var con = new SqlConnection(connectionString);

                return con.Query<int>(@"INSERT INTO Ders (Name, Description) VALUES (@name, @descript) 
SELECT @@IDENTITY",
                    new { ders.name, ders.descript }).First();
            
        }
        public void SilDers(int dersid)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("DELETE FROM Ders WHERE Id=@id DELETE FROM DersSinif WHERE FK_Ders = @id",
                    new { id = dersid });
            }
        }
        public void GuncelleDers(Ders ders)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("UPDATE Ders SET Name =@name, Description =@descript WHERE Id=@id",
                    new { ders.name, ders.descript, ders.id });
            }
        }

        public void DersSinifEkle(int dersId, Ders temp)
        {
            string sql =@"";
            using (var con = new SqlConnection(connectionString))
            {
                foreach (var item in temp.sinifId)
	            {
                    sql += "INSERT INTO DersSinif (FK_Ders, FK_Sinif) VALUES("+ dersId+","+item+") ";
	            }
                con.Execute(sql);
            }
        }
    }
}

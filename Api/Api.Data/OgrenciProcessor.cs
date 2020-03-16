using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Api.Data
{
    public class OgrenciProcessor : IOgrenciProcessor
    {
        private readonly string connectionString;

        public OgrenciProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int EkleOgrenci(Ogrenci ogrenci)
        {
            var con = new SqlConnection(connectionString);

            return con.Query<int>(@"INSERT INTO Ogrenci (Name, Surname) VALUES (@name, @surname) 
SELECT @@IDENTITY",
                new { ogrenci.name, ogrenci.surname }).First();

        }
        public void SilOgrenci(int ogrencid)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("DELETE FROM Ogrenci WHERE Id=@id DELETE FROM OgrenciDers WHERE FK_Ders = @id",
                    new { id = ogrencid });
            }
        }
        public void GuncelleOgrenci(Ogrenci ogrenci)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute("UPDATE Ogrenci SET Name =@name, Surname =@surname WHERE Id=@id",
                    new { ogrenci.name, ogrenci.surname, ogrenci.id });
            }
        }

        public void OgrenciDersEkle(int ogrencid, Ogrenci temp)
        {
            string sql = @"";
            using (var con = new SqlConnection(connectionString))
            {
                foreach (var item in temp.dersId)
                {
                    sql += "INSERT INTO OgrencıDers (FK_Ogr, FK_Ders) VALUES(" + ogrencid + "," + item + ") ";
                }
                con.Execute(sql);
            }



        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pokladna
{
    public class SqlRepos : IRepos
    {
        private string sqlConnectionText = ("Data Source=82.117.153.236,50010;Initial Catalog=pokladnizaznamSima;User ID=sa;Password=Nejlepsiserver123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public List<PoklZaznam> Nacti(int rok, int mesic)
        {
            List<PoklZaznam> result = new List<PoklZaznam>();
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionText))
            {
                string dotaz = $"select * from PokladniZaznamy where YEAR(Datum)={rok} and MONTH(Datum)={mesic} order by Datum";
                using (SqlCommand sqlCommand = new SqlCommand(dotaz, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result.Add(new PoklZaznam(Convert.ToInt32(dataReader["IdPokladniZaznam"])
                                                        , Convert.ToInt32(dataReader["Cislo"])
                                                        , Convert.ToDateTime(dataReader["Datum"])
                                                        , dataReader["Popis"].ToString()
                                                        , Convert.ToDouble(dataReader["Castka"])
                                                        , Convert.ToDouble(dataReader["Zustatek"])
                                                        , dataReader["Poznamka"].ToString()));
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return result;
        }

        public void VytvorTestData(List<PoklZaznam> vychozizaznam)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionText))
            {
                string dotaz = "DROP table if exists [Pokladnizaznam]; CREATE TABLE [dbo].[Pokladnizaznam]( [IdPokladniZaznam] INT NOT NULL PRIMARY KEY identity(1,1),"
                    + "[Cislo] int NOT NULL,[Datum] datetime NOT NULL,	[Popis] varchar(250) NOT NULL,   "
                    + " [Poznamka] varchar(250) NOT NULL,[Castka] float NOT NULL,[Zustatek] float NOT NULL,);";
                foreach (var z in vychozizaznam)
                {
                    dotaz += $"insert into Pokladnizaznam(Cislo,Datum,Popis,Castka,Zustatek,Poznamka)" + $"values({z.cislo},'{z.datum.ToString("yyyyMMdd")}','{z.popis}',{z.castka},{z.zustatek},'{z.poznamka}');";
                }
                using (SqlCommand sqlCommand = new SqlCommand(dotaz, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public List<PoklZaznam> NactiVse()
        {
            List<PoklZaznam> result = new List<PoklZaznam>();
            result.Add(new PoklZaznam(DateTime.Now, "wad", 10, "wd"));
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionText))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select * from Pokladnizaznam", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            result.Add(new PoklZaznam(Convert.ToInt32(dataReader["IdPokladniZaznam"]),
                                Convert.ToInt32(dataReader["Cislo"]),
                                Convert.ToDateTime(dataReader["Datum"]),
                                dataReader["Popis"].ToString(),
                                Convert.ToDouble(dataReader["Castka"]),
                                Convert.ToDouble(dataReader["Zustatek"]),
                                dataReader["Poznamka"].ToString()));
                        }
                    }
                    sqlConnection.Close();
                }
            }
            VytvorTestData(result);
            return result;
        }

        public PoklZaznam NactiZaznam(int idPokladniZaznam)
        {
            throw new NotImplementedException();
        }

        public void SmazZaznam(PoklZaznam poklZaznam)
        {
            throw new NotImplementedException();
            List<PoklZaznam> result = new List<PoklZaznam>();
            result.Add(new PoklZaznam(DateTime.Now, "wad", 10, "wd"));
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionText))
            {
                using (SqlCommand sqlCommand = new SqlCommand("update * from Pokladnizaznam", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            VytvorTestData(result);
        }

        public void UpravZaznam(PoklZaznam poklZaznam)
        {
            List<PoklZaznam> result = new List<PoklZaznam>();
            result.Add(new PoklZaznam(DateTime.Now, "wad", 10, "wd"));
            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionText))
            {
                using (SqlCommand sqlCommand = new SqlCommand("update * from Pokladnizaznam", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            VytvorTestData(result);
        }

        public PoklZaznam VytvorZaznam(PoklZaznam pokladniZaznam)
        {
            throw new NotImplementedException();
        }
    }
}
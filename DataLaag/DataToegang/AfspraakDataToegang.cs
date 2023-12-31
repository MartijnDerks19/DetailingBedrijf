﻿using System.Configuration;
using System.Runtime.CompilerServices;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace DataLaag.DataToegang 
{
    public class AfspraakDataToegang : IAfspraak
    {
        private string _connectionString;
        private IConfiguration _configuration;


        public AfspraakDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
        }

        public List<AfspraakDTO> AllesOphalen()
        {
            List<AfspraakDTO> lijstVanAfspraken = new List<AfspraakDTO>();
            string query = "SELECT * FROM dbi495061.afspraak ORDER BY DatumEnTijd";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var afspraak = new AfspraakDTO()
                        {
                            AfspraakID = reader.GetInt32(0),
                            DetailerID = reader.GetInt32(1),
                            AutoID = reader.GetInt32(2),
                            DatumEnTijd = reader.GetDateTime(3),
                        };
                        lijstVanAfspraken.Add(afspraak);
                    }
                }
                connection.Close();
            }
            return lijstVanAfspraken;
        }

        public AfspraakDTO OphalenOpID(int id)
        {
            AfspraakDTO afspraak = new AfspraakDTO();
            string query = "SELECT * FROM dbi495061.afspraak WHERE AfspraakID = @AfspraakID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@AfspraakID", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        afspraak.DetailerID = reader.GetInt32(0);
                        afspraak.AutoID = reader.GetInt32(1);
                        afspraak.AfspraakID = reader.GetInt32(2);
                        afspraak.DatumEnTijd = reader.GetDateTime(3);
                    }
                }
                connection.Close();
            }
            return afspraak;
        }

        public void Aanmaken(AfspraakDTO afspraak)
        {
            string query = "INSERT INTO dbi495061.afspraak (DetailerID, AutoID, DatumEnTijd) VALUES (@DetailerID, @AutoID, @DatumEnTijd)";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int32, 255).Value = afspraak.DetailerID;
                    cmd.Parameters.Add("@AutoID", MySqlDbType.Int32, 255).Value = afspraak.AutoID;
                    cmd.Parameters.Add("@DatumEnTijd", MySqlDbType.DateTime, 255).Value = afspraak.DatumEnTijd;

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void VerwijderenOpID(int id)
        {
            using (MySqlConnection connectie = new(_connectionString))
            {
                connectie.Open();
                using (MySqlCommand cmd = new("DELETE FROM dbi495061.afspraak WHERE AfspraakID = @AfspraakID", connectie))
                {
                    cmd.Parameters.Add("@AfspraakID", MySqlDbType.Int64, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connectie.Close();
            }
        }

        public void AanpassenOpID(int id, AfspraakDTO afspraak)
        {
            string query = "UPDATE dbi495061.afspraak SET (DetailerID, AutoID, DatumEnTijd) VALUES (@DetailerID, @AutoID, @DatumEnTijd) WHERE AfspraakID = @AfspraakID";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int32, 255).Value = afspraak.DetailerID;
                    cmd.Parameters.Add("@AutoID", MySqlDbType.String, 255).Value = afspraak.AutoID;
                    cmd.Parameters.Add("@DatumEnTijd", MySqlDbType.DateTime, 255).Value = afspraak.DatumEnTijd;
                    cmd.Parameters.Add("@AfspraakID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<AutoDTO> AutosOphalenVoorEigenaar(int eigenaarID)
        {
            throw new NotImplementedException();
        }
    }
}

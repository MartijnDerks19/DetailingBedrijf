﻿using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.DataToegang
{
    public class AfspraakDataToegang
    {
        private IConfiguration _configuration;
        private string _connectionString;
        public AfspraakDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
            _connectionString = connectionString;
        }

        public List<AfspraakDTO> AlleAfsprakenOphalen()
        {
            List<AfspraakDTO> lijstVanAfspraken = new List<AfspraakDTO>();
            string query = "SELECT * FROM detailer";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var detailer = new DetailerDTO()
                        {
                            DetailerID = reader.GetInt32(0),
                            Naam = reader.GetString(1),
                        };
                        lijstVanAfspraken.Add(detailer);
                    }
                }
                connection.Close();
            }
            return lijstVanAfspraken;
        }

        public AfspraakDTO AfspraakOphalenOpID(int id)
        {
            DetailerDTO detailer = new DetailerDTO();
            string query = "SELECT * FROM detailer WHERE DetailerID = @DetailerID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int64, 255).Value = id;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        detailer.DetailerID = reader.GetInt32(0);
                        detailer.Naam = reader.GetString(1);
                    }
                }
                connection.Close();
            }
            return detailer;
        }

        public void AfspraakToevoegen(DetailerDTO detailer)
        {
            string query = "INSERT INTO detailer (Naam) VALUES (@Naam)";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Naam", MySqlDbType.Enum, 255).Value = detailer.Naam;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void VerwijderAfspraakOpID(int id)
        {
            using (MySqlConnection connectie = new(_connectionString))
            {
                connectie.Open();
                using (MySqlCommand cmd = new("DELETE FROM detailer WHERE DetailerID = @DetailerID", connectie))
                {
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int64, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connectie.Close();
            }
        }
    }
}

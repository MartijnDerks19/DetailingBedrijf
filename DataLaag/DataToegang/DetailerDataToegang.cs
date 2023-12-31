﻿using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.DataToegang
{
    public class DetailerDataToegang : IDetailer
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public DetailerDataToegang(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionSettings")["ConnectionString"];
        }

        public List<DetailerDTO> AllesOphalen()
        {
            List<DetailerDTO> lijstVanDetailers = new List<DetailerDTO>();
            string query = "SELECT * FROM detailer ORDER BY Naam";
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
                        lijstVanDetailers.Add(detailer);
                    }
                }
                connection.Close();
            }
            return lijstVanDetailers;
        }

        public DetailerDTO OphalenOpID(int id)
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

        public List<AfspraakDTO> AllesOphalenVoorDetailer(int detailerID)
        {
            List<AfspraakDTO> lijstVanAfspraken = new List<AfspraakDTO>();
            string query = "SELECT * FROM afspraak WHERE DetailerID = @DetailerID";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int64, 255).Value = detailerID;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var afspraak = new AfspraakDTO()
                        {
                            AfspraakID = reader.GetInt32(0),
                            AutoID = reader.GetInt32(1),
                            DetailerID = reader.GetInt32(2),
                            DatumEnTijd = (DateTime)reader.GetMySqlDateTime(3),
                        };
                        lijstVanAfspraken.Add(afspraak);
                    }
                }
                connection.Close();
            }
            return lijstVanAfspraken;
        }

        public void Aanmaken(DetailerDTO detailer)
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

        public void VerwijderenOpID(int id)
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

        public void AanpassenOpID(int id, DetailerDTO detailer)
        {
            string query = "UPDATE dbi495061.detailer (Naam) VALUES (@Naam) WHERE DetailerID = @DetailerID";

            using (MySqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Naam", MySqlDbType.String, 255).Value = detailer.Naam;
                    cmd.Parameters.Add("@DetailerID", MySqlDbType.Int32, 255).Value = id;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}

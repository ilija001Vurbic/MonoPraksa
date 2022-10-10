using CarDealership.Model;
using CarDealership.Model.Common;
using CarDealership.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repository
{
    public class CarRepository: ICarRepository
    {
        string connString = @"Server=ST-01;Initial Catalog=master;Trusted_connection=true;";
        public async Task<List<CarManufacturer>> GetAllManufacturers()
        {
            List<CarManufacturer> manufacturers = new List<CarManufacturer>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarManufacturer", con))
                { 
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            manufacturers.Add(new CarManufacturer
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Name = sdr["manufacturer"].ToString(),
                                Country = sdr["country"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return manufacturers;
                }
            }
        }
        public async Task<CarManufacturer> GetManufacturerById(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarManufacturer WHERE id=@id", con))
                {
                    CarManufacturer manufacturer = new CarManufacturer();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            manufacturer=new CarManufacturer
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Name = sdr["manufacturer"].ToString(),
                                Country = sdr["country"].ToString()
                            };
                        }
                    }
                    con.Close();
                    return manufacturer;
                }
            }
        }

        public async Task<CarManufacturer> PostCarManufacturer(CarManufacturer manufacturer)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CarManufacturer VALUES (@id,@manufacturer,@country)", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{manufacturer.Id}");
                    cmd.Parameters.AddWithValue("@manufacturer", $"{manufacturer.Name}");
                    cmd.Parameters.AddWithValue("@country", $"{manufacturer.Country}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return manufacturer;
                }
            }
        }
        
        public async Task<CarManufacturer> PutCarManufacturer(int id, CarManufacturer manufacturer)
        {
            id = manufacturer.Id;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE CarManufacturer SET manufacturer=@manufactuerer,country=@country WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{id}");
                    cmd.Parameters.AddWithValue("@manufacturer", $"{manufacturer.Name}");
                    cmd.Parameters.AddWithValue("@country", $"{manufacturer.Country}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return manufacturer;
                }
            }
        }
        
        public async Task DeleteCarManufacturer(CarManufacturer manufacturer)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM CarManufacturer WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{manufacturer.Id}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        
    }
}

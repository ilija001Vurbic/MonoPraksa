using CarDealership.Model;
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
        List<CarManufacturer> manufacturers = new List<CarManufacturer>();
        public List<CarManufacturer> GetAllManufacturers()
        {
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
        public CarManufacturer GetManufacturerById(int id)
        {
            CarManufacturer manufacturer = new CarManufacturer();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarManufacturer WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{manufacturer.Id}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return manufacturer;
                }
            }
        }

        public CarManufacturer PostCarManufacturer(CarManufacturer manufacturer)
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
        
        public CarManufacturer PutCarManufacturer(int id, CarManufacturer manufacturer)
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
        
        public void DeleteCarManufacturer(CarManufacturer manufacturer)
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

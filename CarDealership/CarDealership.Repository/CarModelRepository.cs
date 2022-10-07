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
    public class CarModelRepository : ICarModelRepositoryCommon
    {
        string connString = @"Server=ST-01;Initial Catalog=master;Trusted_connection=true;";
        public List<CarModel> GetAllModels()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarModel", con))
                {
                    List<CarModel> models = new List<CarModel>();
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            models.Add(new CarModel
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                ManufacturerId = Convert.ToInt32(sdr["manufacturerId"]),
                                Model = sdr["model"].ToString(),
                                Engine = sdr["engine"].ToString(),
                                Price = Convert.ToInt32(sdr["price"]),
                                BodyType = sdr["bodyType"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return models;
                }
            }
        }
        public CarModel GetModelById(int id)
        {
            CarModel model = new CarModel();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarModel WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{model.Id}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return model;
                }
            }
        }
        public CarModel PostCarModel(CarModel model)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CarModel VALUES (@id,@manufacturerId,@model,@engine,@price,@bodyType)", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{model.Id}");
                    cmd.Parameters.AddWithValue("@manufacturerId", $"{model.ManufacturerId}");
                    cmd.Parameters.AddWithValue("@model", $"{model.Model}");
                    cmd.Parameters.AddWithValue("@engine", $"{model.Engine}");
                    cmd.Parameters.AddWithValue("@price", $"{model.Price}");
                    cmd.Parameters.AddWithValue("@bodyType", $"{model.BodyType}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return model;
                }
            }
        }
        public CarModel PutCarModel(int id, CarModel model)
        {
            id = model.Id;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE CarModel SET manufacturerId=@manufacturerId,model=@model,engine=@engine,price=@price,bodyType=@bodyType WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{id}");
                    cmd.Parameters.AddWithValue("@manufacturerId", $"{model.ManufacturerId}");
                    cmd.Parameters.AddWithValue("@model", $"{model.Model}");
                    cmd.Parameters.AddWithValue("@engine", $"{model.Engine}");
                    cmd.Parameters.AddWithValue("@price", $"{model.Price}");
                    cmd.Parameters.AddWithValue("@bodyType", $"{model.BodyType}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return model;
                }
            }
        }
        public void DeleteCarModel(CarModel model)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM CarModel WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{model.Id}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();                
                }
            }
        }
    }
}

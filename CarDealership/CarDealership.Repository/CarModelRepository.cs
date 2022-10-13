using CarDealership.Common;
using CarDealership.Model;
using CarDealership.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repository
{
    public class CarModelRepository : ICarModelRepositoryCommon
    {
        string connString = @"Server=ST-01;Initial Catalog=master;Trusted_connection=true;";
        
        public async Task<List<CarModel>> GetAllModels(Paging paging, Sorting sorting, Filtering filtering)
        {
            StringBuilder queryBuilder = new StringBuilder();
            using (SqlConnection con = new SqlConnection(connString))
            {
                queryBuilder.Append("SELECT * FROM CarModel ");
                SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con);
                if (filtering.MadeBefore != null || filtering.MadeAfter != null || filtering.HasBodyType == true)
                {
                    queryBuilder.AppendLine("WHERE dateOfManufacturing < " + filtering.MadeBefore +" ");
                }
                if (sorting.SortBy == "Model")
                {
                    queryBuilder.AppendLine(" ORDER BY model ");
                }
                if (sorting.SortOrder == "asc")
                {
                    queryBuilder.AppendLine(" ASC;");
                }
                if (sorting.SortOrder == "desc")
                {
                    queryBuilder.AppendLine(" DESC;");
                }

                int offset = (paging.PageNumber - 1) * paging.PageSize;

                if(paging.PageNumber!=0 || paging.PageSize!=0)
                {
                queryBuilder.Append(" ORDER BY id ASC ");
                queryBuilder.Append(" OFFSET " + offset + " ROWS ");
                queryBuilder.AppendLine(" FETCH NEXT " + paging.PageSize + " ROWS ONLY;");
                }
                using (cmd)
                {

                    List<CarModel> models = new List<CarModel>();
                    cmd.CommandText = queryBuilder.ToString();
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
        public async Task<CarModel> GetModelById(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CarModel WHERE id=@id", con))
                {
                    CarModel model = new CarModel();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            model=new CarModel
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                ManufacturerId = Convert.ToInt32(sdr["manufacturerId"]),
                                Model = sdr["model"].ToString(),
                                Engine = sdr["engine"].ToString(),
                                Price = Convert.ToInt32(sdr["price"]),
                                BodyType = sdr["bodyType"].ToString(),
                            };
                        }
                    }
                    con.Close();
                    return model;
                }
            }
        }
        public async Task<CarModel> PostCarModel(CarModelRest modelRest)
        {
            CarModel model = new CarModel(modelRest.Id,modelRest.ManufacturerId,modelRest.Model,modelRest.Engine,modelRest.Price,null,modelRest.ManufacturingDate);
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CarModel VALUES (@id,@manufacturerId,@model,@engine,@price,@dateOfManufacturing)", con))
                {
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.Parameters.AddWithValue("@manufacturerId", model.ManufacturerId);
                    cmd.Parameters.AddWithValue("@model", model.Model);
                    cmd.Parameters.AddWithValue("@engine", model.Engine);
                    cmd.Parameters.AddWithValue("@price", model.Price);
                    cmd.Parameters.AddWithValue("@dateOfManufacturing", model.ManufacturingDate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return model;
                }
            }
        }
        public async Task<CarModel> PutCarModel(int id, CarModel model)
        {
            id = model.Id;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE CarModel SET manufacturerId=@manufacturerId,model=@model,engine=@engine,price=@price,bodyType=@bodyType WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@manufacturerId", model.ManufacturerId);
                    cmd.Parameters.AddWithValue("@model", model.Model);
                    cmd.Parameters.AddWithValue("@engine",model.Engine);
                    cmd.Parameters.AddWithValue("@price",model.Price);
                    cmd.Parameters.AddWithValue("@bodyType", model.BodyType);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return model;
                }
            }
        }
        public async Task DeleteCarModel(CarModel model)
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
        //private void Sort(IEnumerable<CarModel> models, string orderByQueryString)
        //{
        //    if (!models.Any())
        //        return;
        //    if(string.IsNullOrWhiteSpace(orderByQueryString))
        //    {
        //        models = models.OrderBy(c => c.Model);
        //        return;
        //    }
        //    var modelParams = orderByQueryString.Trim().Split(',');
        //    var propInfos = typeof(CarModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var orderQueryBuilder = new StringBuilder();
        //    foreach(var param in modelParams)
        //    {
        //        if (string.IsNullOrWhiteSpace(param))
        //            continue;
        //        var propFromQueryName = param.Split(' ')[0];
        //        var objectProperty = propInfos.FirstOrDefault(pi => pi.Name.Equals(propFromQueryName, StringComparison.InvariantCultureIgnoreCase));
        //        if (objectProperty == null)
        //            continue;
        //        var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
        //        orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder},");
        //    }
        //    var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        //    if (string.IsNullOrWhiteSpace(orderQuery))
        //    {
        //        models = models.OrderBy(c => c.Model);
        //        return;
        //    }
        //    models = models.OrderBy(orderQuery);
        //}
    }
}

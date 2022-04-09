using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ShopClothes.Models;

namespace ShopClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select ID, NAME,PRICE,ORI_PRICE,HOTPRODUCT,CREATEBY,CREATEAT,UPDATEBY,UPDATEAT,DESCRIPTION,IMAGE,COMPANY,IDCATEGORY,SEX from dbo.PRODUCTS";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ShopClothes");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(PRODUCT prod)
        {
            string query = @"
                    insert into dbo.PRODUCTS (NAME,PRICE,ORI_PRICE,CREATEBY,CREATEAT,UPDATEBY,UPDATEAT,DESCRIPTION,IMAGE,COMPANY,IDCATEGORY,SEX) values 
                    (@NAME,@PRICE,@ORI_PRICE,@CREATEBY,@CREATEAT,@UPDATEBY,@UPDATEAT,@DESCRIPTION,@IMAGE,@COMPANY,@IDCATEGORY,@SEX)
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ShopClothes");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@NAME", prod.NAME);
                    myCommand.Parameters.AddWithValue("@CREATEAT", prod.CREATEAT);
                    myCommand.Parameters.AddWithValue("@CREATEBY", prod.CREATEBY ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@UPDATEBY", prod.UPDATEBY ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@UPDATEAT", prod.UPDATEAT);
                    myCommand.Parameters.AddWithValue("@PRICE", prod.PRICE);
                    myCommand.Parameters.AddWithValue("@ORI_PRICE", prod.ORI_PRICE);
                    myCommand.Parameters.AddWithValue("@DESCRIPTION", prod.DESCRIPTION);
                    myCommand.Parameters.AddWithValue("@IMAGE", prod.IMAGE ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@COMPANY", prod.COMPANY);
                    myCommand.Parameters.AddWithValue("@IDCATEGORY", prod.IDCATEGORY);
                    myCommand.Parameters.AddWithValue("@SEX", prod.SEX);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(PRODUCT prod)
        {
         //   NAME,PRICE,ORI_PRICE,CREATEBY,CREATEAT,UPDATEBY,UPDATEAT,DESCRIPTION,IMAGE,COMPANY,IDCATEGORY,SEX
            string query = @"
                           update dbo.CATEGORIES
                           set NAME = @NAME,
                                PRICE=@PRICE,
                                ORI_PRICE=@ORI_PRICE,
                                DESCRIPTION=@DESCRIPTION,
                                IMAGE=@IMAGE,
                                COMPANY=@COMPANY,
                                IDCATEGORY=@IDCATEGORY,
                                SEX=@SEX,
                            CREATEBY = @CREATEBY,
                            CREATEAT = @CREATEAT,
                            UPDATEBY = @UPDATEBY,
                            UPDATEAT = @UPDATEAT
                            where ID = @ID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ShopClothes");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID", prod.ID);
                    myCommand.Parameters.AddWithValue("@NAME", prod.NAME);
                    myCommand.Parameters.AddWithValue("@CREATEAT", prod.CREATEAT);
                    myCommand.Parameters.AddWithValue("@CREATEBY", prod.CREATEBY ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@UPDATEBY", prod.UPDATEBY ?? (object)DBNull.Value);
                    myCommand.Parameters.AddWithValue("@UPDATEAT", prod.UPDATEAT);
                    myCommand.Parameters.AddWithValue("@PRICE", prod.PRICE);
                    myCommand.Parameters.AddWithValue("@ORI_PRICE", prod.ORI_PRICE);
                    myCommand.Parameters.AddWithValue("@DESCRIPTION", prod.DESCRIPTION);
                    myCommand.Parameters.AddWithValue("@IMAGE", prod.IMAGE ?? (object)DBNull.Value) ;
                    myCommand.Parameters.AddWithValue("@COMPANY", prod.COMPANY);
                    myCommand.Parameters.AddWithValue("@IDCATEGORY", prod.IDCATEGORY);
                    myCommand.Parameters.AddWithValue("@SEX", prod.SEX);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.PRODUCTS
                            where ID=@ID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ShopClothes");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}

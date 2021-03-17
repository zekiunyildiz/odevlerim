using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDapperCRUD.Models
{
    public class ProductRepo
    {
        private string connectionString;
        public ProductRepo()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;integrated security=true";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        // Burada sqlQuery değişkenine @ başlayan kısma SQL kodumuzu yazarız, parametreleri birebir aynı olmak zorundadır.

        public void Add(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                    string sqlQuery = @"INSERT INTO Products (ProductName,QuantityPerUnit,UnitPrice) VALUES(@ProductName,@QuantityPerUnit,@UnitPrice)";
                    dbConnection.Execute(sqlQuery, new
                    {
                        ProductName = "Laptop",
                        QuantityPerUnit = 25,
                        UnitPrice = 15

                    });

                }
            }
        }
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    string sqlQuery = @"Select * FROM Products";
                    if (dbConnection.State != ConnectionState.Open)
                        dbConnection.Open();
                    var reader = dbConnection.ExecuteReader(sqlQuery);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    
                }
                
                
            }
            
            
        }
        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"Select * FROM Products Where ProductId=@Id";
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                return dbConnection.Query<Product>(sqlQuery, new { Id = id }).FirstOrDefault();
            }
        }
        // Query ile oluşturulmuş bir veriyi database'den silebiliriz
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"DELETE FROM Products Where ProductId=@Id";
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                //Kullanicidan alinacak olan id ye gore silme islemi yapacagim.
                dbConnection.Execute(sqlQuery, new { Id = id });
            }
        }
        //Obje üzerinden bir update işlemi yapıyor.
        public void Update(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"UPDATE Products SET ProductName=@ProductName,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice Where ProductId=@ProductId";
                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                dbConnection.Execute(sqlQuery, new { Id=2 });
            }
        }
        public void SPInsert(Product product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                DynamicParameters parm = new DynamicParameters();

                parm.Add("@ProductName", product.ProductName);
                parm.Add("@QuantityPerUnit", product.QuantityPerUnit);
                parm.Add("@UnitPrice", product.UnitPrice);

                if (dbConnection.State != ConnectionState.Open)
                    dbConnection.Open();
                dbConnection.Execute("AddSPInsert", parm, commandType: CommandType.StoredProcedure);
                dbConnection.Close();


            }
        }

    }
}

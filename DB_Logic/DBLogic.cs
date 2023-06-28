using NutriAppyWPF2.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAppyWPF2.DB_Logic
{
    internal class DBLogic
    {
        /// <summary>
        /// Queries
        /// </summary>
        private const string querySelectAllProductsPossible = "SELECT Product.Id, Nutrient.Name, AmountsPerProduct.AmountLeft, Nutrient.Unit" +
            " FROM (AmountsPerProduct " +
            "INNER JOIN Nutrient on AmountsPerProduct.LeftId = Nutrient.Id)" +
            "INNER JOIN Product on AmountsPerProduct.RightId = Product.Id";
        private const string querySelectFirstProduct = "SELECT Product.Id, Product.Name, Product.Description" +
            " FROM (AmountsPerProduct " +
            "INNER JOIN Nutrient on AmountsPerProduct.LeftId = Nutrient.Id)" +
            "INNER JOIN Product on AmountsPerProduct.RightId = Product.Id";
        private const string querySelectProductIds = "SELECT DISTINCT Product.Id FROM (Product INNER JOIN AmountsPerProduct on AmountsPerProduct.RightId = Product.Id)";
        private const string tmpQr = "SELECT * FROM AmountsPerProduct";//For testing
        public DBLogic() { }

        
        private SQLiteConnection connection = new SQLiteConnection("Data Source = DB_Logic\\FoodDB.db");

        /// <summary>
        /// Get IDs of all prerecorded products
        /// </summary>
        /// <returns>List of product ids</returns>
        public List<int> ReadAllProductIds()
        {
            List<int> prodIds = new(); 
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(querySelectProductIds, connection);
                var reader = command.ExecuteReader();
                //prodIds
                while (reader.Read())
                {
                    prodIds.Add(reader.GetInt32(0));
                }

            }
            catch (Exception ex)
            {
                //Logging to be added
            }
            finally { connection.Close(); }

            return prodIds;
        }

        /// <summary>
        /// Get product with an exact ID
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>Product object</returns>
        private Product GetProductInfoById(int id)
        {
            connection.Open();

            SQLiteCommand commandForNutrientValues = new SQLiteCommand(querySelectAllProductsPossible + " WHERE Product.Id == " + id, connection);

            SQLiteCommand commandForName = new SQLiteCommand(querySelectFirstProduct + " WHERE Product.Id == " + id + " LIMIT 1", connection);
            try
            {
                var reader = commandForName.ExecuteReader();
                Product newProduct = new();
                while (reader.Read())
                {
                    var idvar = reader.GetValue(0);
                    var name = reader.GetString(1);
                    var desc = reader.GetString(2);
                    newProduct = new Product(name, desc);
                }
                reader = commandForNutrientValues.ExecuteReader();
                while (reader.Read())
                {
                    string nutrientName = reader.GetString(1);
                    decimal amountPerProduct = reader.GetDecimal(2);
                    string unit = reader.GetString(3);
                    newProduct.addNutrient(new Nutrient(nutrientName, amountPerProduct, unit));

                }
                connection.Close();
                return newProduct;
            }
            catch (Exception ex)
            {
                //Logging to be implemented
            }
            return null;
        }
        
        /// <summary>
        /// For future usage
        /// </summary>
        public void ReadAllProds()
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(querySelectAllProductsPossible, connection);

            var reader = command.ExecuteReader();

            List<string> strings = new List<string>();

            while (reader.Read())
            {
                var idvar = reader.GetValue(0);
                var a = reader.GetValue(1);
                var b = reader.GetValue(2);
                var c = reader.GetValue(3);
                var d = reader.GetValue(4);
            }
            connection.Close();
        }

        /// <summary>
        /// Get all prerecorded products
        /// </summary>
        /// <returns>products</returns>
        public List<Product> ReadAllPossibleProducts()
        {
            List<Product> products = new List<Product>();
            List<int> prodIds = new();
            prodIds = ReadAllProductIds();
            prodIds.ForEach(id => { products.Add(GetProductInfoById(id)); });

            return products;
        }
    }

}

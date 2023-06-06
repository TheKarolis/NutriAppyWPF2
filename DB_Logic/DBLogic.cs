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
        private const string querySelectAllProductsPossible = "SELECT Product.Name, Nutrient.Name, AmountsPerProduct.AmountLeft, Nutrient.Unit" +
            " FROM (AmountsPerProduct " +
            "INNER JOIN Nutrient on AmountsPerProduct.LeftId = Nutrient.Id)" +
            "INNER JOIN Product on AmountsPerProduct.RightId = Product.Id";
        private const string querySelectProductIds = "SELECT Product.Id FROM Product";
        private const string tmpQr = "SELECT * FROM AmountsPerProduct";//For testing
        public DBLogic() { }

        private List<int> prodIds = new(); 
        private SQLiteConnection connection = new SQLiteConnection("Data Source = DB_Logic\\FoodDB.db");

        public void ReadAllProductIds()
        {
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

            }
            finally { connection.Close(); }

        }

        
        public void ReadAllProds()
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(querySelectAllProductsPossible, connection);

            var reader = command.ExecuteReader();

            List<string> strings = new List<string>();

            while (reader.Read())
            {
                var a = reader.GetValue(1);
                var b = reader.GetValue(2);
                var c = reader.GetValue(3);
                var d = reader.GetValue(4);
                var e = reader.GetValue(5);
                var f = reader.GetValue(6);
                //strings.Add(reader.GetValue(1));
            }
            connection.Close();
        }



    }

}

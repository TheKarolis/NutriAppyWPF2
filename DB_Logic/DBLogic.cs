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
        private const string querySelectAllProductsPossible = "SELECT AmountsPerProduct.AmountLeft, Nutrient.Name, Product.Name" +
            " FROM (AmountsPerProduct " +
            "INNER JOIN Nutrient on AmountsPerProduct.LeftId = Nutrient.Id)" +
            "INNER JOIN Product on AmountsPerProduct.RightId = Product.Id";
        private const string tmpQr = "SELECT * FROM AmountsPerProduct";
        public DBLogic() { }
        
        public void readAllProds()
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source = DB_Logic\\FoodDB.db");
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

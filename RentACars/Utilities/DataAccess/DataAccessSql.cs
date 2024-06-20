using Microsoft.Data.SqlClient;
using Microsoft.Maui.Graphics;
using RentACars.Auto;
using RentACars.Utilities.DataAccess.Files;
using RentACars.Utilities.Interfaces;


namespace RentACars.Utilities.DataAccess
{
    public class DataAccessSql : DataAccess, IDataAccess
    {
        public DataAccessSql(DataFilesManager dfm, IAlertService alertService) : base(dfm, alertService)
        {
            try
            {
                AccessPath = DataFilesManager.DataFiles.GetValueByCodeFunction("CONNECTION_STRING");
                //const string CONN_STRING = @"Data Source=PC-FREDDEWEY;Initial Catalog=Auto;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
                SqlConnection = new SqlConnection(AccessPath);
                SqlConnection.Open();
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Connection Error", ex.Message);
            }
        }

        public SqlConnection SqlConnection { get; set; }

        public override VehiclesCollection GetAllVehicles()
        {
            SqlConnection.Close();
            try
            {
                VehiclesCollection vehicle = new VehiclesCollection();
                string sql = "SELECT * FROM Vehicle;";

                using (SqlCommand cmd = new SqlCommand(sql, SqlConnection))
                {
                    SqlConnection.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Vehicle ve = GetVehicle(dataReader);
                            if (ve != null)
                            {
                                vehicle.Add(ve);
                            }
                        }
                    }
                    SqlConnection.Close();
                }

                return vehicle;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }
        }

        //public override VehiclesCollection GetAllVehicles()
        //{
        //    try
        //    {
        //        VehiclesCollection vehicles = new VehiclesCollection();
        //        string sql = "SELECT * FROM Vehicle;";
        //        SqlCommand cmd = new SqlCommand(sql, SqlConnection);
        //        SqlDataReader dataReader = cmd.ExecuteReader();
        //        while (dataReader.Read())
        //        {
        //            Vehicle ve = GetVehicle(dataReader);
        //            if (ve != null)
        //            {
        //                vehicles.Add(ve);
        //            }
        //        }
        //        dataReader.Close();
        //        return vehicles;
        //    }
        //    catch (Exception ex)
        //    {
        //        alertService.ShowAlert("Database Request Error", ex.Message);
        //        return null;
        //    }
        //}


        private static Vehicle GetVehicle(SqlDataReader dr)
        {
            string type = dr.GetValue(1).ToString();
            switch (type)
            {
                case "Car":
                    return new Car(
                        id: dr.GetInt32(0),
                        picture_name: dr.GetString(2),
                        brand: dr.GetString(3),
                        model: dr.GetString(4),
                        color: dr.GetString(5),
                        plate: dr.GetString(6),
                        available: dr.GetBoolean(7),
                        chassis_number: dr.GetString(8),
                        motorization: dr.GetString(9),
                        year_of_launch: dr.GetString(10),
                        length: dr.GetDouble(11),
                        width: dr.GetDouble(12),
                        speed: dr.GetInt32(13),
                        fuel: dr.GetString(14),
                        power: dr.GetInt32(15),
                        price_of_day: dr.GetDouble(16),
                        vat_rate: dr.GetDouble(17),
                        driver_license: dr.GetString(18));

                case "Truck":
                    return new Truck(
                        id: dr.GetInt32(0),
                        picture_name: dr.GetString(2),
                        brand: dr.GetString(3),
                        model: dr.GetString(4),
                        color: dr.GetString(5),
                        plate: dr.GetString(6),
                        available: dr.GetBoolean(7),
                        chassis_number: dr.GetString(8),
                        motorization: dr.GetString(9),
                        year_of_launch: dr.GetString(10),
                        length: dr.GetDouble(11),
                        width: dr.GetDouble(12),
                        speed: dr.GetInt32(13),
                        fuel: dr.GetString(14),
                        power: dr.GetInt32(15),
                        price_of_day: dr.GetDouble(16),
                        vat_rat: dr.GetDouble(17),
                        height: dr.GetDouble(19),
                        capacity: dr.GetDouble(20));

                default:
                    return null;
            }
        }

        public override bool UpdateVehicles(VehiclesCollection vehicle)
        {
            SqlConnection.Close();
            SqlConnection.Open();
            string sql = string.Empty;
            try
            {
                // Récupérer tous les IDs depuis le serveur SQL
                List<int> sqlIds = new List<int>();
                string sqlQuery = "SELECT Id FROM Vehicle";
                SqlCommand selectCommand = new SqlCommand(sqlQuery, SqlConnection);
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    sqlIds.Add(reader.GetInt32(0));
                }
                reader.Close();

                // Comparer les IDs avec ceux dans ton programme
                List<int> programIds = new List<int>();
                foreach (Vehicle ve in vehicle)
                {
                    programIds.Add(ve.Id);
                }

                // Trouver les IDs manquants
                List<int> missingIds = sqlIds.Except(programIds).ToList();

                // Supprimer les IDs manquants de ta base de données
                foreach (int missingId in missingIds)
                {
                    string deleteSql = $"DELETE FROM Vehicle WHERE Id = {missingId}";
                    SqlCommand deleteCommand = new SqlCommand(deleteSql, SqlConnection);
                    deleteCommand.ExecuteNonQuery();
                }

                foreach (Vehicle ve in vehicle)
                {
                    // If id already in database, update its values; insert otherwise
                    sql = IsInDb(ve.Id, "Id", "Vehicle") ? GetSqlUpdateVehicle(ve) : GetSqlInsertVehicle(ve);
                    if (!string.IsNullOrEmpty(sql))
                    {
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            int insertedId = Convert.ToInt32(result);
                            if (insertedId > 0)
                            {
                                ve.Id = insertedId;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", $"{ex.Message} \nSQL Query: {sql}");
                return false;
            }
        }

        private string GetSqlUpdateVehicle(Vehicle ve)
        {
            string[] strType = ve.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)
            {
                case "Car":
                    return $@"UPDATE Vehicle 
                      SET Picture_name = '{ve.Picture_name}', 
                          Brand = '{ve.Brand}', 
                          Model = '{ve.Model}', 
                          Color = '{ve.Color}', 
                          Plate = '{ve.Plate}', 
                          Available = {BoolSqlConvert(ve.Available)}, 
                          Chassis_number = '{ve.Chassis_number}', 
                          Motorization = '{ve.Motorization}', 
                          Year_of_launch = '{ve.Year_of_launch}', 
                          Length = {ve.Length}, 
                          Width = {ve.Width}, 
                          Speed = {ve.Speed}, 
                          Fuel = '{ve.Fuel}', 
                          Power = {ve.Power}, 
                          Price_of_day = {ve.Price_of_day}, 
                          Vat_rate = {ve.Vat_rate}
                          WHERE Id = {ve.Id}";

                case "Truck":
                    Truck t = (Truck)ve;
                    return $@"UPDATE Vehicle 
                      SET Picture_name = '{ve.Picture_name}', 
                          Brand = '{ve.Brand}', 
                          Model = '{ve.Model}', 
                          Color = '{ve.Color}', 
                          Plate = '{ve.Plate}', 
                          Available = {BoolSqlConvert(ve.Available)}, 
                          Chassis_number = '{ve.Chassis_number}', 
                          Motorization = '{ve.Motorization}', 
                          Year_of_launch = '{ve.Year_of_launch}', 
                          Length = {ve.Length}, 
                          Width = {ve.Width}, 
                          Speed = {ve.Speed}, 
                          Fuel = '{ve.Fuel}', 
                          Power = {ve.Power}, 
                          Price_of_day = {ve.Price_of_day}, 
                          Vat_rate = {ve.Vat_rate}, 
                          Height = {t.Height}, 
                          Capacity = {t.Capacity}
                          WHERE Id = {ve.Id}";

                default:
                    return null;
            }
        }


        private string GetSqlInsertVehicle(Vehicle ve)
        {
            string[] strType = ve.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];

            switch (type)
            {
                case "Car":
                    return $@"
                INSERT INTO Vehicle 
                (Type, Picture_name, Brand, Model, Color, Plate, Available, Chassis_number, Motorization, Year_of_launch, 
                 Length, Width, Speed, Fuel, Power, Price_of_day, Vat_rate)
                VALUES 
                ('{type}', '{ve.Picture_name}', '{ve.Brand}', '{ve.Model}', '{ve.Color}', '{ve.Plate}', 
                 {BoolSqlConvert(ve.Available)}, '{ve.Chassis_number}', '{ve.Motorization}', '{ve.Year_of_launch}', 
                 {ve.Length}, {ve.Width}, {ve.Speed}, '{ve.Fuel}', {ve.Power}, {ve.Price_of_day}, {ve.Vat_rate});
                SELECT SCOPE_IDENTITY();";

                case "Truck":
                    Truck t = (Truck)ve;
                    return $@"
                INSERT INTO Vehicle 
                (Type, Picture_name, Brand, Model, Color, Plate, Available, Chassis_number, Motorization, Year_of_launch, 
                 Length, Width, Speed, Fuel, Power, Price_of_day, Vat_rate, Height, Capacity)
                VALUES 
                ('{type}', '{ve.Picture_name}', '{ve.Brand}', '{ve.Model}', '{ve.Color}', '{ve.Plate}', 
                 {BoolSqlConvert(t.Available)}, '{t.Chassis_number}', '{t.Motorization}', '{t.Year_of_launch}', 
                 {t.Length}, {t.Width}, {t.Speed}, '{t.Fuel}', {t.Power}, {t.Price_of_day}, {t.Vat_rate}, 
                 {t.Height}, {t.Capacity});
                SELECT SCOPE_IDENTITY();";

                default:
                    return null;
            }
        }


        private bool IsInDb(int idValue, string idColumnName, string tableName)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = {idValue}";
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            bool isInDb = reader.HasRows;
            reader.Close();
            return isInDb;
        }

        private static string BoolSqlConvert(bool value)
        {
            return value ? "1" : "0";
        }
    }
}

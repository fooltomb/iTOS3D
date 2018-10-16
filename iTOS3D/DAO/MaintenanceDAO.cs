using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using iTOSeunm;

namespace iTOS3D.DAO
{
    public static class MaintenanceDAO
    {
        static RequestCode request = RequestCode.Maintenance;
        public static void GetMaintenanceInfo(MySqlConnection conn,Action<byte[]> SendToUnity)
        {
            MySqlDataReader reader=null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from maintenance", conn);
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    int parent = reader.GetInt32("parent");
                    int maintenanceCycle = reader.GetInt32("maintenance_cycle");
                    string id = reader.GetString("id");
                    string name = reader.GetString("name");
                    string status = reader.GetString("status");
                    string maintenanceType = reader.GetString("maintenance_type");
                    string maintenanceUnit = reader.GetString("maintenance_unit");
                    string maintenanceStandards = reader.GetString("maintenance_standards");
                    string maintenanceContent = reader.GetString("maintenance_content");

                    string valueString = id + "|" + name + "|" + status + "|" + maintenanceType + "|" + maintenanceUnit + "|" + maintenanceStandards + "|" + maintenanceContent;
                    byte[] value = BitConverter.GetBytes(parent).Concat(BitConverter.GetBytes(maintenanceCycle)).ToArray().Concat(Encoding.UTF8.GetBytes(valueString)).ToArray();
                    byte[] length = BitConverter.GetBytes(value.Length);
                    SendToUnity(length.Concat(value).ToArray());
                }
            }
            catch(Exception ex)
            {
                //TODO
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}

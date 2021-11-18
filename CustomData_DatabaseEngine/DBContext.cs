using System;

using System.Collections;

using System.Collections.Specialized;

using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.Linq;

using System.Text;

using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace CustomData_DatabaseEngine
{
    public static class DBContext
    {
        public static bool Data_Insert(object _object)
        {

            string connString = @"Server = LAPTOP-ISG4DLCP; Database = testDB; Trusted_Connection = True;";
            string _SQLTable = "";

            Type t = _object.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (System.Reflection.PropertyInfo prp in props)
            {
                object value = prp.GetValue(_object, new object[] { });
                dict.Add(prp.Name, value);

            }

            _SQLTable = dict["SqlTableName"].ToString();

            dict.Remove("SqlTableName");
            dict.Remove("Data_Transaction_Status");
            dict.Remove("Data_Transaction_Message");

            using (SqlConnection con = new SqlConnection(connString))
            {
                String query = "INSERT INTO " + _SQLTable + " ( ";

                foreach (var i in dict)
                {
                    query += i.Key.ToString() + ",";
                }

                query = query.Remove(query.Length - 1, 1);

                query += " ) VALUES ( ";

                foreach (var i in dict)
                {
                    query += "@" + i.Key.ToString() + ",";
                }

                query = query.Remove(query.Length - 1, 1);

                query += " ) ";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    foreach (var i in dict)
                    {
                        command.Parameters.AddWithValue("@" + i.Key.ToString(), i.Value);
                    }

                    con.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }




            }


            bool _TransactionStatus = true;
            return _TransactionStatus;
        }

        public static bool Data_Update(object _object)
        {

            string connString = @"Server = LAPTOP-ISG4DLCP; Database = testDB; Trusted_Connection = True;";
            string _SQLTable = "";

            Type t = _object.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (System.Reflection.PropertyInfo prp in props)
            {
                object value = prp.GetValue(_object, new object[] { });
                dict.Add(prp.Name, value);

            }



            _SQLTable = dict["SqlTableName"].ToString();

            dict.Remove("SqlTableName");
            dict.Remove("Data_Transaction_Status");
            dict.Remove("Data_Transaction_Message");

            using (SqlConnection con = new SqlConnection(connString))
            {
                String query = "UPDATE " + _SQLTable + " SET ";

                foreach (var i in dict)
                {
                    query += i.Key.ToString() + " = @" + i.Key.ToString() + ",";
                }

                query = query.Remove(query.Length - 1, 1);

                //query += " WHERE ";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    foreach (var i in dict)
                    {
                        command.Parameters.AddWithValue("@" + i.Key.ToString(), i.Value);
                    }

                    con.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }




            }


            bool _TransactionStatus = true;
            return _TransactionStatus;
        }

        public static bool Data_Select(object _object)
        {

            string connString = @"Server = LAPTOP-ISG4DLCP; Database = testDB; Trusted_Connection = True;";
            string _SQLTable = "";

            Type t = _object.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (System.Reflection.PropertyInfo prp in props)
            {
                object value = prp.GetValue(_object, new object[] { });
                dict.Add(prp.Name, value);

            }



            _SQLTable = dict["SqlTableName"].ToString();

            dict.Remove("SqlTableName");
            dict.Remove("Data_Transaction_Status");
            dict.Remove("Data_Transaction_Message");

            using (SqlConnection con = new SqlConnection(connString))
            {
                String query = "SELECT ";

                foreach (var i in dict)
                {
                    query += i.Key.ToString() + ",";
                }

                query = query.Remove(query.Length - 1, 1);

                query += " FROM " + _SQLTable;

                //query += " WHERE ";


                using (SqlCommand command = new SqlCommand(query, con))
                {

                    con.Open();


                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Object obj = Activator.CreateInstance(t);

                        foreach (var i in dict)
                        {
                            obj.GetType().GetProperty(i.Key.ToString()).SetValue(obj, dr[i.Key.ToString()], null);
                        }


                    }

                }




            }


            bool _TransactionStatus = true;
            return _TransactionStatus;
        }

    }
}
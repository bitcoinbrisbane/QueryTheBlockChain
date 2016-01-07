using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Web.Utilities
{
    internal class SQL
    {
        private const String INVALID_QUERY_REG_EX = "delete|drop|alter|update|insert|master|grant|create|#|@";

        /// <summary>
        /// Excute the SQL
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal static ViewModels.QueryResult Execute(String query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                Regex validQuery = new Regex("select");
                Regex invalidQuery = new Regex(INVALID_QUERY_REG_EX, RegexOptions.IgnoreCase);

                Match found = invalidQuery.Match(query.ToLower());

                if (found.Success == false)
                {
                    ViewModels.QueryResult results = new ViewModels.QueryResult();

                    using (SqlConnection sqlConnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["blockchainEntities"].ConnectionString)) //"Server=localhost;Database=BlockChain;User Id=QueryTheBlockchain;Password=Dugong1979!;")) //
                    {
                        sqlConnection1.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = sqlConnection1;

                            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                //Sql time
                                sw.Stop();
                                results.ExecutionTime = sw.Elapsed;

                                int count = reader.FieldCount;

                                for (Int16 i = 0; i < count; i++)
                                {
                                    results.Columns.Add(String.Format("{0}", reader.GetName(i)));
                                }

                                String row = String.Empty;

                                while (reader.Read())
                                {
                                    row = "<tr>";

                                    for (int i = 0; i < count; i++)
                                    {
                                        try
                                        {
                                            Type columnType = reader.GetFieldType(i);

                                            if (columnType == typeof(Byte[]))
                                            {
                                                Byte[] data = (Byte[])reader.GetValue(i);

                                                if (data != null)
                                                {
                                                    String hex = BitConverter.ToString(data).Replace("-", String.Empty);
                                                    row += String.Format("<td>{0}</td>", hex);
                                                }
                                                else
                                                {
                                                    row += "";
                                                }
                                            }
                                            else
                                            {
                                                row += String.Format("<td>{0}</td>", reader.GetValue(i));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            row += "";
                                        }
                                    }

                                    row += "</tr>";
                                    results.Rows.Add(row);

                                    row = string.Empty;
                                }
                            }
                        }

                        sqlConnection1.Close();
                    }

                    return results;
                }
                else
                {
                    throw new ArgumentException("Query is invalid");
                }
            }
            else
            {
                throw new ArgumentNullException("Query cannot be null or empty");
            }
        }
    }
}
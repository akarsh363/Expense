using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExpenseEntity;

namespace ExpenseManager
{
    public class EntityManager
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ExpenseDB;Integrated Security=True";

        public void AddExpense(Expense exp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ExpenseTable (Description, Amount, Date) VALUES (@Description, @Amount, @Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Description", exp.Description);
                cmd.Parameters.AddWithValue("@Amount", exp.Amount);
                cmd.Parameters.AddWithValue("@Date", exp.ExpenseDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Expense> GetAllExpenses()
        {
            List<Expense> list = new List<Expense>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ExpenseTable";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Expense
                    {
                        ExpenseId = (int)reader["ExpenseId"],
                        Description = reader["Description"].ToString(),
                        Amount = (decimal)reader["Amount"],
                        ExpenseDate = (DateTime)reader["Date"]
                    });
                }
            }
            return list;
        }
    }
}

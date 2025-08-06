using ExpenseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManager;

namespace ExpenseApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EntityManager obj = new EntityManager();

            // Create new Expense object
            ExpenseEntity.Expense exp = new ExpenseEntity.Expense();
            exp.Description = txtDescription.Text;
            exp.Amount = Convert.ToDecimal(txtAmount.Text);
            exp.ExpenseDate = dtExpenseDate.Value;

            // Call AddExpense method
            obj.AddExpense(exp);

            MessageBox.Show("Expense saved successfully!");
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            EntityManager obj = new EntityManager();

            // Get all expenses
            List<ExpenseEntity.Expense> expenses = obj.GetAllExpenses();

            // Clear listbox before adding
            lstExpenses.Items.Clear();

            // Add to listbox
            foreach (var item in expenses)
            {
                lstExpenses.Items.Add($"{item.ExpenseId} - {item.Description} - {item.Amount} - {item.ExpenseDate.ToShortDateString()}");
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

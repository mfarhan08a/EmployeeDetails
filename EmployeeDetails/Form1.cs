using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class Form1 : Form
    {
        Employee employee = new Employee();
        public Form1()
        {
            InitializeComponent();
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
        }

        // Add employee details when clicks the Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cbGender.SelectedItem.ToString();
            // Call Insert Employee method to insert the employee details to database
            var success = employee.InsertEmployee(employee);
            // Refresh the grid to show the updated employee details
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                ClearControls();
                MessageBox.Show("Employee has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void ClearControls()
        {
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            txtAge.Text = "";
            txtContactNo.Text = "";
            cbGender.Text = "";
        }

        // Update selected employee details when clicks the update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            employee.EmpName = txtEmpName.Text;
            employee.Age = txtAge.Text;
            employee.ContactNo = txtContactNo.Text;
            employee.Gender = cbGender.SelectedItem.ToString();
            // Call Update Employee method to update the selected employee details to database
            var success = employee.UpdateEmployee(employee);
            // Refresh the grid to show the updated employee details
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                ClearControls();
                MessageBox.Show("Employee has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");

        }

        // Delete selected employee when clicks the delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee.EmpId = txtEmpId.Text;
            // Call DeleteEmployee method to delete the selected employee from database
            var success = employee.DeleteEmployee(employee);
            // Refresh the grid to show the updated employee details
            dgvEmployeeDetails.DataSource = employee.GetEmployees();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                ClearControls();
                MessageBox.Show("Employee has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        // Clear all controls when clicks clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        // This data grid event triggers when select the grid rows and populate the controls with selected employee details
        private void dgvEmployeeDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtEmpId.Text = dgvEmployeeDetails.Rows[index].Cells[0].Value.ToString();
            txtEmpName.Text = dgvEmployeeDetails.Rows[index].Cells[1].Value.ToString();
            txtAge.Text = dgvEmployeeDetails.Rows[index].Cells[2].Value.ToString();
            txtContactNo.Text = dgvEmployeeDetails.Rows[index].Cells[3].Value.ToString();
            cbGender.Text = dgvEmployeeDetails.Rows[index].Cells[4].Value.ToString();
        }
    }
}

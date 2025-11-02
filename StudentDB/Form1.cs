using System.Data;
using System.Data.SQLite;

using System.Data.SQLite;
using System.IO;


namespace StudentDB
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var connection = DBHelper.dbGetConnection();
            connection.Open();

            string query = "INSERT INTO students (name, age) VALUES (@name, @age)";

            using var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@name", txtName.Text);
            command.Parameters.AddWithValue("@age", (int)nudAge.Value);

            command.ExecuteNonQuery();

            MessageBox.Show("Student has been added");


            // sql command - 3 stages
            // 1 stage - creating command object
            // 2 stage - filling command object
            // 3 stage - execute object
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            using var connection = DBHelper.dbGetConnection();
            connection.Open();

            string query = "SELECT * FROM students";
            using var adapter = new SQLiteDataAdapter(query, connection);

            var table = new DataTable(); // table that located in desing

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }
    }
}

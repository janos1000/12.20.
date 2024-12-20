using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListViewWithDatabase
{
    public partial class Form1 : Form
    {
        
        private string connectionString = @"Data Source=YOUR_SERVER;Initial Catalog=user;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                
                string query = "SELECT ID, FirstName, LastName, Password, CreatedTime, UpdateTime FROM data";

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    
                    DataTable dataTable = new DataTable();

                    
                    dataAdapter.Fill(dataTable);

                    
                    listView2.View = View.Details;  
                    listView2.Columns.Clear();      

                    
                    listView2.Columns.Add("ID", 50);
                    listView2.Columns.Add("First Name", 100);
                    listView2.Columns.Add("Last Name", 100);
                    listView2.Columns.Add("Password", 100);
                    listView2.Columns.Add("Created Time", 120);
                    listView2.Columns.Add("Update Time", 120);

                    
                    listView2.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["Id"].ToString());
                        item.SubItems.Add(row["FirstName"].ToString());
                        item.SubItems.Add(row["LastName"].ToString());
                        item.SubItems.Add(row["Password"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(row["CreatedTime"]).ToString("yyyy-MM-dd HH:mm:ss"));
                        item.SubItems.Add(Convert.ToDateTime(row["UpdateTime"]).ToString("yyyy-MM-dd HH:mm:ss"));

                        
                        listView2.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

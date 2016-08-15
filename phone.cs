using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Telephone
{

    public partial class phone : Form



    {
        MySqlConnection mCon = new MySqlConnection("datasource=localhost;port=3306;username=homs;password=");
        MySqlCommand mcd;



        public void Display(string q)
        {
            try
            {

                openCon();

                MySqlDataAdapter asd = new MySqlDataAdapter(q, mCon);
                DataTable dt = new DataTable();
                asd.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["Id"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["First"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Last"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Mobile"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["Email"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item["Catagory"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeCon();
            }
        }
             

        public void ExecuteQuery(string q)
        {
            try
            {
                openCon();
                mcd = new MySqlCommand(q, mCon);
                if (mcd.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Query Ex");
                }
                else
                {
                    MessageBox.Show("Quary not Ex");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeCon();
            }
        }
        public void openCon()
        {
            
            if (mCon.State==ConnectionState.Closed)
            {
                mCon.Open();
            }
        }
        public void closeCon()
        {
            if(mCon.State==ConnectionState.Open)
            {
                mCon.Close();
            }
        }

        public void clearall()
        {
            txtId.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            cmb1.SelectedIndex = -1;
            txt1.Focus();
        }





        public phone()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String q = "insert into h.phone (id,First,Last,Mobile,Email,Catagory) values ('" + txtId.Text + "','" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + cmb1.Text + "')";

            ExecuteQuery(q);





        }

        private void phone_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearall();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            String q = "Select * from h.phone";
            Display(q);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            cmb1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string q = "DELETE FROM `h`.`phone` WHERE `id`='" + txtId.Text  +" ';";
            ExecuteQuery(q);
            String q1 = "Select * from h.phone";
            Display(q1);
            clearall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string q = " UPDATE `h`.`phone` SET id='" + txtId.Text + "'  ,First = '" + txt1.Text + "',Last = '" + txt2.Text + "' , Mobile = '" + txt3.Text + "' ,Email = '" + txt4.Text + "' , Catagory = '" + cmb1.Text + "' WHERE (`id`='" + txtId.Text  + "') ";
            ExecuteQuery(q);
            String q1 = "Select * from h.phone";
            Display(q1);
        }
    }
    

    }
  
      

   


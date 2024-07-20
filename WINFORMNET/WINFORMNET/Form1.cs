using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WINFORMNET
{

    public partial class Form1 : Form
    {

        int lokace = 0;
        int Identifikace = 0;
        int Zmena= 0;
        int destrukce = 0;
        int stahnuti = 0;
        int celkem = 0;
        long celycas;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void button1_Click(object sender, EventArgs e)
        {
            int z = Int32.Parse(textBox15.Text);

            generation a = new generation();
            Random r = new Random();

            for (int k = 1; k <= z; k++)
            {
                int rInt = r.Next(0, 11);

                if (rInt <= 2)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    generation.GPSLoc();
                    lokace = lokace + 1;

                    watch.Stop();

                    var elapsedTime = watch.ElapsedMilliseconds;

                    celycas = celycas + elapsedTime;
                    textBox6.Text = elapsedTime.ToString();
                    textBox12.Text = celycas.ToString();
                }

                if (rInt >= 3 && rInt <= 7)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    generation.STATUS();
                    Zmena = Zmena + 1;

                    watch.Stop();

                    var elapsedTime = watch.ElapsedMilliseconds;

                    celycas = celycas + elapsedTime;
                    textBox8.Text = elapsedTime.ToString();
                    textBox12.Text = celycas.ToString();
                }

                if (rInt == 8)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    generation.ID();
                    Identifikace = Identifikace + 1;

                    watch.Stop();

                    var elapsedTime = watch.ElapsedMilliseconds;

                    celycas = celycas + elapsedTime;
                    textBox10.Text = elapsedTime.ToString();
                    textBox12.Text = celycas.ToString();
                }

                if (rInt == 9)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    generation.DELETE();
                    destrukce = destrukce + 1;

                    watch.Stop();

                    var elapsedTime = watch.ElapsedMilliseconds;

                    celycas = celycas + elapsedTime;
                    textBox7.Text = elapsedTime.ToString();
                    textBox12.Text = celycas.ToString();
                }

                if (rInt == 10)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    generation.DOWN();
                    stahnuti = stahnuti + 1;
                    watch.Stop();

                    var elapsedTime = watch.ElapsedMilliseconds;

                    celycas = celycas + elapsedTime;
                    textBox9.Text = elapsedTime.ToString();
                    textBox12.Text = celycas.ToString();
                }

                celkem = lokace + destrukce + Zmena + stahnuti + Identifikace;


                textBox1.Text = lokace.ToString();
                textBox2.Text = destrukce.ToString();
                textBox3.Text = Zmena.ToString();
                textBox4.Text = stahnuti.ToString();
                textBox5.Text = Identifikace.ToString();
                textBox11.Text = celkem.ToString();
                textBox13.Text = System.Runtime.InteropServices.Marshal.SizeOf(lokace).ToString();
                textBox16.Text = System.Runtime.InteropServices.Marshal.SizeOf(Zmena).ToString();
                textBox17.Text = System.Runtime.InteropServices.Marshal.SizeOf(Identifikace).ToString();
            }    

                
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);

            using (SqlCommand command = new SqlCommand("TRUNCATE TABLE CISstorage", con))
            {
                con.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error deleting data in Database!");
            }
        }

        public void sendall_Click(object sender, EventArgs e)
        {
            int z = Int32.Parse(textBox15.Text);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int a = 0;
            int b = 0;
            int c = 0;

            for (int i=0;i<z;i++)
          { 
            string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);

            String query = "INSERT INTO CISstorage (COORDINATES#1,COORDINATES#2,STATUS#1,STATUS#2,ID#1,ID#2) VALUES (@COORDINATES#1,@COORDINATES#2,@STATUS#1,@STATUS#2,@ID#1,@ID#2)";



            
            //generace random gps lokací v ČR
            Random rnd = new Random();
            double N1;
            double N2;
            double E1;
            double E2;

            double exponent = rnd.NextDouble();


            N1 = (rnd.Next(49, 50) * exponent);

            exponent = rnd.NextDouble();

            N2 = (rnd.Next(49, 50) * exponent);

            exponent = rnd.NextDouble();

            E1 = (rnd.Next(13, 19) * exponent);

            exponent = rnd.NextDouble();

            E2 = (rnd.Next(13, 19) * exponent);

            string coord1 = ("N" + N1 + " E" + E1);
            string coord2 = ("N" + N2 + " E" + E2);
            lokace = lokace + 1;



            string Status = "I am still flying!";
            string Status1 = "I crashed!";

            Random r = new Random();
            int rInt = r.Next(0, 10);
            Zmena = Zmena + 1;


            Random res = new Random();

            // String that contain both alphabets and numbers 
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 7;

            // Initializing the empty string 
            String ID1 = "";
            String ID2 = "";

            for (int k = 0; k < size; k++)
            {

                // Selecting a index randomly 
                int x = res.Next(str.Length);
                int y = res.Next(str.Length);

                // Appending the character at the  
                // index to the random alphanumeric string. 
                ID1 = ID1 + str[x];
                ID2 = ID2 + str[y];

            }
            Identifikace = Identifikace + 1;


            celkem = lokace + destrukce + Zmena + stahnuti + Identifikace;

            System.Diagnostics.Debug.WriteLine(coord1);

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@COORDINATES#1", coord1);
                command.Parameters.AddWithValue("@COORDINATES#2", coord2);
                command.Parameters.AddWithValue("@STATUS#1", Status);
                command.Parameters.AddWithValue("@STATUS#2", Status1);
                command.Parameters.AddWithValue("@ID#1", ID1);
                command.Parameters.AddWithValue("@ID#2", ID2);

                con.Open();
                int result = command.ExecuteNonQuery();
                con.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
            }
                a = coord1.Length *sizeof(char);
                b = Status.Length * sizeof(char);
                c = ID1.Length * sizeof(char);
          }

            watch.Stop();

            var elapsedTime = watch.ElapsedMilliseconds;

            textBox13.Text = a.ToString();
            textBox16.Text = b.ToString();
            textBox17.Text = c.ToString();

            celycas = elapsedTime;
            textBox14.Text = elapsedTime.ToString();
            textBox12.Text = celycas.ToString();

            textBox1.Text = lokace.ToString();
            textBox2.Text = destrukce.ToString();
            textBox3.Text = Zmena.ToString();
            textBox4.Text = stahnuti.ToString();
            textBox5.Text = Identifikace.ToString();
            textBox11.Text = celkem.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {          
            Stopwatch s = new Stopwatch();
            s.Start();
            int a = 0;
            int b = 0;
            int c = 0;

            while (s.Elapsed < TimeSpan.FromSeconds(300))
            {
                string connstring = "Data source = LAPTOP-O47J0G1K;Initial Catalog=CIS; User ID=TEST;Password=TEST";
                SqlConnection con = new SqlConnection(connstring);

                String query = "INSERT INTO CISstorage (COORDINATES#1,COORDINATES#2,STATUS#1,STATUS#2,ID#1,ID#2) VALUES (@COORDINATES#1,@COORDINATES#2,@STATUS#1,@STATUS#2,@ID#1,@ID#2)";




                //generace random gps lokací v ČR
                Random rnd = new Random();
                double N1;
                double N2;
                double E1;
                double E2;

                double exponent = rnd.NextDouble();


                N1 = (rnd.Next(49, 50) * exponent);

                exponent = rnd.NextDouble();

                N2 = (rnd.Next(49, 50) * exponent);

                exponent = rnd.NextDouble();

                E1 = (rnd.Next(13, 19) * exponent);

                exponent = rnd.NextDouble();

                E2 = (rnd.Next(13, 19) * exponent);

                string coord1 = ("N" + N1 + " E" + E1);
                string coord2 = ("N" + N2 + " E" + E2);
                lokace = lokace + 1;



                string Status = "I am still flying!";
                string Status1 = "I crashed!";

                Random r = new Random();
                int rInt = r.Next(0, 10);
                Zmena = Zmena + 1;


                Random res = new Random();

                // String that contain both alphabets and numbers 
                String str = "abcdefghijklmnopqrstuvwxyz0123456789";
                int size = 7;

                // Initializing the empty string 
                String ID1 = "";
                String ID2 = "";

                for (int k = 0; k < size; k++)
                {

                    // Selecting a index randomly 
                    int x = res.Next(str.Length);
                    int y = res.Next(str.Length);

                    // Appending the character at the  
                    // index to the random alphanumeric string. 
                    ID1 = ID1 + str[x];
                    ID2 = ID2 + str[y];

                }
                Identifikace = Identifikace + 1;


                celkem = lokace + destrukce + Zmena + stahnuti + Identifikace;

                System.Diagnostics.Debug.WriteLine(coord1);

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@COORDINATES#1", coord1);
                    command.Parameters.AddWithValue("@COORDINATES#2", coord2);
                    command.Parameters.AddWithValue("@STATUS#1", Status);
                    command.Parameters.AddWithValue("@STATUS#2", Status1);
                    command.Parameters.AddWithValue("@ID#1", ID1);
                    command.Parameters.AddWithValue("@ID#2", ID2);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    con.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
                a = coord1.Length * sizeof(char);
                b = Status.Length * sizeof(char);
                c = ID1.Length * sizeof(char);
            }

            s.Stop();

            textBox13.Text = a.ToString();
            textBox16.Text = b.ToString();
            textBox17.Text = c.ToString();
            textBox12.Text = celycas.ToString();

            textBox1.Text = lokace.ToString();
            textBox2.Text = destrukce.ToString();
            textBox3.Text = Zmena.ToString();
            textBox4.Text = stahnuti.ToString();
            textBox5.Text = Identifikace.ToString();
            textBox11.Text = celkem.ToString();

        }
    }
    public class generation
    {
        static public void GPSLoc()
        {
            //generace random gps lokací v ČR
            Random rnd = new Random();
            double N1 ;
            double N2 ;
            double E1 ;
            double E2 ;
            
                double exponent = rnd.NextDouble();

                string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
                SqlConnection con = new SqlConnection(connstring);

                String coordquery = "INSERT INTO CISstorage (COORDINATES#1,COORDINATES#2) VALUES (@COORDINATES#1,@COORDINATES#2)";

                N1 = (rnd.Next(49, 50) * exponent);

                exponent = rnd.NextDouble();

                N2 = (rnd.Next(49, 50) * exponent);

                exponent = rnd.NextDouble();

                E1 = (rnd.Next(13, 19) * exponent);

                exponent = rnd.NextDouble();

                E2 = (rnd.Next(13, 19) * exponent);

                string coord1 = ("N" + N1 + " E" + E1);
                string coord2 = ("N" + N2 + " E" + E2);

                using (SqlCommand command = new SqlCommand(coordquery, con))
                {
                    command.Parameters.AddWithValue("@COORDINATES#1", coord1);
                    command.Parameters.AddWithValue("@COORDINATES#2", coord2);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    con.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }

            

        }

        static public void STATUS()
        {
            string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);

            String statusquery = "INSERT INTO CISstorage (STATUS#1,STATUS#2) VALUES (@STATUS#1,@STATUS#2)";

            string Status = "I am still flying!";
            string Status1 = "I crashed!";

            Random r = new Random();
            int rInt = r.Next(0, 10);

            if (rInt < 5)
            {
                using (SqlCommand command = new SqlCommand(statusquery, con))
                {
                    command.Parameters.AddWithValue("@STATUS#1", Status);
                    command.Parameters.AddWithValue("@STATUS#2", Status1);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    con.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand(statusquery, con))
                {
                    command.Parameters.AddWithValue("@STATUS#1", Status1);
                    command.Parameters.AddWithValue("@STATUS#2", Status);

                    con.Open();
                    int result = command.ExecuteNonQuery();
                    con.Close();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }


            }
        }

        static public void ID()
        {
            string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);

            String idquery = "INSERT INTO CISstorage (ID#1,ID#2) VALUES (@ID#1,@ID#2)";

            Random res = new Random();

            // String that contain both alphabets and numbers 
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 7;

            // Initializing the empty string 
            String ID1 = "";
            String ID2 = "";

            for (int i = 0; i < size; i++)
            {

                // Selecting a index randomly 
                int x = res.Next(str.Length);
                int y = res.Next(str.Length);

                // Appending the character at the  
                // index to the random alphanumeric string. 
                ID1 = ID1 + str[x];
                ID2 = ID2 + str[y];

            }

            using (SqlCommand command = new SqlCommand(idquery, con))
            {
                command.Parameters.AddWithValue("@ID#1", ID1);
                command.Parameters.AddWithValue("@ID#2", ID2);

                con.Open();
                int result = command.ExecuteNonQuery();
                con.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
            }
        }

        static public void DELETE()
        {
            string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);

            String deletequery1 = "DELETE FROM CISstorage WHERE STATUS#1 = 'I crashed!'";
            String deletequery2 = "DELETE FROM CISstorage WHERE STATUS#2 = 'I crashed!'";

            using (SqlCommand command = new SqlCommand(deletequery1, con))
            {

                con.Open();
                int result = command.ExecuteNonQuery();
                con.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error deleting data from Database!");
            }

            using (SqlCommand command = new SqlCommand(deletequery2, con))
            {

                con.Open();
                int result = command.ExecuteNonQuery();
                con.Close();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error deleting data from Database!");
            }
        }

        static public void DOWN()
        {
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"D:\Reporty\";
            {

                //Declare Variables and provide values
                string FileNamePart = "LogBook";//Datetime will be added to it
                string DestinationFolder = @"D:\Reporty\";
                string TableName = "CISstorage";
                string FileDelimiter = ","; //You can provide comma or pipe or whatever you like
                string FileExtension = ".txt"; //Provide the extension you like such as .txt or .csv


                //Create Connection to SQL Server in which you like to load files
                string connstring = "Data source = DESKTOP-FCAV6P5;Initial Catalog=CIS;Integrated Security=true";
                SqlConnection con = new SqlConnection(connstring);

                //Read data from table or view to data table
                string query = "Select * From " + TableName;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                DataTable d_table = new DataTable();
                d_table.Load(cmd.ExecuteReader());
                con.Close();

                //Prepare the file path 
                string FileFullPath = DestinationFolder + "\\" + FileNamePart + "_" + datetime + FileExtension;

                StreamWriter sw = null;
                sw = new StreamWriter(FileFullPath, false);

                // Write the Header Row to File
                int ColumnCount = d_table.Columns.Count;
                for (int ic = 0; ic < ColumnCount; ic++)
                {
                    sw.Write(d_table.Columns[ic]);
                    if (ic < ColumnCount - 1)
                    {
                        sw.Write(FileDelimiter);
                    }
                }
                sw.Write(sw.NewLine);

                // Write All Rows to the File
                foreach (DataRow dr in d_table.Rows)
                {
                    for (int ir = 0; ir < ColumnCount; ir++)
                    {
                        if (!Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write(dr[ir].ToString());
                        }
                        if (ir < ColumnCount - 1)
                        {
                            sw.Write(FileDelimiter);
                        }
                    }
                    sw.Write(sw.NewLine);

                }

                sw.Close();

            }

        }

    }


}
    


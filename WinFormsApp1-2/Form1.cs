using System.Data;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WinFormsApp1
{
    public partial class Form1 : Form

    {
        DataTable Table;
        public Form1()
        {
            InitializeComponent();
            Text = "Notes Application";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Table = new DataTable();
            Table.Columns.Add("Title", typeof(string));
            Table.Columns.Add("Messages", typeof(string));

            dataGridView1.DataSource = Table;
            LoadNotes(); 
        }

        //Clear
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Add note
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please specify a title and message.");
                return;
            }

            Table.Rows.Add(textBox1.Text, textBox2.Text);
            Clear();
        }

        //Delete note
        private void button3_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;

            Table.Rows[Index].Delete();
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;

            textBox1.Text = (string)dataGridView1.Rows[Index].Cells[0].Value;
            textBox2.Text = (string)dataGridView1.Rows[Index].Cells[1].Value;
        }

        //Update note
        private void button2_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows[Index].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[Index].Cells[1].Value = textBox2.Text;
        }

        private void Clear()
        {
            textBox2.Clear();
            textBox1.Clear();
        }

        private void SerializeToFile(DataTable dataTable, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            dataTable.TableName = "Notes";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, dataTable);
            }
        }

        private DataTable DeserializeFromFile(string fileName)
        {
            DataTable dataTable;

            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));

            using (StreamReader reader = new StreamReader(fileName))
            {
                dataTable = (DataTable)serializer.Deserialize(reader);
            }

            return dataTable;
        }

        //Save notes
        private void button5_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePath();
            SerializeToFile(Table, filePath);
        }

        //Load notes
        private void button6_Click(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void LoadNotes()
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
                return;

            DataTable dt = DeserializeFromFile(filePath);
            Table = dt;
            dataGridView1.DataSource = Table;
        }

        private string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return $"{currentDirectory}\\notes.xml";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

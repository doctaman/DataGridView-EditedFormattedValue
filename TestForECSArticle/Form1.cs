using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForECSArticle
{
    public partial class Form1 : Form
    {
        int rowOfLastClicked = 1;
        int colOfLastClicked = 1;
        public Form1()
        {
            InitializeComponent();
            SetupDGV();
            PopulateDataGridView();
            textBox1.Text = "";
        }

        private void SetupDGV()
        {
            dataGridView1.ColumnCount = 3;

            dataGridView1.Columns[0].Name = "One";
            dataGridView1.Columns[1].Name = "Two";
            dataGridView1.Columns[2].Name = "Three";


            dataGridView1.CellEnter += new
                DataGridViewCellEventHandler(dataGridView1_CellEnter);

            dataGridView1.EditingControlShowing += new
                DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < dataGridView1.ColumnCount)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                rowOfLastClicked = e.RowIndex;
                colOfLastClicked = e.ColumnIndex;
            }
        }



        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyUp -= dataGridView1_KeyUp;
            e.Control.KeyUp += new KeyEventHandler(dataGridView1_KeyUp);
        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[rowOfLastClicked].Cells[colOfLastClicked].EditedFormattedValue.ToString();
        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "Person 1", "11/22/1968", "2"};
            string[] row1 = { "Person 2", "1960", "5"};
            string[] row2 = { "Person 3", "11/11/1971", "1" };

            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
         
            dataGridView1.Columns[0].DisplayIndex = 0;
            dataGridView1.Columns[1].DisplayIndex = 1;
            dataGridView1.Columns[2].DisplayIndex = 2;
        }
    }
}

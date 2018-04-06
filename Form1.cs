using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace puzzleGame
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Jong Woon Kim
        /// #7428014
        /// Oriented Gaming
        /// 2016/10/23
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ///generate
            int col = Int32.Parse(txtCol.Text);
            int row = Int32.Parse(txtRow.Text);
            if (col == 0 || row == 0)
            {
                MessageBox.Show("Row or Columns should not have null or 0 value in it!");
                return;
            }
            else if (col != row)
            {
                MessageBox.Show("Rows and Columns should have same value!");
                return;
            }
            puzzleView.ColumnCount = col;
            puzzleView.RowCount = row;


            for (int i = 0; i < puzzleView.ColumnCount; i++)
            {
                puzzleView.Columns[i].Width = puzzleView.Width / col;

            }
            for (int i = 0; i < puzzleView.RowCount; i++)
            {
                puzzleView.Rows[i].Height = puzzleView.Height / row;
            }

            puzzleView[col - 1, row - 1].Value = "";


            if (col == 2 && row == 2)
            {
                puzzleView[0, 0].Value = "1";
                puzzleView[1, 0].Value = "2";
                puzzleView[0, 1].Value = "3";

            }
            else if (col == 3 && row == 3)
            {
                puzzleView[0, 0].Value = "1";
                puzzleView[1, 0].Value = "2";
                puzzleView[2, 0].Value = "3";
                puzzleView[0, 1].Value = "4";
                puzzleView[1, 1].Value = "5";
                puzzleView[2, 1].Value = "6";
                puzzleView[0, 2].Value = "7";
                puzzleView[1, 2].Value = "8";


            }
            else if (col == 4 && row == 4)
            {
                puzzleView[0, 0].Value = "1";
                puzzleView[1, 0].Value = "2";
                puzzleView[2, 0].Value = "3";
                puzzleView[3, 0].Value = "4";
                puzzleView[0, 1].Value = "5";
                puzzleView[1, 1].Value = "6";
                puzzleView[2, 1].Value = "7";
                puzzleView[3, 1].Value = "8";
                puzzleView[0, 2].Value = "9";
                puzzleView[1, 2].Value = "10";
                puzzleView[2, 2].Value = "11";
                puzzleView[3, 2].Value = "12";
                puzzleView[0, 3].Value = "13";
                puzzleView[1, 3].Value = "14";
                puzzleView[2, 3].Value = "15";


            }
            else if (col == 5 && row == 5)
            {
                puzzleView[0, 0].Value = "1";
                puzzleView[1, 0].Value = "2";
                puzzleView[2, 0].Value = "3";
                puzzleView[3, 0].Value = "4";
                puzzleView[4, 0].Value = "5";
                puzzleView[0, 1].Value = "6";
                puzzleView[1, 1].Value = "7";
                puzzleView[2, 1].Value = "8";
                puzzleView[3, 1].Value = "9";
                puzzleView[4, 1].Value = "10";
                puzzleView[0, 2].Value = "11";
                puzzleView[1, 2].Value = "12";
                puzzleView[2, 2].Value = "13";
                puzzleView[3, 2].Value = "14";
                puzzleView[4, 2].Value = "15";
                puzzleView[0, 3].Value = "16";
                puzzleView[1, 3].Value = "17";
                puzzleView[2, 3].Value = "18";
                puzzleView[3, 3].Value = "19";
                puzzleView[4, 3].Value = "20";
                puzzleView[0, 4].Value = "21";
                puzzleView[1, 4].Value = "22";
                puzzleView[2, 4].Value = "23";
                puzzleView[3, 4].Value = "24";
            }
            else
            {
                MessageBox.Show("We do not haveless than 1 more than 24 puzzles!");
                return;
            }



        }

        private void puzzleView_SelectionChanged(object sender, EventArgs e)
        {
            //cell click on color remove
            puzzleView.ClearSelection();
        }

        bool checkSpace(int col, int row)
        {

            if ((row - 1 > -1) && (puzzleView[col, row - 1].Value.ToString().Equals("")))
            {
                //move up             
                puzzleView[col, row - 1].Value = puzzleView[col, row].Value;
                puzzleView[col, row].Value = "";
                return true;
            }
            else if ((row + 1 < puzzleView.RowCount) && (puzzleView[col, row + 1].Value.ToString().Equals("")))
            {
                //move down            
                puzzleView[col, row + 1].Value = puzzleView[col, row].Value;
                puzzleView[col, row].Value = "";
                return true;
            }
            else if ((col - 1 > -1) && (puzzleView[col - 1, row].Value.ToString().Equals("")))
            {
                //move left
                puzzleView[col - 1, row].Value = puzzleView[col, row].Value;
                puzzleView[col, row].Value = "";
                return true;
            }
            else if ((col + 1 < puzzleView.ColumnCount) && (puzzleView[col + 1, row].Value.ToString().Equals("")))
            {
                //move right
                puzzleView[col + 1, row].Value = puzzleView[col, row].Value;
                puzzleView[col, row].Value = "";
                return true;
            }
            return false;
        }
        private void puzzleView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkSpace(e.ColumnIndex, e.RowIndex);
            bool puzzleWin = true;
            int nP = 0;


            for (int row = 0; row < puzzleView.RowCount; row++)
            {
                for (int col = 0; col < puzzleView.ColumnCount; col++)
                {
                    nP++;
                    if ((row == puzzleView.RowCount - 1) && (col == puzzleView.ColumnCount - 1))
                    {
                        if (!puzzleView[col, row].Value.ToString().Equals(""))
                        {
                            puzzleWin = false;
                            break;
                        }
                    }

                    else if (!puzzleView[col, row].Value.ToString().Equals(nP + ""))
                    {
                        puzzleWin = false;
                        break;
                    }
                }
                if (!puzzleWin)
                {
                    break;
                }
            }
            if (puzzleWin)
            {
                MessageBox.Show("Congratulation! You Win! New game starts");
                Shuffle();
            }
        }

        private void puzzleView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (puzzleView[e.ColumnIndex, e.RowIndex].Value.ToString().Equals(""))
            {
                puzzleView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightYellow;
            }
            else
            {
                puzzleView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGray;
            }            
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void Shuffle()
        {
            //shuffle            
            int count = 0;
            Random rnd = new Random();
            while (count != 100)
            {
                if (checkSpace(rnd.Next(0, puzzleView.ColumnCount), rnd.Next(0, puzzleView.RowCount)))
                {
                    puzzleView.Refresh();
                    count++;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text File |*.txt";
            if(save.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                string path = save.FileName;
                TextWriter writer = new StreamWriter(File.Create(path));
                for (int i = 0; i < puzzleView.ColumnCount; i++)
                {
                    for (int j = 0; j < puzzleView.RowCount; j++)
                    {
                        writer.Write("\n" + puzzleView[i,j].Value.ToString() + "\n"+ " | ");
                    }
                }              
                writer.Dispose();
            } 
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text File |*.txt";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = open.FileName;
                TextReader reader = new StreamReader(File.OpenRead(path));
            }
        }
    }
}



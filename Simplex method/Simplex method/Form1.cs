using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplexLibrary;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Simplex_method
{
    public partial class Form1 : Form
    {
        int numberOfUnknown = 3;
        int numberOfLimits = 3;
        List<SolvingMatrix> solvingMatrixList = new List<SolvingMatrix>();
        int step = -1; 
        public Form1()
        {
            InitializeComponent();
            Matrix.Rows.Add();
            Matrix.Rows.Add();
            Matrix.Rows.Add();
            Matrix.Rows.Add();
            baseSolution.Rows.Add();
            FillMatrixWithZeros();
            FillBaseSolutionWithZeros();
            minMaxBox.Text = "min";
            fractionViewBox.Text = "Обычные";
            solutionMethodBox.Text = "Симплекс";
            Matrix.Rows[3].Cells[0].Value = "F";
            Matrix.Rows[0].Cells[1].Selected = true;
            //NOTES
            //test.Text = (new Fraction(0.5) * 0.7).ToString();
            //Matrix.Rows[1].Cells[2].Style.BackColor = Color.Red;
            //Matrix.Rows[1].Cells[2].Style.SelectionBackColor = Color.Green;
            //Matrix.Rows[1].Cells[1].Style.SelectionBackColor = Color.White;
        }
        private void SaveMatrix()
        {
            Fraction[,] logMatrix = new Fraction[numberOfLimits+1, numberOfUnknown+1];
            for (int i = 0; i < numberOfLimits+1; i++)
                for (int j = 1; j < numberOfUnknown + 2; j++)
                {
                    /*
                    if (Matrix.Rows[i].Cells[j].Value == null)      
                    {
                        MessageBox.Show(
                            "Матрица заполнена не полностью",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }
                    */
                    String value = Matrix.Rows[i].Cells[j].Value.ToString();
                    int counter = 0;
                    bool inputMode = false; //Если false, то ввод в формате x/y, иначе ввод в формате double
                    foreach (char letter in value)
                    {
                        if (letter == '/')
                            counter++;

                        if (letter == '.')
                        {
                            counter++;
                            inputMode = true;
                        }        
                    }
                    /*
                    if (new Regex(@"[^(0-9,/,.)]").IsMatch(value)||(counter > 1))
                    {
                        MessageBox.Show(
                            "Некорректное значение в [" + (i+1).ToString() + ", " + j.ToString() + "], введите корректное значение",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }
                    */
                    if (inputMode)
                    {
                        String text = Matrix.Rows[i].Cells[j].Value.ToString();
                        NumberFormatInfo formatProvider = new NumberFormatInfo();
                        formatProvider.NumberDecimalSeparator = ".";
                        logMatrix[i, j - 1] = new Fraction(Convert.ToDouble(text, formatProvider));
                    }
                    else
                    {
                        String text = Matrix.Rows[i].Cells[j].Value.ToString();
                        int numerator = Convert.ToInt32(text.Split('/')[0]);
                        int denominator = 1;
                        if (text.Split('/').Length > 1)
                            denominator = Convert.ToInt32(text.Split('/')[1]);
                        logMatrix[i, j - 1] = new Fraction(numerator, denominator);
                    }
                }
            solvingMatrixList.Add(new SolvingMatrix(logMatrix));
            showBases();
            //test.Text = solvingMatrixList.Count.ToString();
        }
        private void LoadMatrix()
        {
            bool fractionsType; //true - обычные дроби, false - десятичные 
            if (fractionViewBox.Text == "Обычные")
                fractionsType = true;
            else
                fractionsType = false;

            numberOfLimits = solvingMatrixList[step].GetRowsAmount()-1;
            numberOfUnknown = solvingMatrixList[step].GetColumnsAmount()-1;
            for (int i = 0; i < numberOfLimits+1; i++)
                for (int j = 0; j < numberOfUnknown+1; j++)
                {
                    if (fractionsType)
                        Matrix.Rows[i].Cells[j + 1].Value = solvingMatrixList[step].GetValue(i, j).ToString();
                    else
                        Matrix.Rows[i].Cells[j + 1].Value = solvingMatrixList[step].GetValue(i, j).ToDoubleString();
                }
            showBases();
        }

        private void FillMatrixWithZeros()
        {
            for (int row = 0; row < numberOfLimits+1; row++)
                for (int column = 1; column < numberOfUnknown+2; column++)
                {
                    Matrix.Rows[row].Cells[column].Value = '0';
                }
        }

        private void FillBaseSolutionWithZeros()
        {
            for (int column = 0; column < numberOfUnknown; column++)
                baseSolution.Rows[0].Cells[column].Value = '0';
        }

        private void FillRowWithZeros(int row)
        {
            for (int column = 1; column < numberOfUnknown + 2; column++)
                Matrix.Rows[row].Cells[column].Value = '0';
        }

        private void FillColumnWithZeros(int column)
        {
            for (int row = 0; row < numberOfLimits+1; row++)
                Matrix.Rows[row].Cells[column].Value = '0';
        }

        private void showBases()
        {
            if (step != -1)
                for (int b = 0; b < numberOfLimits; b++)
                    Matrix.Rows[b].Cells[0].Value = solvingMatrixList[step].StringBasis(b);
            else
                for (int b = 0; b < numberOfLimits; b++)
                    Matrix.Rows[b].Cells[0].Value = null;
        }



        private void addUnknown_Click(object sender, EventArgs e)
        {
            if (numberOfUnknown < 16)//При необходимости может быть увеличено до 2147483647
                numberOfUnknown++;
            textNumberOfUnknown.Text = numberOfUnknown.ToString();
            textNumberOfUnknown.SelectionStart = textNumberOfUnknown.Text.Length;
        }

        private void subtractUnknown_Click(object sender, EventArgs e)
        {
            
            if (numberOfUnknown > 1)
                numberOfUnknown--;
            textNumberOfUnknown.Text = numberOfUnknown.ToString();
            textNumberOfUnknown.SelectionStart = textNumberOfUnknown.Text.Length;
        }

        private void addLimit_Click(object sender, EventArgs e)
        {
            if (numberOfLimits < 16)//При необходимости может быть увеличено до 2147483647
                numberOfLimits++;
            textNumberOfLimits.Text = numberOfLimits.ToString();
            textNumberOfLimits.SelectionStart = textNumberOfLimits.Text.Length;
        }

        private void subtractLimit_Click(object sender, EventArgs e)
        {
            if (numberOfLimits > 1)
                numberOfLimits--;
            textNumberOfLimits.Text = numberOfLimits.ToString();
            textNumberOfLimits.SelectionStart = textNumberOfLimits.Text.Length;
        }

        private void textNumberOfUnknown_TextChanged(object sender, EventArgs e)
        {
            String[] bColumn = new String[numberOfLimits+1];
            for (int i = 0; i < numberOfLimits+1; i++)
                bColumn[i] = Matrix.Rows[i].Cells[Matrix.Columns.Count - 1].Value.ToString();
            try
            {
                numberOfUnknown = Int32.Parse(textNumberOfUnknown.Text);
                if (numberOfUnknown < 1)
                    numberOfUnknown = 1;
                Matrix.Columns.RemoveAt(Matrix.Columns.Count - 1);

            }

            catch
            {
                if (textNumberOfUnknown.Text.Length > 1)
                {
                    textNumberOfUnknown.Text = numberOfUnknown.ToString();
                    textNumberOfUnknown.SelectionStart = textNumberOfUnknown.Text.Length;
                }
            }

            while (Matrix.Columns.Count - 1 != numberOfUnknown)
            {
                if (Matrix.Columns.Count - 1 < numberOfUnknown)
                {
                    String name = "x" + (Matrix.Columns.Count).ToString();
                    Matrix.Columns.Add(name, name);
                    Matrix.Columns[Matrix.Columns.Count - 1].Width = 50;
                    Matrix.Columns[Matrix.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    FillColumnWithZeros(Matrix.Columns.Count - 1);
                    baseSolution.Columns.Add(name, name);
                    baseSolution.Rows[0].Cells[baseSolution.Columns.Count - 1].Value = '0';
                    baseSolution.Columns[baseSolution.Columns.Count - 1].Width = 50;
                    baseSolution.Columns[baseSolution.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                else
                {
                    Matrix.Columns.RemoveAt(Matrix.Columns.Count - 1);
                    baseSolution.Columns.RemoveAt(baseSolution.Columns.Count - 1);
                }
            }
            Matrix.Columns.Add("b", "b");
            Matrix.Columns[Matrix.Columns.Count - 1].Width = 50;
            Matrix.Columns[Matrix.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < numberOfLimits+1; i++)
                Matrix.Rows[i].Cells[Matrix.Columns.Count - 1].Value = bColumn[i];
    
        }

        private void textNumberOfLimits_TextChanged(object sender, EventArgs e)
        {
            String[] FColumn = new String[numberOfUnknown+2];
            for (int i = 1; i < numberOfUnknown+2; i++)
                FColumn[i] = Matrix.Rows[Matrix.Rows.Count - 1].Cells[i].Value.ToString();
            try
            {
                numberOfLimits = Int32.Parse(textNumberOfLimits.Text);
                if (numberOfLimits < 1)
                    numberOfLimits = 1;
                Matrix.Rows.RemoveAt(Matrix.Rows.Count - 1);
            }
            catch
            {
                if (textNumberOfLimits.Text.Length > 1)
                {
                    textNumberOfLimits.Text = numberOfLimits.ToString();
                    textNumberOfLimits.SelectionStart = textNumberOfLimits.Text.Length;
                }
            }
            while (Matrix.Rows.Count != numberOfLimits)
            {
                if (Matrix.Rows.Count < numberOfLimits)
                {
                    Matrix.Rows.Add();
                    FillRowWithZeros(Matrix.Rows.Count-1);
                }
                else
                    Matrix.Rows.RemoveAt(Matrix.Rows.Count - 1);
            }
            Matrix.Rows.Add();
            for (int i = 1; i < numberOfUnknown+2; i++)
                Matrix.Rows[Matrix.Rows.Count - 1].Cells[i].Value = FColumn[i];
            Matrix.Rows[Matrix.Rows.Count - 1].Cells[0].Value = "F";
        }

        private void test_Click(object sender, EventArgs e)
        {

        }

        private void solve_Click(object sender, EventArgs e)
        {
            if (step == -1)
            {
                SaveMatrix();
                solveButton.Text = "Далее";
                backButton.Text = "Назад";
            }
        }

        private void Matrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Кнопка очищает матрицу, если решение еще не начато, или возвращает к предыдущему шагу решения
        private void back_Click(object sender, EventArgs e)
        {
            if (step > 0)
            {
                step--;
                LoadMatrix();
                solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
            }
            else if (step == 0)
            {
                step--;
                solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                solveButton.Text = "Решить";
                backButton.Text = "Очистить";
                showBases();
            }
            else
            {
                FillMatrixWithZeros();
                solvingMatrixList.Clear();
            }
            
        }

        private void Matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Matrix.CurrentCell != null)
            {
                if (Matrix.CurrentCell.Value == null)
                    Matrix.CurrentCell.Value = '0';
                else
                {
                    int counter = 0;
                    foreach (char letter in Matrix.CurrentCell.Value.ToString())
                        if ((letter == '/') || (letter == '.'))
                            counter++;

                    if (new Regex(@"[^(0-9,/,.)]").IsMatch(Matrix.CurrentCell.Value.ToString()) || (counter > 1))
                        Matrix.CurrentCell.Value = Matrix.CurrentCell.Value.ToString().Remove(Matrix.CurrentCell.Value.ToString().Length - 1);

                    if (Matrix.CurrentCell.Value.ToString() != "")
                    {
                        if ((Matrix.CurrentCell.Value.ToString()[0] == '/') ||
                            (Matrix.CurrentCell.Value.ToString()[0] == '.'))
                            Matrix.CurrentCell.Value = Matrix.CurrentCell.Value = Matrix.CurrentCell.Value.ToString().Remove(0);
                        if ((Matrix.CurrentCell.Value.ToString()[Matrix.CurrentCell.Value.ToString().Length - 1] == '/') ||
                            (Matrix.CurrentCell.Value.ToString()[Matrix.CurrentCell.Value.ToString().Length - 1] == '.'))
                            Matrix.CurrentCell.Value = Matrix.CurrentCell.Value = Matrix.CurrentCell.Value.ToString().Remove(Matrix.CurrentCell.Value.ToString().Length - 1);
                    }

                    else
                        Matrix.CurrentCell.Value = '0';
                }
            }
        }

        private void solutionMethodBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (solutionMethodBox.Text == "Симплекс")
            {
                label6.Visible = true;
                bschek.Visible = true;
                if (bschek.Checked)
                    baseSolution.Visible = true;
            }
            else
            {
                label6.Visible = false;
                bschek.Visible = false;
                baseSolution.Visible = false;
            }

        }

        private void bschek_CheckedChanged(object sender, EventArgs e)
        {
            if (bschek.Checked)
                baseSolution.Visible = true;
            else
                baseSolution.Visible = false;
        }

        private void prevStepButton_Click(object sender, EventArgs e)
        {
            if (step > 0)
            {
                solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                step--;
                LoadMatrix();
                numberOfStep.Text = "Шаг N" + (step + 1).ToString();
            }
            else if (step == 0)
            {
                step--;
                solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                //solveButton.Text = "Решить";
                //backButton.Text = "Очистить";
                numberOfStep.Text = "Ввод...";
                showBases();
            }
            else
            {
                FillMatrixWithZeros();
                solvingMatrixList.Clear();
            }
        }

        private void nextStepButton_Click(object sender, EventArgs e)
        {
            if (step == -1)
            {
                step++;
                SaveMatrix();
                //solveButton.Text = "Далее";
                //backButton.Text = "Назад";
                numberOfStep.Text = "Шаг N" + (step + 1).ToString();
            }
            else
            {
                solvingMatrixList.Add(solvingMatrixList[solvingMatrixList.Count - 1].Transform(0, 0));

                step++;                
                LoadMatrix();
                //SaveMatrix();

                numberOfStep.Text = "Шаг N" + (step + 1).ToString();
            }
        }

        private void testb_Click(object sender, EventArgs e)
        {
            step = 0;
            LoadMatrix();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }
    }
}

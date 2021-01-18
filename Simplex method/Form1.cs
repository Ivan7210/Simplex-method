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
using System.IO;

namespace Simplex_method
{
    public partial class Form1 : Form
    {
        int numberOfUnknown = 3; //количество неизвестных
        int numberOfLimits = 3; //количество ограничений
        int maxNumberOfUnknown = 16; //максимальное количество неизвестных
        int maxNumberOfLimits = 16; //максимальное количество ограничений
        List<SolvingMatrix> solvingMatrixList = new List<SolvingMatrix>(); //Список матриц - этапов решения
        int step = -1; //Номер текущего шага решения
        int addedColumns = 0; //Количество дополнительных переменных
        int basisVars = 0; //Количество базисных переменных 
        bool[] vector; //Опорное решение
        Fraction[] function; //Изначальная функция для оптимизации
        bool end = false; //Завершен ли алгоритм решения
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
            solutionMethodBox.Text = "Иск. базиса";
            Matrix.Rows[3].Cells[0].Value = "F";
            //Matrix.Rows[0].Cells[1].Selected = true;
            undefineBasicElements();
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
            //NOTES
            //test.Text = (new Fraction(0.5) * 0.7).ToString();
            //Matrix.Rows[1].Cells[2].Style.BackColor = Color.Red;
            //Matrix.Rows[1].Cells[2].Style.SelectionBackColor = Color.Green;
            //Matrix.Rows[1].Cells[1].Style.SelectionBackColor = Color.White;
        }
        //Сохраняет вводимую матрицу
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
        }
        //Выводит матрицу из списка по номеру текущего шага
        private void LoadMatrix()
        {
            bool fractionsType; //true - обычные дроби, false - десятичные 
            if (fractionViewBox.Text == "Обычные")
                fractionsType = true;
            else
                fractionsType = false;

            textNumberOfLimits.Text = (solvingMatrixList[step].GetRowsAmount()-1).ToString();
            textNumberOfUnknown.Text = (numberOfUnknown = solvingMatrixList[step].GetColumnsAmount()-1).ToString();
            for (int i = 0; i < numberOfLimits+1; i++)
                for (int j = 0; j < numberOfUnknown+1; j++)
                {
                    if (fractionsType)
                        Matrix.Rows[i].Cells[j + 1].Value = solvingMatrixList[step].GetValue(i, j).ToString();
                    else
                        Matrix.Rows[i].Cells[j + 1].Value = solvingMatrixList[step].GetValue(i, j).ToDoubleString();
                }
        }
        //Скрывает базисные столбцы
        private void HideBasisColumns()
        {
            ShowAllColumns();
            if (step != -1)
                for (int row = 0; row < solvingMatrixList[step].GetRowsAmount() - 1; row++)
                {
                    int column = solvingMatrixList[step].Basis(row);
                    if (column != -1)
                        Matrix.Columns[column + 1].Visible = false;
                }
            if (solutionMethodBox.Text == "Иск. базиса")
            {
                for (int column = Matrix.Columns.Count - addedColumns - 1; column < Matrix.Columns.Count - 1; column++)
                    Matrix.Columns[column].Visible = false;
            }    

        }
        //Показывает все столбцы
        private void ShowAllColumns()
        {
            for (int column = 0; column < numberOfUnknown + 2; column++)
                Matrix.Columns[column].Visible = true;
        }
        //Блокирует ввод
        private void BlocInput()
        {
            textNumberOfUnknown.Enabled = false;
            textNumberOfLimits.Enabled = false;
            addUnknownButton.Enabled = false;
            addLimitButton.Enabled = false;
            subtractLimitButton.Enabled = false;
            subtractUnknownButton.Enabled = false;
            minMaxBox.Enabled = false;
            solutionMethodBox.Enabled = false;
            bschek.Enabled = false;
            bschek.Enabled = false;
            for (int column = 0; column < numberOfUnknown; column++)
                baseSolution.Columns[column].ReadOnly = true;
            for (int column = 1; column < numberOfUnknown + 2; column++)
                Matrix.Columns[column].ReadOnly = true;
        }
        //Разрешает ввод
        private void AllowInput()
        {
            textNumberOfUnknown.Enabled = true;
            textNumberOfLimits.Enabled = true;
            addUnknownButton.Enabled = true;
            addLimitButton.Enabled = true;
            subtractLimitButton.Enabled = true;
            subtractUnknownButton.Enabled = true;
            minMaxBox.Enabled = true;
            solutionMethodBox.Enabled = true;
            bschek.Enabled = true;
            bschek.Enabled = true;
            for (int column = 0; column < numberOfUnknown; column++)
                baseSolution.Columns[column].ReadOnly = false;
            for (int column = 1; column < numberOfUnknown + 2; column++)
                Matrix.Columns[column].ReadOnly = false;
        }
        //Заполняет матрицу нулями
        private void FillMatrixWithZeros()
        {
            for (int row = 0; row < numberOfLimits+1; row++)
                for (int column = 1; column < numberOfUnknown+2; column++)
                {
                    Matrix.Rows[row].Cells[column].Value = '0';
                }
        }
        //Заполняет опорное решение нулями
        private void FillBaseSolutionWithZeros()
        {
            for (int column = 0; column < numberOfUnknown; column++)
                baseSolution.Rows[0].Cells[column].Value = '0';
        }
        //Устанавливает опорное решение, если пользователь не ввел его сам
        private void SetupBaseSolutions()
        {
            for (int column = 0; column < numberOfUnknown; column++)
                baseSolution.Rows[0].Cells[column].Value = '1';
        }
        //Заполняет выбранную строку нулями
        private void FillRowWithZeros(int row)
        {
            for (int column = 1; column < numberOfUnknown + 2; column++)
                Matrix.Rows[row].Cells[column].Value = '0';
        }
        //Заполняет выбранный столбец нулями
        private void FillColumnWithZeros(int column)
        {
            if (column != 0)
                for (int row = 0; row < numberOfLimits + 1; row++)
                    Matrix.Rows[row].Cells[column].Value = '0';
            else
            {
                for (int row = 0; row < numberOfLimits; row++)
                    Matrix.Rows[row].Cells[0].Value = " ";
                Matrix.Rows[Matrix.Rows.Count - 1].Cells[0].Value = "F";
            }
        }
        //Выводит на экран базис текущей матрицы
        private void showBases()
        {
            if (step != -1)
                for (int b = 0; b < numberOfLimits + 1; b++)
                    Matrix.Rows[b].Cells[0].Value = solvingMatrixList[step].StringBasis(b);
            else
            {
                for (int b = 0; b < numberOfLimits; b++)
                    Matrix.Rows[b].Cells[0].Value = " ";
                Matrix.Rows[Matrix.Rows.Count - 1].Cells[0].Value = "F";
            }
        }
        //Определяет возможные опорные элементы
        private bool defineBasicElements()
        {
            bool flag = true;
            bool symplexFlag = true;
            bool flagNoBasisAtALL = true;

            for (int column = 0; column < numberOfUnknown + 1; column++)
            {
                bool anywayFlag = false;
                bool flagNoBasis = true;
                for (int row = 0; row < numberOfLimits + 1; row++)
                {
                    bool isBase;
                    if ((solutionMethodBox.Text == "Иск. базиса") && (step <= addedColumns))
                        isBase = solvingMatrixList[step].IsBaseElementArtificial(row, column, addedColumns);
                    else if ((solutionMethodBox.Text == "Симплекс") && (step <= basisVars))
                        isBase = solvingMatrixList[step].IsBaseElementBaseSolution(row, column, vector, anywayFlag) && (symplexFlag);
                    else
                        isBase = solvingMatrixList[step].IsBaseElement(row, column);

                    if ((row == numberOfLimits) || (column == numberOfUnknown))
                        isBase = false;
                    if (isBase)
                    {
                        Matrix.Rows[row].Cells[column + 1].Style.BackColor = Color.Orange;
                        Matrix.Rows[row].Cells[column + 1].Style.ForeColor = Color.Blue;
                        Matrix.Rows[row].Cells[column + 1].Style.SelectionBackColor = Color.Red;
                        Matrix.Rows[row].Cells[column + 1].Style.SelectionForeColor = Color.White;
                        if (flag)
                        {
                            if (Matrix.Rows[row].Cells[column + 1].Visible)
                            {
                                //Matrix.Rows[row].Cells[column + 1].Selected = true;
                                flag = false;
                            }
                        }
                        symplexFlag = false;
                        flagNoBasis = false;
                        flagNoBasisAtALL = false;
                    }
                    else
                    {
                        Matrix.Rows[row].Cells[column + 1].Style.SelectionBackColor = Color.White;
                        Matrix.Rows[row].Cells[column + 1].Style.SelectionForeColor = Color.Black;
                    }
                }
                if (column < numberOfUnknown)
                    if ((flagNoBasis) && (solutionMethodBox.Text == "Симплекс") && (step <= basisVars) && (vector[column]))
                        anywayFlag = true;

            }
            bool selection = true;
            for (int row = 0; row < Matrix.Rows.Count; row++)
                for (int column = 1; column < Matrix.Columns.Count - 1; column++)
                    if ((Matrix.Rows[row].Cells[column].Style.BackColor == Color.Orange) && (selection))
                    {
                        Matrix.Rows[row].Cells[column].Selected = true;
                        selection = false; 
                    }
                    
            if (flagNoBasisAtALL)
                return false;
            else
                return true;

        }
        //Очищает выборку опорных элементов
        private void undefineBasicElements()
        {
            for (int row = 0; row < numberOfLimits + 1; row++)
                for (int column = 0; column < numberOfUnknown + 1; column++)
                {
                    Matrix.Rows[row].Cells[column + 1].Style.BackColor = Color.White;
                    Matrix.Rows[row].Cells[column + 1].Style.ForeColor = Color.Black;
                    Matrix.Rows[row].Cells[column + 1].Style.SelectionBackColor = Color.Empty;
                    Matrix.Rows[row].Cells[column + 1].Style.SelectionForeColor = Color.White;
                }
        }
        //Добавляет одно неизвестное
        private void addUnknown_Click(object sender, EventArgs e)
        {
            if (numberOfUnknown < maxNumberOfUnknown)//При необходимости может быть увеличено до 2147483647
                numberOfUnknown++;
            textNumberOfUnknown.Text = numberOfUnknown.ToString();
            textNumberOfUnknown.SelectionStart = textNumberOfUnknown.Text.Length;
        }
        //Вычитает одно неизвестное
        private void subtractUnknown_Click(object sender, EventArgs e)
        {
            
            if (numberOfUnknown > 1)
                numberOfUnknown--;
            textNumberOfUnknown.Text = numberOfUnknown.ToString();
            textNumberOfUnknown.SelectionStart = textNumberOfUnknown.Text.Length;
        }
        //Добавляет одно ограничение
        private void addLimit_Click(object sender, EventArgs e)
        {
            if (numberOfLimits < maxNumberOfLimits)//При необходимости может быть увеличено до 2147483647
                numberOfLimits++;
            textNumberOfLimits.Text = numberOfLimits.ToString();
            textNumberOfLimits.SelectionStart = textNumberOfLimits.Text.Length;
        }
        //Вычитает одно ограничение
        private void subtractLimit_Click(object sender, EventArgs e)
        {
            if (numberOfLimits > 1)
                numberOfLimits--;
            textNumberOfLimits.Text = numberOfLimits.ToString();
            textNumberOfLimits.SelectionStart = textNumberOfLimits.Text.Length;
        }
        //Приводит фактическое количество столбцов в соответствие с их указанным количеством
        private void textNumberOfUnknown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(textNumberOfUnknown.Text) > maxNumberOfUnknown)
                    textNumberOfUnknown.Text = maxNumberOfUnknown.ToString();
                if (Int32.Parse(textNumberOfUnknown.Text) < 1)
                    textNumberOfUnknown.Text = 1.ToString();
            }
            catch
            {
                return;
            }

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
            
            //костыль
            if ((Matrix.Rows.Count > 0) && (Matrix.Columns.Count > 0))
                if (Matrix.Rows[0].Cells[0].Value != null)
                    if (Matrix.Rows[0].Cells[0].Value.ToString() == "0")
                        Matrix.Rows[0].Cells[0].Value = " ";
            
        }
        //Приводит фактическое количество строк в соответствие с их указанным количеством
        private void textNumberOfLimits_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(textNumberOfLimits.Text) > maxNumberOfLimits)
                    textNumberOfLimits.Text = maxNumberOfLimits.ToString();
                if (Int32.Parse(textNumberOfLimits.Text) < 1)
                    textNumberOfLimits.Text = 1.ToString();
            }
            catch
            {
                return;
            }
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
            
            //костыль
            if ((Matrix.Rows.Count > 0) && (Matrix.Columns.Count > 0))
                if (Matrix.Rows[0].Cells[0].Value != null)
                    if (Matrix.Rows[0].Cells[0].Value.ToString() == "0")
                        Matrix.Rows[0].Cells[0].Value = " ";
            
        }
        //Решает задачу в автоматическом режиме
        private void solve_Click(object sender, EventArgs e)
        {
            if (solutionMethodBox.Text != "Графический")
            {
                if (end)
                {
                    //Сохраняем решение
                }
                if (step == -1)
                {
                    if (solutionBegin())
                        while (!end)
                            solutionNextStep();
                }
                else
                    while (!end)
                        solutionNextStep();
            }
            else
            {
                solutionGrahp();
            }
        }
        //Не дает выбрать неподходящую ячейку при работе в пошаговом режиме
        private void Matrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Matrix.SelectedCells[0].Style.SelectionBackColor == Color.White)
                Matrix.SelectedCells[0].Selected = false;
        }
        //Кнопка очищает матрицу, если решение еще не начато, или возвращает к предыдущему шагу решения
        private void clear_Click(object sender, EventArgs e)
        {
            solutionCancel();
        }
        //Следит за тем, чтобы в ячейках матрицы оставались только допустимые значения
        private void Matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Matrix.CurrentCell != null)
                if ((Matrix.CurrentCell.Value == null))
                    Matrix.CurrentCell.Value = '0';
                else
                    if (Matrix.CurrentCell.OwningColumn.Index != 0)
                    {
                        if ((Matrix.CurrentCell.Value == null)||(Matrix.CurrentCell.Value.ToString() == ""))
                            Matrix.CurrentCell.Value = '0';
                        else
                        {
                            int counter = 0;
                            foreach (char letter in Matrix.CurrentCell.Value.ToString())
                                if ((letter == '/') || (letter == '.'))
                                    counter++;

                            if (new Regex(@"[^(0-9,/,.,\-)]").IsMatch(Matrix.CurrentCell.Value.ToString()) || (counter > 1))
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
            /*
            if ((Matrix.Rows.Count > 0)&&(Matrix.Columns.Count > 0))
                if (Matrix.Rows[0].Cells[0].Value != null)
                    if (Matrix.Rows[0].Cells[0].Value.ToString() == "0")
                        Matrix.Rows[0].Cells[0].Value = "";
            */
        }
        //Выводит/скрывает интерфейс для ввода базисного решения
        private void bschek_CheckedChanged(object sender, EventArgs e)
        {
            if (bschek.Checked)
                baseSolution.Visible = true;
            else
                baseSolution.Visible = false;
        }
        //Подсчитывает необходимое количество базисных элементов
        private int ammountOfBasisVar()
        {
            int counter = 0;
            for (int column = 0; column < numberOfUnknown; column++)
                if (baseSolution.Rows[0].Cells[column].Value.ToString() == "1")
                    counter++;
            return counter;
        }
        //Возвращает разницу между рангом матрицы и количеством выбранных базисных переменных
        private int chekBaseSolutionСorrectness()
        {
            int counter = ammountOfBasisVar();
            int matrixRank = solvingMatrixList[0].rank();
            return counter - matrixRank;
        }
        //Начинает решение задачи
        private bool solutionBegin()
        {
            addedColumns = 0;
            ShowAllColumns();
            undefineBasicElements();

            step = 0;
            SaveMatrix();

            SolvingMatrix result = solvingMatrixList[solvingMatrixList.Count - 1].Copy();

            if (result.isDegenerate())
            {
                step = -1;
                return false;
            }

            result = result.RemoveDependent();
            result = result.Standardization();

            if (minMaxBox.Text == "max")
                result = result.minToMax();
            function = new Fraction[result.GetColumnsAmount()];
            for (int column = 0; column < result.GetColumnsAmount(); column++)
                function[column] = result.GetValue(result.GetRowsAmount() - 1, column);

            if (solutionMethodBox.Text == "Иск. базиса")
                result = result.ArtificialBasis();
            solvingMatrixList.Add(result);
            

           

            step = 1;

            if (solutionMethodBox.Text == "Иск. базиса")
                addedColumns = solvingMatrixList[1].GetColumnsAmount() - solvingMatrixList[0].GetColumnsAmount();
            


            if (solutionMethodBox.Text == "Симплекс")
            {
                basisVars = solvingMatrixList[0].rank();
                if (!bschek.Checked)
                    SetupBaseSolutions();
                vector = new bool[numberOfUnknown];
                for (int column = 0; column < numberOfUnknown; column++)
                    if (baseSolution.Rows[0].Cells[column].Value.ToString() == "1")
                        vector[column] = true;
                    else
                        vector[column] = false;
                
                
            }    



                //Проверяем и подготавливаем опорное решение
                if (solutionMethodBox.Text == "Симплекс")
                if (bschek.Checked)
                {
                    int dif = chekBaseSolutionСorrectness();
                    if (dif != 0)
                    {
                        MessageBox.Show(
                            "Ранг матрицы = " + solvingMatrixList[0].rank().ToString() + " не совпадает с числом заданных базисных переменных = " + (solvingMatrixList[0].rank() + dif).ToString() + ".",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        solutionCancel();
                        return false;
                    }
                }
                else
                    SetupBaseSolutions();
            

            LoadMatrix();
            clearButton.Text = "В начало";
            BlocInput();
            numberOfStep.Text = "Шаг N" + step.ToString();
            showBases();
            if (hideBasisColunmsChek.Checked)
                HideBasisColumns();

            end = !defineBasicElements();

            if (end)
                solutionEnd();
            return true;
        }
        //Возвращает к этапу ввода значений
        private void solutionCancel()
        {
            solutionContinue();
            ShowAllColumns();
            undefineBasicElements();

            if (step == -1)
            {
                FillMatrixWithZeros();
                showBases();
            }
            else
            {
                step = 0;
                LoadMatrix();
                step = -1;
                solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                numberOfStep.Text = "Ввод...";
                clearButton.Text = "Очистить";
            }
            solvingMatrixList.Clear();
            AllowInput();
            FillBaseSolutionWithZeros();
            showBases();
            if (solutionMethodBox.Text == "Графический")
            {
                Graphics graphic = schedule.CreateGraphics();
                graphic.Clear(Color.White);
            }    
        }
        //Заканчивает решение и выводит ответ
        private void solutionEnd()
        {
            if (step < basisVars && solutionMethodBox.Text == "Симплекс")
            {
                Log.Text = "Недопустимое опорное решение";
                return;
            }
            else if (addedColumns != 0)
                Log.Text = "Нет решений";
            else
                Log.Text = solvingMatrixList[solvingMatrixList.Count - 1].Answer(minMaxBox.Text == "min", fractionViewBox.Text == "Десятичные");
            numberOfStep.Text = "Решено";
            //solveButton.Text = "Сохранить";
        }
        //Используется когда решение продолжается
        private void solutionContinue()
        {
            Log.Text = "";
            solveButton.Text = "Решить";
            end = false;
        }
        //Обрабатывает следующий шаг решения
        private void solutionNextStep()
        {
                if (end)
                    return;
                if ((Matrix.CurrentCell != null) && (Matrix.CurrentCell.OwningColumn.Index >= 0) && (Matrix.CurrentCell.OwningRow.Index >= 0))
                    if (Matrix.CurrentCell.Style.SelectionBackColor != Color.White)
                    {

                        ShowAllColumns();
                        undefineBasicElements();
                        SolvingMatrix result = solvingMatrixList[solvingMatrixList.Count - 1].Copy();
                        result = result.Transform(Matrix.CurrentCell.OwningRow.Index, Matrix.CurrentCell.OwningColumn.Index - 1);
                        if ((step == addedColumns) && (solutionMethodBox.Text == "Иск. базиса"))
                        {
                            int numberOfColumns = result.GetColumnsAmount();
                            for (int column = numberOfColumns - addedColumns - 1; column < numberOfColumns - 1; column++)
                            {
                                result = result.RemoveColumn(column);
                                column--;
                                numberOfColumns--;
                            }
                            addedColumns = 0;
                            result = result.CalculateStep2Function(function);
                        }

                        //...
                        //if (solutionMethodBox.Text == "Симплекс")
                        result = result.Standardization(addedColumns);
                        //...

                        solvingMatrixList.Add(result);
                        step++;
                        LoadMatrix();

                        numberOfStep.Text = "Шаг N" + step.ToString();
                        showBases();

                        end = !defineBasicElements();

                        if (end)
                            solutionEnd();
                    //...
                    //if (solutionMethodBox.Text == "Симплекс")
                    //if ((!result.IsAlowed())&&((step > basisVars)&&(solutionMethodBox.Text == "Симплекс"))|| ((step> addedColumns) && (solutionMethodBox.Text == "Иск. базиса")))
                        if (!result.IsAlowed())
                        {
                            end = true;
                            solutionEnd();
                            if (solutionMethodBox.Text == "Симплекс")
                                Log.Text = "Недопустимое опорное решение";
                            else
                                Log.Text = "Нет решений";
                        }
                        //...


                        if (hideBasisColunmsChek.Checked)
                            HideBasisColumns();
                    }
        }
        //Возвращает на предыдущий шаг решения
        private void solutionPrevStep()
        {

                solutionContinue();
                if (step == -1)
                    solutionCancel();
                else
                {
                    if ((addedColumns == 0) && (solutionMethodBox.Text == "Иск. базиса") && (step <= 1 + solvingMatrixList[1].GetColumnsAmount() - solvingMatrixList[0].GetColumnsAmount()))
                        addedColumns = solvingMatrixList[1].GetColumnsAmount() - solvingMatrixList[0].GetColumnsAmount();
                    ShowAllColumns();
                    undefineBasicElements();
                    solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                    step--;
                    LoadMatrix();
                    defineBasicElements();
                    numberOfStep.Text = "Шаг N" + step.ToString();
                    if (hideBasisColunmsChek.Checked)
                        HideBasisColumns();
                    showBases();

                }
            
        }
        //Возвращает на предыдущий шаг решения (кнопка)
        private void prevStepButton_Click(object sender, EventArgs e)
        {
            if (solutionMethodBox.Text != "Графический")
            {
                end = false;
                if (step <= 1)
                    solutionCancel();
                else
                {
                    solutionPrevStep();
                }
            }
            else
                solutionCancel();
        }
        //Обрабатывает следующий шаг решения (кнопка)
        private void nextStepButton_Click(object sender, EventArgs e)
        {
            if (solutionMethodBox.Text != "Графический")
            {
                if (step == -1)
                    solutionBegin();
                else
                {
                    solutionNextStep();
                }
            }
            else
                solutionGrahp();
        }
        //Сохраняет текущую матрицу в файл
        private void saveButton_Click(object sender, EventArgs e)
        {
            String path = null;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = dialog.FileName;
                    
                    using (FileStream fs = File.Create(path))
                    {
                        step++;
                        SaveMatrix();
                        byte[] info;
                        if (fractionViewBox.Text == "Обычные")
                            info = new UTF8Encoding(true).GetBytes(solvingMatrixList[step].ToString());
                        else
                            info = new UTF8Encoding(true).GetBytes(solvingMatrixList[step].ToDoubleString());
                        solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                        step--;
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        showBases();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            ex.ToString(),
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                }
            }
            
        }
        //Загружает матрицу из файла
        private void loadButton_Click(object sender, EventArgs e)
        {
            addedColumns = 0;
            solutionContinue();
            //solutionCancel();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String matrix = File.ReadAllText(dialog.FileName);
                    solvingMatrixList.Clear();
                    
                    solvingMatrixList.Add(new SolvingMatrix(matrix));
                    bool buff = hideBasisColunmsChek.Checked;
                    step = -1;
                    hideBasisColunmsChek.Checked = false;
                    step = 0;
                    LoadMatrix();
                    step = -1;
                    hideBasisColunmsChek.Checked = buff;
                    numberOfStep.Text = "Ввод...";
                    clearButton.Text = "Очистить";
                    solvingMatrixList.RemoveAt(solvingMatrixList.Count - 1);
                    AllowInput();
                    ShowAllColumns();
                    undefineBasicElements();
                    showBases();
                    if (solutionMethodBox.Text == "Графический")
                    {
                        Graphics graphic = schedule.CreateGraphics();
                        graphic.Clear(Color.White);
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(
                           ex.ToString(),
                           "Ошибка",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1);
                }
                
            }
            


        }
        //В реальном времени изменяет вид дробей используемых в решении
        private void fractionViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (step != -1)
                LoadMatrix();
            if (end)
                Log.Text = solvingMatrixList[solvingMatrixList.Count - 1].Answer(minMaxBox.Text == "min", fractionViewBox.Text == "Десятичные");
        }
        //Скрывает/показывает базисные столбцы
        private void hideBasisColunmsChek_CheckedChanged(object sender, EventArgs e)
        {
            if (step != -1)
                if (hideBasisColunmsChek.Checked)
                    HideBasisColumns();
                else
                    ShowAllColumns();
        }
        //Следит за тем, чтобы в опорном решении были только допустимые значения
        private void baseSolution_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (baseSolution.CurrentCell != null)
                if ((baseSolution.CurrentCell.Value.ToString() != "0") && (baseSolution.CurrentCell.Value.ToString() != "1"))
                    if ((baseSolution.CurrentCell.Value.ToString() == "2")||
                        (baseSolution.CurrentCell.Value.ToString() == "3")||
                        (baseSolution.CurrentCell.Value.ToString() == "4") ||
                        (baseSolution.CurrentCell.Value.ToString() == "5") ||
                        (baseSolution.CurrentCell.Value.ToString() == "6") ||
                        (baseSolution.CurrentCell.Value.ToString() == "7") ||
                        (baseSolution.CurrentCell.Value.ToString() == "8") ||
                        (baseSolution.CurrentCell.Value.ToString() == "9"))
                        baseSolution.CurrentCell.Value = "1";
                else
                        baseSolution.CurrentCell.Value = "0";
        }
        //Следит за корректной отрисовкой элементов интерфейса для разных методов решения
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
            if ((solutionMethodBox.Text == "Графический")&&(step == -1))
            {
                if (schedule.Visible == false)
                {
                    schedule.Visible = true;
                    coordinates.Visible = true;
                    Matrix.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                    this.Size = new System.Drawing.Size(this.Size.Width + this.Size.Height, this.Size.Height);
                }
            }
            else if (step == -1)
            {
                schedule.Visible = false;
                coordinates.Visible = false;
                this.Size = new System.Drawing.Size(this.Size.Width - schedule.Width, this.Size.Height);
                Matrix.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            }

        }
        //Выводит справку
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "В первую очередь необходимо ввести количество неизвестных и количество ограничений в предназначенные для них поля. Это можно сделать как в ручную, так и при помощи кнопок +/- рядом с ними.\n"
                                + "Затем необходимо ввести задачу линнейного программирования в канонической форме записи в таблицу справа, а также задать следующие параметры:\n"
                                + "Задача оптимизации - максимизировать или минимизировать значение функции\n"
                                + "Вид дробей - какие дроби использовать при выводе информации(при вводе можно использовать любые)\n"
                                + "Метод решения: доступны симплекс метод, метод искусственного базиса и графический метод\n"
                                + "При решении симплекс методом можно задать опорное решение. Если его не задовать, программа использует опорное решение по умолчанию.\n"
                                + "В зависимости от вашего выбора можно скрыть или показать базисные столбцы.\n\n"
                                + "Для того, чтобы приступить к решению, используйте навигатор под матрицей.\n"
                                + "Кнопка >> открывает следующий шаг решения, кнопка << возвращает к предыдущему. При пошаговом решении выбирайте опорный элемент(выделен красным) из доступных(выделены оранжевым), кликая по нему.\n"
                                + "Кнопка 'Решить' дорешивает задачу с текущего шага в автономном режиме.\n"
                                + "Кнопка 'В начало' вернет вас к вводу задачи, а повторное нажатие заполнит матрицу нулями.\n"
                                + "В графическом методе при наведении мыши на экран в нижнем левом углу графика появляются координаты точки, на которую направлен курсор, а при проктутку колеса мыши изменяется масштаб изображения.",

                            "Справка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);
        }
        //Выводит информацию о программе
        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "Данная программа предназначена для решения задач линнейного программирования при помощи симплекс метода и метода искусственного базиса.\n\nАвтор программы:\nстудент ЯрГУ им.П.Г.Демидова\nфакультета ИВТ\nгруппы ИТ - 32\nМещеряков Иван Андреевич",
                            "О программе",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }

        //
        //Далее идут переменные и методы, требующееся для графического решения
        //

        //Общая функция решающая задачу графически
        private void solutionGrahp()
        {
            step = 0;
            solutionMethodBox.Text = "Иск. базиса";
            step = -1;
            if (solutionBegin())
            {
                
                while (!end)
                    solutionNextStep();
                solutionMethodBox.Text = "Графический";
                step++;
                SolvingMatrix canonicalView = solvingMatrixList[0].ToGraphSolution();
                if (canonicalView == null)
                {
                    MessageBox.Show(
                    "Данная задача не разрешима графическим методом",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    solutionCancel();
                    return;
                }
                else
                {
                    solvingMatrixList.Add(canonicalView);
                    LoadMatrix();
                    showBases();
                    hideBasisColunmsChek.Checked = false;
                    hideBasisColunmsChek.Checked = true;
                    /*
                    String answer = "";
                    int commas = 0;
                    int index = 0;
                    bool read = true;
                    while(index < Log.Text.Length)
                    {
                        
                        if (Log.Text[index] == ',')
                            commas++;
                        if ((commas == 2)&&(Log.Text[index] == ','))
                            read = false;
                        if (Log.Text[index] == '}')
                            read = true;
                        if (read)
                            answer += Log.Text[index];
                        index++;
                    }
                    Log.Text = answer;
                    */
                    Render();
                }
            }
            else
            {
                MessageBox.Show(
                "Данная задача не разрешима графическим методом",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                solutionCancel();
                return;
            }
        }


        int shiftX = 0;//Сдвиг по координате x
        int shiftY = 0;//Сдвиг по координате y

        //Конвертирует координату 'x' графика в координату 'x' DrawImage
        private int xConvert (int x)
        {
            return x + schedule.Width / 2 + shiftX;
        }
        //Конвертирует координату 'y' графика в координату  'y' DrawImage
        private int yConvert(int y)
        {
            return -y + schedule.Height / 2 - shiftY;
        }
        //Конвертирует координату 'x' DrawImage в координату 'x' графика
        private int xDeConvert(int x)
        {
            return x - schedule.Width / 2 - shiftX;
        }
        //Конвертирует координату 'y' DrawImage в координату 'y' графика
        private int yDeConvert(int y)
        {
            return -y + schedule.Height / 2 - shiftY;
        }

        double scale = 10;//Масштаб изображения

        //k1 * x1 + k2 * x2 - b = 0
        //x1 = (b - k2 * x2) / k1
        //x2 = (b - k1 * x1) / k2

        //Находит Х1 по X2
        private int X1(Fraction k1, Fraction k2, Fraction b, int x2)
        {
            return ((b - k2 * new Fraction(x2/scale)) / k1).pixel(scale);
        }
        //Находит Х2 по X1
        private int X2(Fraction k1, Fraction k2, Fraction b, int x1)
        {
            return ((b - k1 * new Fraction(x1/scale)) / k2).pixel(scale);
        }
        //Находит значение функции в точке и проверяет, удовлетворяет ли оно заданному условию
        private bool F(Fraction k1, Fraction k2, Fraction b, double x, double y)
        {
            return (k1 * x + k2 * y <= b);
        }
        //Узнает координату x1 точки-ответа
        private int x1Answer()
        {
            Fraction x1;
            String value = "";
            int index = 0;
            bool read = false;
            while (index < Log.Text.Length)
            {
                if (Log.Text[index] == ',')
                    break;
                if (read)
                    value += Log.Text[index];
                if (Log.Text[index] == '{')
                    read = true;
                index++;
            }

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
            if (inputMode)
            {
                NumberFormatInfo formatProvider = new NumberFormatInfo();
                formatProvider.NumberDecimalSeparator = ".";
                x1 = new Fraction(Convert.ToDouble(value, formatProvider));
            }
            else
            {
                int numerator = Convert.ToInt32(value.Split('/')[0]);
                int denominator = 1;
                if (value.Split('/').Length > 1)
                    denominator = Convert.ToInt32(value.Split('/')[1]);
                x1 = new Fraction(numerator, denominator);
            }

            //int check = xConvert(x1.pixel(scale));
            return (xConvert(x1.pixel(scale)));
        }
        //Узнает координату x2 точки-ответа
        private int x2Answer()
        {
            Fraction x2;
            String value = "";
            int index = 0;

            bool read = false;
            while (index < Log.Text.Length)
            {
                if (((Log.Text[index] == ',') || (Log.Text[index] == '}')) && (read))
                    break;
               

                if (read)
                    value += Log.Text[index];
                if ((Log.Text[index] == ',') && (!read))
                {
                    read = true;
                    index++;
                }

                index++;
            }

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
            if (inputMode)
            {
                NumberFormatInfo formatProvider = new NumberFormatInfo();
                formatProvider.NumberDecimalSeparator = ".";
                x2 = new Fraction(Convert.ToDouble(value, formatProvider));
            }
            else
            {
                int numerator = Convert.ToInt32(value.Split('/')[0]);
                int denominator = 1;
                if (value.Split('/').Length > 1)
                    denominator = Convert.ToInt32(value.Split('/')[1]);
                x2 = new Fraction(numerator, denominator);
            }

            return (yConvert(x2.pixel(scale)));
        }

        //Рисует графики
        private void Render()
        {
            Graphics graphic = schedule.CreateGraphics();
            graphic.Clear(Color.White);
            Pen pen;
            SolidBrush drawBrush;

            if (step != -1)
            {
                SolvingMatrix matrix = solvingMatrixList[step];

                //Штрихуем область
                if (!matrix.isStrict()) // не штрихуем если условия строгие
                    for (int xSch = 0; xSch < schedule.Width; xSch++)
                        for (int ySch = 0; ySch < schedule.Height; ySch++)
                        {
                       
                            double x = Convert.ToDouble(xDeConvert(xSch)) / scale;
                            double y = Convert.ToDouble(yDeConvert(ySch)) / scale;
                            bool isAllowed = true;
                            bool isEqual = true;
                            for (int row = 0; row < matrix.GetRowsAmount() - 1; row++)
                            {
                                Fraction k1 = matrix.GetValue(row, 0);
                                Fraction k2 = matrix.GetValue(row, 1);
                                Fraction b = matrix.GetValue(row, matrix.GetColumnsAmount() - 1);
                                if (!F(k1, k2, b, x, y))/* && (matrix.GetValue(row, row + 2) != 0))*/
                                    isAllowed = false;
                            }

                            if (x > 0 && y > 0 && isAllowed && (xSch + ySch)%4 < 2)//все условия выполнены
                                graphic.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(xSch, ySch, 1, 1));

                        }

                //Рисуем разметку (оси)
                pen = new Pen(Color.Black);
                drawBrush = new SolidBrush(Color.Black);
                graphic.DrawLine(pen, xConvert(0), yConvert(schedule.Height / 2), xConvert(0), yConvert(-schedule.Height / 2));
                graphic.DrawLine(pen, xConvert(schedule.Width / 2), yConvert(0), xConvert(-schedule.Width / 2), yConvert(0));
                //graphic.DrawLine(pen, schedule.Width / 2, 0, schedule.Width / 2, schedule.Height);
                //graphic.DrawLine(pen, 0, schedule.Height / 2, schedule.Width, schedule.Height / 2);
                graphic.DrawLine(pen, xConvert(0), yConvert(schedule.Height / 2), xConvert(-5), yConvert(schedule.Height / 2 - 5));
                graphic.DrawLine(pen, xConvert(0), yConvert(schedule.Height / 2), xConvert(5), yConvert(schedule.Height / 2 - 5));
                graphic.DrawLine(pen, xConvert(schedule.Width / 2), yConvert(0), xConvert(schedule.Width / 2 - 5), yConvert(-5));
                graphic.DrawLine(pen, xConvert(schedule.Width / 2), yConvert(0), xConvert(schedule.Width / 2 - 5), yConvert(5));
                graphic.DrawString("x2", new Font("Arial", 10), drawBrush, xConvert(0), yConvert(schedule.Height / 2), new StringFormat());
                graphic.DrawString("x1", new Font("Arial", 10), drawBrush, xConvert(schedule.Width / 2 - 20), yConvert(0), new StringFormat());

                for (int pos = xConvert(0); pos < xConvert(schedule.Width / 2); pos += Convert.ToInt32(scale))
                    graphic.DrawLine(pen, pos, yConvert(0) + 2, pos, yConvert(0) - 2);
                for (int pos = xConvert(0); pos > xConvert(-(schedule.Width / 2)); pos -= Convert.ToInt32(scale))
                    graphic.DrawLine(pen, pos, yConvert(0) + 2, pos, yConvert(0) - 2);
                for (int pos = yConvert(0); pos > yConvert(schedule.Height / 2); pos -= Convert.ToInt32(scale))
                    graphic.DrawLine(pen, xConvert(0) + 2, pos, xConvert(0) - 2, pos);
                for (int pos = yConvert(0); pos < yConvert(-(schedule.Height / 2)); pos += Convert.ToInt32(scale))
                    graphic.DrawLine(pen, xConvert(0) + 2, pos, xConvert(0) - 2, pos);


                //Рисуем линии графиков
                pen = new Pen(Color.Red);
                //pen.Width = 3;

                for (int row = 0; row < matrix.GetRowsAmount()-1; row++)
                {
                    int x1Start;
                    int x1Finish;
                    int x2Start;
                    int x2Finish;
                    Fraction k1 = matrix.GetValue(row, 0);
                    Fraction k2 = matrix.GetValue(row, 1);
                    Fraction b = matrix.GetValue(row, matrix.GetColumnsAmount() - 1);
                    if (k2 != 0)
                    {
                        x1Start = xConvert(-schedule.Width / 2);
                        x1Finish = xConvert(schedule.Width / 2);
                        x2Start = yConvert(X2(k1, k2, b, -schedule.Width / 2));
                        x2Finish = yConvert(X2(k1, k2, b, schedule.Width / 2));
                    }
                    else
                    {
                        x2Start = yConvert(-schedule.Height / 2);
                        x2Finish = yConvert(schedule.Height / 2);
                        x1Start = xConvert(X1(k1, k2, b, -schedule.Height / 2));
                        x1Finish = xConvert(X1(k1, k2, b, schedule.Height / 2));
                    }
                    graphic.DrawLine(pen, x1Start, x2Start, x1Finish, x2Finish);
                }

                

                //Рисуем вектор нормали
                pen = new Pen(Color.Purple);
                pen.Width = 2;
                Fraction v1;
                Fraction v2;
                if (minMaxBox.Text == "max")
                {
                    v1 = matrix.GetValue(matrix.GetRowsAmount() - 1, 0);
                    v2 = matrix.GetValue(matrix.GetRowsAmount() - 1, 1);
                }
                else
                {
                    v1 = matrix.GetValue(matrix.GetRowsAmount() - 1, 0)*-1;
                    v2 = matrix.GetValue(matrix.GetRowsAmount() - 1, 1)*-1;
                }

                Double vSize = Math.Sqrt(Math.Pow(v1.ToDouble(), 2) + Math.Pow(v2.ToDouble(), 2));
                graphic.DrawLine(pen, xConvert(0), yConvert(0), xConvert(((v1 * 2 / vSize).pixel(scale))), yConvert((v2 * 2 / vSize).pixel(scale)));
                
                //Обозначим точку-ответ
                //pen = new Pen(Color.Green);
                drawBrush = new SolidBrush(Color.Blue);
                Rectangle rect = new Rectangle(x1Answer()-3, x2Answer()-3, 7, 7);
                graphic.FillEllipse(drawBrush, rect);
            }
        }

        //Перерисовывает графики при изменении размера экрана
        private void schedule_SizeChanged(object sender, EventArgs e)
        {
            Render();
        }
        //Перерисовывает графики при изменении размера экрана
        private void schedule_Resize(object sender, EventArgs e)
        {
            Render();
        }

        bool mouseIn = false; //true, если указатель мыши внутри окна графика
        //Когда мышь входит в экран, mouseIn становится true
        private void schedule_MouseEnter(object sender, EventArgs e)
        {
            mouseIn = true;
            //coordinates.Text = Cursor.Position.X.ToString() + ", " + Cursor.Position.Y.ToString();
            //Log.Text = mouseIn.ToString();
        }
        //Когда мышь покидает экран, mouseIn становится false
        private void schedule_MouseLeave(object sender, EventArgs e)
        {
            mouseIn = false;
            coordinates.Text = "     ";
            //Log.Text = mouseIn.ToString();
        }
        //Изменяет масштаб, когда пользователь прокручивает колесико мыши
        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseIn)
            {
                int delta = 0;
                if (e.Delta > 0)
                    delta = 10;
                if (e.Delta < 0)
                    delta = -10;
                scale += delta;
                if (scale < 10)
                {
                    scale = 10;
                    delta = 0;
                }
                //Log.Text = scale.ToString();
                if (delta != 0)
                    Render();
            }
        }
        //Выводит на экран координаты точки, на которую указывает пользователь
        private void schedule_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIn)
            coordinates.Text = Math.Round(Convert.ToDouble(xDeConvert(e.Location.X) / scale), 2).ToString() + " : " + Math.Round(Convert.ToDouble(yDeConvert(e.Location.Y) / scale), 2).ToString();
        }
    }
}

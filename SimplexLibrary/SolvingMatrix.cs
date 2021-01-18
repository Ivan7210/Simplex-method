using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SimplexLibrary
{
    public class SolvingMatrix
    {
        private int rows; //количество строк
        private int columns; //количество столбцов
        private Fraction[,] matrix; //матрица, в которой происходят вычисления
        //Конструкторы
        public SolvingMatrix(Fraction[,] matrix)
        {
            this.rows = matrix.GetLength(0);
            this.columns = matrix.GetLength(1);
            this.matrix = matrix;
        }
        public SolvingMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new Fraction[rows, columns];
        }
        //Делает копию объекта
        public SolvingMatrix Copy()
        {
            Fraction[,] copyMatrix = new Fraction[this.rows, this.columns];
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                    copyMatrix[row, column] = this.matrix[row, column];
            return new SolvingMatrix(copyMatrix);
        }
        //Возвращает количество строк
        public int GetRowsAmount()
        {
            return this.rows;
        }
        //Возвращает количество столбцов
        public int GetColumnsAmount()
        {
            return this.columns;
        }
        //Возвращает значение в ячейке с указанными индексами
        public Fraction GetValue(int row, int column)
        {
            if ((row > -1) && (row < rows) && (column > -1) && (column < columns))
                return matrix[row, column];
            else
                return null;
        }
        //Возвращает индекс столбца базиса для выбранной строки
        public int Basis(int inRow)
        {
            int basis = -1;
            for (int column = 0; column < columns - 1; column++)
                if (this.GetValue(inRow, column) != 0)//== 1
                {
                    basis = column;
                    for (int row = 0; row < rows; row++)
                        if ((this.GetValue(row, column) != 0) && (row != inRow))
                        {
                            basis = -1;
                            break;
                        }
                    if (basis != -1)
                        return basis;
                }
            return basis;
        }
        //Возвращает строковое представление базиса для выбранной строки
        public String StringBasis(int inRow)
        {
            if (inRow == rows - 1)
                return "F";
            int basis = Basis(inRow);
            if (basis != -1)
                return 'x' + (basis + 1).ToString();
            else
                return "";
        }
        //Осуществляет переход к базису с выбранным опорным элементом
        public SolvingMatrix Transform(int targetRow, int targetColumn)
        {
            Fraction targetElement = this.matrix[targetRow, targetColumn];
            if (targetElement == 0)
                return null; //Если выбранный опорный элемент равен 0, преобразование невоможно
            SolvingMatrix result = this.Copy();
            //Делим row на опорный элемент
            for (int column = 0; column < columns; column++)
                result.matrix[targetRow, column] /= targetElement;
            //Обнуляем столбец
            for (int row = 0; row < rows; row++)
            {
                Fraction k = result.matrix[row, targetColumn];
                if (row != targetRow)
                    for (int column = 0; column < columns; column++)
                        result.matrix[row, column] -= k * result.matrix[targetRow, column];
            }
            return result;
        }
        //Проверяет, является ли матрица пустой
        public bool isDegenerate()
        {
            for (int row = 0; row < this.rows; row++)
                for (int column = 0; column < this.columns; column++)
                    if (this.matrix[row, column] != 0)
                        return false;
            return true;
        }
        //Проверяет, является ли полученное решение допустимым
        public bool IsAlowed()
        {
            for (int row = 0; row < this.rows - 1; row++)
                if (this.matrix[row, this.columns - 1] < 0)
                    return false;
            return true;
        }

        //Возвращает максимальную длину строкового представления дроби в столбце. Используестя для построения красивого текстового вывода в файл.
        private int MaxLength(int column, bool fractionsType) ////Если false, то вывод в формате x/y, иначе вывод в формате double
        {
            int max = 0;
            if (column != -1)
                for (int row = 0; row < rows; row++)
                    //for (int column = 0; column < columns; column++)
                    if (fractionsType)
                    {
                        if (this.matrix[row, column].ToDoubleString().Length > max)
                            max = this.matrix[row, column].ToDoubleString().Length;
                    }
                    else
                    {
                        if (this.matrix[row, column].ToString().Length > max)
                            max = this.matrix[row, column].ToString().Length;
                    }
            else
            {
                for (int row = 0; row < rows; row++)
                    if (this.StringBasis(row).Length > max)
                        max = this.StringBasis(row).Length;
            }
            return max;
        }
        //Удаляет строку по индексу
        public SolvingMatrix RemoveRow(int targetRow)
        {
            SolvingMatrix result = new SolvingMatrix(this.rows - 1, this.columns);
            for (int row = 0; row < result.rows; row++)
                for (int column = 0; column < result.columns; column++)
                    if (row < targetRow)
                        result.matrix[row, column] = this.matrix[row, column];
                    else
                        result.matrix[row, column] = this.matrix[row+1, column];
            return result;
        }
        //Удаляес столбец по индексу
        public SolvingMatrix RemoveColumn(int targetColumn)
        {
            SolvingMatrix result = new SolvingMatrix(this.rows, this.columns-1);
            for (int row = 0; row < result.rows; row++)
                for (int column = 0; column < result.columns; column++)
                    if (column < targetColumn)
                        result.matrix[row, column] = this.matrix[row, column];
                    else
                        result.matrix[row, column] = this.matrix[row, column+1];
            return result;
        }
        //Проверяет, является ли выбранный столбец базисным
        private bool IsBasisColumn(int targetColumn)
        {
            if (targetColumn >= this.columns)
                return false;
            int counter = 0;
            for (int row = 0; row < this.rows; row++)
                if (this.matrix[row, targetColumn] != null)
                    if (this.matrix[row, targetColumn] != 0)
                        counter++;
            if (counter == 1)
            {
                counter = 0;
                for (int row = 0; row < this.rows; row++)
                    if (this.matrix[row, targetColumn] != null)
                        if (this.matrix[row, targetColumn] == 1)
                            counter++;
                if (counter == 1)
                    return true;
            }

            return false;
        }
        //Осуществляет переход к искусственному базису
        public SolvingMatrix ArtificialBasis()
        {
            int count = 0;
            for (int row = 0; row < this.rows - 1; row++)
                if (this.Basis(row) != -1)
                    count++;
            SolvingMatrix result = new SolvingMatrix(this.rows, this.columns + this.rows - 1);
            for (int row = 0; row < this.rows; row++)
                for (int column = 0; column < this.columns - 1; column++)
                    result.matrix[row, column] = this.matrix[row, column];

            for (int column = this.columns - 1; column < result.columns - 1; column++)
                for (int row = 0; row < result.rows; row++)
                    if (column - this.columns + 1 == row)
                    {
                        result.matrix[row, column] = new Fraction(1);
                    }
                    else
                        result.matrix[row, column] = new Fraction(0);


            for (int row = 0; row < this.rows; row++)
                result.matrix[row, result.columns-1] = this.matrix[row, this.columns-1];

            //Считаем F

            for (int column = 0; column < result.columns; column++)
                result.matrix[result.rows - 1, column] = new Fraction(0);

            for (int row = 0; row < this.rows - 1; row++)
                for (int column = 0; column < this.columns - 1; column++)
                        result.matrix[result.rows - 1, column] -= this.matrix[row, column];
          
            for (int row = 0; row < this.rows - 1; row++)
                result.matrix[result.rows - 1, result.columns - 1] -= this.matrix[row, this.columns - 1];



            return result;
        }
        //Осуществляет переход к изначальной функции после решения искусственного базиса
        public SolvingMatrix CalculateStep2Function(Fraction[] step1)
        {
            SolvingMatrix result = this.Copy();
            
            for (int column = 0; column < result.columns; column++)
                result.matrix[result.rows - 1, column] = new Fraction(0);

            for (int column = 0; column < step1.Length; column++)
            {
                if (this.IsBasisColumn(column))
                {
                    int targetRow = 0;
                    while (this.matrix[targetRow, column] == 0)
                        targetRow++;
                    if (this.Basis(targetRow) == column)
                    {
                        for (int targetColumn = 0; targetColumn < step1.Length; targetColumn++)
                            if (!((this.IsBasisColumn(targetColumn)&&(this.Basis(targetRow) == targetColumn)))||(targetColumn == this.columns - 1))
                                result.matrix[result.rows - 1, targetColumn] -= result.matrix[targetRow, targetColumn] * step1[column];
                    }
                    else
                        result.matrix[result.rows - 1, column] += step1[column];
                }
                else
                    result.matrix[result.rows - 1, column] += step1[column];
            }
            
            return result;
        }
        //Проверяет b в каждой строке и домножает ее на -1, если оно отрицательно и при этом данная строка не является базисной для добавочных переменных. 
        public SolvingMatrix Standardization(int addedColumns)
        {
            SolvingMatrix result = this.Copy();
            for (int row = 0; row < result.rows - 1; row++)
                if ((result.matrix[row, result.columns - 1] < 0)&&((result.Basis(row) == -1)|| (result.Basis(row)) > this.columns - addedColumns - 2))
                    for(int column = 0; column < result.columns; column++)
                        result.matrix[row, column] *= -1;

            return result;
        }
        //Проверяет b в каждой строке и домножает ее на -1, если оно отрицательно
        public SolvingMatrix Standardization()
        {
            SolvingMatrix result = this.Copy();
            for (int row = 0; row < result.rows - 1; row++)
                if ((result.matrix[row, result.columns - 1] < 0) && (result.Basis(row) == -1))
                    for (int column = 0; column < result.columns; column++)
                        result.matrix[row, column] *= -1;

            return result;
        }
        //Осуществляет переход к min/max функции
        public SolvingMatrix minToMax()
        {
            SolvingMatrix result = this.Copy();
            for (int column = 0; column < result.columns; column++)
                result.matrix[result.rows - 1, column] *= -1;
            return result;
        }
        //Проверяет, есть ли в выбранной строке хотя бы один не нулевой элемент
        public bool IsZeroRow(int row)
        {
            for (int column = 0; column < columns; column++)
                if (this.matrix[row, column] != 0)
                    return false;
            return true;
        }
        //Проверяет, есть ли в выбранном столбце хотя бы один не нулевой элемент
        public bool IsZeroColumn(int column)
        {
            for (int row = 0; row < rows; row++)
                if (this.matrix[row, column] != 0)
                    return false;
            return true;
        }
        //Убирает все линнейно зависимые строки
        public SolvingMatrix RemoveDependent()
        {
            SolvingMatrix result = this.Copy();
            SolvingMatrix buff = this.Copy();
            buff = buff.RemoveRow(buff.rows - 1);
            for (int row = 0; row < buff.rows; row++)
            {
                int column = 0;
                bool mayTransform = true;
                while (buff.matrix[row, column] == 0)
                {
                    column++;
                    if (column > buff.columns - 1)
                    {
                        mayTransform = false;
                        break;
                    }
                }
                if (mayTransform)
                    buff = buff.Transform(row, column);
            }
            int ammountOfRows = buff.rows;
            for (int row = 0; row < ammountOfRows; row++)
                if (buff.IsZeroRow(row))
                {
                    buff = buff.RemoveRow(row);
                    result = result.RemoveRow(row);
                    ammountOfRows--;
                    row--;
                }
            return result;

        }
        //Возвращает ранг матрицы
        public int rank()
        {
            if (this.isDegenerate())
                return 0;
            int counter = 0;
            SolvingMatrix result = this.Copy().RemoveDependent();
            return result.rows - 1;
        }
        //Проверяет, является ли выбранный элемент допустимым опорным элементом (базовый вариант)
        public bool IsBaseElement(int targetRow, int targetColumn)
        {
            Fraction min = new Fraction(0);
            //найдем минимальный элемент
            for (int column = 0; column < this.columns - 1; column++)
            {
                if (this.matrix[this.rows - 1, column] < min)
                    min = this.matrix[this.rows - 1, column];
            }



            if (/*(this.matrix[this.rows - 1, targetColumn] >= 0)||(this.matrix[targetRow, this.columns - 1] <= 0) ||*/(min >= 0)||(this.matrix[this.rows - 1, targetColumn] != min)||(targetRow >= this.rows - 1) || (targetColumn >= this.columns - 1) || (this.matrix[targetRow, targetColumn] == 0))
                return false;
            for (int row = 0; row < this.rows - 1; row++)
            {
                Fraction a = this.matrix[row, this.columns - 1] / this.matrix[row, targetColumn];
                Fraction b = this.matrix[targetRow, this.columns - 1] / this.matrix[targetRow, targetColumn];
                if (((a < b) && (a > 0))||(b <= 0))//Правило Блэнда: (b <= 0)
                    return false;
            }
            return true;

        }
        //Проверяет, является ли выбранный элемент допустимым опорным элементом (при переходе к искусственному базису)
        public bool IsBaseElementArtificial(int targetRow, int targetColumn, int addedColumns)
        {
            
            SolvingMatrix result = new SolvingMatrix(this.rows, this.columns - addedColumns);
            for (int row = 0; row < this.rows; row++)
                for (int column = 0; column < this.columns - addedColumns - 1; column++)
                    result.matrix[row, column] = this.matrix[row, column];
            for (int row = 0; row < this.rows; row++)
                result.matrix[row, result.columns - 1] = this.matrix[row, this.columns - 1];

            Fraction min = null;
            //найдем минимальный элемент
            for (int column = 0; column < this.columns - 1; column++)
            {
                bool allowed = true;
                for (int row = 0; row < this.rows; row++)
                {
                    int g533 = this.Basis(row);
                    if (this.Basis(row) == column)
                        allowed = false;
                }
                if (allowed)
                    if (min != null)
                    {
                        if ((this.matrix[this.rows - 1, column] < min) && (allowed))
                            min = this.matrix[this.rows - 1, column];
                    }
                    else
                        min = this.matrix[this.rows - 1, column];
            }

            //Корректива для искусственного базиса
            bool negative = false;
            if (min < 0)
                negative = true;


            bool a43 = (this.Basis(targetRow) < this.columns - addedColumns - 1);
            int b43 = this.Basis(targetRow);
            if ((targetRow >= this.rows - 1) || 
                (targetColumn >= this.columns - 1) || 
                (this.matrix[targetRow, targetColumn] == 0) ||
                (this.Basis(targetRow) < this.columns - addedColumns - 1)||
                (targetColumn >= this.columns - addedColumns - 1)||
                //(this.matrix[this.rows - 1, targetColumn] != min)
                ((this.matrix[this.rows - 1, targetColumn] >= 0)&&(negative))) //Корректива для искусственного базиса
                return false;

          

            for (int row = 0; row < result.rows - 1; row++)
            {
                Fraction a = result.matrix[row, result.columns - 1] / result.matrix[row, targetColumn];
                Fraction b = result.matrix[targetRow, result.columns - 1] / result.matrix[targetRow, targetColumn];
                if (((a < b) && (a >= 0) && (this.Basis(row) >= this.columns - addedColumns - 1)) || (b < 0))//Правило Блэнда: (a >= 0) -> (a > 0), (b < 0) -> (b <= 0)
                    return false;
            }
            return true;
        }
        //Проверяет, является ли выбранный элемент допустимым опорным элементом (при переходе к заданному пользователем базису)
        public bool IsBaseElementBaseSolution(int targetRow, int targetColumn, bool[] vector, bool anyway)
        {
            
            bool a34 = this.IsBasisColumn(targetColumn);
            bool b54 = this.Basis(targetRow) != -1;
            if ((targetRow >= this.rows - 1) || 
                (targetColumn >= this.columns - 1) || 
                (this.matrix[targetRow, targetColumn] == 0) ||
                (!vector[targetColumn] && !anyway) ||
                (this.IsBasisColumn(targetColumn))||
                (this.Basis(targetRow) != -1))
                return false;
            
            return true;
        }
        //Возвращает строковое представление матрицы (обыкновенные дроби)
        override
        public String ToString()
        {
            String result = "";
            int[] columnSize = new int[columns];
            for (int column = 0; column < columns; column++)
                columnSize[column] = MaxLength(column, false) + 3;

            for (int row = -1; row < rows; row++)
            {
                for (int column = -1; column < columns; column++)
                {
                    if (row == -1)
                        if (column == -1)
                        {
                            String space = "";
                            for (int i = 0; i < this.MaxLength(column, false) + 3; i++)
                                space += " ";
                            result += space;
                        }
                        else
                        {
                            String space = "";
                            for (int i = 0; i < columnSize[column] - ("x" + column.ToString()).Length; i++)
                                space += " ";
                            if (column != this.columns - 1)
                                result += "x" + (column + 1).ToString() + space;
                            else 
                                result += "b" + space + " ";
                        }
                    else
                        if (column != -1)
                    {
                        String space = "";
                        for (int i = 0; i < columnSize[column] - this.matrix[row, column].ToString().Length; i++)
                            space += " ";
                        result += this.matrix[row, column].ToString() + space;
                    }
                    else
                    {
                        String space = "";
                        for (int i = 0; i < this.MaxLength(column, false) + 3 - this.StringBasis(row).Length; i++)
                            space += " ";
                        result += this.StringBasis(row) + space;
                    }
                }
                result += "\n";
            }
            return result;
        }
        //Возвращает строковое представление матрицы (десятичные дроби)
        public String ToDoubleString()
        {
            String result = "";
            int[] columnSize = new int[columns];
            for (int column = 0; column < columns; column++)
                columnSize[column] = MaxLength(column, true) + 3;

            for (int row = -1; row < rows; row++)
            {
                for (int column = -1; column < columns; column++)
                {
                    if (row == -1)
                        if (column == -1)
                        {
                            String space = "";
                            for (int i = 0; i < this.MaxLength(column, false) + 3; i++)
                                space += " ";
                            result += space;
                        }
                        else
                        {
                            String space = "";
                            for (int i = 0; i < columnSize[column] - ("x" + column.ToString()).Length; i++)
                                space += " ";
                            result += "x" + (column + 1).ToString() + space;
                        }
                    else
                        if (column != -1)
                    {
                        String space = "";
                        for (int i = 0; i < columnSize[column] - this.matrix[row, column].ToDoubleString().Length; i++)
                            space += " ";
                        result += this.matrix[row, column].ToDoubleString() + space;
                    }
                    else
                    {
                        String space = "";
                        for (int i = 0; i < this.MaxLength(column, false) + 3 - this.StringBasis(row).Length; i++)
                            space += " ";
                        result += this.StringBasis(row) + space;
                    }
                }
                result += "\n";
            }
            return result;
        }
        //Конструктор объекта по строковому представлению
        public SolvingMatrix(String input)
        {
            try
            {
                List<String> rowsStr = new List<String>(input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
                //if (new Regex(@"[^(0-9,/,.)]").IsMatch(rowsStr[0]))
                String clone = rowsStr[0];
                if ((clone.Replace(" ", ""))[0] == 'x')
                    rowsStr.RemoveAt(0);
                List<String>[] rows = new List<String>[rowsStr.Count];
                for (int i = 0; i < rowsStr.Count; i++)
                {
                    rows[i] = new List<String>(rowsStr[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    foreach (String column in rows[i].ToArray())
                        //if (new Regex(@"[^(0-9,/,.)]").IsMatch(column))
                        if ((column[0] == 'x')||(column[0] == 'F')||(column[0] == 'f'))
                            rows[i].Remove(column);
                }
                this.rows = rowsStr.Count;
                this.columns = rows[0].Count;
                Fraction[,] matrix = new Fraction[this.rows, this.columns];

                for (int row = 0; row < this.rows; row++)
                    for (int column = 0; column < this.columns; column++)
                    {
                        String text = (rows[row])[column];
                        int counter = 0;
                        bool inputMode = false; //Если false, то ввод в формате x/y, иначе ввод в формате double
                        foreach (char letter in text)
                        {
                            if (letter == '/')
                                counter++;

                            if (letter == '.')
                            {
                                counter++;
                                inputMode = true;
                            }
                        }
                        if (counter > 1)
                            throw new Exception("Строка имеет неправильный входной формат");
                        if (inputMode)
                        {
                            NumberFormatInfo formatProvider = new NumberFormatInfo();
                            formatProvider.NumberDecimalSeparator = ".";
                            matrix[row, column] = new Fraction(Convert.ToDouble(text, formatProvider));
                        }
                        else
                        {
                            int numerator = Convert.ToInt32(text.Split('/')[0]);
                            int denominator = 1;
                            if (text.Split('/').Length > 1)
                                denominator = Convert.ToInt32(text.Split('/')[1]);
                            matrix[row, column] = new Fraction(numerator, denominator);
                        }
                    }
                this.matrix = matrix;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //Возвращает строку -ответ на задачу оптимизации
        public String Answer(bool min, bool useDoubles)
        {
            bool correct = true;
            for (int row = 0; row < this.rows - 1; row++)
                if (this.matrix[row, this.columns - 1] < 0)
                    correct = false;



            if (correct)
            {
                String answer = "Ответ: X = {";
                for (int column = 0; column < this.columns - 1; column++)
                {
                    if (this.IsBasisColumn(column))
                    {
                        int targetRow = 0;
                        while (this.matrix[targetRow, column] == 0)
                            targetRow++;
                        if (this.Basis(targetRow) == column)
                        {
                            if (useDoubles)
                                answer += this.matrix[targetRow, this.columns - 1].ToDoubleString() + ", ";
                            else
                                answer += this.matrix[targetRow, this.columns - 1].ToString() + ", ";
                            //if (this.matrix[targetRow, this.columns - 1] < 0)
                                //return ("Нет решений");
                        }
                        else
                            answer += "0, ";
                    }
                    else
                        answer += "0, ";
                }
                answer = answer.Remove(answer.Length - 1);
                answer = answer.Remove(answer.Length - 1);
                if (min)
                    if (useDoubles)
                        answer += "}    L(X) = " + (new Fraction(-1) * this.matrix[this.rows - 1, this.columns - 1]).ToDoubleString();
                    else
                        answer += "}    L(X) = " + (new Fraction(-1) * this.matrix[this.rows - 1, this.columns - 1]).ToString();
                else
                    if (useDoubles)
                        answer += "}    L(X) = " + (this.matrix[this.rows - 1, this.columns - 1]).ToDoubleString();
                    else
                        answer += "}    L(X) = " + (this.matrix[this.rows - 1, this.columns - 1]).ToString();
                return answer;
            }
            else
                return ("Нет решений");
        }


        //
        //Далее идут переменные и методы, требующееся для графического решения
        //

        //Приводит матрицу к стандартному виду для графического решения 
        public SolvingMatrix ToGraphSolution()
        {
            SolvingMatrix result = this.Copy();

            if (result.columns > result.rows + 2)
                return null;

            for (int column = 2; column < result.columns - 1; column++)
                if (result.GetValue(column - 2, column) != 0)
                    result = result.Transform(column - 2, column);

            result = result.Standardization();

            for (int row = 0; row < result.rows; row++)
                for (int column = 2; column < result.columns - 1; column++)
                    if ((row != column - 2) && (result.GetValue(row, column) != 0))
                        return null;

            return result;
        }
        //Проверяет, требуется ли штриховка области
        public bool isStrict()
        {
            if (this.columns != this.rows + 2)
                return true;
            for (int column = 2; column < this.columns - 1; column++)
                if (this.matrix[column - 2, column] == 0)
                    return true;
            return false;
        }
    }
}

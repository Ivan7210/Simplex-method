using System;
using System.Collections.Generic;
using System.Text;

namespace SimplexLibrary
{
    public class SolvingMatrix
    {
        private int rows;
        private int columns;
        private Fraction[,] matrix;
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

        public SolvingMatrix Copy()
        {
            Fraction[,] copyMatrix = new Fraction[this.rows, this.columns];
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                    copyMatrix[row, column] = this.matrix[row, column];
            return new SolvingMatrix(copyMatrix);
        }


        public int GetRowsAmount()
        {
            return this.rows;
        }

        public int GetColumnsAmount()
        {
            return this.columns;
        }

        public Fraction GetValue(int row, int column)
        {
            if ((row > -1) && (row < rows) && (column > -1) && (column < columns))
                return matrix[row, column];
            else
                return null;
        }

        public int Basis(int inRow)
        {
            int basis = -1;
            for (int column = 0; column < columns-1; column++)
                if (this.GetValue(inRow, column) != 0)
                {
                    basis = column;
                    for (int row = 0; row < rows; row++)
                        if ((this.GetValue(row, column) != 0)&&(row != inRow))
                        {
                            basis = -1;
                            break;
                        }
                    if (basis != -1)
                        return basis;
                }
            return basis;
        }

        public String StringBasis(int inRow)
        {
            if (inRow == rows-1)
                return "F";
            int basis = Basis(inRow);
            if (basis != -1)
                return 'x' + (basis+1).ToString();
            else
                return "";
        }



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



    }
}

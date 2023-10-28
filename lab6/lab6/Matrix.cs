using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    //Класс матрицы
    class Matrix
    {
        //Сама матрица
        double[,] matrix;
        //Количество строк и столбцов
        int rows;
        int cols;

        //Конструктор
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new double[rows, cols];
        }

        //Заполнение матрицы нулями
        public Matrix fillZero()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = 0;
            return this;
        }

        //Заполнение матрицы элементами из массива
        public Matrix fillWithElements(params double[] values)
        {
            if (values.Length < rows * cols)
            {
                throw new Exception("Ошибка: элементов недостаточно, чтобы заполнить матрицу!");
            }
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = Math.Round(values[i * cols +j], 2);
            return this;
        }

        //Взятие значения элемента
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        //Умножение матрицы на число
        public static Matrix operator *(Matrix matr, double value)
        {
            Matrix temp = new Matrix(matr.rows, matr.cols);
            for (int i = 0; i < temp.rows; i++)
                for (int j = 0; j < temp.cols; j++)
                    temp.matrix[i, j] += matr.matrix[i, j] * value;
            return temp;
        }

        //Умножение матрицы на матрицу
        public static Matrix operator *(Matrix matr1, Matrix matr2)
        {
            if(matr1.cols != matr2.rows)
            {
                throw new Exception("Ошибка: количество элементов в столбце первой матрицы не равно количеству элементов в строке второй матрицы!");
            }

            Matrix temp = new Matrix(matr1.rows, matr2.cols);
            for (int i = 0; i < temp.rows; i++)
                for (int j = 0; j < temp.cols; j++)
                    for (int g = 0; g < matr1.cols; g++)
                        temp.matrix[i, j] += matr1.matrix[i, g] * matr2.matrix[g, j];
            return temp;
        }
    }
}

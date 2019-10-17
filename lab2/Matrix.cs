﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Matrix
    {
        private double[][] m_matrix;

        public Matrix(int rows, int cols)
        {
            m_matrix = new double[rows][];
            for (int i = 0; i < rows; i++)
                m_matrix[i] = new double[cols];
        }

        public Matrix(double[][] other) : this(other.Length, other[0].Length)
        {
            for (int i = 0; i < other.Length; i++)
                for (int j = 0; j < other[0].Length; j++)
                    m_matrix[i][j] = other[i][j];
        }

        // Размер матрицы доступен только для чтения через свойства: 
        public int Rows { get { return m_matrix.Length; } }
        public int Columns { get { return m_matrix[0].Length; } }

        // доступ к элементам матрицы через свойство-индексатор: 
        public double this[int i, int j] {
            get { return m_matrix[i - 1][j - 1]; }
            set { m_matrix[i - 1][j - 1] = value; }
        }

        // Является ли матрица квадратной 
        public bool IsSquared { get { return m_matrix.Length == m_matrix[0].Length ? true : false; } }

        // Является ли матрица нулевой 
        public bool IsEmpty {
            get {
                for (int i = 0; i < this.Rows; i++)
                    for (int j = 0; j < this.Columns; j++)
                        if (m_matrix[i][j] != 0) return false; 

                return true;
            }
        }

        // Является ли матрица единичной 
        public bool IsUnity {
            get {
                if (!this.IsSquared) return false;
                if (!this.IsDiagonal) return false;

                for (int i = 0; i < this.Rows; i++)
                    if (m_matrix[i][i] != 1) return false;

                return true;
            }
        }

        // Является ли матрица диагональной 
        public bool IsDiagonal {
            get {
                if (!this.IsSquared) return false;

                for (int i = 0; i < this.Rows; i++)
                    for (int j = 0; j < this.Columns; j++)
                        if (i != j) if (m_matrix[i][j] != 0) return false;

                return true;
            }
        }
        
        // Является ли матрица симметричной 
        public bool IsSymmetric {
            get {
                if (this.Rows == 1 && this.Columns == 1) return true;
                if (!this.IsSquared) return false;

                for (int i = 1; i < this.Rows; i++)
                    for (int j = 0; j < i; j++)
                        if (m_matrix[i][j] != m_matrix[j][i]) return false;

                return false;
            }
        }

        // Матрицы с нулевым следом называют бесследовыми
        public bool isTraceless { get { return this.Trace() == 0 ? true : false; } }
        public bool isTracefree { get { return this.isTraceless; } }

        // стандартные матричные операции через перегрузку операторов: 
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null) return null;
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns) return null;
            Matrix m3 = new Matrix(m1.Rows, m1.Columns);

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    m3[i, j] = m1[i, j] + m2[i, j];

            return m3;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null) return null;
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns) return null;
            Matrix m3 = new Matrix(m1.Rows, m1.Columns);

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    m3[i, j] = m1[i, j] - m2[i, j];

            return m3;
        }
        
        public static Matrix operator *(Matrix m1, double d)
        {
            if (m1 == null) return null;
            Matrix m3 = new Matrix(m1.Rows, m1.Columns);

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Columns; j++)
                    m3[i, j] = m1[i, j] * d;

            return m3;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null) return null; // throw new exception
            if (m1.Columns != m2.Rows) return null;  // throw new exception

            Matrix m3 = new Matrix(m1.Rows, m2.Columns);

            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m2.Columns; j++)
                    for (int k = 0; k < m2.Rows; k++)
                        m3[i, j] += m1[i, k] * m2[k, j];

            return new Matrix(1, 1);
        }

        // оператор преобразования типов: 
        public static explicit operator Matrix(double[,] arr)
        {
            
            return new Matrix(1, 1);
        }


        // транспонирование матрицы    
        public Matrix Transpose()
        {
            Matrix mt = new Matrix(this.Columns, this.Rows);

            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Columns; j++)
                    mt[j, i] = m_matrix[i][j];

            return mt;
        }

        // вычисление следа матрицы
        public double Trace()
        {
            // След матрицы — это сумма элементов главной диагонали матрицы
            if (!this.IsSquared) return 0; // throw exception

            double sum = 0;
            for (int i = 0; i < this.Rows; i++)
                sum += m_matrix[i][i];

            return sum;
        }

        public override string ToString()
        {
            string m = "";

            for (int i = 0; i < this.Rows; i++)
            {
                if (i != 0) m += ",";

                for (int j = 0; j < this.Columns; j++)
                {
                    if (i != 0) m += " ";

                    m = "" + m_matrix[i][j];
                }
            }       
                    
            return m;
        }

        // порождения единичной матрицы определенного размера: 
        public static Matrix GetUnity(int size)
        {
            Matrix m = Matrix.GetEmpty(size);

            for (int i = 0; i < size; i++)
                m[i, i] = 1;

            return m;
        }

        // порождения нулевой матрицы определенного размера: 
        public static Matrix GetEmpty(int size)
        {
            Matrix m = new Matrix(size, size);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    m[i, j] = 0;

            return m;
        }

        // создания матрицы по строчке в определенном формате.
        public static Matrix Parse(string s)
        {
            // Метод Parse должен генерировать исключение FormatException, если формат некорректный.
            // Формат строки «1 2 3, 4 5 6, 7 8 9» 
            if (String.IsNullOrWhiteSpace(s))
                throw new FormatException();

            string[] rows = s.Split(',');

            if (rows.Length == 0)
                throw new FormatException();

            double[][] matrix = new double[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] elements = rows[i].Split(' ');

                if (elements.Length == 0)
                    throw new FormatException();

                matrix[i] = new double[elements.Length];

                for (int j = 0; j < rows.Length; j++)
                {
                    matrix[i][j] = Double.Parse(elements[j]);
                }
            }

            return new Matrix(matrix);
        }

        // создания матрицы по строчке в определенном формате.
        public static bool TryParse(string s, out Matrix m)
        {
            m = null;

            try
            {
                m = Matrix.Parse(s);
                return true;
            } catch (FormatException e)
            {
                return false;
            }
        }



    }
}

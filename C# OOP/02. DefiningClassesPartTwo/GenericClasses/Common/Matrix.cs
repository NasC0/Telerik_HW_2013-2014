/* Task 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). */

namespace GenericClasses.Common
{
    using System;
    using System.Text;
    using VersionAttribute;

    [VersionAttribute(1, 1)]
    public class Matrix<T> where T : struct
    {
        private T[,] InnerMatrix { get; set; }
        private int rowSize;
        private int colSize;

        public Matrix(int matrixRowSize, int matrixColSize)
        {
            this.RowSize = matrixRowSize;
            this.ColSize = matrixColSize;
            this.InnerMatrix = new T[this.RowSize, this.ColSize];
        }

        public int RowSize
        {
            get
            {
                return this.rowSize;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Matrix row size cannot be negative");
                }

                this.rowSize = value;
            }
        }

        public int ColSize
        {
            get
            {
                return this.colSize;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Matrix column size cannot be negative.");
                }

                this.colSize = value;
            }
        }

        /* Task 9. Implement an indexer this[row, col] to access the inner matrix cells. */
        public T this[int row, int col]
        {
            get
            {
                return this.InnerMatrix[row, col];
            }
            set
            {
                if (row < 0 || row >= this.RowSize)
                {
                    throw new ArgumentOutOfRangeException("Row index out of bounds.");
                }

                if (col < 0 || col >= this.ColSize)
                {
                    throw new ArgumentOutOfRangeException("Column index out of bounds.");
                }

                this.InnerMatrix[row, col] = value;
            }
        }

        /* Task 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. 
         * Throw an exception when the operation cannot be performed. 
         * Implement the true operator (check for non-zero elements). */

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.RowSize != secondMatrix.RowSize || firstMatrix.ColSize != secondMatrix.ColSize)
            {
                throw new InvalidOperationException("Cannot add matrices of different size.");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.RowSize, firstMatrix.ColSize);
            for (int i = 0; i < firstMatrix.RowSize; i++)
            {
                for (int j = 0; j < firstMatrix.ColSize; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.RowSize != secondMatrix.RowSize || firstMatrix.ColSize != secondMatrix.ColSize)
            {
                throw new InvalidOperationException("Cannot add matrices of different size.");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.RowSize, firstMatrix.ColSize);
            for (int row = 0; row < firstMatrix.RowSize; row++)
            {
                for (int col = 0; col < firstMatrix.ColSize; col++)
                {
                    resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.ColSize != secondMatrix.RowSize)
            {
                throw new InvalidOperationException("The first matrix columns must equal the second matrix rows.");
            }

            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.RowSize, secondMatrix.ColSize);

            for (int rows = 0; rows < resultMatrix.RowSize; rows++)
            {
                for (int cols = 0; cols < resultMatrix.ColSize; cols++)
                {
                    for (int k = 0; k < firstMatrix.ColSize; k++)
                    {
                        resultMatrix[rows, cols] += (dynamic)firstMatrix[rows, k] * (dynamic)secondMatrix[k, cols];
                    }
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.RowSize; rows++)
            {
                for (int cols = 0; cols < matrix.ColSize; cols++)
                {
                    if (matrix[rows, cols] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.RowSize; rows++)
            {
                for (int cols = 0; cols < matrix.ColSize; cols++)
                {
                    if (matrix[rows, cols] == (dynamic)0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int rows = 0; rows < this.RowSize; rows++)
            {
                for (int cols = 0; cols < this.ColSize; cols++)
                {
                    builder.AppendFormat("{0} ", this.InnerMatrix[rows, cols]);
                }
                builder.Append("\n");
            }

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
    }
}

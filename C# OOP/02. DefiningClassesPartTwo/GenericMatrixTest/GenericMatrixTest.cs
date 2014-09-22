namespace GenericMatrixTest
{
    using GenericClasses.Common;
    using System;
    using VersionAttribute;

    class GenericMatrixTest
    {
        static void Main()
        {
            // Task 11. Apply the version attribute to a sample class and display its version at runtime. 
            Type version = typeof(Matrix<>);
            var attributes = version.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute is VersionAttribute)
                {
                    Console.WriteLine("Matrix class version: {0}", (attribute as VersionAttribute).Version);
                }
            }

            Console.WriteLine();

            // Test matrices
            Matrix<int> testIntMatrix = new Matrix<int>(2, 2);
            Matrix<double> testDoubleFirstMatrix = new Matrix<double>(3, 3);
            Matrix<double> testDoubleSecondMatrix = new Matrix<double>(3, 3);

            //Matrix<string> testStringMatrix = new Matrix<string>(1, 2);
            Matrix<decimal> testDecimalMatrix = new Matrix<decimal>(3, 3);

            // Test matrix indexer
            int count = 1;
            for (int rows = 0; rows < testDoubleFirstMatrix.RowSize; rows++)
            {
                for (int cols = 0; cols < testDoubleFirstMatrix.ColSize; cols++)
                {
                    testDoubleFirstMatrix[rows, cols] = count;
                    testDoubleSecondMatrix[rows, cols] = count;
                    testDecimalMatrix[rows, cols] = count;
                    count++;
                }
            }

            // Show matrix
            Console.WriteLine(testDoubleFirstMatrix);

            Console.WriteLine();

            // Matrix addition
            var resultAddition = testDoubleFirstMatrix + testDoubleSecondMatrix;
            Console.WriteLine("Matrix addition");
            Console.WriteLine(resultAddition);
            Console.WriteLine();

            // Matrix substraction
            var resultSubstraction = resultAddition - testDoubleFirstMatrix;
            Console.WriteLine("Matrix substraction");
            Console.WriteLine(resultSubstraction);
            Console.WriteLine();

            // Matrix multiplication
            var resultMultiplication = testDoubleFirstMatrix * resultAddition;
            Console.WriteLine("Matrix multiplication");
            Console.WriteLine(resultMultiplication);
            Console.WriteLine();

            // Matrix true and false operators. Remember that the Matrix<int> testIntMatrix hasn't been changes
            Console.WriteLine("Matrix true and false");
            Console.WriteLine("First check matrix:");
            Console.WriteLine(testIntMatrix);

            if (testIntMatrix)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            for (int rows = 0; rows < testIntMatrix.RowSize; rows++)
            {
                for (int cols = 0; cols < testIntMatrix.ColSize; cols++)
                {
                    testIntMatrix[rows, cols] = 1;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Then test matrix:");
            Console.WriteLine(testIntMatrix);

            if (testIntMatrix)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}

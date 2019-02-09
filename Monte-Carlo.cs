using System;

namespace MonteCarlo
{
    class Program
    {
        public static bool CheckMultiplication(int[,] MatrixA, int[,] MatrixB, int[,] MatrixC)
        {
            int numberOfElements = MatrixA.GetLength(0);

            int[] randomArray = new int[numberOfElements];
            int[] x = new int[numberOfElements]; // -- x = B * randomArray
            int[] y = new int[numberOfElements]; // -- y = A * x  = A * B * randomArray

            // x = C * randomArray

            // Using Random Data
            // randomArray number between 0 and 1

            var random = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                randomArray[i] = random.Next(0, 2);
            }

            //x=B*randomArray
            for (int i = 0; i < numberOfElements; i++)
            {
                x[i] = 0;
                for (int j = 0; j < numberOfElements; j++)
                    x[i] = (x[i] + MatrixB[i, j] * randomArray[j]) % 2;

            }
            //y=A*x=A*B*randomArray
            for (int i = 0; i < numberOfElements; i++)
            {
                y[i] = 0;
                for (int j = 0; j < numberOfElements; j++)
                    y[i] = (y[i] + MatrixA[i, j] * x[j]) % 2;

            }
            //x=C*randomArray
            for (int i = 0; i < numberOfElements; i++)
            {
                x[i] = 0;
                for (int j = 0; j < numberOfElements; j++)
                    x[i] = (x[i] + MatrixC[i, j] * randomArray[j]) % 2;
            }
            //A*B*r=C*randomArray
            for (int i = 0; i < numberOfElements; i++)
            {
                if (y[i] != x[i])
                {
                    return false;
                }
            }

            return true;
        }

        //Amplification
        public static bool Amplification(int[,] A, int[,] B, int[,] C)
        {
            // Running alghoritm in k times for reducing the failure
            int k = 10;

            for (int i = 0; i < k; i++)
            {
                if (CheckMultiplication(A, B, C))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Alghorithm for Matrix multiplication using Monte Carlor.");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1. Matrix multiplication");
            Console.WriteLine("2. Check multiplication matrix");
            Console.WriteLine("3. Exit");
        }

        static void Main(string[] args)
        {

            int[] data = { 1, 3, 1, 4, };

            int NumberOfMatrix = 0;
            int option = 1;

            //Added a default matrix values in the case if we not adding any value from keyboard.
            int[,] MatrixA = { { 1, 2, 3 }, { 4, 2, 4 }, { -2, 2, 6 } };
            int[,] MatrixB = { { 2, 2, 2 }, { -2, 5, 1 }, { 6, 1, 2 } };
            int[,] MatrixC = { { 1, 3, 2 }, { 5, 1, 3 }, { 2, 1, 2 } };

            while (option != 3)
            {
                Console.Clear();
                ShowMenu();
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        System.Console.Write("Insert Nuber of elements =");
                        NumberOfMatrix = int.Parse(Console.ReadLine());
                        MatrixA = new int[NumberOfMatrix, NumberOfMatrix];
                        MatrixB = new int[NumberOfMatrix, NumberOfMatrix];
                        MatrixC = new int[NumberOfMatrix, NumberOfMatrix];

                        //Read Matrix A
                        System.Console.WriteLine("Insert element for matrix A");
                        for (int i = 0; i < NumberOfMatrix; i++)
                        {
                            for (int j = 0; j < NumberOfMatrix; j++)
                            {
                                System.Console.Write("A[" + i + "," + j + "]=");
                                MatrixA[i, j] = int.Parse(Console.ReadLine());
                            }

                        }

                        // Read Matrix B
                        System.Console.WriteLine("Insert elements for matrix B");
                        for (int i = 0; i < NumberOfMatrix; i++)
                        {
                            for (int j = 0; j < NumberOfMatrix; j++)
                            {
                                System.Console.Write("B[" + i + "," + j + "]=");
                                MatrixB[i, j] = int.Parse(Console.ReadLine());
                            }

                        }

                        for (int i = 0; i < NumberOfMatrix; i++)
                        {
                            System.Console.WriteLine();
                            for (int j = 0; j < NumberOfMatrix; j++)
                            {
                                MatrixC[i, j] = 0;
                                for (int k = 0; k < NumberOfMatrix; k++)
                                {
                                    MatrixC[i, j] = MatrixC[i, j] + MatrixA[i, k] * MatrixB[k, j];

                                }
                                System.Console.Write(MatrixC[i, j] + " ");
                            }
                        }

                        System.Console.ReadLine();
                        break;
                    case 2:
                        bool resultAmplification = Amplification(MatrixA, MatrixB, MatrixC);
                        System.Console.WriteLine();
                        if (resultAmplification)
                        {
                            System.Console.WriteLine("Correct Multiplication" + resultAmplification);
                        }
                        else
                        {
                            System.Console.WriteLine("Bad Multiplication" + resultAmplification);
                        }

                        System.Console.ReadLine();
                        break;
                    case 3:
                        break;
                    default:

                        System.Console.WriteLine("Invalid :) :) Tray again");
                        System.Console.ReadLine();
                        break;

                }
            }
            System.Console.ReadLine();
        }
    }
}

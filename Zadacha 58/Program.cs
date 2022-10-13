// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Матрицу P можно умножить на матрицу K только в том случае, если число столбцов матрицы P равняется числу строк матрицы K. Матрицы, для которых данное условие не выполняется, умножать нельзя. 


int GetNumber(string message)
{
    Console.WriteLine(message);
    int number = int.Parse(Console.ReadLine());
    return number;
}

int[,] InitMatrix(int m, int n)
{
    int[,] matrix = new int[m, n];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0, 5);
        }
    }

    return matrix;
}


void PrintMatrix(int[,] matrix)
{

    for (int i = 0; i < matrix.GetLength(0); i++)
    {

        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write($"{matrix[i, j]}\t ");

        }

        Console.WriteLine();

    }

}

int[,] MultiplyMatrix(int[,] matrix, int[,] matrix2)
{
    int rowMatrix = matrix.GetLength(0);
    int columnMatrix = matrix.GetLength(1);
    int rowMatrix2 = matrix2.GetLength(0);
    int columnMatrix2 = matrix2.GetLength(1);
    int temp = 0;
    int[,] multiMatrix = new int[rowMatrix, columnMatrix2];

    for (int i = 0; i < rowMatrix; i++)
    {
        for (int j = 0; j < columnMatrix2; j++)
        {
            temp = 0;
            for (int k = 0; k < columnMatrix; k++)
            {
                temp += matrix[i, k] * matrix2[k, j];
            }
            multiMatrix[i, j] = temp;
        }
    }
    return multiMatrix;
}




int m = GetNumber("Введите число строк массива m");
int n = GetNumber("Введите столбцов массива n");
int m1 = GetNumber("Введите строк массива2 m");
int n1 = GetNumber("Введите столбцов массива2 n");
if (n != m1)
{
    Console.WriteLine("Эти матрицы нельзя перемножить");
    Environment.Exit(0);


}
int[,] matrix = InitMatrix(m, n);
int[,] matrix2 = InitMatrix(m1, n1);

Console.WriteLine("Матрица1:");
PrintMatrix(matrix);
Console.WriteLine("Матрица2:");
PrintMatrix(matrix2);
Console.WriteLine("Перемножение матриц:");
PrintMatrix(MultiplyMatrix(matrix, matrix2));
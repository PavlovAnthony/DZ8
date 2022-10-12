/* Задача 54: Задайте двумерный массив.
 Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
\* */


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
            matrix[i, j] = rnd.Next(0, 20);
        }
    }

    return matrix;
}
int[,] Sort(int[,] matrix)
{
    
    int[,] matrix2 = matrix;
    int [] temp = new int[matrix.GetLength(1)];
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {                
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            temp[j] = matrix2[i,j];
      
        }
        Array.Sort(temp);
        Array.Reverse(temp);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix2[i,j]= temp[j] ;
 
        }
    }
    return matrix2;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {

            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int m = GetNumber("Введите размер массива m");
int n = GetNumber("Введите размер массива n");


int[,] matrix = InitMatrix(m, n);


Console.WriteLine("Матрица:");
PrintMatrix(matrix);
Console.WriteLine("Отсортированная матрица:");
PrintMatrix(Sort(matrix));


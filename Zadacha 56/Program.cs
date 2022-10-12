// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
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
void FindSumString(int[,] matrix)
{


    int sum = 0;

    int count = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sum = sum + matrix[0, j];
    }
    int min = sum;
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum = sum + matrix[i, j];
        }

        if (sum < min)
        {
            min = sum;
            count = i + 1;
        }
    }

    Console.WriteLine("Наименьшая сумма в строке: " + count);
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
FindSumString(matrix);

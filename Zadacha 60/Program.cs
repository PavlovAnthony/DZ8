//трехмерный массив

int[,,] array = { { { 20, 25}, { 30, 35 }}, {{ 66, 76 }, {52, 48} } };

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int k = 0; k < array.GetLength(2); k++)
        {
            Console.WriteLine($"{array[i, j, k]} ({i}, {j}, {k})" );
        }
    }
}

 void Main()
        {
            int m = 0, n = 0, start = 0, step = 0;
            bool errorOcured = false;
            //проверка вводимых параметров
            try
            {
                
                Console.Write("Введите количество столбцов в массиве: ");
                m = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество строк в массиве: ");
                n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ввелите начальное число: ");
                start = Convert.ToInt32(Console.ReadLine());
                Console.Write("Шаг массива: ");
                step = Convert.ToInt32(Console.ReadLine());
                if (m < 0 || n < 0 || start < 0 || step < 0) throw new FormatException();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Неверный ввод: {0}]", e.Message);
                errorOcured = true;
            }

            if (!errorOcured)
            {
                int[,] mat = new int[m, n];
                mat = initMatrix(m, n, start, step);

                Console.WriteLine("Исходная матрица:");
                PrintMatrix(mat, m, n);

                Console.WriteLine("\n Спиральный массив:");
                mat = calculateSpider(mat, m, n);
                PrintMatrix(mat, m, n);
            }
            
        }
        int[,] initMatrix(int m, int n, int start, int step)
        {
            int[,] array = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = start;
                    start += step;
                }
            }
            return array;
        }
       void PrintMatrix(int[,] mat, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t{0}", mat[i, j]);
                }
                Console.WriteLine();
            }
        }
       static int[,] calculateSpider(int[,] mat, int m, int n)
        {
            int[,] intMat;
            //если массив 2x2 и меньше
            if (m <= 2 || n <= 2)
            {

                if (m == 2 && n == 2)
                {
                    int[,] t = new int[m, n];
                    t[0, 0] = mat[0, 0];
                    t[0, 1] = mat[0, 1];
                    t[1, 0] = mat[1, 1];
                    t[1, 1] = mat[1, 0];
                    return t;
                }
                else if (m == 2)
                {
                    int[,] temp = new int[m, n];
                    for (int i = 0; i < n; i++)
                    {
                        temp[0, i] = mat[0, i];
                        temp[1, n - 1 - i] = mat[1, i];
                    }
                    return temp;
                }
                else if (n == 2)
                {
                    int[,] t = new int[m, n];
                    int[] stMat = new int[m * n];
                    int c = 0;
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            stMat[c] = mat[i, j];
                            c++;
                        }
                    }
                    c = 0;
                    for (int i = 0; i < n; i++)
                    {
                        t[0, i] = stMat[c];
                        c++;
                    }
                    for (int i = 1; i < m; i++)
                    {
                        t[i, 1] = stMat[c];
                        c++;
                    }
                    if(m>1) t[m - 1, 0] = stMat[c];
                    c++;
                    for (int i = m - 2; i >= 1; i--)
                    {
                        t[i, 0] = stMat[c];
                        c++;
                    }
                    return t;
                }
                else return mat;
            }
            intMat = new int[m - 2, n - 2];
            int[,] internalMatrix = new int[m - 2, n - 2]; 
            for (int i = 0; i < ((m - 2) * (n - 2)); i++)
            {//zamena
                internalMatrix[(m - 2) - 1 - i / (n - 2), (n - 2) - 1 - i % (n - 2)] = mat[m - 1 - (i / n), n - 1 - (i % n)];
            }
            intMat = calculateSpider(internalMatrix, m - 2, n - 2);

            int[,] retMat = new int[m, n]; 
           
           
            int[] tempMat = new int[(m * n) - ((m - 2) * (n - 2))];
            for (int i = 0; i < (m * n) - ((m - 2) * (n - 2)); i++)
            {
                tempMat[i] = mat[i / n, i % n];
            }
            int count = 0;
            //copy fist row
            for (int i = 0; i < n; i++)
            {
                retMat[0, i] = tempMat[count];
                count++;
            }
            //последний столбец
            for (int i = 1; i < m; i++)
            {
                retMat[i, n - 1] = tempMat[count];
                count++;
            }
            //последняя строка
            for (int i = n - 2; i >= 0; i--)
            {
                retMat[m - 1, i] = tempMat[count];
                count++;
            }
            
            for (int i = m - 2; i >= 1; i--)
            {
                retMat[i, 0] = tempMat[count];
                count++;
            }
            
            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    retMat[i, j] = intMat[i - 1, j - 1];
                }
            }
            return retMat;
        }
        Main();

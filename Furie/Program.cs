using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

//Заполнение данных
//Ф А Х Р А З И Е В
//3 0 3 2 0 1 1 0 -
double[] data = { 3, 0, 3, 2, 0, 1, 1, 0 };

// Бфстрое преобразование фурье
Complex[] complexResult = new Complex[data.Length];
for (int i = 0; i < data.Length; i++)
{
    complexResult[i] = new Complex(data[i], 0);
}

Fourier.Forward(complexResult);

// Результаты
Console.WriteLine("X(n):");
for (int i = 0; i < complexResult.Length; i++)
{
    Console.WriteLine("n {0}: Real={1:0.0}, Imaginary={2}", i, complexResult[i].Real, complexResult[i].Imaginary);
}


int T = 3;
//Формула x(t) для T = 3
Console.WriteLine($"\n\nx(t) = {complexResult[0].Real} + 2 * {Math.Abs(complexResult[1].Real)} * cos(2*pi/{T}*t - ({Math.Atan(complexResult[1].Imaginary / complexResult[1].Real)})) " +
    $"+ 2 * {Math.Abs(complexResult[2].Real)} * cos(2*pi/{T}*2t - ({Math.Atan(complexResult[2].Imaginary / complexResult[2].Real)})) + {Math.Abs(complexResult[3].Magnitude)} + {complexResult[4].Real}");

//4
Console.Write("\n\n");
double temp = 0;
for(int i = 0; i < complexResult.Length; i++)
{
    temp = Math.Sqrt(Math.Pow(complexResult[i].Real, 2) + Math.Pow(complexResult[i].Imaginary, 2));
    if(temp > 1)
    {
        Console.WriteLine("|x({0})| = {1} , x({2}) > 1", i, temp, i);
    }
    else if (temp < 1)
    {
        Console.WriteLine("|x({0})| = {1} , x({2}) < 1", i, temp, i);
    }
    else if (temp == 1)
    {
        Console.WriteLine("|x({0})| = {1} , x({2}) = 1", i, temp, i);
    }
}
Console.ReadLine();
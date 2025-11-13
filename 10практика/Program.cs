using System;

//Абстракция
public abstract class EquationSolver
{
    public abstract void Solve();
}

//Наследование
public class QuadraticEquationSolver : EquationSolver
{
    private double a, b, c;

    public QuadraticEquationSolver(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    //Полиморфизм 
    public override void Solve()
    {
        SolveEquation(a, b, c);
    }

    public void SolveEquation(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("x - любое");
                }
                else
                {
                    Console.WriteLine("Нет решения");
                }
            }
            else
            {
                double x1 = -c / b;
                Console.WriteLine($"x1 = {x1}");
            }
        }
        else
        {
            double D = b * b - 4 * a * c;

            if (D > 0)
            {
                double x1 = (-b - Math.Sqrt(D)) / (2 * a);
                double x2 = (-b + Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"x1 = {x1}, x2 = {x2}");
            }
            else if (D == 0)
            {
                double x1 = -b / (2 * a);
                Console.WriteLine($"x1 = {x1}");
            }
            else
            {
                Console.WriteLine("Нет решения");
            }
        }
    }

    public void SolveEquation(int a, int b, int c)
    {
        SolveEquation((double)a, (double)b, (double)c);
    }
}

//Инкапсуляция
public class MathProcessor
{
    private QuadraticEquationSolver solver;

    public MathProcessor(double a, double b, double c)
    {
        solver = new QuadraticEquationSolver(a, b, c);
    }

    public void Process()
    {
        solver.Solve();
    }
}

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(
            c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
            c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
        );
    }

    public static implicit operator ComplexNumber(double d)
    {
        return new ComplexNumber(d, 0);
    }

    public static explicit operator double(ComplexNumber c)
    {
        return c.Real;
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Решение квадратных уравнений");

        double a = 1, b = -3, c = 2;
        MathProcessor processor = new MathProcessor(a, b, c);
        Console.Write($"Уравнение: {a}x² + {b}x + {c} = 0 -> ");
        processor.Process();

        QuadraticEquationSolver solver = new QuadraticEquationSolver(0, 0, 0);
        Console.Write("Уравнение с целыми коэффициентами: ");
        solver.SolveEquation(1, 0, -4);

        ComplexNumber num1 = new ComplexNumber(2, 3);
        ComplexNumber num2 = new ComplexNumber(1, 2);

        ComplexNumber sum = num1 + num2;
        ComplexNumber product = num1 * num2;

        Console.WriteLine($"Комплексные числа: {num1} + {num2} = {sum}");
        Console.WriteLine($"Комплексные числа: {num1} * {num2} = {product}");

        ComplexNumber num3 = 5.0; 
        double realPart = (double)num3;

        Console.WriteLine($"Преобразование: double -> ComplexNumber: {num3}");
        Console.WriteLine($"Преобразование: ComplexNumber -> double: {realPart}");
    }
}
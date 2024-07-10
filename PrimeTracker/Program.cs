using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int start = 0;
        int end = 100;

        List<int> primes = await GetPrimesAsync(start, end);

        Console.WriteLine($"Prime numbers between {start} and {end}: {string.Join(", ", primes)}");
    }

    static Task<List<int>> GetPrimesAsync(int start, int end)
    {
        return Task.Run(() =>
        {
            List<int> primes = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        });
    }

    
    static bool IsPrime(int number)
    {
        if (number <=1)
        {
            return false;
        }
        if (number == 2)
        {
            return true;
        }
        if (number % 2 == 0)
        {
            return false;
        }
        for (int i = 3; i <= Math.Sqrt(number);i+=2)
        {
            if (number % i ==0)
            {
                return false;
            }
        }
        return true;
    }

}

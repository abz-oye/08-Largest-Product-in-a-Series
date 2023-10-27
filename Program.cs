using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Numerics;

class Program
{
    /*
    Project Euler Problem 8: Largest Product in a Series

    Summary:
    Find the sequeunce that meets these conditions:"
    *   13 digits long
    *   Does not contain 0
    *   Does not contain 1
    *   Is the largest

    Then multiply the digits together to get the largest product in the series
    */
    static bool containsZeroOrOne(int[] arr, int start) { 
        /* Funciton that checks if an item contains the numbers 0 or 1 which will either cause 
        the number to be times at least once by itself or return zero meaning it cannot be the largerst*/
        bool zero = false;
        for (int i = 0; i < 12; i++) {
            if ((arr[start + i] == 0) || (arr[start+i]==1)) {
                zero = true;
            }
        }
        return zero;
    }
    
    static void Main(string[] args)
    {
        // Converting the 1000-digit number into a BigInteger, then back to a string, and finally back into an integer array
        string numberStr = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        BigInteger bigInteger = BigInteger.Parse(numberStr);
        string bigIntegerStr = bigInteger.ToString();

        int[] digits = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            digits[i] = int.Parse(bigIntegerStr[i].ToString());
        }

        int maxStart = 0; 
        int maxSum = 0;

        long ans = 1;

        for (int i = 0; i <= 987; i++) // iterates through the 1000 digit sequence, 1000 - 13 = 987 as limit
        {
            int sumNew = 0;

            for (int j = 0; j < 13; j++)
            {
                sumNew += digits[i + j];
            }

            if (sumNew > maxSum && containsZeroOrOne(digits, i) == false) // Compares sum to previous sum and makes sure 
            {
                maxSum = sumNew;
                maxStart = i;
            }
        }

        for (int i = maxStart; i < maxStart + 13; i++) // Outputs the sequeuence that has the largest total and meets conditions above
        {
            Console.Write(digits[i]);
        }
        

        for (int i = maxStart; i < maxStart + 13; i++) { // Outputs the product of the series
            ans = ans * digits[i];
        }

        Console.WriteLine($"\n\n{ans}");
    }
}

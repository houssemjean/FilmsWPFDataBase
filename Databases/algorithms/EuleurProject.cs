using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithms
{
    class EulerProject
    {
        public static long Problem10() {
            long sum = 0;

            for (long i = 2; i < 2000000; i++) {
                if (estPremier(i))
                    sum += i;
            }

            return sum;

        }

        public static String Problem166Correction()
        {
            int count = 0;
            int[] num = new int[8];  // A counter in base 10, little-endian
            do
            {
                int a = num[0], b = num[1], c = num[2], d = num[3];
                int e = num[4], g = num[5], i = num[6], k = num[7];
                int m = b + c + d - e - i; if (m < 0 || m > 9) continue;
                int o = a + b + d - g - k; if (o < 0 || o > 9) continue;
                int j = a + b + c - g - m; if (j < 0 || j > 9) continue;
                int l = a + b + c + d - i - j - k; if (l < 0 || l > 9) continue;
                int f = b + c + d * 2 - e - i - k; if (f < 0 || f > 9) continue;
                int h = a + b + c + d - e - f - g; if (h < 0 || h > 9) continue;
                int n = a + c + d - f - j; if (n < 0 || n > 9) continue;
                int p = a + b + c - h - l; if (p < 0 || p > 9) continue;
                count++;  // All tests passed
            } while (increment(num));
            return count.ToString();
        }


        // Increments the given base-10 counter in little endian, e.g. {9, 9, 5, 1} -> {0, 0, 6, 1}.
        // Returns true if incremented, otherwise returns false if all elements are already 9.
        private static bool increment(int[] num)
        {
            int i = 0;
            while (num[i] == 9)
            {
                num[i] = 0;
                i++;
                if (i == num.Length)
                    return false;
            }
            num[i]++;
            return true;
        }
	

        public static int Problem166()
        {
            int result = 0;
            for (int i = 0; i <= 9; i++)
            {
                int[,] tab = new int[4, 4];
                for (int j = 0; j <= 9; j++)
                    for (int k = 0; k <= 9; k++)
                        for (int t = 0; t <= 9; t++)
                        {

                            tab[0, 0] = i;
                            tab[0, 1] = j;
                            tab[0, 2] = k;
                            tab[0, 3] = t;
                            for (int i1 = 0; i1 <= i + j + k + t && i1 <= 9; i1++)
                                for (int j1 = 0; j1 <= i + j + k + t - i1 && j1 <= 9; j1++)
                                    for (int k1 = 0; k1 <= i + j + k + t - i1 - j1 && k1 <= 9; k1++)
                                    {
                                        tab[1, 0] = i1;
                                        tab[1, 1] = j1;
                                        tab[1, 2] = k1;

                                        tab[1, 3] = i + j + k + t - i1 - j1 - k1;
                                        for (int i2 = 0; i2 <= i + j + k + t && i2 <= 9; i2++)
                                            for (int j2 = 0; j2 <= i + j + k + t - i1 && j2 <= 9; j2++)
                                                for (int k2 = 0; k2 <= i + j + k + t - i2 - j2 && k2 <= 9; k2++)
                                                {
                                                    tab[2, 0] = i2;
                                                    tab[2, 1] = j2;
                                                    tab[2, 2] = k2;
                                                    tab[2, 3] = i + j + k + t - i2 - j2 - k2;

                                                    if (i + j + k + t - i - i1 - i2 >= 0 && i + j + k + t - j - j1 - j2 >= 0 && i + j + k + t - k - k1 - k2 >= 0)
                                                    {
                                                        tab[3, 0] = i + j + k + t - i - i1 - i2;
                                                        tab[3, 1] = i + j + k + t - j - j1 - j2;
                                                        tab[3, 2] = i + j + k + t - k - k1 - k2;
                                                        int tab33 = i + j + k + t - tab[3, 0] - tab[3, 1] - tab[3, 2];
                                                        tab[3, 3] = i + j + k + t - tab[3, 0] - tab[3, 1] - tab[3, 2];
                                                        tab33 = tab[3, 3];
                                                        if (tab[3, 3] >= 0 && tab[1, 1] + tab[0, 0] + tab[2, 2] + tab[3, 3] == i + j + k + t && tab[0, 3] + tab[1, 2] + tab[2, 1] + tab[3, 0] == i + j + k + t)
                                                        {
                                                            bool zeb = true;
                                                            for (int f = 0; f < 4 && zeb; f++)
                                                            {
                                                                for (int g = 0; g < 4; g++)
                                                                {
                                                                    //Console.Write(tab[f, g] + " ");//
                                                                    if (tab[f, g] < 0 || tab[f, g] > 9)
                                                                    {
                                                                        zeb = false;
                                                                        break;
                                                                        //Console.WriteLine("fail");
                                                                        //result--;
                                                                    }

                                                                }
                                                                //Console.WriteLine();//
                                                            }

                                                            if (zeb)
                                                            {
                                                                result++;


                                                                if (tab[1, 1] + tab[0, 0] + tab[2, 2] + tab[3, 3] != i + j + k + t)
                                                                    Console.WriteLine("fail");
                                                                if (tab[3, 0] + tab[3, 1] + tab[3, 2] + tab[3, 3] != i + j + k + t)
                                                                    Console.WriteLine("fail");
                                                                if (tab[0, 0] + tab[0, 1] + tab[0, 2] + tab[0, 3] != i + j + k + t)
                                                                    Console.WriteLine("fail");
                                                                if (tab[0, 3] + tab[1, 2] + tab[2, 1] + tab[3, 0] != i + j + k + t)
                                                                    Console.WriteLine("fail");



                                                                #region affichage du tab
                                                                /*
                                                                for (int f = 0; f < 4 && zeb; f++)
                                                                {

                                                                    for (int g = 0; g < 4; g++)
                                                                    {
                                                                        Console.Write(tab[f, g] + " ");//

                                                                    }
                                                                    Console.WriteLine();

                                                                }
                                                                Console.WriteLine("______________");

                                                                */
                                                                #endregion
                                                            }


                                                        }
                                                    }
                                                }
                                    }





                        }

            


                #region MyRegion
                //for (int f = 0; f < 4; f++)
                //{
                //    for (int g = 0; g < 4; g++)
                //    {
                //        Console.Write(tab[f, g] + " ");
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine("______________"); 
                #endregion
                int zebzeb = 0;

            }

                return result;
            }
        

        public static long Problem119() {
            int i = 0;
            List<long> myList = new List<long>();
            long result = 0;
            while (i < 30) {
                long j = 2;
                long pow = 1;
                for (int p=1; pow/long.MaxValue==0 && p<40 &&p>0  ; ) {
                    p++;
                    //int p = 0;
                    for (j = 2; j < 90; j++)
                    {
                        int a;
                        if (j==8) 
                             a =2;
                         pow = (long)Math.Pow(j, p);
                         if (pow / 10 == 0 || pow < 0) { pow = 1; continue; }
                        int sum = 0;
                        string testStringNumber = pow.ToString();
                        for (int k = 0; k < testStringNumber.Length; k++)
                        {
                            sum += int.Parse(testStringNumber[k].ToString());
                        }

                        if (sum == j)
                        {

                            i++;
                            myList.Add(pow);
                        }

                    }
                }
                

                myList.Sort();
                
            }
            return myList[29];
        }

        public static double Problem368() {
            double sum = 0;
            int i; 
            for (i = 1; i < int.MaxValue; i++) {
                string test = i.ToString();
                if (!test.Contains("9")) 
                    sum = sum + 1 /(double) i;
            }
                return sum;
        }

        public static int Problem9(int n) {
            int result = 0;
            for (int i = 1; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    for (int k = j + 1; k < n; k++)
                        if (i + j + k == n && i * i + j * j == k * k)
                            result = i * j * k;

                        return result;
        }

        public static long Problem8(int n, string serie)
        {
            long max = 0;
            for (int i = 0; i < serie.Length - n - 1; i++)
            {
                long product = long.Parse(serie[i].ToString());
                for (int j = i; j < n + i - 1; j++)
                    product = product * int.Parse(serie[j].ToString());
                if (product > max) max = product;
            }
            return max;
        }

        public static long Problem5() {
            int j=0;
            int i = 1;
            while (j <= 10001) {
                i++;
                if (estPremier(i)) j++;
                
            }
            return i;
        }

        public static long Problem4(long n)
        {
            long max = 0;
            for (int i = 100; i <= 999; i++)
            {
                for (int j = 100; j <= 999; j++)
                {
                    if (isPalindrome(i * j))
                        if (i * j > max) max = i * j;
                }
            }
            return max;
        }

        public static bool isPalindrome(long n) {
            bool isPalindrome= true;
            string nEnString= n.ToString();
            int taille= n.ToString().Count();
            for (int i = 0; i < taille; i++) {
                if (nEnString[i] != nEnString[taille - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
                return isPalindrome;
        }

        public static int Problem1_Multiple3and5(int n) {
            int s = 0;
            for (int i = 3; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) s += i;
            }
                return s;
        }

        public static long Problem2_Fibonacci(long n) {
            long a = 1, b = 2,c=0;
            List<long> listTermesFibonacci = new List<long>();
            listTermesFibonacci.Add(a);
            listTermesFibonacci.Add(b);
            while (c <= n) {
                c = b + a;
                a = b;
                b = c;
                listTermesFibonacci.Add(c);
            }
            foreach (long u in listTermesFibonacci) Console.WriteLine(u);
            long s = 0;
            foreach (long u in listTermesFibonacci) {
                if (u % 2 == 0) s += u;
            }
            return s;
        
        }

        public static long Problem6_squareSum(long n)
        {
            long sumOfSquare = 0, squareOfSum = 0;
            for (int i = 1; i <= n; i++)
            {
                sumOfSquare += i * i;
                squareOfSum += i;
            }
            squareOfSum = squareOfSum * squareOfSum;
            return -sumOfSquare + squareOfSum;
        }

        public static long Problem5_Test(long n)
        {
            bool divisibleByAll = false;
            long k = n-1;
            while (divisibleByAll == false)
            {
                k++;
                for (int i = 1; i <= n; i++)
                {
                    if (k % i != 0) break;
                    if (i==n) divisibleByAll = true;
                }
                
            }
            return k;

        }

        public static long Problem3(long number) {

            int i;
            for (i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    number /= i;
                    i--;
                }
            }
            return i;
            
        }

        public static long largestPrimFacor(long n) {

            long max = listeFacteurPremiers(n).Max();
            return max;
        }

        public static List<long> listeFacteurPremiers(long n)
        {
            List<long> listeFacteurPremier = new List<long>();
            for (long i = 2; i < n / 2; i++)
            {
                
                if (n % i == 0)
                {
                    if (estPremier(i))
                    {
                        Console.WriteLine(i + " est facteur premier");
                        listeFacteurPremier.Add(i);
                    }
                }
            }
            return listeFacteurPremier;
        }

        public static bool estPremier(long n)
        {
            if ( n == 2) return true;
            if (n % 2 == 0) return false;
            double racine = Math.Sqrt(n);
            for (long i = 3; i <= racine ; i+=2) {
                if (n % i == 0) return false;
                
            }
            return true;
        }

    }
}

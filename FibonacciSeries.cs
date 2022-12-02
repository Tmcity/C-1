namespace Fibonacci
{
    class GitFib
    {
        //============================斐波那契数列=============================//
        public static int Fib(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
    }
}

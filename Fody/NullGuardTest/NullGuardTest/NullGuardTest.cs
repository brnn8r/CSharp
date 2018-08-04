using System;
using System.Diagnostics;
using System.Linq;
using NullGuard;

namespace NullGuardTest
{
   
    class MyNullGuardTest
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Hello World");

            var myZero = new MyInt(0,"Zero");

            var testResult = NullGuardTest(5, "steve", myZero).Map(m => new Random(m.Length).Next())
                        .Match(
                            some: result => result * result,
                            none: () => 0);

            Debug.WriteLine(testResult);

            var yourZero = new MyInt(0, "Zero");

            if (myZero.Equals(yourZero))
            {
                Debug.WriteLine("Yay! Fody! Equals!");
            }

            var testResult2 = NullGuardTest(-5, "ok", null).Map(m => new Random(m.Length).Next()).Match(
                            some: result => result * result,
                            none: () => 0); 

            Debug.WriteLine(testResult2);
                        
        }

        private static IMaybe<string> NullGuardTest(int i, string s, [AllowNull] MyInt j)
        {

            var checkResult = i < s.Length ? "less than" 
                    : (i == s.Length ? "equal to" : "greater than");

            if(i < 0)
            {
                return Maybe<string>.None;
            }
            else
            {
                return Maybe<string>.Some($"{i} is {checkResult} the length of {s} oh and MyInt was {j}");
            }
        }

    }
}

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingUtilities
{
    public class TestEnvironment
    {
        public static bool InVsEnvironment()
        {
            string currentProcess = Process.GetCurrentProcess().ProcessName;
            return currentProcess == "vstest.executionengine.x86" || currentProcess == "TE.ProcessHost.Managed" || currentProcess == "ProcessInvocation86";
        }
    }

    public static class TestExtensions
    {
        public static int TimeInSeconds(this DateTime dte)
        {
            return dte.Hour * 3600 + dte.Minute * 60 * dte.Second;
        }
        public static void ShouldEqual<T>(this T val1, T val2)
        {
            Assert.AreEqual(val1, val2);
        }

        public static void ShouldContain(this string val, string searchVal)
        {
            Assert.IsTrue(val.Contains(searchVal));
        }

        public static void ShouldNotContain(this string val, string searchVal)
        {
            Assert.IsFalse(val.Contains(searchVal));
        }

        public static void ShouldBeTrue(this bool val)
        {
            Assert.IsTrue(val);
        }

        public static void ShouldBeFalse(this bool val)
        {
            Assert.IsFalse(val);
        }

        public static void ShouldBeBetween<T>(this T val1, T lowValue, T highValue)
        {
            Assert.IsTrue(val1.GreaterThanInclusive(lowValue) || val1.LessThanInclusive(highValue));
        }

        public static void ShouldNotEqual<T>(this T val1, T val2)
        {
            Assert.AreNotEqual(val1, val2);
        }
        public static void ShouldBeNull<T>(this T val)
        {
            Assert.IsNull(val);
        }
        public static void ShouldNotBeNull<T>(this T val)
        {
            Assert.IsNotNull(val);
        }

        public static void ShouldBeSameAs<T>(this T val, T val2) where T : class
        {
            Assert.IsTrue(val == val2);
        }

        public static void ShouldBeGreaterThan<T>(this T val1, T val2)
        {
            Assert.IsTrue(val1.GreaterThan(val2));
        }
        public static void ShouldBeGreaterThanOrEqualTo<T>(this T val1, T val2)
        {
            Assert.IsTrue(val1.GreaterThanInclusive(val2));
        }

        public static void ShouldBeLessThan<T>(this T val1, T val2)
        {
            Assert.IsTrue(val1.LessThan(val2));
        }


        public static void ShouldBeLessThanOrEqualTo<T>(this T val1, T val2)
        {
            Assert.IsTrue(val1.LessThanInclusive(val2));
        }

        private static bool EqualTo<T>(this T val1, T val2)
        {
            return Compare(val1, val2) == 0;
        }

        private static bool GreaterThan<T>(this T val1, T val2)
        {
            return Compare(val1, val2) == 1;
        }

        private static bool GreaterThanInclusive<T>(this T val1, T val2)
        {
            var result = Compare(val1, val2);
            return result == 1 || result == 0;
        }

        private static bool LessThan<T>(this T val1, T val2)
        {
            return Compare(val1, val2) == -1;
        }

        private static bool LessThanInclusive<T>(this T val1, T val2)
        {
            var result = Compare(val1, val2);
            return result == -1 || result == 0;
        }

        public static int Compare(object tVal, object other)
        {
            var mType = tVal.GetType();
            if (mType == typeof(int))
            {
                return new IntCompare(tVal).CompareTo(other);
            }
            if (mType == typeof(decimal))
            {
                return new DecimalCompare(tVal).CompareTo(other);
            }
            if (mType == typeof(char))
            {
                return new CharCompare(tVal).CompareTo(other);
            }
            if (mType == typeof(string))
            {
                return String.CompareOrdinal((string)tVal, (string)other);
            }
            if (mType == typeof(DateTime))
            {
                return new DateTimeCompare(tVal).CompareTo(other);
            }
            throw new Exception("Unknown type!");
        }
    }

    internal abstract class CompareBase<T>
    {
        protected T tVal;

        protected CompareBase(object val)
        {
            tVal = (T)val;
        }

        public abstract int CompareTo(object other);
    }
    internal class IntCompare : CompareBase<int>
    {
        internal IntCompare(object val)
            : base(val)
        {

        }
        public override int CompareTo(object other)
        {
            if (tVal == (int)other) return 0;
            if (tVal > (int)other) return 1;
            return -1;
        }
    }

    internal class DecimalCompare : CompareBase<decimal>
    {
        internal DecimalCompare(object val)
            : base(val)
        {

        }
        public override int CompareTo(object other)
        {
            if (tVal == (decimal)other) return 0;
            if (tVal > (decimal)other) return 1;
            return -1;
        }
    }

    internal class DateTimeCompare : CompareBase<DateTime>
    {
        internal DateTimeCompare(object val)
            : base(val)
        {

        }
        public override int CompareTo(object other)
        {
            if (tVal == (DateTime)other) return 0;
            if (tVal > (DateTime)other) return 1;
            return -1;
        }
    }

    internal class CharCompare : CompareBase<char>
    {
        internal CharCompare(object val)
            : base(val)
        {

        }
        public override int CompareTo(object other)
        {
            if (tVal == (char)other) return 0;
            if (tVal > (char)other) return 1;
            return -1;
        }
    }
}
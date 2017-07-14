using System;
using System.Reflection;
using Apache.Ibatis.Common.Test.Domain;
using Apache.Ibatis.Common.Test.Fixtures.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.NUnit.CommonTests.Utilities
{
    [TestFixture]
    public class PropertyAccessorPerformance
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
        }


        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        {
        }

        #endregion

        /// <summary>
        /// Test integer property access performance
        /// </summary>
        [Test]
        public void TestGetIntegerPerformance()
        {
            const int TEST_ITERATIONS = 1000000;
        	Property prop = new Property();
            int test = -1;
            Timer timer = new Timer();

            #region Direct access (fastest)
        	GC.Collect();
            GC.WaitForPendingFinalizers();

            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                test = -1;
                test = prop.Int;
                Assert.AreEqual(int.MinValue, test);
            }
            timer.Stop();
            double directAccessDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            #endregion

            #region IL Property accessor
            GC.Collect();
            GC.WaitForPendingFinalizers();

            IGetAccessorFactory factory = new GetAccessorFactory(true);
            IGetAccessor propertyAccessor = factory.CreateGetAccessor(typeof(Property), "Int");
            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                test = -1;
                test = (int)propertyAccessor.Get(prop);
                Assert.AreEqual(int.MinValue, test);
            }
            timer.Stop();
            double propertyAccessorDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double propertyAccessorRatio = propertyAccessorDuration / directAccessDuration;
            #endregion

            #region IBatisNet.Common.Utilities.Object.ReflectionInfo
            GC.Collect();
            GC.WaitForPendingFinalizers();

        	ReflectionInfo reflectionInfo = ReflectionInfo.GetInstance(prop.GetType());
            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                test = -1;
            	PropertyInfo propertyInfo = (PropertyInfo)reflectionInfo.GetGetter("Int");
                test = (int)propertyInfo.GetValue(prop, null);
                Assert.AreEqual(int.MinValue, test);
            }
            timer.Stop();
            double reflectionInfoDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionInfoRatio = (float)reflectionInfoDuration / directAccessDuration;
            #endregion

            #region Reflection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Type type = prop.GetType();
            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                test = -1;
                PropertyInfo propertyInfo = type.GetProperty("Int", BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
                test = (int)propertyInfo.GetValue(prop, null);
                Assert.AreEqual(int.MinValue, test);
            }
            timer.Stop();
            double reflectionDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionRatio = reflectionDuration / directAccessDuration;
            #endregion

            #region ReflectionInvokeMember (slowest)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                test = -1;
                test = (int)type.InvokeMember("Int",
                    BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance,
                    null, prop, null);
                Assert.AreEqual(int.MinValue, test);
            }
            timer.Stop();
            double reflectionInvokeMemberDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionInvokeMemberRatio = reflectionInvokeMemberDuration / directAccessDuration;
            #endregion

            // Print results
            Console.WriteLine("{0} property gets on integer...", TEST_ITERATIONS);
            Console.WriteLine("Direct access: \t\t{0} ", directAccessDuration.ToString("F3"));
            Console.WriteLine("IMemberAccessor: \t\t{0} Ratio: {1}", propertyAccessorDuration.ToString("F3"), propertyAccessorRatio.ToString("F3"));
            Console.WriteLine("IBatisNet ReflectionInfo: \t{0} Ratio: {1}", reflectionInfoDuration.ToString("F3"), reflectionInfoRatio.ToString("F3"));
            Console.WriteLine("ReflectionInvokeMember: \t{0} Ratio: {1}", reflectionInvokeMemberDuration.ToString("F3"), reflectionInvokeMemberRatio.ToString("F3"));
            Console.WriteLine("Reflection: \t\t\t{0} Ratio: {1}", reflectionDuration.ToString("F3"), reflectionRatio.ToString("F3"));
        }


        /// <summary>
        /// Test the performance of getting an integer property.
        /// </summary>
        [Test]
        public void TestSetIntegerPerformance()
        {
            const int TEST_ITERATIONS = 1000000;
            Property prop = new Property();
            int value = 123;
            Timer timer = new Timer();

            #region Direct access (fastest)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                prop.Int = value;
            }
            timer.Stop();
            double directAccessDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            #endregion

            #region Property accessor
            GC.Collect();
            GC.WaitForPendingFinalizers();

            ISetAccessorFactory factory = new SetAccessorFactory(true);
            ISetAccessor propertyAccessor = factory.CreateSetAccessor(typeof(Property), "Int");
            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                propertyAccessor.Set(prop, value);
            }
            timer.Stop();
            double propertyAccessorDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double propertyAccessorRatio = propertyAccessorDuration / directAccessDuration;
            #endregion

            #region IBatisNet.Common.Utilities.Object.ReflectionInfo
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Type type = prop.GetType();
            ReflectionInfo reflectionInfo = ReflectionInfo.GetInstance(type);
            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PropertyInfo propertyInfo = (PropertyInfo)reflectionInfo.GetSetter("Int");
                propertyInfo.SetValue(prop, value, null);
            }
            timer.Stop();
            double reflectionInfoDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionInfoRatio = reflectionInfoDuration / directAccessDuration;
            #endregion

            #region Reflection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PropertyInfo propertyInfo = type.GetProperty("Int", BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance);
                propertyInfo.SetValue(prop, value, null);
            }
            timer.Stop();
            double reflectionDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionRatio = reflectionDuration / directAccessDuration;
            #endregion

            #region ReflectionInvokeMember (slowest)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            timer.Start();
            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                type.InvokeMember("Int",
                    BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance,
                    null, prop, new object[] { value });
            }
            timer.Stop();
            double reflectionInvokeMemberDuration = 1000000 * (timer.Duration / (double)TEST_ITERATIONS);
            double reflectionInvokeMemberRatio = reflectionInvokeMemberDuration / directAccessDuration;
            #endregion

            // Print results
            Console.WriteLine("{0} property sets on integer...", TEST_ITERATIONS);
            Console.WriteLine("Direct access: \t\t{0} ", directAccessDuration.ToString("F3"));
            Console.WriteLine("IMemberAccessor: \t\t{0} Ratio: {1}", propertyAccessorDuration.ToString("F3"), propertyAccessorRatio.ToString("F3"));
            Console.WriteLine("IBatisNet ReflectionInfo: \t{0} Ratio: {1}", reflectionInfoDuration.ToString("F3"), reflectionInfoRatio.ToString("F3"));
            Console.WriteLine("ReflectionInvokeMember: \t{0} Ratio: {1}", reflectionInvokeMemberDuration.ToString("F3"), reflectionInvokeMemberRatio.ToString("F3"));
            Console.WriteLine("Reflection: \t\t\t{0} Ratio: {1}", reflectionDuration.ToString("F3"), reflectionRatio.ToString("F3"));
        }
    }
}

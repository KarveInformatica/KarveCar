using System;
using System.Collections.Generic;
using Apache.Ibatis.Common.Test.Domain;
using Apache.Ibatis.Common.Utilities;
using NUnit.Framework;


namespace Apache.Ibatis.Common.Test.Fixtures.Utilities
{
    [TestFixture] 
    public class TypeResolverTest
    {
        /// <summary>
        /// Test space on generic type
        /// </summary>
        [Test]
        public void Generic_list_of_nullable_guid_should_be_resolved()
        {
            Type genericType = TypeUtils.ResolveType(typeof(List<Guid?>).FullName);
            Assert.IsNotNull(genericType);
        }

        /// <summary>
        /// Test space on generic type
        /// </summary>
        [Test]
        public void TestTrimSpace()
        {
            Type genericType = TypeUtils.ResolveType("System.Collections.Generic.Dictionary`2[[System.String],[System.Int32]]");

            Assert.IsNotNull(genericType);
        }



        /// <summary>
        /// Test nullable resolver
        /// </summary>
        [Test]
        public void TestFullNameNullableType()
        {
            Type nullableType = typeof(bool?);

            Type nullableBooleanType = TypeUtils.ResolveType(nullableType.FullName);

            Assert.IsNotNull(nullableBooleanType);
        }

        /// <summary>
        /// Test nullable resolver
        /// </summary>
        [Test]
        public void TestAssemblyQualifiedNameNullableType()
        {
            Type nullableType = typeof(bool?);

            Type nullableBooleanType = TypeUtils.ResolveType(nullableType.AssemblyQualifiedName);

            Assert.IsNotNull(nullableBooleanType);
        }

        /// <summary>
        /// Test generic list resolver
        /// </summary>
        [Test]
        public void TestGeneicListType()
        {
            IList<Account> list = new List<Account>();
            string assemblyQualifiedName = list.GetType().AssemblyQualifiedName;
            Type listType = TypeUtils.ResolveType(assemblyQualifiedName);

            Assert.IsNotNull(listType);
        }

        /// <summary>
        /// Test generic dictionary resolver
        /// </summary>
        [Test]
        public void TestGenericDictionaryType()
        {
            IDictionary<string, int> dico = new Dictionary<string, int>();

            Console.WriteLine(typeof(IDictionary<,>).FullName);
            Console.WriteLine(dico.GetType().FullName);

            string assemblyQualifiedName = dico.GetType().AssemblyQualifiedName;
            Type listType = TypeUtils.ResolveType(assemblyQualifiedName);

            Assert.IsNotNull(listType);
        }

        /// <summary>
        /// Test generic dictionary resolver
        /// </summary>
        [Test]
        public void TestGenericParameter()
        {
            IDictionary<List<int>, List<string>> dico = new Dictionary<List<int>, List<string>>();

            Console.WriteLine(typeof(IDictionary<,>).FullName);
            Console.WriteLine(dico.GetType().FullName);

            string assemblyQualifiedName = dico.GetType().AssemblyQualifiedName;
            Type type = TypeUtils.ResolveType(assemblyQualifiedName);

            Assert.IsNotNull(type);

            MyGeneric<Dictionary<List<int>, List<string>>, string, List<int>, decimal> gen = new MyGeneric<Dictionary<List<int>, List<string>>, string, List<int>, decimal>();

            Console.WriteLine(gen.GetType().FullName);

            assemblyQualifiedName = gen.GetType().AssemblyQualifiedName;
            type = TypeUtils.ResolveType(assemblyQualifiedName);

            Assert.IsNotNull(type);

            Assert.That(gen, Is.InstanceOfType(type));
        }

        private class MyGeneric<X, Y, Z, W>
        {}

    }
}

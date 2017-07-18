using System.Collections.Generic;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Contracts.Exceptions;
using Apache.Ibatis.Common.Test.Domain;
using NUnit.Framework;
using Is=Apache.Ibatis.Common.Contracts.Constraints.Is;

namespace Apache.Ibatis.Common.Test.Fixtures.Contracts
{
    [TestFixture]
    public class RequireTest
    {
        [Test]
        public void Boolean_condition_should_be_true()
        {
            Contract.Require.That(1 == 1).When("checking boolean condition");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Boolean object should be equal to 'True' when checking condition")]
        public void Boolean_condition_should_raise_exception_on_when_false()
        {
            Contract.Require.That(1 == 2).When("checking condition");
        }

        [Test]
        public void Boolean_true_should_be_true()
        {
            bool val1 = true;

            Contract.Require.That(val1, Common.Contracts.Constraints.Is.True).When("checking true bool value");
        }

        [Test]
        public void Boolean_false_should_be_false()
        {
            bool val1 = false;

            Contract.Require.That(val1, Common.Contracts.Constraints.Is.False).When("checking false bool value");
        }

        [Test]
        public void Should_be_negate()
        {
            bool val1 = false;

            Contract.Require.That(val1, !Common.Contracts.Constraints.Is.True).When("negating");
        }

        [Test]
        public void Null_should_be_null()
        {
            Contract.Require.That(null, Common.Contracts.Constraints.Is.Null).When("checking null value");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "String object should be equal to null when checking string value")]
        public void Should_raise_exception_when_constraint_null_not_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Null).When("checking string value");
        }

        [Test]
        public void String_should_be_empty()
        {
            Contract.Require.That(string.Empty, Common.Contracts.Constraints.Is.Empty).When("checking empty string");
        }

        [Test]
        public void Collection_should_be_empty()
        {
            Contract.Require.That(new List<string>(), Common.Contracts.Constraints.Is.Empty).When("checking empty collection");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "String object should be empty when checking empty string")]
        public void Should_raise_exception_when_constraint_empty_not_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Empty).When("checking empty string");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Boolean object should be equal to 'False' when checking boolean value")]
        public void Should_raise_exception_when_constraint_not_verified()
        {
            Contract.Require.That(true, Common.Contracts.Constraints.Is.False).When("checking boolean value");
        }

        [Test]
        public void Should_be_equal_to_2()
        {
            Contract.Require.That(2, Common.Contracts.Constraints.Is.EqualTo(2)).When("checking 2 value");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Int32 object should be equal to '2' when checking 3 value")]
        public void Should_raise_exception_when_not_equal_to()
        {
            Contract.Require.That(3, Common.Contracts.Constraints.Is.EqualTo(2)).When("checking 3 value");
        }

        [Test]
        public void And_constraints_should_be_verified()
        {
            int integer = 35;
            Contract.Require.That(integer, Common.Contracts.Constraints.Is.EqualTo(35) & Common.Contracts.Constraints.Is.Not.Null).When("checking and constraint");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "String object should be equal to 'titi' when checking string")]
        public void Should_raise_exception_when_and_constraints_not_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.EqualTo("titi") & Common.Contracts.Constraints.Is.Empty).When("checking string");
        }

        [Test]
        public void Or_constraints_should_be_verified()
        {
            Contract.Require.That(string.Empty, Common.Contracts.Constraints.Is.Null | Common.Contracts.Constraints.Is.Empty).When("checking or constraint");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "String object should be empty when checking string value")]
        public void Should_raise_exception_when_or_constraints_not_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Null | Common.Contracts.Constraints.Is.Empty).When("checking string value");
        }

        [Test]
        public void Not_null_constraint_should_be_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Not.Null).When("checking string");
        }

        [Test]
        public void Not_empty_constraint_should_be_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Not.Empty).When("checking string");
        }

        [Test]
        public void Not_equal_constraint_should_be_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Not.EqualTo("titi")).When("checking 'toto' string");
        }

        [Test]
        public void And_not_constraints_should_be_verified()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.Not.Null & Common.Contracts.Constraints.Is.Not.Empty).When("checking 'toto' string");
        }

        [Test]
        public void Should_be_typeof_string()
        {
            Contract.Require.That("toto", Common.Contracts.Constraints.Is.TypeOf<string>()).When("checking 'toto' string");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Int32 object should be of type String when checking 25")]
        public void Should_raise_exception_when_typeof_not_verified()
        {
            Contract.Require.That(25, Common.Contracts.Constraints.Is.TypeOf<string>()).When("checking 25");
        }

        [Test]
        public void Should_be_assignable_from()
        {
            Contract.Require.That("Hello", Common.Contracts.Constraints.Is.AssignableFrom<string>()).When("checking assignable");
        }

        [Test]
        public void Should_be_not_assignable_from()
        {
            Contract.Require.That(55, Common.Contracts.Constraints.Is.Not.AssignableFrom<string>()).When("checking assignable");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Int32 object should be assignable from String when checking assignable")]
        public void Should_raise_exception_when_assignable_not_verified()
        {
            Contract.Require.That(55, Common.Contracts.Constraints.Is.AssignableFrom<string>()).When("checking assignable");
        }

        [Test]
        public void Should_be_same_as()
        {
            Address address1 = new Address();
            Address address2 = address1;

            Contract.Require.That(address2, Common.Contracts.Constraints.Is.SameAs(address1)).When("checking same");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Address object should be same as Apache.Ibatis.Common.Test.Domain.Address when checking same")]
        public void Should_raise_exception_when_sameas_not_verified()
        {
            Address address1 = new Address();
            Address address2 = new Address(); ;

            Contract.Require.That(address2, Common.Contracts.Constraints.Is.Not.SameAs(address1)).When("checking not same");
            Contract.Require.That(address2, Common.Contracts.Constraints.Is.SameAs(address1)).When("checking same");
        }

        [Test]
        public void Should_contains()
        {
            Contract.Require.That("gilles bayon", Common.Contracts.Constraints.Is.Contains("gilles")).When("checking contains");
        }

        [Test]
        public void Should_like()
        {
            Contract.Require.That("123abc456", Common.Contracts.Constraints.Is.Like("abc")).When("checking like");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Object reference should not be equal to null when retrieving argument IResource")]
        public void Should_be_not_null()
        {
            Contract.Require.That(null, Common.Contracts.Constraints.Is.Not.Null).When("retrieving argument IResource");
        }

        [Test]
        public void Should_be_LessThan_3()
        {
            Contract.Require.That(2, Common.Contracts.Constraints.Is.LessThan(3)).When("checking LessThan");
        }

        [Test]
        public void Should_be_GreaterThan_3()
        {
            Contract.Require.That(5, Common.Contracts.Constraints.Is.GreaterThan(3)).When("checking GreaterThan");
        }

        [Test]
        [ExpectedException(typeof(PreConditionException), ExpectedMessage = "Int32 object should greater than '10' when checking GreaterThan")]
        public void Should_be_GreaterThan_10()
        {
            Contract.Require.That(5, Common.Contracts.Constraints.Is.GreaterThan(10)).When("checking GreaterThan");
        }

        [Test]
        public void Should_be_Anything()
        {
            Contract.Require.That("abracadabra", Common.Contracts.Constraints.Is.Anything).When("checking Anything");
        }
    }
}

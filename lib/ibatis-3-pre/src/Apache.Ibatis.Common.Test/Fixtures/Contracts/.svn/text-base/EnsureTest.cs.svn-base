using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Contracts.Exceptions;
using NUnit.Framework;
using Is=Apache.Ibatis.Common.Contracts.Is;

namespace Apache.Ibatis.Common.Test.Fixtures.Contracts
{
    [TestFixture]
    public class EnsureTest
    {

        [Test]
        [ExpectedException(typeof(PostConditionException), ExpectedMessage = "Boolean object should be equal to 'True' when checking false value")]
        public void Boolean_condition_should_raise_exception_on_when_false()
        {
            Contract.Ensure.That(1 == 2).When("checking false value");
        }

        [Test]
        [ExpectedException(typeof(PostConditionException), ExpectedMessage = "String object should be equal to 'titi' when checking string")]
        public void Should_raise_exception_when_and_constraints_not_verified()
        {
            Contract.Ensure.That("toto", Is.EqualTo("titi") & Is.Empty).When("checking string");
        }

    }
}

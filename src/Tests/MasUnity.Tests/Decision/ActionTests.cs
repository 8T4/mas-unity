using FluentAssertions;
using MasUnity.Decision.Actions;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class ActionTests
    {
        [Fact]
        public void Test_perception_assertion()
        {
            var perception = Perception.Assertion(() => true);

            perception.IsFalse.Should().BeFalse();
            perception.IsTrue.Should().BeTrue();
        }
        
        [Fact]
        public void Test_proposition_assertion()
        {
            var perception = Proposition.Assertion("true", true);

            perception.IsFalse.Should().BeFalse();
            perception.IsTrue.Should().BeTrue();
            perception.Description.Should().Be("true");
        }        
        
    }
}
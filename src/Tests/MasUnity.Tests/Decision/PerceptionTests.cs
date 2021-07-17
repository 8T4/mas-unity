using System.Threading.Tasks;
using FluentAssertions;
using MasUnity.Decision.Actions;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class PerceptionTests
    {
        [Fact]
        public async Task Test_perception_assertion()
        {
            var perception = await Perception.Assertion(() => true);

            perception.IsFalse.Should().BeFalse();
            perception.IsTrue.Should().BeTrue();
        }
        
        [Fact]
        public async Task Test_perception_assertion_with_whennotrealize_method_defined()
        {
            var perception = await Perception.Assertion(() => false);
            
            await perception.IfNotRealize(() =>
            {
                Assert.True(true, "IfNotRealize was called");
            });

            perception.IsFalse.Should().BeTrue();
            perception.IsTrue.Should().BeFalse();
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
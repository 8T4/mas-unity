using System;
using System.Threading;
using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Decision.Actions;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Agents
{
    public class ReactiveAgentTests
    {
        [Fact]
        public void Test_constructor()
        {
            var agent = new SynchronousReactiveAgentStub();
            
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Concurrency.Should().Be(ConcurrencyMode.Synchronous);
            agent.State.Value.Should().Be(AgentStates.Initiated);
            agent.State.Description.Should().Be(AgentStates.Initiated.ToString());
            agent.Identity.Should().BeNull();
        }

        [Fact]
        public void Test_invoke_synchronously()
        {
            var agent = new SynchronousReactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }
        
        [Fact]
        public void Test_invoke_asynchronously()
        {
            var agent = new AsynchronousReactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.Concurrency.Should().Be(ConcurrencyMode.Asynchronous);
            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }  
        
        [Fact]
        public void Test_invoke_failure_action()
        {
            var agent = new FailureAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeFalse();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }
        
        [Fact]
        public void Test_invoke_move_next()
        {
            var agent = new SkypAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().BeNull();
        }  
        
        [Fact]
        public void Test_invoke_move_next_async()
        {
            var agent = new SkypAsyncAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().BeNull();
        }         
        
        [Fact]
        public void Test_invoke_exception_action()
        {
            var agent = new ExceptionAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeFalse();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }   
        
        [Fact]
        public void Test_invoke_cancelation_token_action()
        {
            var agent = new CancellationTokenAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.Result.IsSuccess.Should().BeFalse();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }        
    }
}
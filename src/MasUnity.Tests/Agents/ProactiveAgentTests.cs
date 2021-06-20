using System;
using System.Threading;
using FluentAssertions;
using MasUnity.Decision;
using MasUnity.Decision.Actions;
using MasUnity.Tests.Stubs;
using Xunit;

namespace MasUnity.Tests.Agents
{
    public class ProactiveAgentTests
    {
        [Fact]
        public void Test_constructor()
        {
            var agent = new SynchronousProactiveAgentStub();
            
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Concurrency.Should().Be(ConcurrencyMode.Synchronous);
            agent.State.Value.Should().Be(AgentStates.Initiated);
            agent.State.Description.Should().Be(AgentStates.Initiated.ToString());
            agent.Identity.Should().BeNull();
        }

        [Fact]
        public void Test_invoke_synchronously()
        {
            var agent = new SynchronousProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Active);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Quit();
        }
        
        [Fact]
        public void Test_invoke_asynchronously()
        {
            var agent = new AsynchronousProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.Concurrency.Should().Be(ConcurrencyMode.Asynchronous);
            agent.State.Value.Should().Be(AgentStates.Active);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeTrue();
        } 
        
        [Fact]
        public void Test_invoke_failure_action()
        {
            var agent = new FailureProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Active);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void Test_invoke_move_next()
        {
            var agent = new SkypProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Active);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().BeNull();
        }  
        
        [Fact]
        public void Test_invoke_move_next_async()
        {
            var agent = new SkypAsyncProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Active);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeTrue();
            agent.Report.Result.Reasons.Should().BeNull();
        }         
        
        [Fact]
        public void Test_invoke_exception_action()
        {
            var agent = new ExceptionProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeFalse();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }   
        
        [Fact]
        public void Test_invoke_cancelation_token_action()
        {
            var agent = new CancellationTokenProactiveAgentStub();
            agent.Invoke();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            agent.State.Value.Should().Be(AgentStates.Suspended);
            agent.Report.LastExecution.Should().NotBeNull();
            agent.Report.Result.IsSuccess.Should().BeFalse();
            agent.Report.Result.Reasons.Should().HaveCountGreaterThan(0);
        }        
    }
}
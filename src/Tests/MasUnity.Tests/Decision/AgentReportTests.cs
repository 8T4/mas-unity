using System;
using FluentAssertions;
using MasUnity.Decision;
using Xunit;

namespace MasUnity.Tests.Decision
{
    public class AgentReportTests
    {
        private readonly AgentReport _report;

        public AgentReportTests()
        {
            _report = new AgentReport();
        }

        [Fact]
        public void Test_constructor()
        {
            _report.Result.IsSuccess.Should().BeTrue();
            _report.LastExecution.Should().BeNull();
            _report.NextExecution.Should().BeNull();
        }
        
        [Fact]
        public void Test_update_next_execution()
        {
            _report.UpdateNextExecution(DateTimeOffset.Now);
            _report.LastExecution.Should().BeNull();
            _report.NextExecution.Should().NotBeNull();
        }  
        
        [Fact]
        public void Test_update_next_execution_when_exception_by_null()
        {
            try
            {
                _report.UpdateNextExecution(null);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }            
        } 
        
        [Fact]
        public void Test_update_next_execution_when_exception_by_invalid_date()
        {
            try
            {
                _report.UpdateNextExecution(DateTimeOffset.Now.AddMinutes(1));
                _report.UpdateNextExecution(DateTimeOffset.Now);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }


    }
}
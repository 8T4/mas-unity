using System.Threading.Tasks;
using MasUnity.Cluster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasUnity.HostedService.Contracts
{
    /// <summary>
    /// Agent controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AgentsController: ControllerBase
    {
        private IAgentStorage InMemoryStorage { get; }

        public AgentsController(IAgentStorage inMemoryStorage)
        {
            InMemoryStorage = inMemoryStorage;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var result = await InMemoryStorage.GetAll().ConfigureAwait(false);
            var statusCode = result == null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK;
            return StatusCode(statusCode, result);
        }
        
        [HttpGet("instance/{uri}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string uri)
        {
            var result = await InMemoryStorage.Get(uri).ConfigureAwait(false);
            var statusCode = result == null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK;
            return StatusCode(statusCode, result);
        }   
        
        [HttpPost("instance/{uri}/invoke")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Invoke(string uri)
        {
            var result = await InMemoryStorage.Get(uri).ConfigureAwait(false);
            await result.Invoke().ConfigureAwait(false);
            return NoContent();
        }

        [HttpPost("instance/{uri}/resume")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Resume(string uri)
        {
            var result = await InMemoryStorage.Get(uri).ConfigureAwait(false);
            await result.Resume().ConfigureAwait(false);
            return NoContent();
        }     
        
        [HttpPost("instance/{uri}/waiting")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Waiting(string uri)
        {
            var result = await InMemoryStorage.Get(uri).ConfigureAwait(false);
            await result.Wait().ConfigureAwait(false);
            return NoContent();
        }    
        
        [HttpPost("instance/{uri}/wakeup")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> WakeUp(string uri)
        {
            var result = await InMemoryStorage.Get(uri).ConfigureAwait(false);
            await result.WakeUp().ConfigureAwait(false);
            return NoContent();
        }        
    }
}
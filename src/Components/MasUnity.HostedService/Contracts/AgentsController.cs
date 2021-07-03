using System.ComponentModel;
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
        private IAgentStorage Storage { get; }

        public AgentsController(IAgentStorage storage)
        {
            Storage = storage;
        }

        /// <summary>
        /// Get all agents
        /// </summary>
        /// <returns>List of Agents</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Description("Get all agents")]
        public async Task<IActionResult> Get()
        {
            var result = await Storage.GetAll().ConfigureAwait(false);
            var statusCode = result == null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK;
            return StatusCode(statusCode, result);
        }
        
        /// <summary>
        /// Get agent by uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>Agent Instance</returns>
        [HttpGet("instance/{uri}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string uri)
        {
            var result = await Storage.Get(uri).ConfigureAwait(false);
            var statusCode = result == null ? StatusCodes.Status404NotFound : StatusCodes.Status200OK;
            return StatusCode(statusCode, result);
        }   
        
        /// <summary>
        /// Invoke an agent!
        /// It´s must be Initiated
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>202 - Result</returns>
        [HttpPatch("instance/{uri}/invoke")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Invoke(string uri)
        {
            var result = await Storage.Get(uri).ConfigureAwait(false);
            await result.Invoke().ConfigureAwait(false);
            return NoContent();
        }

        /// <summary>
        /// Resume an agent!
        /// It´s must be Suspended
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>202 - Result</returns>
        [HttpPatch("instance/{uri}/resume")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Resume(string uri)
        {
            var result = await Storage.Get(uri).ConfigureAwait(false);
            await result.Resume().ConfigureAwait(false);
            return NoContent();
        }     
        
        /// <summary>
        /// Uptate an agent to Waiting State
        /// It´s must be Active
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>202 - Result</returns>
        [HttpPatch("instance/{uri}/waiting")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Waiting(string uri)
        {
            var result = await Storage.Get(uri).ConfigureAwait(false);
            await result.Wait().ConfigureAwait(false);
            return NoContent();
        }    
        
        /// <summary>
        /// WakeUp an agent
        /// It´s must be in state Waiting
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>202 - Result</returns>
        [HttpPatch("instance/{uri}/wakeup")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> WakeUp(string uri)
        {
            var result = await Storage.Get(uri).ConfigureAwait(false);
            await result.WakeUp().ConfigureAwait(false);
            return NoContent();
        }        
        
        /// <summary>
        /// Quit an agent
        /// It´s must be not Active
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>202 - Result</returns>
        [HttpDelete("instance/{uri}/quit")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Quit(string uri)
        {
            await Storage.Remove(uri).ConfigureAwait(false);
            return NoContent();
        }        
    }
}
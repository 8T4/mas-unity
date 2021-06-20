using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasUnity.Commons.Storages
{
    public abstract class AbstractStorage<T>
    {
        private Dictionary<string, T> Agents { get; }

        protected AbstractStorage()
        {
            Agents = new Dictionary<string, T>();
        }

        public Task Add(string uri, T agent)
        {
            Agents[uri] = agent;
            return Task.CompletedTask;
        }

        public Task<T> Get(string uri)
        {
            var result = Agents.ContainsKey(uri) ? Agents[uri] : default;
            return Task.FromResult(result);
        }
        
        public Task<IEnumerable<T>> GetAll()
        {
            var result = Any() ? Agents.Values : default;
            return Task.FromResult<IEnumerable<T>>(result);
        }

        public int Count() => Agents.Count;
        public bool Any() => Agents.Any();        
    }
}
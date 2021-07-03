namespace MasUnity.HostedService.Contracts
{
    public interface IAgentServiceScope
    {
        T GetService<T>();
    }
}
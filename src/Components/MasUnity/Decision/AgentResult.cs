using System.Collections.Generic;
using System.Linq;

namespace MasUnity.Decision
{
    public sealed class AgentResult
    {
        public bool IsSuccess { get; private set; }
        public string[] Reasons { get; private set; }

        private AgentResult(bool isSuccess, string[] reasons)
        {
            IsSuccess = isSuccess;
            Reasons = reasons;
        }

        public static AgentResult Fail(params string[] reasons) =>
            new AgentResult(false, reasons);        

        public static AgentResult Ok() =>
            new AgentResult(true, default);

        public static AgentResult Ok(params string[] reasons) =>
            new AgentResult(true, reasons);

        public void Merge(params AgentResult[] results)
        {
            IsSuccess = results.All(r => r.IsSuccess);
            var reasons = new List<string>();

            foreach (var result in results)
            {
                reasons.AddRange(result.Reasons);
            }

            Reasons = reasons.ToArray();
        }
                    
    }
}
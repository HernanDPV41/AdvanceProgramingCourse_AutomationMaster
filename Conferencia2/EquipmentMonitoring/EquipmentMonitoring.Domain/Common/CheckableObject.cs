using FluentResults;

namespace EquipmentMonitoring.Domain.Common
{
    public abstract class CheckableObject
    {
        protected CheckableObject() { }

        protected static Result CheckRules(params IBusinessRule[] Rules)
        {
            List<Result> results = new List<Result>();
            foreach (var rule in Rules)
            {
                results.Add(rule.CheckRule());
            }
            return Result.Merge(results.ToArray());
        }

    }
}

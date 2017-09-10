using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Database
{
    public interface IDatabase
    {
        IList<ISeason> Seasons { get; }

        IList<IStudent> Students { get; }

        IList<ITrainer> Trainers { get; }

        IList<string> ExecutionResult { get; }
    }
}

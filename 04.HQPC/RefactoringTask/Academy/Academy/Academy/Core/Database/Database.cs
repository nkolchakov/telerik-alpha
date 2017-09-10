using Academy.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Academy.Core.Database
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.Seasons = new List<ISeason>();
            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
            this.ExecutionResult = new List<string>();
        }

        public IList<ISeason> Seasons { get; }

        public IList<IStudent> Students { get; }

        public IList<ITrainer> Trainers { get; }

        public IList<string> ExecutionResult { get; }
    }
}

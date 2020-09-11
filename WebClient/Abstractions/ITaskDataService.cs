using Domain.Commands;
using Domain.Queries;
using System.Threading.Tasks;

namespace WebClient.Abstractions
{
    public interface ITaskDataService
    {
        public Task<CreateTaskCommandResult> Create(CreateTaskCommand command);
        public Task<GetAllTasksQueryResult> GetAllTasks();
        public Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command);
    }
}

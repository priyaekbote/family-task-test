using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Domain.Commands;
using Domain.Queries;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = Domain.DataModels;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<CreateTaskCommandResult> CreateTaskCommandHandler(CreateTaskCommand command)
        {
            var taskRecord = _mapper.Map<DataModel.Task>(command);
            var task = await _taskRepository.CreateRecordAsync(taskRecord);

            var vm = _mapper.Map<TaskVm>(task);

            return new CreateTaskCommandResult()
            {
                Tasks = vm
            };
        }

        public async Task<GetAllTasksQueryResult> GetAllTasksQueryHandler()
        {
            IEnumerable<TaskVm> vm = new List<TaskVm>();

            var tasks = await _taskRepository.Reset().ToListAsync();

            if (tasks != null && tasks.Any())
                vm = _mapper.Map<IEnumerable<TaskVm>>(tasks);

            return new GetAllTasksQueryResult()
            {
                Tasks = vm
            };
        }

        public async Task<UpdateTaskCommandResult> UpdateTaskCommandHandler(UpdateTaskCommand command)
        {
            var isSucceed = true;
            var task = await _taskRepository.ByIdAsync(command.Id);

            _mapper.Map<UpdateTaskCommand, Domain.DataModels.Task>(command, task);

            var affectedRecordsCount = await _taskRepository.UpdateRecordAsync(task);

            if (affectedRecordsCount < 1)
                isSucceed = false;

            return new UpdateTaskCommandResult()
            {
                Succeed = isSucceed
            };
        }
    }
}

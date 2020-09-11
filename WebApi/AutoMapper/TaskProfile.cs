﻿using AutoMapper;
using Domain.Commands;
using Domain.ViewModel;

namespace WebApi.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskCommand, Domain.DataModels.Task>();
            CreateMap<UpdateTaskCommand, Domain.DataModels.Task>();
            CreateMap<Domain.DataModels.Task, TaskVm>();
        }
    }
}

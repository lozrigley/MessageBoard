using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.MongoDb
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration CreateConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application.Query.DAL.Message, Message>().ReverseMap();
            });
        }
    }
}

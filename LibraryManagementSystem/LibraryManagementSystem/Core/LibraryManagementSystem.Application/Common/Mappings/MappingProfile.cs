using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities.Dals;
using LibraryManagementSystem.Domain.Entities.Dtos;

namespace LibraryManagementSystem.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UsersDto>();

        }


    }
}

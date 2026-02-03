using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace CleanArch.Application.Mappings
{
    public  class DomainToViewModelMappingProfile:Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}

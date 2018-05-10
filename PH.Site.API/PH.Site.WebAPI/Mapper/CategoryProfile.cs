using AutoMapper;
using PH.Site.Entity;
using PH.Site.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PH.Site.WebAPI.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            var mapper = CreateMap<CategoryDTO, AppCategory>();
            mapper.ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.Id));
            mapper.ForMember(o => o.CreateDate, opt => opt.MapFrom(s => DateTime.Now));
            mapper.ForMember(o => o.ModifyDate, opt => opt.MapFrom(s => DateTime.Now));
            CreateMap<AppCategory, CategoryDTO>();
        }
    }
}

using AutoMapper;
using PH.Site.DTO;
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
            CreateMap<CategoryDTO, AppCategory>()
               .ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.Id))
               .ForMember(o => o.CreateDate, opt => opt.MapFrom(s => s.CreateDate ?? DateTime.Now))
               .ForMember(o => o.ModifyDate, opt => opt.MapFrom(s => s.ModifyDate ?? DateTime.Now));


            CreateMap<AppCategory, CategoryDTO>()
               .ForMember(o => o.Id, opt => opt.MapFrom(s => s.CategoryId));
        }
    }
}

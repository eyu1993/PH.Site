using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PH.Site.Infrastructure
{
    public class AutoMapperHelper
    {
        private static IMapper _mapper;
        public AutoMapperHelper(IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        /// 单个对象映射
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="obj">源对象</param>
        /// <returns>目标对象</returns>
        public static TDestination Map<TDestination, TSource>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        ///// <summary>
        ///// 集合列表类型映射
        ///// </summary>
        //public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        //{
        //    Mapper.CreateMap<TSource, TDestination>();
        //    return Mapper.Map<List<TDestination>>(source);
        //}
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syntax.Ofesauto.Security.Transversal.Common
{
    public class AutoMapp<T, T2>
    {
        public static T2 Convert(T obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });

            Mapper mapper = new Mapper(config);

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<T, T2>(obj);
        }

        public static IEnumerable<T2> ConvertList(IEnumerable<T> obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });

            Mapper mapper = new Mapper(config);

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<T>, IEnumerable<T2>>(obj);
        }

        public static List<T2> ConvertList2(List<T> obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });

            Mapper mapper = new Mapper(config);

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<List<T>, List<T2>>(obj);
        }

        // Me lo invente yo mismo
        public static T Map<T> (object source) where T : class
        {
            var config = new MapperConfiguration(cfg => { });

            var destinationType = typeof(T);
            var sourceType = source.GetType();

            Mapper mapper = new Mapper(config);
            IMapper iMapper = config.CreateMapper();

            var mappingResult = iMapper.Map(source, sourceType, destinationType);
            return mappingResult as T;
        }
    }
}

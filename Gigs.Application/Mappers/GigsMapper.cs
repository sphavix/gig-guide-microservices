using AutoMapper;

namespace Gigs.Application.Mappers
{
    public static class GigsMapper
    {
        private static readonly Lazy<IMapper> LazyMapper = new Lazy<IMapper>(() => 
        {
            var config = new MapperConfiguration(cfg => 
            {
                // Add all profiles here
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<GigsMapperProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });  

        public static IMapper Mapper => LazyMapper.Value;
    }
}
using AutoMapper;
using Prac_assignments.Model;
using Prac_assignments.Model.Dto;

namespace Prac_assignments
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(configurationExpression =>
            {
                configurationExpression.CreateMap<UserDto, UserProfile>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}

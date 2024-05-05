
using AutoMapper;
using DateVoyage.DTOs;
using DateVoyage.Entity;

namespace DateVoyage.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}

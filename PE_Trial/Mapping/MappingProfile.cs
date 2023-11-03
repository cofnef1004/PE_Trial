using AutoMapper;
using DataAccess.DTO;
using PE_Trial.DTOs;
using PE_Trial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Director, DirectorDto>()
                .ForMember(a => a.DobString, opt => opt.MapFrom(src => src.Dob.ToString("dd/MM/yyyy")))
                .ForMember(a => a.Gender, opt => opt.MapFrom(src => src.Male ? "Male" : "Female"))
                .ReverseMap();

            CreateMap<Director, DirectorDto2>()
                .ForMember(a => a.DobString, opt => opt.MapFrom(src => src.Dob.ToString("dd/MM/yyyy")))
                .ForMember(a => a.Gender, opt => opt.MapFrom(src => src.Male ? "Male" : "Female"))
                .ReverseMap();

            CreateMap<Director,AddRequest>()
                .ForMember(a => a.Dob , opt => opt.MapFrom(src => src.Dob.ToString("yyyy-MM-dd"))).ReverseMap();

            CreateMap<Producer, ProducerDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>()
                .ForMember(a => a.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year : (int?)null))
                .ForMember(a => a.ProducerName, opt => opt.MapFrom(src => src.Producer != null ? src.Producer.Name : null))
                .ForMember(a => a.DirectorName, opt => opt.MapFrom(src => src.Director != null ? src.Director.FullName : null));
        }
    }
}

using AutoMapper;
using NavieraOceanoAzul.DTO;
using NavieraOceanoAzul.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClienteDTO, Cliente>();
        CreateMap<BarcoDTO, Barco>();
        CreateMap<TiqueteDTO, Tiquete>();
        CreateMap<HabitacionDTO, Habitacion>();
    }
}
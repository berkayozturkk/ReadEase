using AutoMapper;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Domain.Entities;

namespace ReadEase.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Book, GetAllBookQueryListItemDto>().ReverseMap();
        CreateMap<CreateBookCommand, Book>().ReverseMap();
    }
}

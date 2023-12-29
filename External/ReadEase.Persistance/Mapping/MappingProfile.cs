using AutoMapper;
using ReadEase.Application.Features.BookFeatures.Command.CreateBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBook;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookByStatus;
using ReadEase.Application.Features.BookFeatures.Queries.GetAllBookGenre;
using ReadEase.Application.Features.LoanFeatures.Command.BorrowBook;
using ReadEase.Domain.Entities;
using ReadEase.Persistance.Configuration;

namespace ReadEase.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Book, GetAllBookQueryListItemDto>().ReverseMap();
        CreateMap<CreateBookCommand, Book>().ReverseMap();
        CreateMap<IQueryable<GetAllBookByStatusQueryListItemDto>, IQueryable<Book>>().ReverseMap();

        CreateMap<GetAllBookGenreQueryItemDto, BookGenre>().ReverseMap();

        CreateMap<BorrowBookCommand, Loan>().ReverseMap();
    }
}

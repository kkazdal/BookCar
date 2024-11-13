using System;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using CarBook.Application.Features.Mediator.Results.TagResults;
using CarBook.Application.Interfaces.TagRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers;

public class GetTagByBlogIdHandler : IRequestHandler<GetTagByBlogIdQuery, List<GetTagByBlogIdResult>>
{
    private readonly ITagRepository _tagRepository;

    public GetTagByBlogIdHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<List<GetTagByBlogIdResult>> Handle(GetTagByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _tagRepository.GetTagByBlogIdList(request.BlogId);
        return response;
    }
}

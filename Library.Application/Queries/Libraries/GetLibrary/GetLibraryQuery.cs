using Library.Application.Dtos.Library;

namespace Library.Application.Queries.Libraries.GetLibrary;

public sealed record GetLibraryQuery(Guid LibraryId) : IRequest<ResultResponse<ResponseLibraryUnitDto>>;
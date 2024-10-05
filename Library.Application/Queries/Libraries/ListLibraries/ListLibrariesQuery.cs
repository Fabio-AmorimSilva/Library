using Library.Application.Dtos.Library;

namespace Library.Application.Queries.Libraries.ListLibraries;

public sealed record ListLibrariesQuery : IRequest<ResultResponse<IEnumerable<ResponseLibraryUnitDto>>>;
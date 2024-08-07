using Library.Application.Dtos.Library;
using Library.Core.Result;

namespace Library.Application.Queries.Libraries.ListLibraries;

public sealed record ListLibrariesQuery : IRequest<ResultResponse<IEnumerable<ResponseLibraryUnitDto>>>;
using Library.Application.Dtos.Library;
using Library.Core.Result;

namespace Library.Application.Queries.Libraries.GetLibrary;

public sealed record GetLibraryQuery(Guid LibraryId) : IRequest<ResultResponse<ResponseLibraryUnitDto>>;
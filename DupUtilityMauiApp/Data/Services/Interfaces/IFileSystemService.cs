using DupUtilityMauiApp.Data.DTO;
using DupUtilityMauiApp.Data.Enums;

namespace DupUtilityMauiApp.Data.Services.Interfaces;

public interface IFileSystemService
{
    /// <summary>
    /// Finds file duplicates in the <paramref name="path"/>.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="duplicateSign"></param>
    Task<FindFileDuplicatesResponseDto> FindFileDuplicatesAsync(string path, DuplicateSign duplicateSign);
}

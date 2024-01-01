using DupUtilityMauiApp.Data.DTO;
using DupUtilityMauiApp.Data.Enums;
using DupUtilityMauiApp.Data.Services.Interfaces;
using System.Linq;

namespace DupUtilityMauiApp.Data.Services;

public class FileSystemService : IFileSystemService
{
    /// <inheritdoc/>
    public async Task<FindFileDuplicatesResponseDto> FindFileDuplicatesAsync(string path, DuplicateSign duplicateSign)
    {
        return duplicateSign switch
        {
            DuplicateSign.EqualityInNameAndLengthOfFiles | DuplicateSign.SubstringEqualityInFilenamesWithLengthEqualityInSameDirectory => 
                throw new NotImplementedException(),
            DuplicateSign.EqualityInNameAndLengthOfFiles => await Algorithm1Async(path),
            DuplicateSign.SubstringEqualityInFilenamesWithLengthEqualityInSameDirectory => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    private async Task<FindFileDuplicatesResponseDto> Algorithm1Async(string path)
    {
        // get all files in the path
        IEnumerable<string> filesPaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        var duplicatedFileInfoDtos = new List<FileInfoDto>();
        while (filesPaths.Any())
        {
            // search files with name of first element "filesPaths"
            var suitableFilesPaths = Directory.GetFiles(path, Path.GetFileName(filesPaths.First().AsSpan()).ToString(), SearchOption.AllDirectories);

            if (suitableFilesPaths.Count() > 1)
            {
                // if founds more than 1 file it means that duplicates found. let's put this duplicates file info on the list
                duplicatedFileInfoDtos.AddRange(
                    suitableFilesPaths
                        .Select(
                            suitableFilePath =>
                            {
                                var fileInfo = new FileInfo(suitableFilePath);
                                return new FileInfoDto
                                {
                                    Name = fileInfo.Name,
                                    DirectoryPath = fileInfo.DirectoryName,
                                    Length = fileInfo.Length,
                                    Extension = fileInfo.Extension,
                                    CreationTime = fileInfo.CreationTime,
                                    CreationTimeUtc = fileInfo.CreationTimeUtc,
                                    LastAccessTime = fileInfo.LastAccessTime,
                                    LastAccessTimeUtc = fileInfo.LastAccessTimeUtc,
                                    LastWriteTime = fileInfo.LastWriteTime,
                                    LastWriteTimeUtc = fileInfo.LastWriteTimeUtc
                                };
                            }));
                // except found elements
                filesPaths = filesPaths.Except(suitableFilesPaths);
            }
            else
            {
                // or skip first element if "suitableFilesPaths" length = 0 or 1
                filesPaths = filesPaths.Skip(1);
            }
        }
        return new FindFileDuplicatesResponseDto() { FileInfoDtosGroupedByDuplicateSign = duplicatedFileInfoDtos.GroupBy(x => x.Name) };
    }
}

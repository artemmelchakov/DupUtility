using DupUtilityMauiApp.Data.Enums;

namespace DupUtilityMauiApp.Data.DTO;

public class FindFileDuplicatesResponseDto
{
    public IEnumerable<IGrouping<string, FileInfoDto>> FileInfoDtosGroupedByDuplicateSign { get; set; }
}

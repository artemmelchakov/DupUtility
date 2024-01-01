namespace DupUtilityMauiApp.Data.Enums;

/// <summary>
/// Signs why some file may be duplicates.
/// </summary>
[Flags]
public enum DuplicateSign : byte
{
    /// <summary>
    /// It means when there are files in different directories and they have an equality in name and length it may be duplicates.
    /// </summary>
    /// <example>
    /// docs/a.txt [126 bytes]
    /// docs/old/a.txt [126 bytes]
    /// </example>
    EqualityInNameAndLengthOfFiles = 1,
    /// <summary>
    /// It means when there are files with approximately the same name and they have an equality in length, extension and directory it may be duplicates.
    /// </summary>
    /// <example>
    /// docs/a.txt [126 bytes]
    /// docs/a (1).txt [126 bytes]
    /// </example>
    SubstringEqualityInFilenamesWithLengthEqualityInSameDirectory = 2
}

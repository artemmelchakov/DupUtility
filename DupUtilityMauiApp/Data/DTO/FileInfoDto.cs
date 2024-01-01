namespace DupUtilityMauiApp.Data.DTO;

/// <summary>
/// Represents the DTO for a file info.
/// </summary>
public class FileInfoDto
{
    /// <summary>
    /// The file name.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The full path to the file's directory. 
    /// </summary>
    public string DirectoryPath { get; set; }
    /// <summary>
    /// The size, in bytes, of the current file.
    /// </summary>
    public long Length { get; set; }
    /// <summary>
    /// The extension of the current file.
    /// </summary>
    public string Extension { get; set; }
    /// <summary>
    /// The creation time of the current file.
    /// </summary>
    public DateTime CreationTime { get; set; }
    /// <summary>
    /// The creation time, in UTC, of the current file.
    /// </summary>
    public DateTime CreationTimeUtc { get; set; }
    /// <summary>
    /// The time when the current file was last accessed.
    /// </summary>
    public DateTime LastAccessTime { get; set; }
    /// <summary>
    /// The time, in UTC, when the current file was last accessed.
    /// </summary>
    public DateTime LastAccessTimeUtc { get; set; }
    /// <summary>
    /// The time when the current file was last written to.
    /// </summary>
    public DateTime LastWriteTime { get; set; }
    /// <summary>
    /// The time, in UTC, when the current file was last written to.
    /// </summary>
    public DateTime LastWriteTimeUtc { get; set; }
}

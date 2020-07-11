namespace Niccolo.Interfaces
{
    /// <summary>
    /// Represents a remote file system, such as HDFS.
    /// </summary>
    interface IRemoteFileSystem
    {
        /// <summary>
        /// Upload a file from the local machine to a temporary path on the remote file system.
        /// </summary>
        /// <param name="localFilePath">The path to the file on the local machine.</param>
        /// <returns></returns>
        IRemoteTempFile UploadTempFile(string localFilePath);
    }
}

using System;

namespace Niccolo.Interfaces
{
    /// <summary>
    /// Represents a temporary file on a remote file system. Disposing this object deletes the 
    /// file from the remote file system.
    /// </summary>
    interface IRemoteTempFile : IDisposable
    {
        /// <summary>
        /// The path to the temporary file on the remote file system.
        /// </summary>
        string Path { get; }
    }
}

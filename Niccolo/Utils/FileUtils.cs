using System;
using System.IO;
using System.IO.Compression;

namespace Niccolo.Utils
{
    static class FileUtils
    {
        /// <summary>
        /// Package some directory into a temporary ZIP archive.
        /// </summary>
        /// <param name="sourceDirectoryPath">Path to the source directory.</param>
        /// <returns>The path to the temporary ZIP file.</returns>
        public static string PackageTempZip(string sourceDirectoryPath)
        {
            string tempFileName = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.zip");

            // Zip the executing directory so it can be submitted to the cluster.
            ZipFile.CreateFromDirectory(sourceDirectoryPath, tempFileName);

            return tempFileName;
        }
    }
}

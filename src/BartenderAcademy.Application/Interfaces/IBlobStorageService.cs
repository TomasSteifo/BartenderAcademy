using System;
using System.Threading.Tasks;

namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Abstraction for uploading/downloading blobs (e.g., videos, certificates, badges) to Azure Blob Storage.
    /// Implemented in Infrastructure using Azure.Storage.Blobs.
    /// </summary>
    public interface IBlobStorageService
    {
        /// <summary>
        /// Uploads a file (byte array) to the specified container with the given blob name.
        /// Returns the full URI (or path) to the uploaded blob.
        /// </summary>
        Task<string> UploadAsync(byte[] fileBytes, string containerName, string blobName, string contentType);

        /// <summary>
        /// Downloads a blob’s contents as a byte array.
        /// </summary>
        Task<byte[]> DownloadAsync(string containerName, string blobName);

        /// <summary>
        /// Deletes the specified blob if it exists.
        /// </summary>
        Task DeleteAsync(string containerName, string blobName);

        /// <summary>
        /// Generates a read-only SAS URI for the specified blob that is valid for the given duration.
        /// </summary>
        Uri GetBlobUri(string containerName, string blobName, TimeSpan sasDuration);
    }
}

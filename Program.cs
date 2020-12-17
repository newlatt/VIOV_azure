using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Variables for the cloud storage objects.
                CloudStorageAccount cloudStorageAccount;
                CloudBlobClient blobClient;
                CloudBlobContainer blobContainer;
                BlobContainerPermissions containerPermissions;
                CloudBlob blob;

                // Use the local storage account.
                //cloudStorageAccount = CloudStorageAccount.DevelopmentStorageAccount;

                // If you want to use Windows Azure cloud storage account, use the following
                // code (after uncommenting) instead of the code above.
                //cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=yura123456;AccountKey=Q9nutvtNCYmlOaTDCY2CTJKXbbQaxgWzKoVvaC6AIDeSLLXq4SPlORSrCsSqtCpoTd7vCpr7YDQgFRiy8Yx+6w==");
                cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=hranlt;AccountKey=bETCHgsShy0pYUax/yOKs7B65ps7HrKp4QYGnqJdpyZ12qLVrJhA8q0c0D7cX2wnIpsBWALA56RRMcSKxHB7HA==");

                // Create the blob client, which provides
                // authenticated access to the Blob service.
                blobClient = cloudStorageAccount.CreateCloudBlobClient();

                // Get the container reference.
                blobContainer = blobClient.GetContainerReference("cont-1");
                // Create the container if it does not exist.
               // blobContainer.CreateIfNotExist();

                // Set permissions on the container.
                containerPermissions = new BlobContainerPermissions();
                // This sample sets the container to have public blobs. Your application
                // needs may be different. See the documentation for BlobContainerPermissions
                // for more information about blob container permissions.
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                blobContainer.SetPermissions(containerPermissions);


                blob  = blobContainer.GetBlobReference ("test.txt");
                                                
                var content = blob.DownloadText();
                           
                Console.WriteLine(content);
                Console.ReadLine();

            }
            catch (StorageClientException e)
            {
                Console.WriteLine("Storage client error encountered: " + e.Message);

                // Exit the application with exit code 1.
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered: " + e.Message);

                // Exit the application with exit code 1.
                System.Environment.Exit(1);
            }
            finally
            {
                // Exit the application.
                System.Environment.Exit(0);
            }
        }
    }
}
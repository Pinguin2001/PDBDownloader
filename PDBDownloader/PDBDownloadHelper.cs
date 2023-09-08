namespace PDBDownloader;

public static class PDBDownloadHelper
{
    public static async Task<byte[]> DownloadPDBAsync(string pdburl)
    {
        HttpClient client = new();
        byte[] bytes = await client.GetByteArrayAsync(new Uri(pdburl));
        client.Dispose();
        return bytes;
    }
}

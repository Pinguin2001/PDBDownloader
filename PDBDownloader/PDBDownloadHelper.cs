namespace PDBDownloader;

public static class PDBDownloadHelper
{
    public static async Task<byte[]> DownloadPDBAsync(string pdburl)
    {
        HttpClient client = new();
        byte[] bytes;
        try
        {
            bytes = await client.GetByteArrayAsync(new Uri(pdburl));
        }
        catch
        {
            return null;
        }
        client.Dispose();
        return bytes;
    }
}

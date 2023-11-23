namespace PDBDownloader;

public static class PDBFileHelper
{
    public static FileStream CreatePDBFile(string path, string filename)
    {
        FileStream fileStream;
        FileAttributes attributes = File.GetAttributes(path);

        if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
        {
            fileStream = File.Create(path + filename + ".pdb");
        }
        else
        {
            fileStream = File.Create(path);
        }
        return fileStream;
    }
}

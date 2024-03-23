namespace PDBDownloader;

public static class PDBFileHelper
{
    public static FileStream CreatePDBFile(string path, string filename)
    {
        FileStream fileStream;
        if (!File.Exists(path))
        {
            fileStream = File.Create(path + "\\" + filename + ".pdb");
        }
        else
        {
            FileAttributes attributes = File.GetAttributes(path);
            if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                fileStream = File.Create(path + "\\" + filename + ".pdb");
            }
            else
            {
                File.Delete(path);
                fileStream = File.Create(path + "\\" + filename + ".pdb");
            }
        }
        return fileStream;
    }
}

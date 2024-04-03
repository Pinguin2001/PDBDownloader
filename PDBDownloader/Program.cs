using PDBDownloader;
using PE2PDBUrl;
using System.Reflection;

if (args.Length != 2)
{
    Console.WriteLine($"PDBDownloader {Assembly.GetExecutingAssembly().GetName().Version} - msdl.microsoft.com pdb downloader");
    Console.WriteLine("\nUsage: <PE File> <PDB output path>");
    return;
}

string pefilepath = args[0];
string pefilename = Path.GetFileNameWithoutExtension(pefilepath);
string pdbfilepath = args[1];

if (!File.Exists(pefilepath))
{
    Console.WriteLine($"{pefilepath} does not exist");
    return;
}

Console.WriteLine("Parsing PE file...");
PEDebugInformation peDebugInformation = PEDebugInformation.GetDebugURLs(pefilepath);
if (string.IsNullOrEmpty(peDebugInformation.PDBUrl))
{
    Console.WriteLine($"{pefilepath} cannot be parsed correctly to retrieve debug information.\nThe file might be corrupt.");
    return;
}

Console.WriteLine($"Downloading {pefilename}.pdb...");
byte[] pdb = await PDBDownloadHelper.DownloadPDBAsync(peDebugInformation.PDBUrl);
if (pdb == null)
{
    Console.WriteLine($"An error occured while trying to download {pefilename}.pdb");
    return;
}

FileStream pdbfile = PDBFileHelper.CreatePDBFile(pdbfilepath, pefilename);

await pdbfile.WriteAsync(pdb);

Console.WriteLine($"PDB saved to {pdbfilepath}");
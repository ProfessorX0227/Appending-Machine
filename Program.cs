using System.IO;
using System.Linq;
using System.Diagnostics;

namespace AppendingMachine
{
	class Program
	{

		//Method appends csv data to master.csv file
		static void Main(string[] args)
		{

			string sourceFolder = @"C:\Users\xadams\Downloads\";
			string destinationFile = @"C:\Users\xadams\Desktop\MasterData.csv";

			//gets file from downloads folder
			string[] filePaths = Directory.GetFiles(sourceFolder);

			//new instance of streamwriter to output to destination
			StreamWriter fileDest = new StreamWriter(destinationFile, true);

			int i;
			for (i = 0; i < filePaths.Length; i++)
			{
				string file = filePaths[i];
				string[] lines = File.ReadAllLines(file);

				if (i >= 0)
				{
					lines = lines.Skip(1).ToArray(); //Skips header line
				}

				foreach (string line in lines)
				{
					fileDest.WriteLine(line);
				}

			}
			fileDest.Close();
	
			try
			{
				foreach (Process proc in Process.GetProcessesByName("EXCEL"))
				{
					proc.Kill();
				}
			}
			catch (System.Exception)
			{

			}

		}
	}
}

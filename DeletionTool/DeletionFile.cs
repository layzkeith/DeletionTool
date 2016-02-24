using System;
using System.Collections.Generic;
using System.IO;

namespace DeletionTool
{
	public class DeletionFile
	{
		public List<KeyValuePair <string, string>> DeletionList;

		public DeletionFile()
		{
			DeletionList = new List<KeyValuePair<string,string>>();
		}


		public void readFile()
		{

			FileStream fs = new FileStream ("test_file.txt", FileMode.Open);



			StreamReader inStream = new StreamReader (fs);

			while (!inStream.EndOfStream)
			{
				char delimiter = ' '; 
				//Console.WriteLine (inStream.ReadLine ());
				string line = inStream.ReadLine();
				string[] splitLine = line.Split (delimiter);

				string description = "";
				for( var i = 1; i < splitLine.Length; i++)
				{
					description += splitLine[i] + " ";
				}

				DeletionList.Add (new KeyValuePair<string, string> (splitLine[0], description));
				//Console.WriteLine (splitLine[0]);
				//Console.WriteLine (description);
				description = "";
			}

		}

		public void storeFile()
		{

		}

		public void printFile()
		{
			Console.WriteLine ("In printFile() method...");
			foreach(var element in DeletionList)
			{
				Console.WriteLine (element);	
			}

		}
	}
}


using System;
using System.Collections.Generic;
using System.IO;

namespace DeletionTool
{
	public class DeletionFile
	{
		private List<KeyValuePair <string, string>> deletionList;
		private string nameOfFile;

		public DeletionFile(string fileName)
		{
			deletionList = new List<KeyValuePair<string,string>>();
			nameOfFile = fileName;
		}


		public void readFile()
		{

			FileStream fs = new FileStream (nameOfFile, FileMode.Open);



			StreamReader inStream = new StreamReader (fs);

			while (!inStream.EndOfStream)
			{
				char delimiter = ' '; 

				string line = inStream.ReadLine();
				string[] splitLine = line.Split (delimiter);

				string description = "";
				for( var i = 1; i < splitLine.Length; i++)
				{
					description += splitLine[i] + " ";
				}

				deletionList.Add (new KeyValuePair<string, string> (splitLine[0], description));

				description = "";
			}

		}

		public void storeFile()
		{

		}

		public void printFile()
		{
			Console.WriteLine ("In printFile() method...");
			foreach(var element in deletionList)
			{
				Console.WriteLine (element);	
			}

		}

		public string NameOfFile
		{
			get { return nameOfFile; }
			set { nameOfFile = value; }
		}

		public List<KeyValuePair<string,string>> DeletionList
		{
			get { return deletionList; }
			set { deletionList = value; }
		}
	}
}


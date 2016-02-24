using System;
using System.Collections.Generic;
using System.IO;

namespace DeletionTool
{
	public class MatchingItems
	{

		private List<KeyValuePair<string,string>> matchedItems;
		private List<string> itemsInUse;
		private string nameOfFile;

		public MatchingItems(string fileName)
		{
			matchedItems = new List<KeyValuePair<string, string>> ();
			itemsInUse = new List<string> ();
			nameOfFile = fileName;
		}

		public void readFile()
		{
			FileStream fs = new FileStream (nameOfFile, FileMode.Open);



			StreamReader inStream = new StreamReader (fs);

			while (!inStream.EndOfStream)
			{
				itemsInUse.Add (inStream.ReadLine ());
			}
		}

		public void findMatchingItems(DeletionFile itemsToDelete)
		{
			foreach(KeyValuePair<string,string> kvp in itemsToDelete.DeletionList)
			{
				foreach(var item in itemsInUse)
				{
					if(kvp.Key.ToString() == item.ToString())
					{
						matchedItems.Add( new KeyValuePair<string, string>(kvp.Key.ToString(), kvp.Value.ToString()));
					}
				}
			}
		}

		public void saveToFile(string filePath)
		{
			string path = filePath;

			if(File.Exists(path))
			{
				File.Delete (path);
			}

			StreamWriter sw = new StreamWriter (path);

			foreach(var element in matchedItems)
			{
				sw.WriteLine (element);	
			}
			sw.Close ();
		}

		public void printFile()
		{
			foreach(var element in matchedItems)
			{
				Console.WriteLine (element);	
			}

		}

		public List<KeyValuePair<string,string>> MatchedItems
		{
			get{ return matchedItems;}
			set{ matchedItems = value;}
		}

		public List<string> ItemsInUse
		{
			get{ return itemsInUse;}
			set{ itemsInUse = value;}
		}
		public string NameOfFile
		{
			get { return nameOfFile; }
			set { nameOfFile = value; }
		}
	}
}


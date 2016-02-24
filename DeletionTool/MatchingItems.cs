using System;
using System.Collections.Generic;
using System.IO;

namespace DeletionTool
{
	public class MatchingItems
	{

		public List<KeyValuePair<string,string>> matchedItems;
		public List<string> itemsInUse;

		public MatchingItems()
		{
			matchedItems = new List<KeyValuePair<string, string>> ();
			itemsInUse = new List<string> ();
		}

		public void readFile()
		{
			FileStream fs = new FileStream ("items_to_keep.txt", FileMode.Open);



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

		public void saveToFile()
		{
			string path = "../../test_output.txt";

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
			Console.WriteLine ("In printFile() method...");
			foreach(var element in matchedItems)
			{
				Console.WriteLine (element);	
			}

		}

	}
}


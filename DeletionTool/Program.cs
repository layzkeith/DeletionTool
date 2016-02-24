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

	class MatchingItems
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


	class MainClass
	{
		public static void Main (string[] args)
		{


			Console.WriteLine ("Start of program...");

			Console.WriteLine ("Initialise class...");
			DeletionFile ToDelete = new DeletionFile ();

			Console.WriteLine ("Read file...");
			ToDelete.readFile ();

			Console.WriteLine ("Print file to console...");
			ToDelete.printFile ();

			Console.WriteLine ("Initialise class...");
			MatchingItems matchedItems = new MatchingItems ();

			Console.WriteLine ("Read file...");
			matchedItems.readFile ();

			Console.WriteLine ("Matching coys...");
			matchedItems.findMatchingItems (ToDelete);

			Console.WriteLine ("Printing list of test coys...");
			matchedItems.printFile ();

			Console.WriteLine ("Saving list of test coys...");
			matchedItems.saveToFile ();

		}
	}
}

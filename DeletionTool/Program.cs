using System;
using System.Collections.Generic;
using System.IO;

namespace DeletionTool
{


	class MainClass
	{
		public static void Main (string[] args)
		{


			Console.WriteLine ("Start of program...");

			Console.WriteLine ("Initialise class...");
			DeletionFile ToDelete = new DeletionFile ("test_file.txt");

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

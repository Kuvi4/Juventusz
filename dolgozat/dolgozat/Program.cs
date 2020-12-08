using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dolgozat
{
	struct Focis
	{
		public int Mez { get; set; }
		public string Nev { get; set; }
		public string Nem { get; set; }
		public string Poszt { get; set; }
		public int Szule { get; set; }
	}
	class Program
	{
		static void Main()
		{
			int seg = -1;
			int olaszok = 0;
			string eleres = "juve.txt";
			List<string> sorok = File.ReadAllLines(eleres).ToList();
			var csapat = new List<Focis>();
			foreach (var sor in sorok)
			{
				string[] darabok = sor.Split(';');

				csapat.Add(new Focis() { Mez = Int32.Parse(darabok[0]), Nev = darabok[1], Nem = darabok[2], Poszt = darabok[3], Szule = Int32.Parse(darabok[4]) });
			}
			Console.WriteLine(csapat.Count + " igazolt játékosa van a csapatnak.");
			foreach (var jat in csapat)
			{
				if (jat.Nem == "magyar")
				{
					seg = 1;
				}
			}
			if (seg == 1)
			{
				Console.WriteLine("Van magyar a csapatba.");
			}
			else
			{
				Console.WriteLine("Nincs magyar a csapatba.");
			}
			foreach (var jat in csapat)
			{
				if (jat.Nem == "olasz")
				{
					olaszok++;
				}
			}
			Console.WriteLine(olaszok + " olasz van a csapatba");

			Focis fiatal = csapat[0];
			foreach (var jat in csapat)
			{
				if (jat.Szule > fiatal.Szule)
				{
					fiatal = jat;
				}
			}
			Console.WriteLine(fiatal.Nev + " a legfiatalabb a csapatba");
			 
			Console.ReadKey();
		}
	}
}

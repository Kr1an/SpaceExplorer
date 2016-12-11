using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel.Utils;
using SObjectRepository.Repository.SObjectModel;
using System.IO;
using SObjectApplication.Repository.SObjectApplicationSaveHelper;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Diagnostics;
using SObjectApplication.Repository.Serializer;

namespace SObjectApplication
{
	class Entities
	{
		public Chain<Constellation> Constellations;
		public Chain<Star> Stars;
		public Chain<Planet> Planets;
	}
	class Storage
	{
		public static Entities Entities;
		static public Chain<Constellation> Constellations;
		static public Chain<Star> Stars;
		static public Chain<Planet> Planets;
		public StreamWriter SavingFile;
		public StreamReader LoadingFile;
		static public String FileName = "SObjectDB.dat";//can be changed
		static public String ZipName = "SObjectDB.dat.gz";//can be changed
		static public String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SObjectApplication");
		static public String FullPath = Path.Combine(FolderPath, FileName);



		public void SaveStorage(String saveFormString)
		{
			char[] temp = new char[saveFormString.Length];
			for (int i = 0; i < saveFormString.Length; i++)
				temp[i] = Convert.ToChar(Convert.ToInt32(saveFormString[i]) + 5);
			

			SavingFile = new StreamWriter(FullPath,false);
			SavingFile.Write(new String(temp));
			SavingFile.Flush();
			SavingFile.Close();

			


		}
		public static void Compress(DirectoryInfo directorySelected)
		{
			foreach (FileInfo fileToCompress in directorySelected.GetFiles())
			{
				using (FileStream originalFileStream = fileToCompress.OpenRead())
				{
					if ((File.GetAttributes(fileToCompress.FullName) &
					   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
					{
						using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
						{
							using (GZipStream compressionStream = new GZipStream(compressedFileStream,
							   CompressionMode.Compress))
							{
								originalFileStream.CopyTo(compressionStream);

							}
						}
						FileInfo info = new FileInfo(FolderPath + "\\" + fileToCompress.Name + ".gz");
						Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
						fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
					}

				}
			}
		}
		public static void Decompress(FileInfo fileToDecompress)
		{
			using (FileStream originalFileStream = fileToDecompress.OpenRead())
			{
				string currentFileName = fileToDecompress.FullName;
				string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

				using (FileStream decompressedFileStream = File.Create(newFileName))
				{
					using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
					{
						decompressionStream.CopyTo(decompressedFileStream);
						Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
					}
				}
			}
		}
		static public void StorageWrite()
		{
			File.Delete(Path.Combine(FolderPath, ZipName));
			File.Delete(Path.Combine(FolderPath, FullPath));
			string str = "";
			//foreach (Planet Planet in Storage.Planets)
			//	str += PlanetFormatter.PlanetToSaveFormat(Planet);
			//foreach (Star Star in Storage.Stars)
			//	str += StarFormatter.StarToSaveFormat(Star);
			//foreach (Constellation Constellation in Storage.Constellations)
			//	str += ConstellationFormatter.ConstellationToSaveFormat(Constellation);
			//str += EntitiesFormatter.EntitiesToStringFormat();
			Entities.Constellations = Constellations;
			Entities.Planets = Planets;
			Entities.Stars = Stars;
			str = Serializer.ToBin(Entities);
			new Storage().SaveStorage(str);
			DirectoryInfo directorySelected = new DirectoryInfo(FolderPath);
			Compress(directorySelected);
			File.Delete(FullPath);
		}
		static public void StorageRead()
		{
			Storage.Planets = new Chain<Planet>();
			Storage.Stars = new Chain<Star>();
			Storage.Constellations = new Chain<Constellation>();
			Storage.Entities = new Entities();
			
			if (!File.Exists(Path.Combine(FolderPath, ZipName)))
			{
				if(!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);
				if (!File.Exists(FullPath))
					File.Delete(FullPath);
				AddRecords();
			}
			else
			{
				DirectoryInfo directorySelected = new DirectoryInfo(FolderPath);
				foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
				{
					Decompress(fileToDecompress);
				}
				string str = new Storage().LoadStorage();

				Entities = Serializer.ToObj<Entities>(str);

				Constellations = Entities.Constellations;
				Stars = Entities.Stars;
				Planets = Entities.Planets;


				//Planets = PlanetFormatter.GetPlanetList(str);
				//Stars = StarFormatter.GetStarList(str);
				//Constellations = ConstellationFormatter.GetConstellationList(str);
				//EntitiesFormatter.MakeEntity(str);
			}	
		}


		
		public string LoadStorage()
		{
			LoadingFile = new StreamReader(FullPath);
			string result = LoadingFile.ReadLine();
			LoadingFile.Close();
			File.Delete(FullPath);
			char[] temp = new char[result.Length];
			for(int i = 0; i < result.Length; i++)
				temp[i] = Convert.ToChar(Convert.ToInt32(result[i]) - 5);
			result = new string(temp);
			return result;

		}

		static Storage()
		{
		
			
			
			

				
			
			
		}
		static void AddRecords()
		{
			Storage.Constellations.Add(new Constellation() { Name = "Andromeda", ExInfo = new InfoHelper() { ShortName = "And" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Milkyway", ExInfo = new InfoHelper() { ShortName = "Mv" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Antlia", ExInfo = new InfoHelper() { ShortName = "An" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Ara", ExInfo = new InfoHelper() { ShortName = "Ar" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Aries", ExInfo = new InfoHelper() { ShortName = "Ars" }, Position = new Position() });
			Storage.Constellations.Add(new Constellation() { Name = "Crater", ExInfo = new InfoHelper() { ShortName = "Cr" }, Position = new Position() });

			Storage.Stars.Add(new Star() { Name = "Alrai", ParentConstellation = Storage.Constellations[0], Feature = new StarFeature() { SpecClass = SpectralClass.A_class } });
			Storage.Stars.Add(new Star() { Name = "Acrux", ParentConstellation = Storage.Constellations[2], Feature = new StarFeature() { SpecClass = SpectralClass.B_class } });
			Storage.Stars.Add(new Star() { Name = "Acrab", ParentConstellation = Storage.Constellations[1], Feature = new StarFeature() { SpecClass = SpectralClass.C_class } });
			Storage.Stars.Add(new Star() { Name = "Adhara", ParentConstellation = Storage.Constellations[4], Feature = new StarFeature() { SpecClass = SpectralClass.A_class } });
			Storage.Stars.Add(new Star() { Name = "Ain", ParentConstellation = Storage.Constellations[1], Feature = new StarFeature() { SpecClass = SpectralClass.D_class } });
			Storage.Stars.Add(new Star() { Name = "Albali", ParentConstellation = Storage.Constellations[2], Feature = new StarFeature() { SpecClass = SpectralClass.F_class } });
			Storage.Stars.Add(new Star() { Name = "Albaldah", ParentConstellation = Storage.Constellations[4], Feature = new StarFeature() { SpecClass = SpectralClass.P_class } });

			Storage.Planets.Add(new Planet() { Name = "Ab12", ParentStar = Storage.Stars[0], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Desert_class } });
			Storage.Planets.Add(new Planet() { Name = "BL3", ParentStar = Storage.Stars[2], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Dwarf_class } });
			Storage.Planets.Add(new Planet() { Name = "Plu42", ParentStar = Storage.Stars[1], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Desert_class} });
			Storage.Planets.Add(new Planet() { Name = "Earth", ParentStar = Storage.Stars[4], Feature = new PlanetFeature() { PlanetClass = PlanetClass.IceGiant_class } });
			Storage.Planets.Add(new Planet() { Name = "Jupitor", ParentStar = Storage.Stars[1], Feature = new PlanetFeature() { PlanetClass = PlanetClass.GasGiant_class } });
			Storage.Planets.Add(new Planet() { Name = "BnMJ12", ParentStar = Storage.Stars[2], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Plutoid_class } });
			Storage.Planets.Add(new Planet() { Name = "Rora", ParentStar = Storage.Stars[4], Feature = new PlanetFeature() { PlanetClass = PlanetClass.Outer_class } });


			Storage.Constellations[0].Stars.Add(Storage.Stars[0]);
			Storage.Constellations[1].Stars.Add(Storage.Stars[2]);
			Storage.Constellations[1].Stars.Add(Storage.Stars[4]);
			Storage.Constellations[2].Stars.Add(Storage.Stars[1]);
			Storage.Constellations[2].Stars.Add(Storage.Stars[5]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[3]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[3]);
			Storage.Constellations[4].Stars.Add(Storage.Stars[6]);

			Storage.Stars[0].Planets.Add(Storage.Planets[0]);
			Storage.Stars[1].Planets.Add(Storage.Planets[2]);
			Storage.Stars[1].Planets.Add(Storage.Planets[4]);
			Storage.Stars[2].Planets.Add(Storage.Planets[1]);
			Storage.Stars[2].Planets.Add(Storage.Planets[5]);
			Storage.Stars[4].Planets.Add(Storage.Planets[3]);
			Storage.Stars[4].Planets.Add(Storage.Planets[3]);
			Storage.Stars[4].Planets.Add(Storage.Planets[6]);
			
		}
	}
}

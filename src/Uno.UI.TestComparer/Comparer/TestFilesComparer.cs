﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using SkiaSharp;

namespace Uno.UI.TestComparer.Comparer
{
	class TestFilesComparer
	{
		public TestFilesComparer(string basePath, string artifactsBasePath, string artifactsInnerBasePath, string platform)
		{
			_basePath = basePath;
			_artifactsBasePath = artifactsBasePath;
			_artifactsInnerBasePath = artifactsInnerBasePath;
			_platform = platform;
		}

		internal CompareResult Compare(string[] artifacts)
		{
			var testResult = new CompareResult(_platform);

			string path = _basePath;
			var resultsId = $"{DateTime.Now:yyyyMMdd-hhmmss}";
			string diffPath = Path.Combine(_basePath, $"Results-{_platform}-{resultsId}");
			string resultsFilePath = Path.Combine(_basePath, $"Results-{_platform}-{resultsId}.html");

			Directory.CreateDirectory(path);
			Directory.CreateDirectory(diffPath);

			if (artifacts == null)
			{
				var q1 = from directory in Directory.EnumerateDirectories(_artifactsBasePath)
						 let info = new DirectoryInfo(directory)
						 orderby info.FullName descending
						 select directory;

				var orderedDirectories = from directory in q1
										 orderby directory
										 select directory;

				artifacts = orderedDirectories.ToArray();
			}

			var q = from directory in artifacts.Select((v, i) => new { Index = i, Path = v })
					let files = from sample in EnumerateFiles(Path.Combine(directory.Path, _artifactsInnerBasePath, _platform), "*.png").AsParallel()
								where CanBeUsedForCompare(sample)
								select new { File = sample, Id = BuildSha1(sample) }
					select new
					{
						Path = directory.Path,
						Index = directory.Index,
						Files = files.AsParallel().ToArray(),
					};

			var allFolders = LogForeach(q, i => Console.WriteLine($"Processed {i.Path}")).ToArray();

			testResult.Folders.AddRange(allFolders.Select((p, index) => (index, p.Path)).AsParallel());

			var allFiles = allFolders
				.SelectMany(folder => folder
					.Files.Select(file => Path.GetFileName(file.File))
				)
				.Distinct()
				.ToArray();

			var changedList = new List<string>();
            foreach (var testFile in allFiles)
            {
                var testFileIncrements = from folder in allFolders
                                         orderby folder.Index ascending
                                         select new
                                         {
                                             Folder = folder.Path,
                                             FolderIndex = folder.Index,
                                             Files = new[] {
                                                new { FileInfo = folder.Files.FirstOrDefault(f => Path.GetFileName(f.File) == testFile) }
                                             }
                                         };

                var increments =
                    (
                        from platformIndex in Enumerable.Range(0, 1)
                        select testFileIncrements
                            .Aggregate(
                                new[] { new { FolderIndex = -1, Path = "", IdSha = "", Id = -1, CompareeId = -1 } },
                                (a, f) =>
                                {
                                    var platformFiles = f.Files[platformIndex];

                                    if (platformFiles?.FileInfo == null)
                                    {
                                        return a;
                                    }

                                    var otherMatch = a.Reverse().Where(i => i.IdSha != null).FirstOrDefault();
                                    if (platformFiles.FileInfo?.Id.sha != otherMatch?.IdSha)
                                    {
                                        return a
                                            .Concat(new[] { new { FolderIndex = f.FolderIndex, Path = platformFiles.FileInfo.File, IdSha = platformFiles.FileInfo?.Id.sha, Id = platformFiles.FileInfo?.Id.index ?? -1, CompareeId = otherMatch.Id } })
                                            .ToArray();
                                    }
                                    else
                                    {
                                        return a
                                            .Concat(new[] { new { FolderIndex = f.FolderIndex, Path = platformFiles.FileInfo.File, IdSha = (string)null, Id = platformFiles.FileInfo.Id.index, CompareeId = -1 } })
                                            .ToArray();
                                    }
                                }
                            )
                    ).ToArray();

                var hasChanges = increments.Any(i => i.Where(v => v.IdSha != null).Count() - 1 > 1);

                var compareResultFile = new CompareResultFile();
                compareResultFile.HasChanged = hasChanges;
                compareResultFile.TestName = testFile;

                testResult.Tests.Add(compareResultFile);

                var changeResult = increments[0];

                var firstFolder = changeResult.Where(i => i.FolderIndex != -1).Min(i => i.FolderIndex);

                for (int folderIndex = 0; folderIndex < allFolders.Length; folderIndex++)
                {
                    var folderInfo = changeResult.FirstOrDefault(inc => inc.FolderIndex == folderIndex);

                    if (folderInfo != null)
                    {
                        var hasChangedFromPrevious = folderIndex != firstFolder && folderInfo?.IdSha != null;

                        var compareResultFileRun = new CompareResultFileRun();
                        compareResultFile.ResultRun.Add(compareResultFileRun);

                        compareResultFileRun.ImageId = folderInfo.Id;
                        compareResultFileRun.ImageSha = folderInfo.IdSha;
                        compareResultFileRun.FilePath = folderInfo.Path;

                        compareResultFileRun.HasChanged = hasChangedFromPrevious;

                        if (folderInfo != null)
                        {
                            var previousFolderInfo = changeResult.FirstOrDefault(inc => inc.FolderIndex == folderIndex - 1);
                            if (hasChangedFromPrevious && previousFolderInfo != null)
                            {
                                var diffFilePath = Path.Combine(diffPath, $"{folderInfo.Id}-{folderInfo.CompareeId}.png");

                                if (DiffImages(folderInfo.Path, previousFolderInfo.Path, diffFilePath))
                                {
                                    compareResultFileRun.DiffResultImage = diffFilePath;
                                }
                                changedList.Add(testFile);
                            }
                        }

                    }
                }
            }

			testResult.UnchangedTests = allFiles.Length - changedList.Distinct().Count();
			testResult.TotalTests = allFiles.Length;

			return testResult;
		}

		private bool CanBeUsedForCompare(string sample)
		{
			if(ReadScreenshotMetadata(sample) is IDictionary<string, string> options)
			{
				if(options.TryGetValue("IgnoreInSnapshotCompare", out var ignore) && ignore.ToLower() == "true")
				{
					return false;
				}
			}

			return true;
		}

		private static IDictionary<string, string> ReadScreenshotMetadata(string sample)
		{
			var metadataFile = Path.Combine(Path.GetDirectoryName(sample), Path.GetFileNameWithoutExtension(sample) + ".metadata");

			if (File.Exists(metadataFile))
			{
				var lines = File.ReadAllLines(metadataFile);

				return lines.Select(l => l.Split('=')).ToDictionary(p => p[0], p => p[1]);
			}

			return null;
		}

		private Dictionary<string, int> _fileHashesTable = new Dictionary<string, int>();
		private readonly string _basePath;
		private readonly string _artifactsBasePath;
		private readonly string _artifactsInnerBasePath;
		private readonly string _platform;

		private (string sha, int index) BuildSha1(string sample)
		{
			using (var sha1 = SHA1.Create())
			{
				using (var file = File.OpenRead(@"\\?\" + sample))
				{
					var data = sha1.ComputeHash(file);

					// Create a new Stringbuilder to collect the bytes
					// and create a string.
					var sBuilder = new StringBuilder();

					// Loop through each byte of the hashed data
					// and format each one as a hexadecimal string.
					for (int i = 0; i < data.Length; i++)
					{
						sBuilder.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
					}

					var sha = sBuilder.ToString();

					lock (_fileHashesTable)
					{
						if (!_fileHashesTable.TryGetValue(sha, out var index))
						{
							index = _fileHashesTable.Count;
							_fileHashesTable[sha] = index;
						}

						return (sha, index);
					}
				}
			}
		}

		private IEnumerable<string> EnumerateFiles(string path, string pattern)
		{
			if (Directory.Exists(path))
			{
				return Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);
			}
			else
			{
				return new string[0];
			}
		}

		private static IEnumerable<T> LogForeach<T>(IEnumerable<T> q, Action<T> action)
		{
			foreach (var item in q)
			{
				action(item);
				yield return item;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe bool DiffImages(string a, string b, string diffPath)
		{
			uint changes = 0;
			using var img1 = SKBitmap.Decode(@"\\?\" + a);
			using var img2 = SKBitmap.Decode(@"\\?\" + b);

			// Get Rgba8888 Piexels
			var pixmap1 = GetPixels(img1);
			var pixmap2 = GetPixels(img2);

			// if have same size
			if (pixmap1.Size == pixmap2.Size)
			{
				var bmp1Ptr = (byte*)pixmap1.GetPixels().ToPointer();
				var bmp2Ptr = (byte*)pixmap2.GetPixels().ToPointer();
				var width = pixmap1.Width;
				var height = pixmap2.Height;


				for (var row = 0; row < height; row++)
				{
					for (var col = 0; col < width; col++)
					{
						DiffByte(ref bmp1Ptr, ref bmp2Ptr, ref changes); //Red
						DiffByte(ref bmp1Ptr, ref bmp2Ptr, ref changes); //Gren
						DiffByte(ref bmp1Ptr, ref bmp2Ptr, ref changes); //Blue

						*bmp1Ptr = 0xFF;                    //Alpha opaque
						bmp1Ptr++;
						bmp2Ptr++;
					}
				}

				using var diffImage = SKImage.FromPixels(pixmap1);
				using (var data = diffImage.Encode(SKEncodedImageFormat.Png, 100))
				{
					using (var stream = File.OpenWrite(diffPath))
					{
						data.SaveTo(stream);
					}
				}
			}
			else
			{
				//TODO: throw warings?
				Console.WriteLine($"\t{a} and {b} have differnt size");
			}
			pixmap1?.Dispose();
			pixmap2?.Dispose();
			return changes > 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static unsafe SKPixmap GetPixels(SKBitmap image)
		{
			var pixmap = image.PeekPixels();
			// Adjust color if not Rgba8888
			if (image.ColorType != SKColorType.Rgba8888)
			{
				using (var old = pixmap)
					pixmap = old.WithColorType(SKColorType.Rgba8888);
			}
			return pixmap;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static unsafe void DiffByte(ref byte* bmp1Ptr, ref byte* bmp2Ptr, ref uint changes)
		{
			*bmp1Ptr ^= *bmp2Ptr; // xor
			unchecked
			{
				changes += *bmp1Ptr;
			}
			bmp1Ptr++;
			bmp2Ptr++;
		}

	}
}

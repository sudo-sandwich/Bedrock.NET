using Bedrock.Entities;
using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bedrock.Files {
    public class AddonContent {
        private StringBuilder StrBuilder = new StringBuilder();
        private JsonTextWriter JTextWriter;

        //prefer to use Add() to add entities and functions but you can directly use the fields if you want. Add() is easier though.
        public AddonCatalogue<MCFunction> Functions { get; private set; } = new AddonCatalogue<MCFunction>();
        public AddonCatalogue<Entity> Entities { get; private set; } = new AddonCatalogue<Entity>();
        public AddonCatalogue<AnimationControllerFile> ServerAnimationControllers { get; private set; } = new AddonCatalogue<AnimationControllerFile>();
        public AddonCatalogue<AnimationTimelineFile> ServerAnimationTimelines { get; private set; } = new AddonCatalogue<AnimationTimelineFile>();
        public AddonCatalogue<AnimationControllerFile> ClientAnimationControllers { get; private set; } = new AddonCatalogue<AnimationControllerFile>();
        public AddonCatalogue<AnimationTimelineFile> ClientAnimationTimelines { get; private set; } = new AddonCatalogue<AnimationTimelineFile>();
        public AddonCatalogue<RenderControllerFile> RenderControllers { get; private set; } = new AddonCatalogue<RenderControllerFile>();

        // dict with key of int, with an object that contains lists of all of the object names for search later
        // search, look over all of the entries, check each string for names, if a single one is found, return the entire lot

        public List<AddonCache> Cache { get; } = new List<AddonCache>();
        public bool Cached { get; set; } = false;

        public void AddContent(AddonContent content) {
            Functions.Merge(content.Functions);
            Entities.Merge(content.Entities);
            ServerAnimationControllers.Merge(content.ServerAnimationControllers);
            ServerAnimationTimelines.Merge(content.ServerAnimationTimelines);
            ClientAnimationControllers.Merge(content.ClientAnimationControllers);
            ClientAnimationTimelines.Merge(content.ClientAnimationTimelines);
            RenderControllers.Merge(content.RenderControllers);
            CacheAndMerge(content);
        }

        private void CacheAndMerge(AddonContent content)
        {
            if (content.Cached == false)
            {
                AddonCache ac = new AddonCache();
                ac.AddonContent = content;

                foreach (KeyValuePair<AddonCategory, ICollection<MCFunction>> kvp in content.Functions.Catalogue)
                {
                    HashSet<MCFunction> fc = (HashSet<MCFunction>)kvp.Value;
                    foreach (MCFunction f in fc)
                    {
                        ac.Functions.Add(f.Name);
                    }
                }
                Cache.Add(ac);
                Cached = true; // we are adding this object to cache
            }

            if (content.Cache.Count > 0)
            {
                Cache.AddRange(content.Cache);
                Cached = true;
            }
        }

        public void WriteAll(string serverPackPath, string clientPackPath) => WriteAll(serverPackPath, clientPackPath, AddonWriteSettings.Default);

        public void WriteAll(string serverPackPath, string clientPackPath, AddonWriteSettings settings) {
            JTextWriter = new JsonTextWriter(new StringWriter(StrBuilder)) {
                Formatting = settings.Formatting,
                Indentation = settings.Indentation,
                IndentChar = settings.IndentChar
            };

            DirectoryInfo serverPack = new DirectoryInfo(serverPackPath);
            DirectoryInfo clientPack = new DirectoryInfo(clientPackPath);

            DirectoryInfo functions = serverPack.CreateSubdirectory(settings.FunctionPath);
            DirectoryInfo serverEntities = serverPack.CreateSubdirectory(settings.ServerEntityPath);
            DirectoryInfo clientEntities = clientPack.CreateSubdirectory(settings.ClientEntityPath);
            DirectoryInfo serverAnimationControllers = serverPack.CreateSubdirectory(settings.ServerAnimationControllerPath);
            DirectoryInfo serverAnimationTimelines = serverPack.CreateSubdirectory(settings.ServerAnimationTimelinePath);
            DirectoryInfo clientAnimationControllers = clientPack.CreateSubdirectory(settings.ClientAnimationControllerPath);
            DirectoryInfo clientAnimationTimelines = clientPack.CreateSubdirectory(settings.ClientAnimationTimelinePath);
            DirectoryInfo renderControllers = clientPack.CreateSubdirectory(settings.RenderControllerPath);

            if (settings.ShouldEraseOldBedrockFilesWithHeader) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erasing old files... ");
                IList<FileInfo> mcFunctionFiles = new List<FileInfo>();
                mcFunctionFiles.AddRange(RecursiveGetFiles(functions, ".mcfunction"));
                IList<FileInfo> jsonFiles = new List<FileInfo>();
                jsonFiles.AddRange(RecursiveGetFiles(serverEntities, ".json"));
                jsonFiles.AddRange(RecursiveGetFiles(serverAnimationControllers, ".json"));
                jsonFiles.AddRange(RecursiveGetFiles(serverAnimationTimelines, ".json"));
                jsonFiles.AddRange(RecursiveGetFiles(clientPack, ".json"));
                foreach (FileInfo mcFunctionFile in mcFunctionFiles) {
                    IEnumerable<string> lines = File.ReadLines(mcFunctionFile.FullName);
                    if (lines.Any() && lines.First() == settings.EraseOldMCFunctionHeader) {
                        //Console.WriteLine("deleting " + mcFunctionFile.FullName);
                        mcFunctionFile.Delete();
                    }
                }
                foreach (FileInfo jsonFile in jsonFiles) {
                    IEnumerable<string> lines = File.ReadLines(jsonFile.FullName);
                    if (lines.Any() && lines.First() == settings.EraseOldJsonHeader) {
                        //Console.WriteLine("deleting " + jsonFile.FullName);
                        jsonFile.Delete();
                    }
                }
                Console.WriteLine("Done.");
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Generating functions... ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Linking full function names to function objects...");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (AddonCategory category in Functions.Catalogue.Keys) {
                foreach (MCFunction mcFunction in Functions[category]) {
                    if (category.Count > 0) {
                        Console.WriteLine($"\tLinking {mcFunction.Name} to {category.CategoryPath}...");
                        mcFunction.FunctionName = $"{string.Join('/', category.Categories)}/{mcFunction.Name}";
                    } else {
                        Console.WriteLine($"\tLinking {mcFunction.Name} to (base)...");
                        mcFunction.FunctionName = mcFunction.Name;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Writing functions...");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (AddonCategory category in Functions.Catalogue.Keys) {
                DirectoryInfo directoryToPlaceIn = category.Count == 0 ? functions : functions.CreateSubdirectory(category.CategoryPath);
                foreach (MCFunction mcFunction in Functions[category]) {
                    Console.WriteLine($"\tWriting {(category.Count > 0 ? category + "/" : "")}{mcFunction.Name}.mcfunction...");
                    WriteFunction(Path.Combine(directoryToPlaceIn.FullName, $"{mcFunction.Name}{(settings.UseFunctionExtension ? settings.FunctionExtension : "")}.mcfunction"), mcFunction, settings.MCFunctionHeader);
                }
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            DirectoryInfo categoryDirectory;

            foreach (AddonCategory category in Entities.Catalogue.Keys) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Generating {(category.Count == 0 ? "uncategorized" : category.ToString())} entities...");
                foreach (Entity entity in Entities.Catalogue[category]) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\tWriting {entity.Identifier}...");

                    if (entity.Server != null) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tWriting behavior...");
                        categoryDirectory = GetCategoryDirectory(category, serverEntities);
                        WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseServerEntityExtension ? settings.ServerEntityExtension : "")}.json"), entity.Server.Generate(), settings.JsonHeader);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (entity.Server.AnimationControllerFile.Controllers.Count > 0) {
                            Console.WriteLine("\t\tWriting behavior pack animation controllers...");
                            categoryDirectory = GetCategoryDirectory(category, serverAnimationControllers);
                            WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseServerAnimationControllerExtension ? settings.ServerAnimationControllerExtension : "")}.json"), entity.Server.AnimationControllerFile.Generate(), settings.JsonHeader);
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (entity.Server.AnimationTimelineFile.Timelines.Count > 0) {
                            Console.WriteLine("\t\tWriting behavior pack animation timelines...");
                            categoryDirectory = GetCategoryDirectory(category, serverAnimationTimelines);
                            WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseServerAnimationTimelineExtension ? settings.ServerAnimationTimelineExtension : "")}.json"), entity.Server.AnimationTimelineFile.Generate(), settings.JsonHeader);
                        }
                    }

                    if (entity.Client != null) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\t\tWriting client entity...");
                        categoryDirectory = GetCategoryDirectory(category, clientEntities);
                        WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseClientEntityExtension ? settings.ClientEntityExtension : "")}.json"), entity.Client.Generate(), settings.JsonHeader);

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        if (entity.Client.AnimationControllerFile.Controllers.Count > 0) {
                            Console.WriteLine("\t\tWriting resource pack animation controllers...");
                            categoryDirectory = GetCategoryDirectory(category, clientAnimationControllers);
                            WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseClientAnimationControllerExtension ? settings.ClientAnimationControllerExtension : "")}.json"), entity.Client.AnimationControllerFile.Generate(), settings.JsonHeader);
                        }

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        if (entity.Client.AnimationTimelineFile.Timelines.Count > 0) {
                            Console.WriteLine("\t\tWriting resource pack animation timelines...");
                            categoryDirectory = GetCategoryDirectory(category, clientAnimationTimelines);
                            WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseClientAnimationTimelineExtension ? settings.ClientAnimationTimelineExtension : "")}.json"), entity.Client.AnimationTimelineFile.Generate(), settings.JsonHeader);
                        }

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        if (entity.Client.RenderControllerFile.Controllers.Count > 0) {
                            Console.WriteLine("\t\tWriting render controllers...");
                            categoryDirectory = GetCategoryDirectory(category, renderControllers);
                            WriteJson(Path.Combine(categoryDirectory.FullName, $"{entity.Identifier}{(settings.UseRenderControllerExtension ? settings.RenderControllerExtension : "")}.json"), entity.Client.RenderControllerFile.Generate(), settings.JsonHeader);
                        }
                    }
                }
            }

            Console.ResetColor();
            Console.WriteLine("Writing loose files...");
            foreach (AddonCategory category in ServerAnimationControllers.Catalogue.Keys) {
                categoryDirectory = GetCategoryDirectory(category, serverAnimationControllers);
                foreach (AnimationControllerFile serverAnimationController in ServerAnimationControllers[category]) {
                    Console.WriteLine($"\tWriting {serverAnimationController.Name} server animation controllers...");
                    WriteJson(Path.Combine(categoryDirectory.FullName, $"{serverAnimationController.Name}{(settings.UseServerAnimationControllerExtension ? settings.ServerAnimationControllerExtension : "")}.json"), serverAnimationController.Generate(), settings.JsonHeader);
                }
            }
            foreach (AddonCategory category in ServerAnimationTimelines.Catalogue.Keys) {
                categoryDirectory = GetCategoryDirectory(category, serverAnimationTimelines);
                foreach (AnimationTimelineFile serverAnimationTimeline in ServerAnimationTimelines[category]) {
                    Console.WriteLine($"\tWriting {serverAnimationTimeline.Name} server animation timelines...");
                    WriteJson(Path.Combine(categoryDirectory.FullName, $"{serverAnimationTimeline.Name}{(settings.UseServerAnimationTimelineExtension ? settings.ServerAnimationTimelineExtension : "")}.json"), serverAnimationTimeline.Generate(), settings.JsonHeader);
                }
            }
            foreach (AddonCategory category in ClientAnimationControllers.Catalogue.Keys) {
                categoryDirectory = GetCategoryDirectory(category, clientAnimationControllers);
                foreach (AnimationControllerFile clientAnimationController in ClientAnimationControllers[category]) {
                    Console.WriteLine($"\tWriting {clientAnimationController.Name} client animation controllers...");
                    WriteJson(Path.Combine(categoryDirectory.FullName, $"{clientAnimationController.Name}{(settings.UseClientAnimationControllerExtension ? settings.ClientAnimationControllerExtension : "")}.json"), clientAnimationController.Generate(), settings.JsonHeader);
                }
            }
            foreach (AddonCategory category in ClientAnimationTimelines.Catalogue.Keys) {
                categoryDirectory = GetCategoryDirectory(category, clientAnimationTimelines);
                foreach (AnimationTimelineFile clientAnimationTimeline in ClientAnimationTimelines[category]) {
                    Console.WriteLine($"\tWriting {clientAnimationTimeline.Name} client animation timelines...");
                    WriteJson(Path.Combine(categoryDirectory.FullName, $"{clientAnimationTimeline.Name}{(settings.UseClientAnimationTimelineExtension ? settings.ClientAnimationTimelineExtension : "")}.json"), clientAnimationTimeline.Generate(), settings.JsonHeader);
                }
            }
            foreach (AddonCategory category in RenderControllers.Catalogue.Keys) {
                categoryDirectory = GetCategoryDirectory(category, renderControllers);
                foreach (RenderControllerFile renderController in RenderControllers[category]) {
                    Console.WriteLine($"\tWriting {renderController.Name} render controllers...");
                    WriteJson(Path.Combine(categoryDirectory.FullName, $"{renderController.Name}{(settings.UseRenderControllerExtension ? settings.RenderControllerExtension : "")}.json"), renderController.Generate(), settings.JsonHeader);
                }
            }

            Console.ResetColor();
        }

        private static DirectoryInfo GetCategoryDirectory(AddonCategory category, DirectoryInfo baseDirectory) => category.Count == 0 ? baseDirectory : baseDirectory.CreateSubdirectory(category.CategoryPath);

        private static void WriteFunction(string path, MCFunction function, string header) {
            File.WriteAllText(path, $"{((header == null) ? "" : header + '\n')}{function}");
        }

        private void WriteJson(string path, JToken jToken, string header) {
            jToken.WriteTo(JTextWriter);
            File.WriteAllText(path, $"{((header == null) ? "" : header + '\n')}{StrBuilder}");
            StrBuilder.Clear();
        }

        private static void DeleteDirectoryContent(DirectoryInfo directory) {
            foreach (FileInfo f in directory.GetFiles()) {
                f.Delete();
            }
            foreach (DirectoryInfo d in directory.GetDirectories()) {
                d.Delete(true);
            }
        }

        //recursively gets all files with a certain extension. extension must include '.' (ie ".json").
        private static IList<FileInfo> RecursiveGetFiles(DirectoryInfo directory, string extension) {
            return RecursiveGetFiles(directory, extension, new List<FileInfo>());
        }

        private static IList<FileInfo> RecursiveGetFiles(DirectoryInfo directory, string extension, IList<FileInfo> filesWithExtension) {
            foreach (FileInfo file in directory.GetFiles()) {
                if (file.Extension == extension) {
                    filesWithExtension.Add(file);
                }
            }
            foreach (DirectoryInfo dir in directory.GetDirectories()) {
                RecursiveGetFiles(dir, extension, filesWithExtension);
            }
            return filesWithExtension;
        }
    }
}

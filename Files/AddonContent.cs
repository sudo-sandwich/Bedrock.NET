using Bedrock.Entities;
using Bedrock.Functions;
using Bedrock.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bedrock.Files {
    public class AddonContent {
        private static class Paths {
            public const string Functions = "functions";
            public const string Behaviors = "entities"; //only file that is always generated
            public const string BehaviorPackAnimationTimelines = "animations";
            public const string BehaviorPackAnimationControllers = "animation_controllers";
            public const string ClientEntity = "entities";
            public const string RenderControllers = "render_controllers";
            public const string ResourcePackAnimationControllers = "animation_controllers";
        }
        private static StringBuilder StrBuilder = new StringBuilder();
        private static JsonTextWriter JTextWriter = new JsonTextWriter(new StringWriter(StrBuilder)) {
            Formatting = Formatting.Indented,
            Indentation = 1,
            IndentChar = '\t'
        };

        public IDictionary<string, IList<Entity>> Entities { get; private set; } = new Dictionary<string, IList<Entity>>(); //category, list of entities in that category
        public IList<MCFunction> Functions { get; private set; } = new List<MCFunction>();

        public void Add(Entity entity, string category = "") {
            if (!Entities.ContainsKey(category)) {
                Entities.Add(category, new List<Entity>());
            }
            Entities[category].Add(entity);
        }

        public void Add(MCFunction function) {
            Functions.Add(function);
        }

        public void AddContent(AddonContent content) {
            foreach (string key in content.Entities.Keys) {
                if (!Entities.ContainsKey(key)) {
                    Entities.Add(key, new List<Entity>());
                }
                Entities[key].AddRange(content.Entities[key]);
            }
            Functions.AddRange(content.Functions);
        }

        //eraseOld will erase all files in the behavior pack animations directory, behavior pack animation controllers directory, behavior pack behaviors directory, behavior pack functions directory, resource pack entities directory, and resource pack render controllers directory
        public void WriteAll(DirectoryInfo behaviorPack, DirectoryInfo resourcePack, bool eraseOld = false) {
            DirectoryInfo functions = behaviorPack.CreateSubdirectory(Paths.Functions);
            DirectoryInfo behaviors = behaviorPack.CreateSubdirectory(Paths.Behaviors);
            DirectoryInfo behaviorPackAnimationTimelines = behaviorPack.CreateSubdirectory(Paths.BehaviorPackAnimationTimelines);
            DirectoryInfo behaviorPackAnimationControllers = behaviorPack.CreateSubdirectory(Paths.BehaviorPackAnimationControllers);
            DirectoryInfo clientEntities = resourcePack.CreateSubdirectory(Paths.ClientEntity);
            DirectoryInfo renderControllers = resourcePack.CreateSubdirectory(Paths.RenderControllers);
            DirectoryInfo resourcePackAnimationControllers = resourcePack.CreateSubdirectory(Paths.ResourcePackAnimationControllers);
            if (eraseOld) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Erasing old files... ");
                //DeleteDirectoryContent(functions);
                DeleteDirectoryContent(behaviors);
                DeleteDirectoryContent(behaviorPackAnimationTimelines);
                DeleteDirectoryContent(behaviorPackAnimationControllers);
                DeleteDirectoryContent(clientEntities);
                DeleteDirectoryContent(renderControllers);
                DeleteDirectoryContent(resourcePackAnimationControllers);
                Console.WriteLine("Done.");
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Generating functions... ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (MCFunction mcFunction in Functions) {
                DirectoryInfo directoryToPlaceIn = mcFunction.Name.LastIndexOf('/') == -1 ? functions : functions.CreateSubdirectory(mcFunction.Name.Substring(0, mcFunction.Name.LastIndexOf('/')));
                Console.WriteLine("\tWriting " + mcFunction.Name + "...");
                File.WriteAllText(directoryToPlaceIn.FullName, mcFunction.ToString());
            }

            foreach (string key in Entities.Keys) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Generating " + (key.Length == 0 ? "uncategorized" : key) + " entities...");
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (Entity entity in Entities[key]) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Writing " + entity.Identifier + "...");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tWriting behavior...");
                    DirectoryInfo categoryDirectory = key.Length == 0 ? behaviors : behaviors.CreateSubdirectory(key);
                    WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".behavior.json", entity.GenerateBehavior());

                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (entity.HasBehaviorPackAnimationTimelines) {
                        Console.WriteLine("\tWriting behavior pack animation timelines...");
                        categoryDirectory = key.Length == 0 ? behaviorPackAnimationTimelines : behaviorPackAnimationTimelines.CreateSubdirectory(key);
                        WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".animations.json", entity.GenerateAnimationTimelines());
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (entity.HasBehaviorPackAnimationControllers) {
                        Console.WriteLine("\tWriting behavior pack animation controllers...");
                        categoryDirectory = key.Length == 0 ? behaviorPackAnimationControllers : behaviorPackAnimationControllers.CreateSubdirectory(key);
                        WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".animation_controllers.json", entity.GenerateBehaviorPackAnimationControllers());
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (entity.HasClientEntity) {
                        Console.WriteLine("\tWriting client entity...");
                        categoryDirectory = key.Length == 0 ? clientEntities : clientEntities.CreateSubdirectory(key);
                        WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".entity.json", entity.GenerateClientEntity());
                    }

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (entity.HasRenderControllers) {
                        Console.WriteLine("\tWriting render controllers...");
                        categoryDirectory = key.Length == 0 ? renderControllers : renderControllers.CreateSubdirectory(key);
                        WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".render_controllers.json", entity.GenerateRenderControllers());
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (entity.HasBehaviorPackAnimationControllers) {
                        Console.WriteLine("\tWriting resource pack animation controllers...");
                        categoryDirectory = key.Length == 0 ? resourcePackAnimationControllers : resourcePackAnimationControllers.CreateSubdirectory(key);
                        WriteJson(categoryDirectory.FullName + "/" + entity.Identifier + ".animation_controllers.json", entity.GenerateResourcePackAnimationControllers());
                    }
                }
            }
        }

        /*
        private void WriteEntityGroup(EntityGroup entityGroup, DirectoryInfo behaviors, DirectoryInfo behaviorPackAnimationTimelines, DirectoryInfo behaviorPackAnimationControllers, DirectoryInfo clientEntities, DirectoryInfo renderControllers, DirectoryInfo resourcePackAnimationControllers) {
            foreach (Entity entity in entityGroup.Entities) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Writing " + entity.Identifier + "...");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tWriting behavior...");
                DirectoryInfo categoryDirectory = behaviors.CreateSubdirectory(entityGroup.Name);
                WriteJson(categoryDirectory.FullName, entity.GenerateBehavior());

                Console.ForegroundColor = ConsoleColor.Blue;
                if (entity.HasBehaviorPackAnimationTimelines) {
                    Console.WriteLine("\tWriting behavior pack animation timelines...");
                    categoryDirectory = behaviorPackAnimationTimelines.CreateSubdirectory(entityGroup.Name);
                    WriteJson(categoryDirectory.FullName, entity.GenerateAnimationTimelines());
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                if (entity.HasBehaviorPackAnimationControllers) {
                    Console.WriteLine("\tWriting behavior pack animation controllers...");
                    categoryDirectory = behaviorPackAnimationControllers.CreateSubdirectory(entityGroup.Name);
                    WriteJson(categoryDirectory.FullName, entity.GenerateBehaviorPackAnimationControllers());
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (entity.HasClientEntity) {
                    Console.WriteLine("\tWriting client entity...");
                    categoryDirectory = clientEntities.CreateSubdirectory(entityGroup.Name);
                    WriteJson(categoryDirectory.FullName, entity.GenerateClientEntity());
                }

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (entity.HasBehaviorPackAnimationControllers) {
                    Console.WriteLine("\tWriting render controllers...");
                    categoryDirectory = renderControllers.CreateSubdirectory(entityGroup.Name);
                    WriteJson(categoryDirectory.FullName, entity.GenerateRenderControllers());
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (entity.HasBehaviorPackAnimationControllers) {
                    Console.WriteLine("\tWriting resource pack animation controllers...");
                    categoryDirectory = resourcePackAnimationControllers.CreateSubdirectory(entityGroup.Name);
                    WriteJson(categoryDirectory.FullName, entity.GenerateResourcePackAnimationControllers());
                }
            }
        }
        */

        private void WriteJson(string path, JToken jToken) {
            jToken.WriteTo(JTextWriter);
            File.WriteAllText(path, StrBuilder.ToString());
            StrBuilder.Clear();
        }

        private void DeleteDirectoryContent(DirectoryInfo directory) {
            foreach (FileInfo f in directory.GetFiles()) {
                f.Delete();
            }
            foreach (DirectoryInfo d in directory.GetDirectories()) {
                d.Delete(true);
            }
        }
    }
}

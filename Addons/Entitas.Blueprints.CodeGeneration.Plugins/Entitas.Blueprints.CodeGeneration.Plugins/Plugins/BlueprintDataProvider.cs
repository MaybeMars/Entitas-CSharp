﻿using System.Linq;
using Entitas.Blueprints.Unity.Editor;
using Entitas.CodeGeneration;

namespace Entitas.Blueprints.CodeGeneration.Plugins {

    public class BlueprintDataProvider : ICodeGeneratorDataProvider {

        public string name { get { return "Blueprint"; } }
        public int priority { get { return 0; } }
        public bool isEnabledByDefault { get { return true; } }
        public bool runInDryMode { get { return true; } }

        readonly string[] _blueprintNames;

        public BlueprintDataProvider() {
            _blueprintNames = BinaryBlueprintInspector
                .FindAllBlueprints()
                .Select(b => b.Deserialize().name)
                .ToArray();
        }

        public CodeGeneratorData[] GetData() {
            return _blueprintNames
                .Select(blueprintName => {
                    var data = new BlueprintData();
                    data.SetBlueprintName(blueprintName);
                    return data;
                }).ToArray();
        }
    }

    public static class BlueprintDataProviderExtension {

        public const string BLUEPRINT_NAME = "blueprint_name";

        public static string GetBlueprintName(this BlueprintData data) {
            return (string)data[BLUEPRINT_NAME];
        }

        public static void SetBlueprintName(this BlueprintData data, string blueprintName) {
            data[BLUEPRINT_NAME] = blueprintName;
        }
    }
}

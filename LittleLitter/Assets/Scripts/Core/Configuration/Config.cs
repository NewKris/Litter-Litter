using System;
using System.Threading.Tasks;
using CoffeeBara.Util;
using UnityEngine;

namespace CoffeeBara.Core.Configuration {
    [Serializable]
    public class Config {
        private static Config Instance;
        
        public float moveSpeedMult;
        public float turnSpeedMult;
        public float jumpHeightMult;
        public float jumpTimeMult;

        private static string FilePath => Application.streamingAssetsPath + "config";
        
        public static async Task<Config> GetInstance() {
            if (Instance != null) return Instance;

            Instance = await FileManager.DeserializeFile<Config>(FilePath);
            return Instance;
        }
    }
}
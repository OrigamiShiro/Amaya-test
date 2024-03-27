using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Amaya
{
    public class LevelCreator
    {
        private Level CreateLevelData(LevelBundleData bundleData, Transform parent)
        {
            var level = Level.GetInstance(parent);
            level.SetData(bundleData);
            return level;
        }

        public Level Create(string bundleDataPath, Transform parent)
        {
            var levelBundle = ResourceLoader.Load<LevelBundleData>(bundleDataPath);
            var level = CreateLevelData(levelBundle, parent);
            return level;
        }

        public List<Level> CreateAll(Transform parent)
        {
            var levels = new List<Level>();

            var levelBundles = ResourceLoader.LoadAll<LevelBundleData>("Scripts/Data/Level/Bundles");
            foreach (var levelBundle in levelBundles)
            {
                var level = CreateLevelData(levelBundle, parent);
                levels.Add(level);
                level.Hide();
            }

            return levels;
        }
    }
}
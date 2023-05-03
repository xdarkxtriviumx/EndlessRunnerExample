using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Aberranthian.EndlessRunner.Game.Misc;

namespace Aberranthian.EndlessRunner.Game.Handlers
{
    public class SaveHandler : MonoBehaviour
    {
        private readonly string _saveFolderName = "Saves";
        private readonly string _saveDataName = "save.json";

        public void SaveScore(int score)
        {
            SaveData data = new(score);

            string directory = Path.Combine(Application.persistentDataPath, _saveFolderName);
            string fullPath = Path.Combine(directory, _saveDataName);
            Debug.LogError($"Saved game data to: {fullPath}");

            string dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            File.WriteAllText(fullPath, dataJson);
        }

        public int LoadScore()
        {
            string directory = Path.Combine(Application.persistentDataPath, _saveFolderName);
            string fullPath = Path.Combine(directory, _saveDataName);

            if (!(Directory.Exists(directory) && File.Exists(fullPath))) return 0;

            string dataJson = File.ReadAllText(fullPath);

            return JsonConvert.DeserializeObject<SaveData>(dataJson).Score;
        }
    }
}
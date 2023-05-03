namespace Aberranthian.EndlessRunner.Game.Misc
{
    [System.Serializable]
    public class SaveData
    {
        public int Score { get; set; }

        public SaveData(int score)
        {
            Score = score;
        }
    }
}
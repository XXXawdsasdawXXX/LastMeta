using System;
using System.Collections.Generic;
using Code.Character.Hero;
using Code.Data.Configs;
using Code.Data.GameData;

namespace Code.Services.SaveServices
{
    [Serializable]
    public class SavedData
    {
        public string CurrentScene;
        public TimeData TimeData;
        public HealthData HeroHealth;
        public HeroUpgradesLevelData HeroUpgradesLevel;
        public HeroAbilityLevelData HeroAbilityLevel;
        public PositionData HeroPosition;
        public PositionData CameraPosition;
        public Dictionary<string, Vector3Data> ObjectsPosition;
        public Dictionary<string, PointData> SceneSpawnPoints;
        public int Language;


        public SavedData()
        {
            TimeData = new TimeData
            {
                Seconds =  0,
                Day = 1,
                TimeOfDay = TimeOfDay.Morning.ToString(),
            };
            HeroPosition = new PositionData();
            CameraPosition = new PositionData();
            HeroHealth = new HealthData();
            HeroUpgradesLevel = new HeroUpgradesLevelData();
            HeroAbilityLevel = new HeroAbilityLevelData();
            ObjectsPosition = new Dictionary<string, Vector3Data>();
            SceneSpawnPoints = new Dictionary<string, PointData>();
        }
    }

}
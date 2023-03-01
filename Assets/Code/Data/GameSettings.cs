using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public float dayTime = 50;


    }
}
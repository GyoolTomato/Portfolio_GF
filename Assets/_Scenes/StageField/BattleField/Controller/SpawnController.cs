using System;
using UnityEngine;
using Assets.Character;
using Assets.Character.Battle;

namespace Assets.Scenes.StageField.BattleField.Controller
{
    public class SpawnController
    {

        public SpawnController()
        {
        }

        public GameObject SpawnCharacter(int tDollIndexNumber, Vector3 position)
        {
            GameObject result;

            switch (tDollIndexNumber)
            {
                case 1:
                    result = MonoBehaviour.Instantiate(CharacterObject.Healer(), position, Quaternion.identity);
                    result.AddComponent<Healer>();
                    return result;
                case 2:
                    result = MonoBehaviour.Instantiate(CharacterObject.Sorceress(), position, Quaternion.identity);
                    result.AddComponent<Sorceress>();
                    return result;
                case 3:
                    result = MonoBehaviour.Instantiate(CharacterObject.Wizzard(), position, Quaternion.identity);
                    result.AddComponent<Wizzard>();
                    return result;
                case 4:
                    result = MonoBehaviour.Instantiate(CharacterObject.Archer(), position, Quaternion.identity);
                    result.AddComponent<Archer>();
                    return result;
                case 5:
                    result = MonoBehaviour.Instantiate(CharacterObject.GirlArcher(), position, Quaternion.identity);                    
                    result.AddComponent<GirlArcher>();
                    return result;
                case 6:
                    result = MonoBehaviour.Instantiate(CharacterObject.HoodArcher(), position, Quaternion.identity);                    
                    result.AddComponent<HoodArcher>();
                    return result;
                case 7:
                    result = MonoBehaviour.Instantiate(CharacterObject.BoyKnight(), position, Quaternion.identity);                    
                    result.AddComponent<BoyKnight>();
                    return result;
                case 8:
                    result = MonoBehaviour.Instantiate(CharacterObject.ChargeKnight(), position, Quaternion.identity);                    
                    result.AddComponent<ChargeKnight>();
                    return result;
                case 9:
                    result = MonoBehaviour.Instantiate(CharacterObject.ElfKnight(), position, Quaternion.identity);                    
                    result.AddComponent<ElfKnight>();
                    return result;                    
                default:                    
                    Debug.Log("Spawn Fail");
                    return null;
            }
        }
    }
}
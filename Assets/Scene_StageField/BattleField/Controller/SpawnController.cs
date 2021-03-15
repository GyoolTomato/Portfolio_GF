using System;
using UnityEngine;
using Assets.Character;

namespace Assets.Scene_StageField.BattleField.Controller
{
    public class SpawnController
    {

        public SpawnController()
        {
        }

        public GameObject SpawnCharacter(int tDollIndexNumber, Vector3 position)
        {
            var result = new GameObject();

            switch (tDollIndexNumber)
            {
                case 1:
                    result = MonoBehaviour.Instantiate(CharacterObject.Healer(), position, Quaternion.identity);
                    break;
                case 2:
                    result = MonoBehaviour.Instantiate(CharacterObject.Sorceress(), position, Quaternion.identity);
                    break;
                case 3:
                    result = MonoBehaviour.Instantiate(CharacterObject.Wizzard(), position, Quaternion.identity);
                    break;
                case 4:
                    result = MonoBehaviour.Instantiate(CharacterObject.Archer(), position, Quaternion.identity);
                    break;
                case 5:
                    result = MonoBehaviour.Instantiate(CharacterObject.GirlArcher(), position, Quaternion.identity);
                    break;
                case 6:
                    result = MonoBehaviour.Instantiate(CharacterObject.HoodArcher(), position, Quaternion.identity);
                    break;
                case 7:
                    result = MonoBehaviour.Instantiate(CharacterObject.BoyKnight(), position, Quaternion.identity);
                    break;
                case 8:
                    result = MonoBehaviour.Instantiate(CharacterObject.ChargeKnight(), position, Quaternion.identity);
                    break;
                case 9:
                    result = MonoBehaviour.Instantiate(CharacterObject.ElfKnight(), position, Quaternion.identity);
                    break;
                default:
                    Debug.Log("Spawn Fail");
                    break;
            }

            return result;
        }
    }
}
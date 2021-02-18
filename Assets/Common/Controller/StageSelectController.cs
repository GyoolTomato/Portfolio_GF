using System;
using UnityEngine.SceneManagement;

namespace Assets.Common.Controller
{
    public class StageSelectController
    {
        public StageSelectController()
        {
        }

        public void Initialize()
        {

        }

        public void StageSelect(Assets.Common.DB.User.UserDataBase_Stage data)
        {
            SceneManager.LoadScene("StageField");
        }
    }
}

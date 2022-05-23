using GAME_MAIN.CodeBase.Infrastructure.Services;
using GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Logic
{
    public class SaveGame : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        public void Save()
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Progress saved!");
            //gameObject.SetActive(false);
        }
    }
}

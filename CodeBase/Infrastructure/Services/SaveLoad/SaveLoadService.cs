using GAME_MAIN.CodeBase.Data;
using GAME_MAIN.CodeBase.Infrastructure.Factory;
using GAME_MAIN.CodeBase.Infrastructure.Services.PersistetntProgress;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;


        public SaveLoadService (IPersistentProgressService progressService,IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressesWriter in _gameFactory.ProgressesWriters)
            {
                progressesWriter.UpdateProgress(_progressService.Progress);
                
                PlayerPrefs.SetString(ProgressKey,_progressService.Progress.ToJson());
            }
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.
            ToDeserialized<PlayerProgress>();
    }
}
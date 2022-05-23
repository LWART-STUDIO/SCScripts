using GAME_MAIN.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssets: IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Vector3 at,Transform parent);
    }
}

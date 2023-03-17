using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.Services
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Transform parent);
    }
}

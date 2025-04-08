using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IAddressablesAssetLoaderService
{
    public UniTask<T> LoadAssetAsync<T>(string address) where T : Object;
    public TAsset LoadAsset<TAsset>(string address) where TAsset : Object;
    public bool ReleaseAsset(string address);
    public void ReleaseAllAssets();
    public bool IsAssetLoaded(string address);
}

using Addressables;
using Core.PrefabFactory;
using Feature.PlayerData;
using UnityEngine;
using Zenject;

namespace Feature.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        private IPrefabFactory _prefabFactory;
        private PlayerEntityModel _playerEntityModel;
    
        [Inject]
        public void InjectDependencies(PlayerEntityModel playerEntityModel, IPrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
            _playerEntityModel = playerEntityModel;
        }

        private void Start()
        {
            GameObject player = _prefabFactory.Create(Address.Prefabs.Player, transform.position, transform.root);
            _playerEntityModel.PlayerEntity = player;
        }
    }
}

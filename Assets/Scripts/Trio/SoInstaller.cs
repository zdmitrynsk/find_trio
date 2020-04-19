using UnityEngine;
using Zenject;

namespace Trio
{
    [CreateAssetMenu(fileName = "SoInstaller", menuName = "Create SO Installer")]
    public class SoInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameConfig gameConfig = null;

        public override void InstallBindings()
        {
            Container.BindInstance(gameConfig);
        }
    }
}

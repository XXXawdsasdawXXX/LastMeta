using Code.Data.Configs;
using Code.Data.GameData;
using Code.UI;
using Code.UI.HeadUpDisplay;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class HUDInstaller : MonoInstaller
    {
        [Inject] private PrefabsData _prefabsData;
        [SerializeField] private Constants.TypeOfScene _typeOfScene;

        public override void InstallBindings()
        {
            BindHUD();
        }

        private void BindHUD()
        {
            HUD hud = Container.InstantiatePrefabForComponent<HUD>(
                GetHudPrefabs(),
                Vector3.zero,
                Quaternion.identity,
                null);
            
            Container.Bind<HUD>().FromInstance(hud).AsSingle().NonLazy();
        }

        private HUD GetHudPrefabs()
        {
            switch (_typeOfScene)
            {
                case Constants.TypeOfScene.Real:
                    return _prefabsData.RealHUD;
                case Constants.TypeOfScene.Game:
                default:
                    return _prefabsData.GameHUD;
            }
        }
    }
}
using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>()
                .AsSingle()
                .WithArguments(
                    _settings.Rigidbody2D,
                    _settings.SpriteRenderer,
                    _settings.Animator,
                    _settings.Collider2D);

//            Container.Bind<PlayerFacade>().AsSingle();

            Container.Bind<PlayerDeathHandler>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<PlayerAnimatorHandler>().AsSingle();
            Container.Bind<PlayerCollision>().AsSingle();

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerActionHandler>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerGroundedHandler>().AsSingle();
        }
    }

    [Serializable]
    public class Settings
    {
        public Animator Animator;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;
    }
}
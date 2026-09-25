using System.Collections.Generic;
using Code.Gameplay.Cameras.Provider;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Look.Systems
{
    public class AttachCameraToPlayerHeadSystem : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(1);

        public AttachCameraToPlayerHeadSystem(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Head)
                .NoneOf(
                    GameMatcher.CameraAttached));
        }

        public void Execute()
        {
            if (_cameraProvider.MainCamera == null)
                return;

            foreach (GameEntity hero in _heroes.GetEntities(_buffer))
            {
                Transform cameraTransform = _cameraProvider.MainCamera.transform;

                cameraTransform.SetParent(hero.Head, worldPositionStays: false);
                cameraTransform.localPosition = Vector3.zero;
                cameraTransform.localRotation = Quaternion.identity;

                hero.isCameraAttached = true;
                
                Debug.Log("камера прикреплена");
            }
        }
    }
}
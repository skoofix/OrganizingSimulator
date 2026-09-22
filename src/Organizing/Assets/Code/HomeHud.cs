using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class HomeHUD : MonoBehaviour
    {
        private const string BattleSceneName = "Main";
    
        private IGameStateMachine _stateMachine;

        public Button StartBattleButton;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) => 
            _stateMachine = gameStateMachine;

        private void Awake()
        {
            StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
        }

        private void OnDestroy()
        {
            StartBattleButton.onClick.RemoveListener(EnterBattleLoadingState);
        }

        private void EnterBattleLoadingState() => 
            _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
    }
}
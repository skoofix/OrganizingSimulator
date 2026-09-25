using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class LockCursorSystem : IInitializeSystem, ITearDownSystem
    {
        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void TearDown()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
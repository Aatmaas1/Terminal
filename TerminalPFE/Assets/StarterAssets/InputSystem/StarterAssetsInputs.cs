using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}


        public void OnPause()
        {
			if(SceneManager.GetActiveScene().buildIndex != 3)
            {
                SetPause();
				sc_PlayerManager_HC.Instance.ResetZoom();
            }
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
			if(SceneManager.GetActiveScene().buildIndex == 3 )
			{
				move.x = 0;
				move.y = Mathf.Clamp01(move.y);
			}
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
				look = Vector2.zero;
            }
        }

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			if (GetComponent<PlayerInput>())
			{
				if (GetComponent<PlayerInput>().currentActionMap.name == "Player")
				{
					Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
				}
			}
		}

		private void SetPause()
        {
			if(sc_UIPauseManager.Instance != null)
            {
				sc_UIPauseManager.Instance.TestPause();

			}
        }
	}
	
}
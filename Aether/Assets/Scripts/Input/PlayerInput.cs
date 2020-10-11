using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Aether.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnMove;

		public event Action<Vector2> OnLook;

		public event Action OnJump;

		public event Action<int> OnCastSpell;

		public UnityEvent onInteract;

		private void Start()
		{
			SubscribeToInputEvents();
		}

		private void OnDestroy()
		{
			UnSubscribeFromInputEvents();
		}

		protected virtual void Update()
		{
			var movementVector = InputSystem.InputActions.Player.Movement.ReadValue<Vector2>();
			if(movementVector != Vector2.zero)
				OnMove?.Invoke(movementVector);

			var lookVector = InputSystem.InputActions.Player.Look.ReadValue<Vector2>();
			if(lookVector != Vector2.zero)
				OnLook?.Invoke(lookVector);
		}

		protected virtual void SubscribeToInputEvents()
		{
			InputSystem.InputActions.Player.Interact.started += Interact;
			InputSystem.InputActions.Player.Jump.started += Jump;
			InputSystem.InputActions.Player.CastSpell1.started += CastSpell1;
			InputSystem.InputActions.Player.CastSpell2.started += CastSpell2;
			InputSystem.InputActions.Player.CastSpell3.started += CastSpell3;
			InputSystem.InputActions.Player.CastSpell4.started += CastSpell4;
			InputSystem.InputActions.Player.CastSpell5.started += CastSpell5;
			InputSystem.InputActions.Player.CastSpell6.started += CastSpell6;
			InputSystem.InputActions.Player.CastSpell7.started += CastSpell7;
			InputSystem.InputActions.Player.CastSpell8.started += CastSpell8;
		}

		protected virtual void UnSubscribeFromInputEvents()
		{
			InputSystem.InputActions.Player.Jump.started -= Jump;
			InputSystem.InputActions.Player.CastSpell1.started -= CastSpell1;
			InputSystem.InputActions.Player.CastSpell2.started -= CastSpell2;
			InputSystem.InputActions.Player.CastSpell3.started -= CastSpell3;
			InputSystem.InputActions.Player.CastSpell4.started -= CastSpell4;
			InputSystem.InputActions.Player.CastSpell5.started -= CastSpell5;
			InputSystem.InputActions.Player.CastSpell6.started -= CastSpell6;
			InputSystem.InputActions.Player.CastSpell7.started -= CastSpell7;
			InputSystem.InputActions.Player.CastSpell8.started -= CastSpell8;
		}

		#region Input Event Handlers
		
		private void Interact(InputAction.CallbackContext context)
		{
			onInteract?.Invoke();
		}
		
		private void CastSpell1(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(0);
		}
		
		private void CastSpell2(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(1);
		}
		
		private void CastSpell3(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(2);
		}
		
		private void CastSpell4(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(3);
		}
		
		private void CastSpell5(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(4);
		}
		
		private void CastSpell6(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(5);
		}
		
		private void CastSpell7(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(6);
		}
		
		private void CastSpell8(InputAction.CallbackContext context)
		{
			OnCastSpell?.Invoke(7);
		}

		protected virtual void Jump(InputAction.CallbackContext context)
		{
			OnJump?.Invoke();
		}
		
		#endregion
    }
}

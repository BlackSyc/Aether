using Aether.Core.Attributes;
using Aether.Input;
using Syc.Movement;
using UnityEngine;

namespace Aether.Movement
{
	public class PlayerMovementSystem : MovementSystem
	{
		#region Private Fields
        
		[SerializeField] private CameraPivot cameraPivot;

		[SerializeField] private ScryerAttributes movementDefaultAttributes;

		[SerializeField] private PlayerInput playerInput;

		#endregion

		public override IMovementAttributes MovementAttributes => movementDefaultAttributes;
        
		#region MonoBehaviour

		private void Awake()
		{
			playerInput.OnMove += Move;
			playerInput.OnLook += Rotate;
			playerInput.OnLook += RotateCameraPivot;
			playerInput.OnJump += Jump;
		}

		private void OnDestroy()
		{
			playerInput.OnMove -= Move;
			playerInput.OnLook -= Rotate;
			playerInput.OnLook -= RotateCameraPivot;
			playerInput.OnJump -= Jump;
		}

		#endregion

		#region MyRegion

		private void RotateCameraPivot(Vector2 lookInput)
		{
			cameraPivot.Rotate(lookInput, MovementAttributes.RotationSpeed.Remap());
		}

		#endregion
	}
}

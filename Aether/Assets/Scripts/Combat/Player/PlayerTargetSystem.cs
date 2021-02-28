using System;
using System.Linq;
using Syc.Combat;
using Syc.Combat.TargetSystem;
using UnityEngine;

namespace Aether.Combat.Player
{
	[Serializable]
	public class PlayerTargetSystem : ITargetManager
	{
		public ICombatSystem System { get; set; }
		
		private Transform _playerCamera;

		[SerializeField] private float maxRange;

		[SerializeField] private bool useExactTargets;

		public void SetPlayerCamera(Transform playerCameraTransform)
		{
			_playerCamera = playerCameraTransform;
		}
		
		public Target CreateTarget()
		{
			if (!_playerCamera)
			{
				return new Target(null, Vector3.zero);
			}
			
			var maxRangePosition = maxRange * _playerCamera.forward + _playerCamera.position;
			
			if (_playerCamera == null)
			{
				return new Target(null, maxRangePosition);
			}
			
			var hits = Physics.RaycastAll(_playerCamera.position, _playerCamera.forward, maxRange);
			
			if (!hits.Any())
			{
				
				return new Target(null, maxRangePosition);
			}

			var hit = hits.Last();
			
			return new Target(hit.transform.gameObject, useExactTargets 
				? hit.point 
				: hit.transform.position);
		}

		public void Tick(float deltaTime) { }
	}
}
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
		
		[SerializeField] private Transform playerCamera;

		[SerializeField] private float maxRange;

		[SerializeField] private bool useExactTargets;
		
		public Target CreateTarget()
		{
			var hits = Physics.RaycastAll(playerCamera.position, playerCamera.forward, maxRange);
			
			if (!hits.Any())
			{
				var maxRangePosition = maxRange * playerCamera.forward + playerCamera.position;
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
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
		[SerializeField] 
		private Transform playerCamera;

		[SerializeField] private float maxRange;

		[SerializeField] private bool useExactTargets;
		
		private GameObject _projectedTarget;
		private ICombatSystem _combatSystem;
		

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

		public ICombatSystem System
		{
			get => _combatSystem;
			set
			{
				_combatSystem = value;
				
				if(!_projectedTarget)
					_projectedTarget = new GameObject("<Projected Target>");
				
				_projectedTarget.transform.SetParent(_combatSystem.Origin);
				_projectedTarget.transform.rotation = Quaternion.identity;
				_projectedTarget.transform.localScale = Vector3.one;
				_projectedTarget.transform.position = Vector3.forward * maxRange;
			}
		}
		
		public void Tick(float deltaTime) { }
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/AI/Follow player")]
    public class FollowPlayer : Idle
    {
        [SerializeField]
        private float movementSpeed = 20;

        [SerializeField]
        private float rotationSpeed;


        public override void Create(AIStateMachine stateMachine)
        {
            stateMachine.transform.SetParent(null, true);
            SceneManager.MoveGameObjectToScene(stateMachine.gameObject, SceneController.Instance.BaseScene);
            Player.Instance.AggroRelay.AggroManager = stateMachine.GetComponent<AggroTable>();
        }

        public override void Destroy(AIStateMachine stateMachine)
        {
            Player.Instance.AggroRelay.AggroManager = null;
        }

        public override void FixedUpdateState(AIStateMachine stateMachine)
        {
            Transform transform = stateMachine.transform;
            float distanceToCompanionParent = Vector3.Distance(transform.position, Player.Instance.CompanionParent.position);


            if (distanceToCompanionParent > 0.3333f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(Player.Instance.CompanionParent.position - transform.position);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, Player.Instance.CompanionParent.position, movementSpeed * Time.deltaTime);
            }
            else
            {
                if (!stateMachine.GetComponent<Health>().IsFullHealth)
                    stateMachine.GetComponent<Health>().SetFullHealth();

                Quaternion lookRotation = Quaternion.LookRotation(Player.Instance.transform.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, Player.Instance.CompanionParent.position, Mathf.Pow((3 * distanceToCompanionParent), 2) * movementSpeed * Time.deltaTime);
            }
        }
    }
}

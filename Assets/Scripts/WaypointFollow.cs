using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour {

    public UnityStandardAssets.Utility.WaypointCircuit circuit;


    int currentWP = 0;

    float speed = 3f;
    public float acc;
    float rotSpeed = 1f;

    [SerializeField] private bool isAttackingEnemy = false;

    private UnityStandardAssets.Characters.ThirdPerson.AICharacterControl  aicc;
    private Ally ally;
    private AllyShoot allyShoot;
    private TargetManager targetManager;

    // Use this for initialization
	void Start () {
        targetManager = GameObject.FindObjectOfType<TargetManager>().GetComponent<TargetManager>();
        aicc = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        allyShoot = GetComponent<AllyShoot>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (circuit.Waypoints.Length == 0) return;


        if (targetManager.targets.Count <= 0 && isAttackingEnemy)
        {
            aicc.agent.Resume(); // resume the agent movement after finished attack
            isAttackingEnemy = false;
            Debug.Log("test");

        }

        if (!isAttackingEnemy)
        {
            aicc.target = circuit.Waypoints[currentWP];


            Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].position.x, this.transform.position.y, circuit.Waypoints[currentWP].position.z); // look at target (each waypoint)
            Vector3 direction = lookAtGoal - this.transform.position;


            // might not need this, since thirdpersoncontroller already covered the rotation
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            if (direction.magnitude < acc) //reach target position
            {
                currentWP++;
                if (targetManager.targets.Count > 0)
                {
                    StartCoroutine("AttackEnemy"); // attack

                }
                if (currentWP >= circuit.Waypoints.Length)
                {
                    currentWP = 0;
                }
            }

      
            
        }

    }


    // allied attack random/detected enemies
    IEnumerator AttackEnemy()
    {
        aicc.agent.Stop(); // stop the agent
        isAttackingEnemy = true;

        // animate, calculate, etc.. 
        // attack an enemy in certain duration
        //on progress

        //ally.Attack();

        // if no enemy in target area 
        

        yield return new WaitForSecondsRealtime(0f);
        
        


    }
}

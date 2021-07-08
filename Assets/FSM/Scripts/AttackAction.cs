using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Attack")]
public class AttackAction : Actions {

    public GameObject shootPrefab;
    public float shootTimeInverval = 2;
    private float shootTime = float.PositiveInfinity;
    public float shootEnergy = 5;


    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Attack!");
        shootTime += Time.deltaTime;
        if (shootTime > shootTimeInverval)
        {
            fsm.GetNavMeshAgent().ReduceEnergy(shootEnergy);   
            shootTime = 0;
            GameObject bullet = Instantiate(shootPrefab, fsm.transform.position, fsm.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = fsm.transform.TransformDirection(Vector3.forward * 10);
        }

    }
}

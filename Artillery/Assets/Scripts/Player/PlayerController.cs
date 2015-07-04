﻿/* 
 * Script: PlayerController
 * Purpose: To handle all of the player's input
 */

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerData))]
[RequireComponent (typeof(Motor))]

public class PlayerController : MonoBehaviour 
{
	public PlayerData data;
	public Motor motor;

	// Use this for initialization
	void Start () 
	{
		data = GameManager.instance.playerData;
		motor = GetComponent<Motor> ();
        motor.turretLimits = GameManager.instance.playerData.cannonVerticleLimit;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Forward/Backward
		if (Input.GetKey(GameManager.instance.controlsData.moveForward) || Input.GetKeyDown(GameManager.instance.controlsData.moveForward))
		{
            motor.MoveFoward(GameManager.instance.playerData.forwardSpeed);
		}
        else if (Input.GetKey(GameManager.instance.controlsData.moveBackward) || Input.GetKeyDown(GameManager.instance.controlsData.moveBackward))
        {
            motor.MoveBackward(GameManager.instance.playerData.reverseSpeed);
        }
        else
        {
            motor.ApplyGravity();
        }

		// Body left/right
		if (Input.GetKey(GameManager.instance.controlsData.turnRight) || Input.GetKeyDown(GameManager.instance.controlsData.turnRight))
		{
            motor.TurnRight(GameManager.instance.playerData.turnSpeed);
		}
		else if (Input.GetKey(GameManager.instance.controlsData.turnLeft) || Input.GetKeyDown(GameManager.instance.controlsData.turnLeft))
		{
            motor.TurnLeft(GameManager.instance.playerData.turnSpeed);
		}

		// Turret up/down
        if (Input.GetKey(GameManager.instance.controlsData.turretUp) || Input.GetKeyDown(GameManager.instance.controlsData.turretUp))
        {
            motor.TurretUp(GameManager.instance.playerData.cannonUpDownSpeed);
        }
        else if (Input.GetKey(GameManager.instance.controlsData.turretDown) || Input.GetKeyDown(GameManager.instance.controlsData.turretDown))
        {
            motor.TurretDown(GameManager.instance.playerData.cannonUpDownSpeed);
        }

		// Turret left/right
        if (Input.GetKey(GameManager.instance.controlsData.turretRight) || Input.GetKeyDown(GameManager.instance.controlsData.turretRight))
        {
            motor.TurretRight(GameManager.instance.playerData.cannonTurnSpeed);
        }
        else if (Input.GetKey(GameManager.instance.controlsData.turretLeft) || Input.GetKeyDown(GameManager.instance.controlsData.turretLeft))
        {
            motor.TurretLeft(GameManager.instance.playerData.cannonTurnSpeed);
        }
	}
}

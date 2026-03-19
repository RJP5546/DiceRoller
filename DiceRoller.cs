/*******************************************************************
* COPYRIGHT       : 2026
* PROJECT         : DiceRollerTutorial
* FILE NAME       : DiceRoller.cs
* DESCRIPTION     : Spawns and Rolls the Dice
*                    
* REVISION HISTORY:
* Date 			Author    		        Comments
* ---------------------------------------------------------------------------
* 2026/03/19		Ryan Pederson       File Created
* 
/******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceRoller1 : MonoBehaviour
{
    public Dice DiceToThrow;
    public int AmmountOfDice = 2;
    public float ThrowForce = 5f;
    public float rollForce = 10f;

    private List<GameObject> spawnedDice = new List<GameObject>();

    public static UnityAction<int> OnDiceRoll;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { StartCoroutine(RollDice()); }
    }

    private IEnumerator RollDice()
    {
        OnDiceRoll?.Invoke(AmmountOfDice);

        if (DiceToThrow == null) { yield break; }

        foreach (var die in spawnedDice)
        {
            Destroy(die);
        }

        for (int i = 0; i < AmmountOfDice; i++)
        {
            Dice dice = Instantiate(DiceToThrow, transform.position, transform.rotation);
            spawnedDice.Add(dice.gameObject);
            dice.RollDice(ThrowForce, rollForce, i);
            yield return null;
        }
    }
}

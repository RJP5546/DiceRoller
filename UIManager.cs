/*******************************************************************
* COPYRIGHT       : 2026
* PROJECT         : DiceRollerTutorial
* FILE NAME       : UIManager.cs
* DESCRIPTION     : Manages the UI
*                    
* REVISION HISTORY:
* Date 			Author    		        Comments
* ---------------------------------------------------------------------------
* 2026/03/19		Ryan Pederson       File Created
* 
/******************************************************************/

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject resultContainer;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private List<GameObject> resultTextBoxes;

    private void Awake()
    {
        resultTextBoxes = new List<GameObject>();
    }

    private void OnEnable()
    {
        DiceRoller1.OnDiceRoll += setDiceUI;
        Dice.OnDiceResult += SetText;
    }

    private void OnDisable()
    {
        DiceRoller1.OnDiceRoll -= setDiceUI;
        Dice.OnDiceResult -= SetText;
    }

    private void setDiceUI(int _diceRolled)
    {
        foreach (var textBox in resultTextBoxes)
        {
            Destroy(textBox);
        }

        resultTextBoxes = new List<GameObject>();

        for (int i = 0; i < _diceRolled; i++)
        {
            resultTextBoxes.Add(Instantiate(textPrefab, resultContainer.transform));
        }
    }

    private void SetText(int _diceIndex, int _diceResult)
    {
        resultTextBoxes[_diceIndex].GetComponent<TMP_Text>().text = $"Dice {_diceIndex + 1} rolled a {_diceResult}";
    }
}

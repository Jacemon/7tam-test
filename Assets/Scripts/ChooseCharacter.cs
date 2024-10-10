using System;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public List<CharacterController> characters;

    private void Start()
    {
        SetCurrentCharacter(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCurrentCharacter(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCurrentCharacter(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetCurrentCharacter(2);
        }
    }

    public void SetCurrentCharacter(int index)
    {
        foreach (var character in characters)
        {
            character.enabled = false;
        }

        characters[index].enabled = true;

        Debug.Log($"{characters[index].name} - is active");
    }
}
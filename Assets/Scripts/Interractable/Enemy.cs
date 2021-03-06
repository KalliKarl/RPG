﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    private void Start() {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    private void Update() {
        if (Input.GetButtonDown("Skill1")) {
            Debug.Log("fire");

            Interact();
        }
    }
    public override void Interact() {
        base.Interact();
         CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        //Attack Enemy




        if (playerCombat != null) {
            playerCombat.Attack(myStats);

        }



    }
}

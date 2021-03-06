﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton
    public static EquipmentManager instance;

    void Awake() {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public Transform equipParents;

    EquipmentSlots[] eSlots;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;
    void Start() {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];

        eSlots = equipParents.GetComponentsInChildren<EquipmentSlots>();
    }

    public void Equip(Equipment newItem) {

        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        
        if (currentEquipment[slotIndex] != null) {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null) {

            onEquipmentChanged.Invoke(newItem,oldItem);
            eSlots[slotIndex].AddItem(newItem);
        }
    }
    public void Unequip(int slotIndex) {
        if (currentEquipment[slotIndex] != null) {

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null) {

                onEquipmentChanged.Invoke(null, oldItem);
               

            }

        }

    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquipment.Length; i++) {

            Unequip(i);

        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.U))
            UnequipAll();
    }
}

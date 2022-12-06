using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¸Ë³ÆÃþ
/// </summary>
public class Equipment : Item
{ 
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Agility { get; set; }
    public int Stamina { get; set; }
    public EquipmentType EquipType { get; set; }
    
    public Equipment(int id, string name, ItemType type, ItemQuality quality, string description,
        int capacity, int buyPrice, int sellPrice, string sprite, int strength, int intellect,
        int agility, int stamina, EquipmentType equipType)
        : base(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite)
    {
        this.Strength = strength;
        this.Intellect = intellect;
        this.Agility = agility;
        this.Stamina = stamina;
        this.EquipType = equipType;
    }
    
    public enum EquipmentType
    {
        Head,
        Neck,
        Ring,
        Leg,
        Bracer,
        Boots,
        Trinket,
        Shoulder,
        Belt,
        OffHand
    }
}

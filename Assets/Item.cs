using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���~�����O
/// </summary>
public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }

    public Item()
    {

    }

    public Item(int id, string name,ItemType type, ItemQuality quality, string description, int capacity, int buyPrice, int sellPrice, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
        this.Description = description;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }

    /// <summary>
    /// ���~���O
    /// </summary>
    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    /// <summary>
    /// ���~�~��
    /// </summary>
    public enum ItemQuality
    {
        Common,
        Unmmon,
        Rare,
        Epic,
        Legendary,
        Artifact
    }
}

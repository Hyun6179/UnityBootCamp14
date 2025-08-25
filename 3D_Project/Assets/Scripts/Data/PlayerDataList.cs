using System;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerDataList
{
    public PlayerData playerData;
    public World_state worldState;
    public List<InventoryItem> inventory;
}

[SerializeField]
public class PlayerData
{
    public string nickname;
    public int gold;
    public Vector3 position;

}

[SerializeField]
public class InventoryItem
{
    public string itemID;
    public int count;
    public bool equipped;
}

[SerializeField]
public class Settings
{
    public float volume;
    public bool fullscreen;
}

[SerializeField]
public class World_state
{
    public string time;
    public string weather;
    public string season;
}
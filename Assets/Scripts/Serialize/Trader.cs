using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader
{
    public int level;
    public string traderName;
    public string itemName;
    public int itemCnt;

    public Trader(int level, string traderName, string itemName, int itemCnt)
    {
        this.level = level;
        this.traderName = traderName;
        this.itemName = itemName;
        this.itemCnt = itemCnt;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Trader);
    }

    public bool Equals(Trader other)
    {
        if (other is null)
            return false;

        return level == other.level &&
               traderName == other.traderName &&
               itemName == other.itemName &&
               itemCnt == other.itemCnt;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(level, traderName, itemName, itemCnt);
    }

    public static bool operator ==(Trader left, Trader right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Equals(right);
    }

    public static bool operator !=(Trader left, Trader right)
    {
        return !(left == right);
    }
}

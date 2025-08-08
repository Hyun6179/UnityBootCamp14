using System.Collections.Generic;
using UnityEngine;

public enum DType
{
    Job,
    gender,
    weapon,
    tribe
}

public class DropdownData : MonoBehaviour
{
    public DType Type;

    public List<string> menu = new List<string>();

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public void ChangeFrozenColor()
    {
        Material myMaterial = GetComponent<Material>();
        Color color = myMaterial.color;
        color.a = 255f;
    }
}

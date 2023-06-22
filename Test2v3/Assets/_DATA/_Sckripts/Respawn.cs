using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlayerContorller settings;
    public void Resp()
    {
        settings.HP = settings.maxHp;
    }
}

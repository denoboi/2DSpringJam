using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects /Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
   public int HP;
   public int Damage;
   public float Speed;
   
}

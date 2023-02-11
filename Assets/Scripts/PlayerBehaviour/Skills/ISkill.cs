using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.PlayerBehaviour
{
    public interface ISkill 
    {
        public float GetRange();
        public float GetLevel();
        public void Shoot();
    }
}
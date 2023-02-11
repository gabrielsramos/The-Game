using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerBehaviour
{
    public abstract class Skill : ISkill
    {
        public abstract float GetLevel();

        public abstract float GetRange();

        public abstract void Shoot();
    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlayerBehaviour.Skills
{
    public class HidroSplash : Skill
    {
        public override float GetLevel()
        {
            return 1;
        }

        public override float GetRange()
        {
            return 200;
        }

        public override void Shoot()
        {
        }
    }
}
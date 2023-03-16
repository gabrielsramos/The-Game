using Assets.Scripts.PlayerBehaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSkill : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private ClickToTarget _clickToTarget;

    private void Start()
    {
        _clickToTarget = GetComponent<ClickToTarget>();
    }

    public void Shoot()
    {
        if (_clickToTarget.Target == null)
        {
            Debug.Log("There is no target to shoot at");
            return;
        }

        var projectile = Instantiate(_projectilePrefab, transform);
        projectile.Init(_clickToTarget.Target);
    }
}

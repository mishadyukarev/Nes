using Assets.Scripts.Controllers;
using UnityEngine;
using static Assets.Scripts.Consts.NameConsts;
using static Assets.Scripts.Main;

namespace Assets.Scripts.FromMonoBehaviour
{
    internal sealed class BulletTriggerEnter : MonoBehaviour
    {
        private string _currentTag;

        private ManagerTank ManagerTank => Instance.ManagerTank;
        private BulletManager BulletManager => Instance.BulletManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _currentTag = collision.gameObject.tag;

            if (gameObject.tag == PLAYER_BULLET_TAG)
            {
                if (_currentTag == PLAYER_TANK_TAG)
                {

                }

                else if (_currentTag == ENEMY_TANK_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                    ManagerTank.RemoveTank(false, collision.gameObject);
                }

                else if (_currentTag == PLAYER_BULLET_TAG)
                {

                }

                else if (_currentTag == ENEMY_BULLET_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                    BulletManager.RemoveBullet(collision.gameObject);
                }


                else if (_currentTag == LIMITS_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                }

                else if (_currentTag == WALL_TAG)
                {
                    GameObject.Destroy(collision.gameObject);
                    BulletManager.RemoveBullet(gameObject);
                }
            }

            else
            {
                if (_currentTag == PLAYER_TANK_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                    ManagerTank.RemoveTank(true, collision.gameObject);
                }

                else if (_currentTag == ENEMY_TANK_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                }

                else if (_currentTag == PLAYER_BULLET_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                    BulletManager.RemoveBullet(collision.gameObject);
                }

                else if (_currentTag == ENEMY_BULLET_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                    BulletManager.RemoveBullet(collision.gameObject);
                }

                else if (_currentTag == LIMITS_TAG)
                {
                    BulletManager.RemoveBullet(gameObject);
                }

                else if (_currentTag == WALL_TAG)
                {
                    GameObject.Destroy(collision.gameObject);
                    BulletManager.RemoveBullet(gameObject);
                }
            }
        }
    }
}

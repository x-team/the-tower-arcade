using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Bullet.
    /// </summary>
    /// <typeparam name="BulletCollision>"></typeparam>
    public class PlayerBulletCollision : Simulation.Event<PlayerBulletCollision>
    {
        public PlayerController player;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}
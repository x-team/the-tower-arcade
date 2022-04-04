using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the enemy collided with the death zone.
    /// </summary>
    /// <typeparam name="EnemyDestroy"></typeparam>
    public class EnemyDestroy : Simulation.Event<EnemyDestroy>
    {
        public EnemyController enemy;

        public override void Execute()
        {
            enemy.DestroyInstance();
        }
    }
}

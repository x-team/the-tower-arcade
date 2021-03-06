using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is hitted.
    /// </summary>
    /// <typeparam name="PlayerDamage"></typeparam>
    public class PlayerDamage : Simulation.Event<PlayerDamage>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {
                player.health.Decrement();

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");

                if (!player.health.IsAlive)
                {
                    player.health.Die();
                    model.virtualCamera.m_Follow = null;
                    model.virtualCamera.m_LookAt = null;
                    player.collider2d.enabled = false;
                    player.controlEnabled = false;
                    player.animator.SetBool("dead", true);
                    Simulation.Schedule<GameplayIsOver>(2);
                    //Simulation.Schedule<PlayerSpawn>(2);
                }
            }
        }
    }
}
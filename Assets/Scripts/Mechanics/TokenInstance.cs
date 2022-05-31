using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;
        [Tooltip("Frames per second at which tokens are animated.")]
        public float frameRate = 12;

        internal Sprite[] sprites = new Sprite[0];
        internal SpriteRenderer _renderer;

        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;
        float nextFrameTime = 0;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void Update()
        {
            //if it's time for the next frame...
            if (Time.time - nextFrameTime > (1f / frameRate))
            {
                //update all tokens with the next animation frame.
                _renderer.sprite = sprites[frame];

                if (collected && frame == sprites.Length - 1)
                {
                    Disable();
                }
                else
                {
                    frame = (frame + 1) % sprites.Length;
                }
                //calculate the time of the next frame.
                nextFrameTime += 1f / frameRate;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            collected = true;
            frame = 0;
            sprites = collectedAnimation;
            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerTokenCollision>();
            ev.token = this;
            ev.player = player;
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
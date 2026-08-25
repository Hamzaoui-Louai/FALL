using UnityEngine;

public enum KitType
{
    NoKit,
    Fragile,
    Ice,
    Invincible,
    Shooter,
    Slime,
    Slowfalling,
    Speed,
    Time
}

public class PlayerKit : MonoBehaviour
{
    KitType currentKit = KitType.NoKit;
    float timer;

    public KitType CurrentKit => currentKit;
    public float Timer => timer;
    public bool IsActive => currentKit != KitType.NoKit;

    public void ApplyKit(KitType kit, float duration)
    {
        currentKit = kit;
        timer = duration;
    }

    void FixedUpdate()
    {
        if (!IsActive) return;
        timer -= Time.fixedDeltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            currentKit = KitType.NoKit;
        }
    }
}

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

    public KitType GetKit() => currentKit;

    public void ApplyKit(KitType kit, float duration)
    {
        currentKit = kit;
        timer = duration;
    }

    void FixedUpdate()
    {
        if (currentKit == KitType.NoKit) return;
        timer -= Time.fixedDeltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            currentKit = KitType.NoKit;
        }
    }
}

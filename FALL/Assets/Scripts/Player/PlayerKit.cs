using UnityEngine;

public enum KitType
{
    No_kit,
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
    KitType currentKit = KitType.No_kit;
    float timer;

    public KitType GetKit() => currentKit;

    public void ApplyKit(KitType kit, float duration)
    {
        currentKit = kit;
        timer = duration * 60f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        KitType kit = KitType.No_kit;
        float duration = 5f;
        switch (collision.gameObject.tag)
        {
            case "Fragile": kit = KitType.Fragile; break;
            case "Ice": kit = KitType.Ice; break;
            case "Invincible": kit = KitType.Invincible; break;
            case "Shooter": kit = KitType.Shooter; break;
            case "Slime": kit = KitType.Slime; break;
            case "Slowfalling": kit = KitType.Slowfalling; break;
            case "Speed": kit = KitType.Speed; break;
            case "Time": kit = KitType.Time; break;
        }
        if (kit != KitType.No_kit) ApplyKit(kit, duration);
    }

    void FixedUpdate()
    {
        if (currentKit == KitType.No_kit) return;
        timer--;
        if (timer <= 0f)
        {
            timer = 0f;
            currentKit = KitType.No_kit;
        }
    }
}

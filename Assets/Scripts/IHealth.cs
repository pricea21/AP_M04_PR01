public interface IHealth
{
    event System.Action<float> OnHPPctChanged;
    event System.Action<float> OnHPPctHealerChanged;
    event System.Action OnDied;
    void TakeDamage(int amount);
    void Heal();
}

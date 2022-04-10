using System;
public class HpandMana
{
    private float _crentHeathPlayer;
    private float _currentManaPlayer;

    public float CurrentHeathPlayer
    {
        get => _crentHeathPlayer;
        set => Set(ref _crentHeathPlayer, value);
    }

    public float CurrentManaPlayer
    {
        get => _currentManaPlayer;
        set => Set(ref _currentManaPlayer, value);

    }
    private bool Set(ref float field, float value)
    {
        if (Equals(field, value)) return false;
        if (value > 100)
            field = 100f;
        else if (value < 0)
            value = 0f;
        else
            field = value;
        return true;
    }
    public HpandMana(float Mana, float Health)
    {
        CurrentManaPlayer = Mana;
        CurrentHeathPlayer = Health;
    }

    
}

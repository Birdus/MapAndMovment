using UnityEngine;
using UnityEngine.UI;

public class ShowHpAndMana : MonoBehaviour
{
    public enum ShowBar
    {
        HealthBar = 1,
        ManaBar = 2,
    }

    public float _maxHeal = 100f;
    public float _maxMana = 100f;

    [SerializeField] public Text TextMana;
    [SerializeField] public Text TextHealth;

    private float _currentMana;
    private Image _manaBar;
    private Image _healhBar;
    private HpandMana _pc;
    private float _currentHeath;

    public ShowBar axes = ShowBar.HealthBar;

    void Start()
    {
        _healhBar = GetComponent<Image>();
        _manaBar = GetComponent<Image>();
        _pc = new HpandMana(100, 100);

    }

    void Update()
    {
        if (axes == ShowBar.HealthBar)
        {
            _currentHeath = _pc.CurrentHeathPlayer;
            _healhBar.fillAmount = _currentHeath / _maxHeal;
            TextHealth.text = (int)_currentHeath + "%";
        }
        else if (axes == ShowBar.ManaBar)
        {
            
            _currentMana = _pc.CurrentManaPlayer;
            _manaBar.fillAmount = _currentMana / _maxMana;
            TextMana.text = _currentMana + "%";
        }
    }


}


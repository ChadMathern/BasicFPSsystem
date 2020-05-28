using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	public int _health;
    public Text HealthLv;
    public GameManager TheGameManager;

    void Start() {
		_health = 5;
    }

	public void Hurt(int damage) {
		_health -= damage;

        if (_health <= 0)
        TheGameManager.RestartGame();
        
	}

    public void Update()
    {
        HealthLv.text = _health.ToString();
    }
}


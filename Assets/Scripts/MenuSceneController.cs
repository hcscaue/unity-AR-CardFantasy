using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSceneController : MonoBehaviour
{
    public enum PlayerOneHero { Knight, Archer, Blacksmith, King }
    public enum Screen { Start, Select, Deck, Game }
    
    [Header("Controllers")]
    public PlayerOneHero playerOneHero;
    public Screen screen;

    [Header("Components")]

    public Animator _animGeneral; 
    public Animator _animKnight, _animArcher, _animBlacksmith, _animKing;

    public TextMeshProUGUI textLife, textAttack, textDescription;

    public CardHero[] cardHeroes;

    private void Awake() {
        screen = Screen.Start; // Ensures that the Screen will start in the correct state.
    }

    /// <summary>
    /// Method to manage the screens present in the Menu Scene {Presentation and Selection of Hero}.
    /// </summary>
    public void ToScreen(string nextScreen) {

        // Line of code that checks if the screen state is already in the "Game".
        // For the game to load, the State has to be duplicated, being validated by the 'if' and going to the LoadGame Method.
        if (screen == Screen.Game) { LoadGame(); return; }

        // Enum Screen status change, this change happens before to update the animation later.
        switch (nextScreen) {
            case "Start":
                screen = Screen.Start;
                break;
            case "Select":
                screen = Screen.Select;
                break; 
            case "Deck":
                screen = Screen.Deck;
                break;
            case "Game":
                screen = Screen.Game;
                break;
            default:
                Debug.LogError("Invalid Screen Defined.");
                break;
        }

        _animGeneral.SetInteger("Screen", (int) screen);

    }

    /// <summary>
    /// Method to define the Hero chosen by Player One.
    /// On the Switch within the method, the following actions take place: 1. Activate the animator of the chosen character, thus disabling the other characters; 2. Set the Enum PlayerOneHero according to the chosen Hero.
    /// </summary>
    public void SelectHero(string hero) {

        switch (hero) {
            case "Knight":
                _animArcher.enabled = false;
                _animKing.enabled = false;
                _animBlacksmith.enabled = false;
                _animKnight.enabled = true;
                playerOneHero = PlayerOneHero.Knight;
                break;
            case "Archer":
                _animBlacksmith.enabled = false;
                _animKnight.enabled = false;
                _animKing.enabled = false;
                _animArcher.enabled = true;
                playerOneHero = PlayerOneHero.Archer;
                break;
            case "Blacksmith":
                _animKing.enabled = false;
                _animKnight.enabled = false;
                _animArcher.enabled = false;
                _animBlacksmith.enabled = true;
                playerOneHero = PlayerOneHero.Blacksmith;
                break;
            case "King":
                _animKnight.enabled = false;
                _animArcher.enabled = false;
                _animBlacksmith.enabled = false;
                _animKing.enabled = true;
                playerOneHero = PlayerOneHero.King;
                break;
            default:
                Debug.LogError("Héroi Invalido Definido.");
                break;
        }

        textLife.text = cardHeroes[(int) playerOneHero].Life.ToString();
        textAttack.text = cardHeroes[(int) playerOneHero].Attack.ToString("D2");
        
        if ((int)playerOneHero == 0) textDescription.text = cardHeroes[(int)playerOneHero].descriptionHero + "\n\n" + cardHeroes[(int)playerOneHero].descriptionSpecial;
        else textDescription.text = cardHeroes[(int)playerOneHero].descriptionHero + "\n\n" + cardHeroes[(int)playerOneHero].descriptionSpecial + " " + cardHeroes[(int)playerOneHero].cooldown.ToString("D2") + " Rodadas de tempo de espera.";

    }

    /// <summary>
    /// Method that records the information needed to start the game - Selected Heroes and Deck - and goes to the "Game" Scene.
    /// </summary>
    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }
}

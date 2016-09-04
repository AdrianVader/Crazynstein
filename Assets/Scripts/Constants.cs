using UnityEngine;
using System.Collections;

public static class Constants
{



    // PLAYER MOVEMENT
    public const KeyCode PLAYER_MOVE_LEFT_KEY = KeyCode.A;
    public const KeyCode PLAYER_MOVE_RIGHT_KEY = KeyCode.D;
    public const KeyCode PLAYER_JUMP_KEY = KeyCode.Space;
    public const KeyCode PLAYER_CROUCH_KEY = KeyCode.E;
    public const KeyCode PLAYER_USE_KEY = KeyCode.LeftControl;

    // PLAYER INTERACTION
    public const string PLAYER_INTERACTION = "e";

    // PLAYER ANIMATION
    public const string PLAYER_ANIMATION_VARIABLE_SPEED = "Speed";
    public const string PLAYER_ANIMATION_VARIABLE_JUMP = "Jump";
    public const string PLAYER_ANIMATION_VARIABLE_GROUND = "Ground";

    // PLAYER ANIMATION
    public const float PLAYER_INITIAL_VALUE_LIFE = 100.0f;

    // PLAYER CHARACTERISTICS
    public const float PLAYER_MOVEMENT_SPEED = 5.0f;
    public const float PLAYER_JUMP_HEIGTH = 3.0f;

    // TAGS
    public const string PLAYER_TAG = "Player";
    public const string GROUND_TAG = "Ground";

    // ANIMATION NAMES
    public const string PLAYER_PUNCH_ANIMATION = "Punch";



}

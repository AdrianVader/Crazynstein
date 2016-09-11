using UnityEngine;
using System.Collections;

public static class Constants
{


    // ********** PLAYER ********** //
    // PLAYER MOVEMENT
    public const KeyCode PLAYER_MOVE_LEFT_KEY = KeyCode.A;
    public const KeyCode PLAYER_MOVE_RIGHT_KEY = KeyCode.D;
    public const KeyCode PLAYER_JUMP_KEY = KeyCode.Space;
    public const KeyCode PLAYER_CROUCH_KEY = KeyCode.LeftShift;
    public const KeyCode PLAYER_USE_KEY = KeyCode.E;

    // PLAYER INTERACTION
    public const string PLAYER_INTERACTION = "e";

    // PLAYER ANIMATION
    public const string PLAYER_ANIMATION_VARIABLE_SPEED = "Speed";
    public const string PLAYER_ANIMATION_VARIABLE_JUMP = "Jump";
    public const string PLAYER_ANIMATION_VARIABLE_GROUND = "Ground";

    // PLAYER STATS
    public const float PLAYER_INITIAL_VALUE_LIFE = 100.0f;
    public const float PLAYER_MOVEMENT_SPEED = 5.0f;
    public const float PLAYER_JUMP_HEIGTH = 3.0f;
    public const float PLAYER_MAXIMUM_LIFE_TIME_PUNCH = 0.2f;

    // PLAYER ANIMATION NAMES
    public const string PLAYER_PUNCH_ANIMATION = "Punch";

    // SCIENTIST
    public const float PLAYER_SCIENTIST_PUNCH_DAMAGE = 2.0f;



    // ********** ENEMIES ********** //
    // FROG
    public const float ENEMY_FROG_LIFE = 5.0f;
    public const float ENEMY_FROG_TIME_BETWEEN_JUMPS = 1.25f;
    public const float ENEMY_FROG_MAXIMUM_DISTANCE_FROM_INITIAL_POINT = 3.0f;
    public const float ENEMY_FROG_JUMP_HEIGHT = 3.0f;




    // ********** OBJECTS ********** //
    // DROPS
    public const float DROP_JUMP = 3.0f;
    public const float DROP_ROTARION_SPEED = 2.0f;
    public const float DROP_TAKE_MININUM_DISTANCE = 1.5f;



    // ********** TAGS ********** //
    // TAGS
    public const string PLAYER_TAG = "Player";
    public const string GROUND_TAG = "Ground";



    // ********** SCRIPTS ********** //
    // SCRIPTS NAMES
    public const string DAMAGE_SCRIPT = "Damage";



}

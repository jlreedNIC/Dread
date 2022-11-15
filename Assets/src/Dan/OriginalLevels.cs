/* GameObject JungleLevelPrefabs[];
 * GameObject DesertLevelPrefabs[];

 * Vector<permuation size of levels*> (dynamic)

 * levels permutations would be pushed and popped from memory during game runtime
 * IE as the player exits a previous room, the room is popped from the vector.
 *  
 * after the first checkpoint room was encountered a virtual function would evaluate the state
 * and replace the class with the desert tile prefabs and use that populated array

 */

 /*
    After reflecting on the process, the level generation would not truely be dynamic during execution
    of the game. Because it relies on the checkpoint as a trigger, it is event based and is not polymorphic.

    I was trying to redesign an implementation did for a game long ago
    in the implementation, the player class was the parent class and had a virtual contructor

    I made a virtual vector


  */





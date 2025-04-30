# Object Creation/Deletion and Time

By Ilya Vaschillo

Date: 4/8/25

[https://manyak404.github.io/ObjectCreation/](https://manyak404.github.io/ObjectCreation/)

# Creation

Manager object:

*   A singleton object with the purpose of managing background data and startup.
*   **Manager static reference** so manager is available to all objects, prefab, and script.
*   Helped with inter object communication.

Creating objects from prefabs with keystrokes:

*   Transfer rotational data from player arrow to egg.
*   It is important to send data to the manager.

Text:

*   Use UIDocument to display text in the top left corner. Easy to edit every frame.

# Deletion

*   Deletion is done on collision based on remaining health.
*   Use **kinematic** Rigidbody2D to avoid dynamic physics collision but also have collision between moving objects.
*   All interactable objects must have a Collider2D.

# Time

*   Track time as floats, 1f = 1s, and let Time.deltaTime manage the frame by frame seconds passing.

All in all, I learned a lot about using a manager singleton and collisions, while also resolving miscellaneous small bumps involving time and text. It took me around 4 hours to complete the program. The most challenging part was communicating the death of a plane enemy to the manager object, something resolved by using a static singleton reference.

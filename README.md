# Lab002-GameDesign-MarioImproved
Lab 002 for Game Design (Week 2)

Implemented Features:
- Bouncy [?] Box by learning the concepts of 2D Springs Joints, Coroutines
- One-way platforms where Mario can pass through from underneath but not from the top, using Effectors on Edge Collider 2D
- Camera Movement which follows Mario's location
- Mushroom Object that is spawned when Mario hits the bottom part of the ? Box, using the help of Impulse Force and moving it by creating a Vector2 whose current direction is indicated by -1 (left) or 1 (right). Mushrooms can collide with vertical obstacles like Pipes and slide across horizontal ones like bricks or the ground or the top of the pipes. Stops when colliding with Mario.
- Background element, using different Sorting Layers in the Sprite Renderer
- Animations for Idle, Running, Jumping, Skidding via Animator, Animator Controller, and Animation Clips

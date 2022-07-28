# Programming-Theory-Project

Third-person 3D survival real-time experience.

Player:
- HP bar.
- Move in the horizontal plane (arrow keys)
- Shoot projectiles (deal damage to enemies)
- Get damaged by enemies.

Enemies:
- Move towards the player.
- Touch the player (deal damage)
- Get damaged by the player.

Scenes:
- Main menu (title; high score text; name input; dificulty selector; start button; exit button)
- Game (HUD; mechanics; game over screen (restart button; back button)

Scenes flow:
- Main menu:
  Main menu -> Game (start button)
  Main menu -> Exit (exit button)
- Game:
  Game -> Game (restart button)
  Game -> Main menu (back button)

Game mechanics:
- Main menu:
  High score text displays the name of the player with the highest score (data persistance between sessions).
  Name input to register the name of the current user (maximum 3 characters).
  Dificulty selector allows the user setting up desired difficulty for the game (data persistance between scenes).

- Game:
  The difficulty affects both the maximum number and the type of spawned enemies.
  HUD: displays the name of current user, remaining health and earned score.
  Anytime a projectile triggers an enemy, damage is dealt to the enemy.
  Anytime an enemy triggers the player, damage is dealt to the player.
  Anytime an enemy collides and enemy, happens nothing.
  Each time an enemy is defeated another is spawned.
  The number of enemies in the scene remains always the same (the maximum allowed by the difficulty).
  The game ends when the user health gets zero.
  When game ends Game Over screen is shown.
  When game ends, if score is higher than best score, it is updated.
  
- OOP pilars implementation:
  Inheritance:
    Base (parent) enemy class.
    Child enemy clases: easy, medium, hard (movement speed, dealt damage, HP, etc.)
    Reuse properties as HP and movement speed.
    Reuse, if so, methods as, e.g., DealDamage.
    Define an abstract method as, e.g., DealDamage. The behaviour of this method may not be implemented in base class, but in child classes.
  Polymorphism:
    Override - Virtual
    Overrido - Abstract
  Encapsulation and Abstraction:
    Implemented along the entire project.
    
    
    
    
    
    
    

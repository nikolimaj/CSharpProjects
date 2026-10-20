# C# Game Projects – Sokoban, Battleship, and Memory

This repository contains game projects developed in C# as part of programming assignments. The projects demonstrate different approaches to software development using console applications, Windows Forms, and Windows Presentation Foundation (WPF).

## 🎮 Projects

### 1. Sokoban – C# Console Application

Sokoban is a puzzle game in which the player moves boxes onto designated target positions using a player character.

**Features and game rules:**
- Load game levels from external files.
- Control the player using the arrow keys.
- Boxes can only be pushed, never pulled.
- Only one box can be pushed at a time.
- Walls prevent the player from moving through blocked areas.
- Target positions are represented by `.`.
- Boxes placed on target positions are represented by `*`.
- The player standing on a target position is represented by `+`.
- Count the number of moves made during the game.
- Display the total number of moves when the game ends.
- Load additional levels and start new rounds without restarting the application.
- Exit the game at any time.

**Technologies:**
- C#
- .NET Console Application
- File handling
- Game logic and keyboard input processing

### 2. Battleship – C# Windows Forms

Battleship is a strategy game in which the player competes against the computer. The objective is to sink the entire opposing fleet before the opponent sinks yours.

**Game board and fleet:**

The game board consists of a 10 × 10 grid. Each player has the following fleet:

| Ship Type | Quantity | Size |
|---|---:|---:|
| Submarine | 4 | 1 cell |
| Destroyer | 3 | 2 cells |
| Cruiser | 2 | 3 cells |
| Battleship | 1 | 4 cells |

**Features and game rules:**
- Ships can be placed horizontally or vertically.
- Ship positions are validated before the game starts.
- Ships must not touch each other, including diagonally.
- Ships must be straight and cannot contain bends or protrusions.
- A successful hit allows the player to shoot again.
- A missed shot passes the turn to the computer.
- The opponent is notified when a ship has been completely sunk.
- The computer selects its initial targets randomly.
- After a hit, the computer intelligently searches for further hits.
- The computer remembers partially damaged ships across turns.
- The computer uses information about sunk ships and the game rules to eliminate impossible targets.
- New rounds can be started without restarting the application.
- The number of shots fired is counted.
- A persistent high-score table stores the five best game results.
- Players can register with their own names and change their names through a player management dialog.
- After defeating the computer, a player can qualify for the high-score table.

**Technologies:**
- C#
- Windows Forms
- Event-driven programming
- Randomized and state-based computer strategy
- File handling for persistent data storage

### 3. Memory – C# WPF

Memory is a card-matching game in which players try to find matching pairs of images. The game supports two different modes.

**Game modes:**
- Two human players compete against each other.
- One human player competes against the computer.

In single-player mode, the computer reveals random cards without using an intelligent strategy.

**Features and game rules:**
- The card deck contains at least ten different images.
- Cards are shuffled randomly at the beginning of every game.
- Players can set and change their names.
- The game keeps track of the current game state.
- The winner is displayed at the end of the game.
- Multiple rounds can be played without restarting the application.

**Technical requirements:**
- Build the user interface using Windows Presentation Foundation (WPF).
- Design the user interface primarily in XAML.
- Use data binding for WPF controls wherever possible.
- Follow the MVVM (Model–View–ViewModel) architectural pattern.
- Separate the user interface, data, and game logic.

**Technologies:**
- C#
- WPF
- XAML
- Data Binding
- MVVM
- Image and resource management



## 🚀 Installation and Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/YOUR-USERNAME/YOUR-REPOSITORY.git
   ```

2. Navigate to the directory of the project you want to run.

3. Open the corresponding `.sln` file in Visual Studio, if available.

4. Restore dependencies and build the project.

5. Run the desired game.



## 📚 Learning Objectives

These projects provide practical experience with the following programming concepts:

- Object-oriented programming in C#
- Console and desktop application development
- Event handling and user interaction
- Implementing and validating game rules
- File handling and persistent data storage
- State management and basic AI strategies
- Building graphical user interfaces with Windows Forms and WPF
- Using XAML, data binding, and MVVM

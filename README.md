# 🎄 Advent of Code 2025

![Language](https://img.shields.io/badge/language-C%23-blue)
![Status](https://img.shields.io/badge/status-Active-brightgreen)
![Progress](https://img.shields.io/badge/progress-10%2F12-yellow)

🔗 **Official Advent of Code Website:** [https://adventofcode.com/2025](https://adventofcode.com/2025)

> A curated collection of **C# solutions for Advent of Code 2025**, focused on clean code, algorithmic clarity, and real-world engineering practices.

## 📖 Introduction

This repository documents my journey through **Advent of Code 2025**, solving daily algorithmic challenges using C#.

Beyond simply producing correct answers, the goal is to demonstrate **engineering reasoning**, explicit trade-offs, and clean, maintainable solutions that could be understood and extended by other developers.

---

## 📑 Table of Contents

* [Introduction](#-introduction)
* [Motivation & Engineering Goals](#-motivation--engineering-goals)
* [Repository Structure](#-repository-structure)
* [Progress](#-progress)
* [Technologies Used](#-technologies-used)
* [How to Run Locally](#-how-to-run-locally)
* [Disclaimer](#-disclaimer)
* [Collaboration & Contact](#-collaboration--contact)
* [Acknowledgments](#-acknowledgments)

---

This repository contains my solutions for the **Advent of Code 2025** challenges, written with a strong emphasis on code readability, maintainability, and engineering best practices.

Advent of Code is an annual set of Christmas-themed programming puzzles released daily throughout December. Beyond being fun, it’s an excellent way to:

* Practice problem-solving under constraints
* Improve algorithmic thinking
* Explore language features in a real, incremental context
* Prepare for technical interviews (without the interview anxiety 😄)

---

## 🎯 Motivation & Engineering Goals

* **Consistency**: Solve both parts of the daily puzzle whenever possible until Christmas.
* **Code Quality**: Prioritize clean, readable, and maintainable C# code.
* **Learning**: Explore algorithms, data structures, and the .NET ecosystem in depth.

This is a **learning-first and engineering-oriented** repository. Optimization is welcome, but clarity, correctness, and intent always come first.

---

## 📂 Repository Structure

The repository is organized by **day**, following the Advent of Code calendar.

Each folder contains:

* One or more C# solution files
* The input file used for that specific puzzle

### Naming Conventions

* **`dayXX/`**: Folder for the corresponding day (e.g., `day01`, `day09`)
* **`challengeX_versaoY.cs`**: C# solution files (multiple versions may exist for experimentation or optimization)
* **`comandosX.txt`**: Puzzle input file (user-specific)

### Example Structure

```text
Advent-of-Code-2025
├── day01
│   ├── challenge1.cs
│   └── comandos1.txt
├── day02
│   ├── challenge2_versao1.cs
│   ├── challenge2_versao2.cs
│   └── comandos2_versao1.txt
├── ...
└── README.md
```

---

## 🚀 Progress

| Day | Puzzle              | Description                                                | Topics                           | Part 1 | Part 2 |                             Links                             |
| --: | ------------------- | ---------------------------------------------------------- | -------------------------------- | :----: | :----: | :-----------------------------------------------------------: |
|  01 | The Safe            | Simulating a dial lock rotation to find the combination    | `#Simulation` `#Modulo`          |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/1) · [Code](./day01) |
|  02 | Gift Shop           | Identifying invalid product IDs within specific ranges     | `#Ranges` `#Parsing`             |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/2) · [Code](./day02) |
|  03 | Lobby               | Optimizing battery joltage output from banks               | `#Greedy` `#Optimization`        |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/3) · [Code](./day03) |
|  04 | Printing Department | Determining accessible paper rolls for forklifts in a grid | `#Grid` `#GraphTraversal`        |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/4) · [Code](./day04) |
|  05 | Cafeteria           | Checking ingredient freshness against valid ID ranges      | `#Intervals` `#Filtering`        |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/5) · [Code](./day05) |
|  06 | Trash Compactor     | Solving math problems with unusual vertical formatting     | `#Parsing` `#Math`               |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/6) · [Code](./day06) |
|  07 | Laboratories        | Simulating particle beams hitting splitters                | `#Simulation` `#Recursion`       |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/7) · [Code](./day07) |
|  08 | Playground          | Connecting electrical junction boxes with minimal wire     | `#Geometry` `#Distance`          |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/8) · [Code](./day08) |
|  09 | Movie Theater       | Finding the largest rectangle of red tiles on a floor      | `#Geometry` `#Search`            |    ⭐   |    ⭐   |  [AoC](https://adventofcode.com/2025/day/9) · [Code](./day09) |
|  10 | Factory             | Configuring machine lights by pressing buttons             | `#LinearAlgebra` `#Optimization` |    ⬜   |    ⬜   | [AoC](https://adventofcode.com/2025/day/10) · Code            |
|  11 | Reactor             | Finding paths in a network of devices                      | `#Graphs` `#Pathfinding`         |    ⭐   |    ⭐   | [AoC](https://adventofcode.com/2025/day/11) · [Code](./day11) |
|  12 | Christmas Tree Farm | Packing present shapes into specific grid regions          | `#Backtracking` `#2DGrid`        |    ⬜   |    ⬜   | [AoC](https://adventofcode.com/2025/day/12) · Code            |

**Legend:** ⭐ Completed   |   ⬜ Pending

---

## 🛠️ Technologies Used

* **Language**: C# (.NET)
* **Environment**: Visual Studio / VS Code
* **Core Concepts**:

  * Algorithms & Data Structures
  * File I/O
  * LINQ
  * Recursion & Backtracking
  * Geometry & Graph Traversal

---

## 💻 How to Run Locally

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/) installed

### Clone the Repository

```bash
git clone https://github.com/AmandaFernandes0701/Advent-of-Code-2025.git
cd Advent-of-Code-2025
```

### Navigate to a Specific Day

```bash
cd day01
```

### Run a Solution

Depending on your setup:

**Using `dotnet` (if a project file exists):**

```bash
dotnet run
```

**Running a single C# file directly:**

```bash
dotnet run challenge1.cs
```

**Manual compilation:**

```bash
csc challenge1.cs
./challenge1
```

---

## ⚠️ Disclaimer

* **Inputs**: Advent of Code inputs are unique per user. The `comandosX.txt` files in this repository are specific to my account.
* **Spoilers**: If you’re currently participating, I strongly recommend solving the puzzles yourself before checking any solutions.

---

## 🤝 Collaboration & Contact

This is a personal learning project, but **engineering feedback, alternative approaches, and performance optimizations** are always welcome.

* **Author**: Amanda Fernandes
* **GitHub**: [@AmandaFernandes0701](https://github.com/AmandaFernandes0701)

Feel free to open an issue if you want to discuss a solution or suggest improvements.

---

## 🙏 Acknowledgments

* **Eric Wastl**, for creating and maintaining Advent of Code
* The **AoC community**, for the hints, discussions, and excellent memes

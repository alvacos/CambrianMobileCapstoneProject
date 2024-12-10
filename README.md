# Finance Tracker App

## Table of Contents
1. [Project Scope](#project-scope)
2. [Features and Functionality](#features-and-functionality)
3. [Technical Specifications](#technical-specifications)
4. [User Stories](#user-stories)
5. [Wireframes](#wireframes)
6. [Version Control and Documentation](#version-control-and-documentation)

---

## Project Scope

### Objective
To develop a platform finance tracking application for personal budgeting, providing users with tools to track expenses, categorize spending, and generate financial insights.

### In-Scope Features
- Expense management: Add, edit, delete expenses.
- User-friendly interface: Intuitive navigation and interactive elements.
- Cross-platform compatibility: Android, iOS, Windows, macOS.

### Out-of-Scope Features
- Multi-user or collaborative functionalities.
- Integration with external financial systems (e.g., bank accounts).
- Multi-currency support.

---

## Features and Functionality

### Core Features
1. *Expense Management*
   - Add expense with name, category, amount, and date.
   - Edit and delete expenses from the database.

2. *UI/UX Features*
   - Responsive layout for both mobile and desktop platforms.
   - Real-time updates for expense lists and analytics.

---

## Technical Specifications

### Frameworks and Tools
- **Development Framework:** .NET MAUI
- **Programming Language:** C#
- **Database:** SQLite
- **Development Environment:** Visual Studio 2022
- **Target Platforms:** Android, iOS, Windows, macOS

### Libraries
- `sqlite-net-pcl` (version 1.9.172): SQLite database ORM for easier data manipulation.
- `SQLitePCLRaw.bundle_green` (version 2.1.10): SQLite low-level implementation bundle.
- `CommunityToolkit.Mvvm` (version 8.0.0): Simplifies MVVM implementation with helpers for data binding and commands.

---

## User Stories

### As a User:
1. **Expense Management**
   - I want to add a new expense by entering the name, category, amount, and date.
   - I want to edit existing expense details to correct errors or update information.
   - I want to delete unnecessary or duplicate expenses.

2. **Navigation and UI**
   - I want to have an intuitive interface to navigate between expense management and analytics.

---

## Wireframes

### Overview
1. **Main Page**
   - Expense List View:
     - Displays a list of recorded expenses with fields: name, category, amount, and date.
     - Button for Add
     - swiping directly left or right for Edit, and Delete actions.

2. **Expense Entry/Editing Page**
   - Input fields for name, category (dropdown), amount, and date picker.

*(Optional: Attach wireframe images here or provide links to external design tools like [Figma](https://www.figma.com) or [draw.io](https://app.diagrams.net).)*

---

## Version Control and Documentation

### Repository Structure

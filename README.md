Task Manager CLI
================

Overview
--------

The Task Manager CLI is a console-based application designed to help users manage their tasks efficiently. It allows for creating, viewing, editing, and deleting tasks, with added features for task prioritization and deadline management. The application also supports saving and loading tasks from a file for persistence.

Features
--------

-   **Create Tasks:** Add new tasks with a title, description, priority, and deadline.
-   **View Tasks:** Display tasks with options to sort by priority or deadline.
-   **Edit Tasks:** Modify existing task details.
-   **Delete Tasks:** Remove tasks from the list.
-   **File Persistence:** Save tasks to a file and load them on startup.
-   **Prioritization and Deadlines:** Assign priorities and set deadlines for tasks.

Usage
-----

### Initial Setup

1.  Clone the repository:

    ```bash
    git clone https://github.com/yourusername/task-manager-cli.git
    ```

2.  Navigate to the project directory:

    ```bash
    cd task-manager-cli
    ```

3.  Compile and run the application:
   
    ```bash
    dotnet run
    ```

### Main Menu

Upon starting the application, you will be greeted with the main menu:

1.  Create a new task
2.  View all tasks
3.  Edit a task
4.  Delete a task
5.  Exit

### Task Creation

Follow the prompts to enter the task title, description, priority, and deadline. Once a task is created, it will be added to the list and can be managed from the main menu.

### Viewing Tasks

Choose how you want to view tasks:

1.  View all tasks
2.  View tasks by priority (coming soon)
3.  View tasks by deadline (coming soon)

### Editing Tasks

Select the task you want to edit by entering its ID, then choose which detail to modify (title, description, priority, or deadline).

### Deleting Tasks

Select the task you want to delete by entering its ID. Confirm the deletion to remove the task from the list.

### File Persistence

-   **Save Tasks:** Save the current list of tasks to a file.
-   **Load Tasks:** Load tasks from a previously saved file.

Future Enhancements
-------------------

-   Implement advanced filtering options.
-   Improve the user interface for better interaction.
-   Add unit and integration testing.

Contributing
------------

Contributions are welcome! Please fork the repository and create a pull request with your changes.

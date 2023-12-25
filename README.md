## Overview
For this project, I decided to create a simple not taking application using a WinForms GUI coded in C#. 
It features a DataGridView and textboxes for effective note management, complemented by clear buttons facilitating actions such as adding, updating, and deleting notes.

A DataTable with "Title" and "Messages" columns structure and organize the notes. 
This DataTable interfaces with the DataGridView, providing users with a smooth and efficient means of interacting with their notes.

The "Add note" button lets the user create new note entries, prompting users to input both a title and a message for each note. 

The "Update note" button allows modifications to existing notes while the "Delete note" button removes selected notes from the dataset. 

The "Clear" button resets the input fields, providing users with a way to start fresh.

For data persistence, I implemented XML serialization to save notes to a file named "notes.xml." Upon loading a note, the deserialization process reconstructs the DataTable, restoring previously saved notes.
In terms of user feedback, the application incorporates MessageBox notifications to provide guidance and alerts, particularly during actions such as attempting to add notes without specifying a title or message.

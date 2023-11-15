# EaterShell

## What is EaterShell?
The EaterShell is a shell similar to the Windows Command Prompt. It has similar commands, but uses a custom file system. The file system is stored in a JSON file. By default, the JSON file contains a virtual drive and root directory. The content of the JSON file is deserialized to a Drive object in the program which contains all file system items in a list. The navigation through the directories just works with changing the current selected directory object which is in the root directory. The drive represents a tree-like structure with directories and subdirectories. 

## Commands & Description
- cd: Changes Directory. Allows absolute and relative paths
- cls: Clears screen
- color: Used like: `color red blue`, where the foreground is red and background blue. `color . blue` to keep the foreground and just change background
- del: Deletes Files. Allows absolute and relative paths
- dir: List items in the current directory.
- drive: Displays drive information.
- erase: Erases the data in the file system and resets it.
- exit: Exits the application.
- mkdir: Creates a directory. Allows absolute and relative paths
- more: Lists the contents of a file, but uses only the height of the terminal and more text can be loaded by clicking space.
- move: Moves a file or dir from one path to another. Allows absolute and relative paths
- print: Prints content to the console: `print "hello, world!"`
- ren: Renames a file or directory. Allows absolute and relative paths
- touch: Creates a file. Structure: `touch filename.txt "This is the file content"`. File content currently can''t be edited.
- type: Lists the contents of a file.
- ver: Shows the used windows version.

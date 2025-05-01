# DataStructures

## Overview

This project is a collection of generic data structure implementations in C#. It provides reusable and efficient classes for common data structures, including a Circular Linked List, Circular Queue, Generic List, and Doubly Linked List. Each implementation is designed to be flexible, supporting generic types, and includes essential operations like insertion, deletion, and traversal.

The project is built using C# and can be used as a library or learning resource for understanding data structures in a .NET environment.

---

## Features

- **Circular Linked List (`CirclinkedList.cs`)**  
  A singly linked list where the last node points back to the head, forming a cycle.  
  Supports insertion (first, last, after a node), deletion (first, last, specific data), and traversal.

- **Circular Queue (`CircularQueue.cs`)**  
  A fixed-size queue that uses an array with circular indexing to reuse space efficiently.  
  Includes enqueue, dequeue, peek, and print operations.

- **Generic List (`clsGenericList.cs`)**  
  A dynamic array-based list supporting generic types.  
  Features include adding, removing, inserting, and searching elements, with automatic resizing.

- **Doubly Linked List (`DoublyLinkedList.cs`)**  
  A linked list where each node has a reference to both the next and previous nodes.  
  Supports adding (first, last), removing (first, last), and displaying the list from both ends.

---

## Project Structure

- `CirclinkedList.cs`: Implementation of a Circular Linked List with a `CirNode<T>` class for nodes.
- `CircularQueue.cs`: Implementation of a Circular Queue using an array.
- `clsGenericList.cs`: Implementation of a Generic List with dynamic resizing.
- `DoublyLinkedList.cs`: Implementation of a Doubly Linked List with a `Node<T>` class for nodes.
- `Ds.sln`: Visual Studio solution file for the project.

---

## Usage

### Clone the Repository

```bash
git clone https://github.com/Hanafy75/DataStructures.git
### Open in Visual Studio

1. Open `Ds.sln` in Visual Studio.
2. Build the solution to ensure all dependencies are resolved.

---

### Integrate into Your Project

1. Copy the desired `.cs` file into your project.
2. Use the classes as needed. For example:

```csharp
var list = new CircLinkedList<int>();
list.InsertFirst(1);
list.InsertLast(2);
list.DisplayList();
---

### Run and Test

- Create a test program to instantiate and manipulate the data structures.
- Use the built-in methods to perform operations like insertion, deletion, and traversal.

---

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and test thoroughly.
4. Submit a pull request with a clear description of your changes.

using System.Collections;

public class CircLinkedList<T> : IEnumerable<T>
{
  public CirNode<T>? Head { get; set; }
  public int Count { get; private set; }

  public CirNode<T>? Tail { get; set; }
  public void InsertFirst(T data)
  {
    // Create a new node
    CirNode<T> newNode = new CirNode<T>();
    // put the data in the node
    newNode.Data = data;
    // check if the list is empty
    if (Count == 0)
    {
      Head = newNode;
      Tail = newNode;
      newNode.Next = Head; // Point to itself
      Count++;
      return;
    }
    //put the old head in the next field of the new node
    newNode.Next = Head;
    // make the Head the new node
    Head = newNode;
    Tail!.Next = Head;
    Count++;
  }

  public void InsertLast(T data)
  {
    // Create a new node
    CirNode<T> newNode = new CirNode<T>();
    // put the data in the node
    newNode.Data = data;
    // check if the list is empty
    if (Count == 0)
    {
      Head = newNode;
      Tail = newNode;
      newNode.Next = Head; // Point to itself
      Count++;
      return;
    }

    Tail!.Next = newNode;
    newNode.Next = Head;
    Tail = newNode;
    Count++;
  }

  public void InsertAfter(T existingData, T NewData)
  {
    if (Count == 0)
      return;

    CirNode<T> newNode = new CirNode<T> { Data = NewData };
    CirNode<T> current = Head!;
    do
    {
      if (EqualityComparer<T>.Default.Equals(current.Data!, existingData))
      {
        // Insert the new node
        newNode.Next = current.Next;
        current.Next = newNode;

        // Update Tail if needed
        if (ReferenceEquals(current, Tail))
        {
          Tail = newNode;
        }

        Count++;
        return;
      }

      current = current.Next!;
    } while (current != Head);
    throw new ArgumentException("The specified existingData was not found in the list.");
  }

  public void DeleteFirst()
  {
    if (Count == 0)
      return;

    Head = Head!.Next;
    Tail!.Next = Head;
    Count--;
  }

  public void DeleteLast()
  {
    if (Count == 0)
      return;
    // check if the list has only one node
    if (Count == 1)
    {
      Head = null;
      Tail = null;
      Count--;
      return;
    }

    CirNode<T> Current = Head!;
    // find the second last node
    while (Current!.Next != Tail)
    {
      Current = Current.Next!;
    }
    // delete the last node
    Current.Next = Head;
    Tail = Current;
    Count--;
  }

  public void Delete(T data)
  {
    if (Count == 0) return;
    if (EqualityComparer<T>.Default.Equals(Head!.Data!, data))
    {
      Head = Head.Next;
      Tail = Head;
      Count--;
      return;
    }

    CirNode<T> Current = Head;
    while (Current.Next != Head && (!(EqualityComparer<T>.Default.Equals(Current.Next!.Data, data))))
    {
      Current = Current.Next;
    }
    if (Current.Next == Head) return;
    if (Current.Next == Tail)
    {
      Current.Next = Head;
      Tail = Current;
      Count--;
      return;
    }
    Current.Next = Current.Next.Next;
    Count--;
  }

  /*public bool Contains(T data)
  {
    if (Count == 0)
      return false;
      if (EqualityComparer<T>.Default.Equals(Head!.Data!, data)) return true;

    CirNode<T>? Current = Head;
    while (Current != null && Current != Tail)
    {
      if (EqualityComparer<T>.Default.Equals( Current.Next!.Data,data))
      {
        return true;
      }
      Current = Current.Next;
    }
    return false;
  }*/

  public bool Contains(T data)
  {
    if (Count == 0)
      return false;

    CirNode<T>? current = Head;

    do
    {
      if (EqualityComparer<T>.Default.Equals(current!.Data, data))
        return true;

      current = current.Next;
    }
    while (current != Head); // Loop until we return to the start of the list

    return false;
  }


  public void DisplayList()
  {
    if (Count == 0) return;
    CirNode<T> Current = Head!;
    do
    {
      Current.DisplayNode();
      Current = Current.Next!;
    } while (Current != Head);
    Console.WriteLine("========================");
  }

  public IEnumerator<T> GetEnumerator()
  {
    if (Count == 0) yield break;
    CirNode<T>? Current = Head;
    do
    {
      yield return Current!.Data!;
      Current = Current.Next;
    } while (Current != Head);
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}



public class CirNode<T>
{
  public T? Data { get; set; }
  public CirNode<T>? Next { get; set; }

  public void DisplayNode()
  {
    Console.WriteLine(Data);
  }


}
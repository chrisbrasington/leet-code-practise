using System;
using System.Collections.Generic;

public class Trie
{
   public TrieNode root;
   public Trie()
   {
      root = new TrieNode();
   }


   /// <summary>
   /// insert - will not duplicate existing nodes
   /// </summary>
   /// <param name="input"></param>
   public void Insert(string input)
   {
      TrieNode currentNode = root;

      foreach (char i in input)
      {
         // insert node will also traverse current node
         currentNode = currentNode.Insert(i);
      }

      // I'm opting to store a flag that this node represents a complete prefix
      currentNode.End = true;
   }

   public string Search(string input)
   {
      string result = "";

      // maintain a stack of traversed nodes
      Stack<TrieNode> foundNodes = new Stack<TrieNode>();

      TrieNode currentNode = root;

      // for each character in a given input string
      foreach (char i in input)
      {
         // if not found at current traversal, stop search
         if (!currentNode.Contains(i, out currentNode))
         {
            break;
         }
         // found, 
         foundNodes.Push(currentNode);
      }

      // because only the trie knows the termination of prefix strings
      //   we may have traversed a substring.
      // for example with given prefix '12' and '1234' and a input of '1234'
      //   we have a tree representation of 1-2(end)-3-4(end)
      //   we will have traverse to 1-2-3 and need to back-up to an ending node
      // remove any trailing non-terminating nodes (End is false)
      while (foundNodes.Count > 0 && !foundNodes.Peek().End)
      {
         foundNodes.Pop();
      }

      // concat value
      while (foundNodes.Count > 0)
      {
         currentNode = foundNodes.Pop();
         result = currentNode.Value + result;
      }

      return result;
   }
}

public class TrieNode
{
   /// <summary>
   /// character value
   /// </summary>
   public char? Value;

   /// <summary>
   /// signifies the end of a prefix string
   /// </summary>
   public bool End;

   /// <summary>
   /// child nodes for traversal
   /// </summary>
   public List<TrieNode> Children;

   public TrieNode()
   {
      End = false;
   }
   public TrieNode(char x)
   {
      Value = x;
      End = false;
   }

   /// <summary>
   /// see if node contains the value of x
   /// </summary>
   /// <param name="x"></param>
   /// <param name="foundNode"></param>
   /// <returns></returns>
   public bool Contains(char x, out TrieNode foundNode)
   {
      if (Children != null)
      {
         foreach (TrieNode node in Children)
         {
            // found node
            if (node.Value == x)
            {
               foundNode = node;
               return true;
            }
         }
      }

      // not found node
      foundNode = null;
      return false;
   }

   /// <summary>
   /// insert char node, do not create duplicates
   /// return node
   /// </summary>
   /// <param name="x"></param>
   /// <returns></returns>
   public TrieNode Insert(char x)
   {
      TrieNode foundNode;

      // already in tree, return
      if (Contains(x, out foundNode))
      {
         return foundNode;
      }

      // insert and return
      if (Children == null)
      {
         Children = new List<TrieNode>();
      }
      Children.Add(new TrieNode(x));
      return Children[Children.Count - 1];
   }
}
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        class Action
        {
            public string Name;
            public int Value;
        }

        #region Lecture

        public void LCT01_StackSyntax()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1); // 3
            stack.Push(2); // 2
            stack.Push(3); // 1
            Debug.Log($"Count: {stack.Count}");

            var popped = stack.Pop();
            Debug.Log($"Popped: {popped}");
            // Debug.Log($"Count: {stack.Count}");
            var top = stack.Peek();
            Debug.Log($"Peek: {top}");
            Debug.Log($"Count after peek: {stack.Count}");

            stack.Clear();
            // Clear
            // Debug.Log($"Count after Clear: {stack.Count}");
        }

        public void LCT02_QueueSyntax()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            // 1, 2, 3
            Debug.Log($"Count: {queue.Count}");
            var dequeue = queue.Dequeue();
            Debug.Log($"Dequeue: {dequeue}");
            
            var front = queue.Peek();
            Debug.Log($"Peek: {front}");
            Debug.Log($"Count after dequeue: {queue.Count}");

            queue.Clear();
        }

        public void LCT03_ActionStack()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            Stack<Action> actionStack = new Stack<Action>();
            actionStack.Push(action1);
            actionStack.Push(action2);
            actionStack.Push(action3);

            while (actionStack.Count > 0)
            {
                var action = actionStack.Pop();
                Debug.Log($"Executing {action.Name}");
            }
        }

        public void LCT04_ActionQueue()
        {
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            Queue<Action> actionQueue = new Queue<Action>();
            actionQueue.Enqueue(action1);
            actionQueue.Enqueue(action2);
            actionQueue.Enqueue(action3);

            while(actionQueue.Count > 0)
            {
                var action = actionQueue.Dequeue();
                Debug.Log($"Executing {action.Name}");
            }

        }

        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
            Stack<char> charStack = new Stack<char>();
            
            foreach (char c in str)
            {
                charStack.Push(c);
            }
            
            StringBuilder reversedString = new StringBuilder();
            
            while (charStack.Count > 0)
            {
                char c = charStack.Pop();
                reversedString.Append(c);
            }
            
            Debug.Log(reversedString.ToString());
        }

        public void ASN02_StackPalindrome(string str)
        {
            Stack<char> charStack = new Stack<char>();

            foreach (char c in str)
            {
                charStack.Push(c);
            }

            StringBuilder reversedStringBuilder = new StringBuilder();

            while (charStack.Count > 0)
            {
                reversedStringBuilder.Append(charStack.Pop());
            }

            string reversedString = reversedStringBuilder.ToString();

            if (str.Equals(reversedString))
            {
                Debug.Log("is a palindrome");
            }
            else
            {
                Debug.Log("is not a palindrome");
            }
        }

        #endregion

        #region Extra

        public void EX01_ParenthesesChecker(string str)
        {
            Stack<char> bracketStack = new Stack<char>();

            foreach (char c in str)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    bracketStack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (bracketStack.Count == 0)
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }

                    char top = bracketStack.Pop();

                    if (c == ')' && top != '(')
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                    else if (c == ']' && top != '[')
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                    else if (c == '}' && top != '{')
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }
                }
            }

            if (bracketStack.Count == 0)
            {
                Debug.Log("Balanced");
            }
            else
            {
                Debug.Log("Unbalanced");
            }
        }

        #endregion
    }
}

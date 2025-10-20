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
            // สร้าง Stack ของ int
            Stack<int> stack = new Stack<int>();
            
            // Push 1, 2, 3 เข้า stack (3 จะอยู่บนสุด)
            stack.Push(1); // 3
            stack.Push(2); // 2
            stack.Push(3); // 1
            
            // แสดงจำนวนข้อมูลใน Stack
            Debug.Log($"Count: {stack.Count}"); // Count: 3

            // Pop ข้อมูลออกจาก Stack (ลบข้อมูลบนสุด) และเก็บค่าไว้
            var popped = stack.Pop(); // เอา 3 ออก
            Debug.Log($"Popped: {popped}"); // Popped: 3
            
            // Debug.Log($"Count: {stack.Count}");
            
            // Peek ดู ข้อมูลบนสุดโดยไม่ลบ
            var top = stack.Peek(); // ตอนนี้บนสุดคือ 2
            Debug.Log($"Peek: {top}"); // Peek: 2
            
            // จำนวนข้อมูลหลัง Peek จะไม่ลดลง
            Debug.Log($"Count after peek: {stack.Count}"); // Count after peek: 2

            
            // ล้าง Stack ทั้งหมด
            stack.Clear();
            // Debug.Log($"Count after Clear: {stack.Count}"); // Count after Clear: 0
        }

        public void LCT02_QueueSyntax()
        {
            // สร้าง Queue ของ int
            Queue<int> queue = new Queue<int>();
            
            // Enqueue ข้อมูลเข้า Queue ตามลำดับ
            queue.Enqueue(1); // Queue: [1]
            queue.Enqueue(2); // Queue: [1, 2]
            queue.Enqueue(3); // Queue: [1, 2, 3]
            
            // แสดงจำนวนข้อมูลใน Queue
            Debug.Log($"Count: {queue.Count}"); // Count: 3
            
            // Dequeue ข้อมูลออกจาก Queue (เอาข้อมูลหน้าออก)
            var dequeue = queue.Dequeue(); // เอา 1 ออก
            Debug.Log($"Dequeue: {dequeue}"); // Dequeue: 1
            
            // Peek ข้อมูลหน้าโดยไม่ลบ
            var front = queue.Peek(); // ตอนนี้หน้า Queue คือ 2
            Debug.Log($"Peek: {front}"); // Peek: 2
            
            // แสดงจำนวนข้อมูลหลัง Dequeue
            Debug.Log($"Count after dequeue: {queue.Count}"); // Count after dequeue: 2

            // ล้าง Queue ทั้งหมด
            queue.Clear();
            // Debug.Log($"Count after Clear: {queue.Count}"); // Count after Clear: 0
        }

        public void LCT03_ActionStack()
        {
            // สร้างคลาส Action และกำหนดชื่อ Action
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            // สร้าง Stack ของ Action
            Stack<Action> actionStack = new Stack<Action>();
            
            // Push actions เข้า Stack ตามลำดับ
            actionStack.Push(action1); // Stack: [Action 1]
            actionStack.Push(action2); // Stack: [Action 1, Action 2]
            actionStack.Push(action3); // Stack: [Action 1, Action 2, Action 3]

            // Pop และ execute action จน Stack ว่าง
            while (actionStack.Count > 0)
            {
                var action = actionStack.Pop(); // ดึง action ล่าสุดออก (LIFO)
                Debug.Log($"Executing {action.Name}"); // แสดงผลการ execute
            }
        }

        public void LCT04_ActionQueue()
        {
            // สร้างคลาส Action และกำหนดชื่อ Action
            Action action1 = new Action { Name = "Action 1" };
            Action action2 = new Action { Name = "Action 2" };
            Action action3 = new Action { Name = "Action 3" };
            
            // สร้าง Queue ของ Action
            Queue<Action> actionQueue = new Queue<Action>();
            
            // Enqueue actions เข้า Queue ตามลำดับ
            actionQueue.Enqueue(action1); // Queue: [Action 1]
            actionQueue.Enqueue(action2); // Queue: [Action 1, Action 2]
            actionQueue.Enqueue(action3); // Queue: [Action 1, Action 2, Action 3]

            // Dequeue และ execute action จน Queue ว่าง
            while(actionQueue.Count > 0)
            {
                var action = actionQueue.Dequeue(); // ดึง action หน้า Queue ออก (FIFO)
                Debug.Log($"Executing {action.Name}"); // แสดงผลการ execute
            }
        }

        #endregion

        #region Assignment

        public void ASN01_ReverseString(string str)
        {
            // สร้าง Stack ของตัวอักษร
            Stack<char> charStack = new Stack<char>();
            
            // Push แต่ละตัวอักษรของ str เข้า Stack
            foreach (char c in str)
            {
                charStack.Push(c); // ตัวอักษรตัวแรกจะอยู่ล่างสุด ตัวสุดท้ายอยู่บนสุด
            }
            
            // สร้าง StringBuilder สำหรับเก็บ string ที่ reverse
            StringBuilder reversedString = new StringBuilder();
            
            // Pop ตัวอักษรออกจาก Stack แล้ว append เข้า reversedString
            while (charStack.Count > 0)
            {
                char c = charStack.Pop(); // ดึงตัวอักษรบนสุดออก
                reversedString.Append(c); // ต่อเข้ากับ string ใหม่
            }
            // แสดงผล string ที่ถูก reverse
            Debug.Log(reversedString.ToString());
        }

        public void ASN02_StackPalindrome(string str)
        {
            // สร้าง Stack ของตัวอักษร
            Stack<char> charStack = new Stack<char>();

            // Push ตัวอักษรทั้งหมดของ str เข้า Stack
            foreach (char c in str)
            {
                charStack.Push(c); // ตัวอักษรตัวแรกอยู่ล่างสุด ตัวสุดท้ายอยู่บนสุด
            }

            // สร้าง StringBuilder สำหรับเก็บ string ที่ reverse
            StringBuilder reversedStringBuilder = new StringBuilder();

            // Pop ตัวอักษรออกจาก Stack แล้ว append เข้า reversedStringBuilder
            while (charStack.Count > 0)
            {
                reversedStringBuilder.Append(charStack.Pop());
            }

            // แปลง StringBuilder เป็น string
            string reversedString = reversedStringBuilder.ToString();

            // ตรวจสอบว่า string ตรงกับ reversed string หรือไม่
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
            // แบบใช้ Dictionary สำหรับจับคู่ opening–closing
            // สร้าง Stack สำหรับเก็บ opening brackets
            Stack<char> bracketStack = new Stack<char>();
            
            // สร้าง Dictionary สำหรับจับคู่ closing bracket กับ opening bracket ของมัน
            // key = closing bracket, value = opening bracket
            Dictionary<char, char> brackets = new Dictionary<char, char>
            {
                {')', '('},
                {']', '['},
                {'}', '{'}
            };

            // วนลูปตรวจสอบแต่ละตัวอักษรใน string ที่รับเข้ามา
            foreach (char c in str)
            {
                // ถ้าเจอ opening bracket (คือค่าหนึ่งใน dictionary values) ให้ push เข้า stack
                if (brackets.ContainsValue(c))
                {
                    bracketStack.Push(c); // Push opening bracket
                }
                // ถ้าเจอ closing bracket (คือ key ใน dictionary)
                else if (brackets.ContainsKey(c))
                {
                    // ตรวจสอบว่า stack ว่างหรือไม่ และตัวบนสุดของ stack ตรงกับ opening bracket ของ closing bracket หรือไม่
                    if (bracketStack.Count == 0 || bracketStack.Pop() != brackets[c])
                    {
                        // ถ้าไม่ตรง หรือ stack ว่าง แสดงว่า Unbalanced แล้ว return ออกจากฟังก์ชัน
                        Debug.Log("Unbalanced");
                        return;
                    }
                }
                // ถ้าเป็นตัวอักษรอื่นๆจะถูกข้ามไป (เช่น ตัวอักษร ตัวเลข หรือ text)
            }
            // หลังจากวนลูปตรวจสอบครบแล้ว
            // ถ้า Stack ว่าง แสดงว่า opening ทุกตัวมี closing ตรงกัน → Balanced
            // ถ้า Stack ยังมีตัวเหลือ แสดงว่ามี opening bracket ที่ยังไม่ได้จับคู่ → Unbalanced
            Debug.Log(bracketStack.Count == 0 ? "Balanced" : "Unbalanced");
            
            /* // แบบอ่านเข้าใจง่าย แต่ verbose เพราะมี if-else ซ้อนหลายชั้นสำหรับตรวจสอบ closing bracket แต่ละชนิด
            // สร้าง Stack สำหรับเก็บ opening brackets
            Stack<char> bracketStack = new Stack<char>();

            // วนลูปตรวจสอบแต่ละตัวอักษรใน string ที่รับเข้ามา
            foreach (char c in str)
            {
                // ถ้าเป็น opening bracket ( [ {
                if (c == '(' || c == '[' || c == '{')
                {
                    // Push เข้า Stack เพื่อรอการจับคู่กับ closing bracket
                    bracketStack.Push(c);
                }
                // ถ้าเป็น closing bracket ) ] }
                else if (c == ')' || c == ']' || c == '}')
                {
                    // ถ้า Stack ว่าง แสดงว่ามี closing bracket เกินมา → ไม่สมดุล
                    if (bracketStack.Count == 0)
                    {
                        Debug.Log("Unbalanced");
                        return;
                    }

                    // Pop ตัวบนสุดออกมา (ตัว opening bracket ที่ใกล้ที่สุด)
                    char top = bracketStack.Pop();

                    // ตรวจสอบว่า closing bracket ตรงกับ opening bracket หรือไม่
                    if (c == ')' && top != '(')
                    {
                        Debug.Log("Unbalanced"); // ไม่ตรงกัน → Unbalanced
                        return;
                    }
                    else if (c == ']' && top != '[')
                    {
                        Debug.Log("Unbalanced"); // ไม่ตรงกัน → Unbalanced
                        return;
                    }
                    else if (c == '}' && top != '{')
                    {
                        Debug.Log("Unbalanced"); // ไม่ตรงกัน → Unbalanced
                        return;
                    }
                }
                // ถ้าเป็นตัวอักษรอื่นๆจะถูกข้ามไป (เช่น ตัวอักษร ตัวเลข หรือ text)
            }

            // หลังจากวนลูปตรวจสอบครบแล้ว
            // ถ้า Stack ว่าง แสดงว่า opening ทุกตัวมี closing ตรงกัน → Balanced
            if (bracketStack.Count == 0)
            {
                Debug.Log("Balanced");
            }
            else
            {
                // ถ้า Stack ยังมีตัวเหลือ แสดงว่ามี opening bracket ที่ยังไม่ได้จับคู่ → Unbalanced
                Debug.Log("Unbalanced");
            }*/
        }

        #endregion
    }
}

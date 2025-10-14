using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Solution
{
    public class ActionHistoryManager : MonoBehaviour
    {
        // 1. Undo System using Stack
        private Stack<Vector2> undoStack = new Stack<Vector2>();
        Stack<Vector2> redoStack = new Stack<Vector2>();

        // 2. Auto-Move System using Queue
        private Queue<Vector2> autoMoveQueue = new Queue<Vector2>();


        #region "This Is undoStack Function"

        /// Saves the current player state (position) to the undo stack.
        public void SaveStateForUndo(Vector2 currentPosition)
        {
            // Only push a state if it's different from the last saved state 
            // (optional optimization, but good practice for movement)
            if (undoStack.Count == 0 || !undoStack.Peek().Equals(currentPosition))
            {
                undoStack.Push(currentPosition);
                if (redoStack.Count > 0)
                {
                    redoStack.Clear();
                    Debug.Log("Redo stack clear");
                }
            }
        
        }
        /// Reverts the player's state to the previous one using the undo stack.
        /// </summary>
        public void UndoLastMove(OOPPlayer player)
        {
            // Need at least two states: the current one, and the one to revert to.
           if (undoStack.Count > 1)
           {
                Vector2 currentPosition = undoStack.Pop();
                
                redoStack.Push(currentPosition);
                
                Vector2 previousPosition = undoStack.Peek();

                transform.position = previousPosition;
                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;
                player.UpdatePosition(toX, toY);
                Debug.Log($"Undo successful Reverted to Position " + $"{previousPosition}");
           }
           else
           {
                Debug.Log("Cannot undo: No states save");
           }
        }

        public void RedoLastMove(OOPPlayer player)
        {
            if (redoStack.Count > 0)
            {
                Vector2 currentRedo = redoStack.Pop();

                undoStack.Push(currentRedo);

                transform.position = currentRedo;
                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;
                player.UpdatePosition(toX, toY);
                Debug.Log($"Undo successful Reverted to Position " + $"{currentRedo}");
            }
            else
            {
                Debug.Log("Cannot redo");
            }
        }

        #endregion

        #region "This Is autoMoveQueue Function"

        public void StartAutoMoveSequence(OOPPlayer player)
        {
            //create a sample sequence of moves
            List<Vector2> sequence = new List<Vector2>
            {
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
                Vector2.right,
                Vector2.up,
            };

            // Start the coroutine to process the auto-move sequence
            StartCoroutine(ProcessAutoMoveSequence(sequence, player));
        }
        public IEnumerator ProcessAutoMoveSequence(List<Vector2> moves, OOPPlayer player)
        {
            player.isAutoMoving = true;

            // 1. prepare the Queue with the sequence of moves
            autoMoveQueue.Clear();
            foreach (var move in moves)
            {
                autoMoveQueue.Enqueue(move);
            }
            Debug.Log($"Auto-move sequence started with {autoMoveQueue.Count} steps.");

            while (autoMoveQueue.Count > 0)
            {
                // 2. process the Queue step-by-step
                Vector2 nextDirection = autoMoveQueue.Dequeue();

                player.Move(nextDirection);

                yield return new WaitForSeconds(0.5f); // Initial delay before starting
            }


            player.isAutoMoving = false;
            Debug.Log("Auto-move sequence finished.");
        }

        #endregion

    }
}


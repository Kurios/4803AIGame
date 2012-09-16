using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Diagnostics;

namespace Caverns.Dialogs
{
    class Dialog
    {
        List<DialogState> states;   //List of Dialog States.  These are all possible dialogs by character.
        int startingStateID = 0;  //The starting dialogState.  By default, this is set to 0.

        /// <summary>
        /// Basic constructor for list of states
        /// </summary>
        public Dialog()
        {
            states = new List<DialogState>();
            startingStateID = -1;
        }

        /// <summary>
        /// Constructor that creates a Dialog object based on a list of dialogStates.  By default, it's set to 0.
        /// </summary>
        /// <param name="dialogStates">A list of the dialog states to be made into the list</param>
        public Dialog(List<DialogState> dialogStates)
        {
            states = dialogStates;
        }

        /// <summary>
        /// Constructor that creates dialogStates based on the list of dialogs given.
        /// </summary>
        /// <param name="dialogs">List of dialogs to be made into dialogStates.  By default, they all lead to 'quit'.</param>
        /// <param name="startState"> The starting state for this state machine.</param>
        public Dialog(List<String> dialogs, int startState)
        {
            startingStateID = startState;
            for (int k = 0; k < dialogs.Count; k++)
            {
                String dialogResponse = dialogs[k];
                states.Add(new DialogState(k,dialogResponse));
            }
        }


        

        /// <summary>
        /// Returns the list of dialogStates
        /// </summary>
        /// <returns>Retrieves the list of states</returns>
        public List<DialogState> getStates()
        {
            return states;
        }

        /// <summary>
        /// Adds the given DialogState
        /// </summary>
        /// <param name="state">DialogState to be added</param>
        public void addState(DialogState state)
        {
            states.Add(state);
        }

        /// <summary>
        /// Adds a new DialogState with the given dialog.
        /// </summary>
        /// <param name="dialog">Dialog to be used for a state</param>
        public void addState(String dialog)
        {
            states.Add(new DialogState(states.Count, dialog));
        }

        /// <summary>
        /// Adds a new state based on a dialog and a list of responses to the dialog
        /// </summary>
        /// <param name="dialog">The dialog to be displayed</param>
        /// <param name="responses">The possible responses to the dialog</param>
        public void addState(String dialog, List<Response> responses)
        {
            states.Add(new DialogState(states.Count, dialog, responses));
        }

        /// <summary>
        /// Retrieves the starting state ID.
        /// </summary>
        /// <returns></returns>
        public int getStartStateID()
        {
            return startingStateID;
        }

        public void setStartStateID(int ID)
        {
            startingStateID = ID;
        }

        /// <summary>
        /// Retrieves the starting state.
        /// </summary>
        /// <returns></returns>
        public DialogState getStartState()
        {
            if (startingStateID == -1)  //No starting state declared.
            {
                return null;
            }

            for (int i = 0; i < states.Count; i++)  //Find the starting state.
            {
                if (startingStateID==(states[i]).getID())
                {
                    return states[i];
                }
            }
            return null;    //No starting state found.
        }

        /// <summary>
        /// Prints the current state of the dialog.
        /// </summary>
        public void print()
        {
            Debug.WriteLine("DIALOG STATE MAP: ");
            for (int i = 0; i < states.Count; i++)
            {
                states[i].print();
            }
        }
    }
}

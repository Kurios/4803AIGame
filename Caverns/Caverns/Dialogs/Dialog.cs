using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using KuriosityXLib;
using Microsoft.Xna.Framework.Input;

using System.Diagnostics;

namespace Caverns.Dialogs
{
    /// <summary>
    /// Our Dialog class is what will be handling the entire 'Dialog Map'.  
    /// </summary>
    class Dialog
    {
        #region Constructors
        /// <summary>
        /// Basic constructor for list of states
        /// </summary>
        public Dialog()
        {
            states = new List<DialogState>();
            startingStateID = -1;
            currentID = startingStateID;
            needResponse = true;
        }

        /// <summary>
        /// Constructor that creates a Dialog object based on a list of dialogStates.  By default, it's set to 0.
        /// </summary>
        /// <param name="dialogStates">A list of the dialog states to be made into the list</param>
        public Dialog(List<DialogState> dialogStates)
        {
            states = dialogStates;
            currentID = startingStateID;

            needResponse = true;
        }

        /// <summary>
        /// Constructor that creates dialogStates based on the list of dialogs given.
        /// </summary>
        /// <param name="dialogs">List of dialogs to be made into dialogStates.  By default, they all lead to 'quit'.</param>
        /// <param name="startState"> The starting state for this state machine.</param>
        public Dialog(List<String> dialogs, int startState)
        {
            startingStateID = startState;
            currentID = startingStateID;
            for (int k = 0; k < dialogs.Count; k++)
            {
                String dialogResponse = dialogs[k];
                states.Add(new DialogState(k,dialogResponse));
            }

            needResponse = true;
        }
        #endregion

        #region Fields/Parameters

        /// <summary>
        /// Getter/Setter for list of states
        /// </summary>
        public List<DialogState> states { get; set; }

        /// <summary>
        /// Getter/Setter for ID of starting state
        /// </summary>
        public int startingStateID { get; set; }

        /// <summary>
        /// Getter/Setter for ID of current state
        /// </summary>
        public int currentID { get; set; }

        /// <summary>
        /// Getter/Setter for if the NPC requires a response.  
        /// This is a 'just in case' item.
        /// </summary>
        public Boolean needResponse { get; set; }
        #endregion

        #region Adding States
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

        #endregion

        #region Dialog Actions

        /// <summary>
        /// This can be repeatedly called 
        /// </summary>

        /// <summary>
        /// Goes to the next dialog state
        /// </summary>
        public void toNextDialogState()
        {

            int nextStateID = states[currentID].currentResponse.nextStateID;

            if (nextStateID == -1)
            {
                //Finished with dialog
            }
            else
            {
                currentID = nextStateID;
            }

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
                if (startingStateID==(states[i]).stateID)
                {
                    return states[i];
                }
            }
            return null;    //No starting state found.
        }

        public DialogState getCurrentState()
        {
            return states[currentID];
        }
        #endregion

        #region print
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
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caverns.Dialog
{
    class Dialog
    {
        List<DialogState> states;

        /// <summary>
        /// Basic constructor for list of states
        /// </summary>
        public Dialog()
        {
            states = new List<DialogState>();
        }

        /// <summary>
        /// Constructor that creates a Dialog object based on a list of dialogStates
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
        public Dialog(List<String> dialogs)
        {
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

    }
}
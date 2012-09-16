using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caverns.Dialog
{
    class DialogState
    {
        int stateID;
        String npcText;
        List<Response> responses;

        /// <summary>
        /// Basic constructor for DialogState.
        /// </summary>
        public DialogState(int theID)
        {
            stateID = theID;
            npcText = "";
            responses = new List<Response>();
        }

        /// <summary>
        /// Constructor for DialogState that has only text.
        /// </summary>
        /// <param name="text">Text for the DialogState</param>
        public DialogState(int theID, String text)
        {
            stateID = theID;
            npcText = text;
            responses = new List<Response>();
        }

        /// <summary>
        /// Construct for DialogState that adds only a list of possible responses.
        /// </summary>
        /// <param name="possibleResponses">List of responses to choose from.</param>
        public DialogState(int theID, List<Response> possibleResponses)
        {
            stateID = theID;
            npcText = "";
            responses = possibleResponses;
        }

        /// <summary>
        /// Constructor for the DialogState that covers all parameters.
        /// </summary>
        /// <param name="theID">The integer ID of the state</param>
        /// <param name="text">The text displayed for the state</param>
        /// <param name="possibleResponses">The list of possible responses</param>
        public DialogState(int theID, String text, List<Response> possibleResponses)
        {
            stateID = theID;
            npcText = text;
            responses = possibleResponses;
        }

        /// <summary>
        /// Returns the state ID.
        /// </summary>
        /// <returns>The State ID number</returns>
        public int getID()
        {
            return stateID;
        }


        /// <summary>
        /// Returns the dialog text for the state.
        /// </summary>
        /// <returns>The text for the NPC</returns>
        public String getStateText()
        {
            return npcText;
        }

        /// <summary>
        /// Sets the dialog text for the state.
        /// </summary>
        /// <param name="text">The text for the NPC</param>
        public void setStateText(String text)
        {
            npcText = text;
        }

        /// <summary>
        /// Adds a response with the specified text.  By default, it will lead to a 'quit' state.
        /// </summary>
        /// <param name="respText">Response to be added with the specified text.</param>
        public void addResponse(String respText)
        {
            Response r = new Response(respText);
            responses.Add(r);
        }

        /// <summary>
        /// Adds a response with the specified text and direction to the next state.
        /// </summary>
        /// <param name="respText">Response's specific text</param>
        /// <param name="toNextState">the next state it goes to.</param>
        public void addResponse(String respText, int toNextState)
        {
            Response r = new Response(respText, toNextState);
            responses.Add(r);
        }
    }
}

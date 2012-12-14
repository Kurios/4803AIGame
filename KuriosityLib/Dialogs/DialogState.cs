using System;
using System.Collections.Generic;

using System.Diagnostics;

namespace KuriosityXLib.Dialogs
{
    public class DialogState
    {
        #region Constructors

        /// <summary>
        /// Basic constructor for DialogState.
        /// </summary>
        public DialogState(int theID)
        {
            stateID = theID;
            stateText = "";
            responses = new List<Response>();
        }

        /// <summary>
        /// Constructor for DialogState that has only text.
        /// </summary>
        /// <param name="text">Text for the DialogState</param>
        public DialogState(int theID, String text)
        {
            stateID = theID;
            stateText = text;
            responses = new List<Response>();
        }

        /// <summary>
        /// Construct for DialogState that adds only a list of possible responses.
        /// </summary>
        /// <param name="possibleResponses">List of responses to choose from.</param>
        public DialogState(int theID, List<Response> possibleResponses)
        {
            stateID = theID;
            stateText = "";
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
            stateText = text;
            responses = possibleResponses;
        }

        #endregion Constructors

        #region Fields

        public Response currentResponse { get; set; }

        public List<Response> responses { get; set; }

        

        /// <summary>
        /// Getter and Setter for the stateID.  This ID is used to tell which state we are at.
        /// </summary>
        public int stateID { get; set; }

        /// <summary>
        /// Getter and Setter for
        /// </summary>
        public String stateText { get; set; }

        #endregion Fields

        /// <summary>
        /// Go to a specific response
        /// </summary>
        public Response goToResponse(int respIndex)
        {
            if (respIndex > responses.Count)    //This will cycle from end to beginning of list
            {
                currentResponse = responses[0];
            }
            else if (respIndex < 0)    //This will cycle from beginning to end of list
            {
                currentResponse = responses[responses.Count - 1];
            }
            else
            {
                currentResponse = responses[respIndex];
            }
            return currentResponse;
        }

        #region Adding Responses

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

        #endregion Adding Responses

        #region Print Debug

        /// <summary>
        /// Prints out the DialogState.
        /// </summary>
        public void print()
        {
            Debug.WriteLine("STATE #" + stateID);
            Debug.WriteLine(stateText);
            for (int i = 0; i < responses.Count; i++)
            {
                responses[i].print();
            }
            Debug.WriteLine("");
        }

        #endregion Print Debug
    }
}
using System;

using System.Diagnostics;

namespace KuriosityXLib.Dialogs
{
    public class Response
    {
        #region Constructors

        /// <summary>
        /// A response consists of a text stated by an NPC and an integer representing which state
        /// to go to.
        /// </summary>
        //May have to add functionPointer for an Action later.

        /// <summary>
        /// Basic Response constructor.
        /// </summary>
        public Response()
        {
            responseText = "";
            nextStateID = -1;
        }

        /// <summary>
        /// Response constructor that has only a response text.
        /// </summary>
        /// <param name="textForResponse">The response text</param>
        public Response(String textForResponse)
        {
            responseText = textForResponse;
            nextStateID = -1;
        }

        /// <summary>
        /// Response constructor that only directs to next state.
        /// </summary>
        /// <param name="toNextState">integer of the next state</param>
        public Response(int toNextState)
        {
            responseText = "";
            nextStateID = toNextState;
        }

        /// <summary>
        /// Response constructor that has a textResponse and directs to the next state.
        /// </summary>
        /// <param name="textForResponse">Text used for response</param>
        /// <param name="toNextState">integer of the next state</param>
        public Response(String textForResponse, int toNextState)
        {
            responseText = textForResponse;
            nextStateID = toNextState;
        }

        public Response(String textForResponse, int toNextState, Func<int> OnSellect)
        {
            responseText = textForResponse;
            nextStateID = toNextState;
            this.OnSelect = OnSelect;
        }

        #endregion Constructors

        #region Fields

        public int nextStateID { get; set; }

        public String responseText { get; set; }

        public Func<int> OnSelect { get; set; }

        #endregion Fields

        #region Printing and Debugging

        /// <summary>
        /// Prints the response.  A DEBUG FUNCTION.
        /// </summary>
        public void print()
        {
            Debug.WriteLine("RESPONSE");
            Debug.WriteLine("Response Text: " + this.responseText);
            Debug.WriteLine("directs to state ID" + this.nextStateID);
        }

        #endregion Printing and Debugging
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        #endregion

        #region Fields
        public String responseText { get; set; }
        public int nextStateID { get; set; }
        #endregion

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
        #endregion
    }
}

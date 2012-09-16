using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using System.Diagnostics;

namespace Caverns.Dialogs
{
    class Response
    {
        /// <summary>
        /// A response consists of a text stated by an NPC and an integer representing which state
        /// to go to.
        /// </summary>
        String responseText;
        int nextState = -1;
        //May have to add functionPointer for an Action later.

        /// <summary>
        /// Basic Response constructor.
        /// </summary>
        public Response()
        {
            responseText = "";
        }

        /// <summary>
        /// Response constructor that has only a response text.
        /// </summary>
        /// <param name="textForResponse">The response text</param>
        public Response(String textForResponse)
        {
            responseText = textForResponse;
        }

        /// <summary>
        /// Response constructor that only directs to next state.
        /// </summary>
        /// <param name="toNextState">integer of the next state</param>
        public Response(int toNextState)
        {
            nextState = toNextState;
        }

        /// <summary>
        /// Response constructor that has a textResponse and directs to the next state.
        /// </summary>
        /// <param name="textForResponse">Text used for response</param>
        /// <param name="toNextState">integer of the next state</param>
        public Response(String textForResponse, int toNextState)
        {
            responseText = textForResponse;
            nextState = toNextState;
        }

        /// <summary>
        /// Returns the response text.
        /// </summary>
        /// <returns>responseText</returns>
        public String getResponseText()
        {
            return responseText;
        }

        /// <summary>
        /// Sets the responseText as the given response.
        /// </summary>
        /// <param name="response">The response to be set.</param>
        public void setResponseText(String response)
        {
            responseText = response;
        }

        /// <summary>
        /// Returns the direction to the next state.
        /// </summary>
        /// <returns>direction to the next state</returns>
        public int getNextState()
        {
            return nextState;
        }

        /// <summary>
        /// Sets the next state
        /// </summary>
        /// <param name="toState">integer representing the next state</param>
        public void setNextState(int toState)
        {
            nextState = toState;
        }

        /// <summary>
        /// Prints the response.  A DEBUG FUNCTION.
        /// </summary>
        public void print()
        {
            Console.WriteLine("RESPONSE");
            Console.WriteLine("Response Text: " + this.getResponseText());
            Console.WriteLine("directs to state ID" + this.getNextState());
        }
    }
}

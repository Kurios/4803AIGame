using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialSim.Agents
{
    class Agent
    {
        //An agent knows its name, agents that are important to it (Influences the 'Third Party' aspect), and has a specific "parameterSpace"
            //The parameters are conditions that will be reviewed to determine if certain social games can be played.


        public String name;    //The Agent's name
        List<Agent> importantAgents;    //Agents that are important to this agent.  Influences 'Third Party' connections
        //Conditional parameters

        //-1 to 1
        public float comfort; //Comfort in talking about the subject.  Lower values mean discomfort in discussion, higher values mean greater comfort.
        public float curiosity;    //Curiosity in wanting to talk about the subject.  Lower values mean little curiosity.
        public float consideration;    //Consideration for other agent in wanting to talk about this subject.  Lower values mean little consideration.


        #region Constructors

        public Agent()
        {
            name = "";
            comfort = 0;
            curiosity = 0;
            consideration = 0;
            importantAgents = new List<Agent>();
        }

        public Agent(String aName)
        {
            name = aName;
            comfort = 0;
            curiosity = 0;
            consideration = 0;

            importantAgents = new List<Agent>();
        }

        public Agent(String aName, float comfortLevel, float curiosityLevel, float considerationLevel)
        {
            name = aName;
            comfort = comfortLevel;
            curiosity = curiosityLevel;
            consideration = considerationLevel;

            importantAgents = new List<Agent>();
        }
        #endregion

        #region Methods

        public void addAgent(Agent agen)
        {
            importantAgents.Add(agen);
        }

        public bool isImportant(Agent agen)
        {
            foreach (Agent a in importantAgents)
            {
                if (a.name.Equals(agen.name))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Testing Methods
        #endregion
    }
}

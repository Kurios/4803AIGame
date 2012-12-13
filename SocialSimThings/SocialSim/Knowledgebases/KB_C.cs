using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialSim.Knowledgebases;

namespace SocialSim
{
    //A Knowledgebase consists of data needed for the game.  
    //From the knowledgebase, you got the cultural knowledgebase and social knowledgebase

    //List of 

    class KB_C
    {
        public List<Topic> TopicList;

        public KB_C()
        {
            TopicList = new List<Topic>();
            initialize();
        }

        //Initializing the CKB
        #region Methods...

        private void initialize()
        {
            //Sad Topics
            Topic sadTopics = new Topic(TopicType.Player, 0.25f, 1.0f, 0.25f);
            sadTopics.Subjects.Add(new Subject(SubjectType.Cave, sadTopics.comfortThreshold, sadTopics.considerationThreshold, sadTopics.curiosityThreshold));
            sadTopics.Subjects.Add(new Subject(SubjectType.Girl, sadTopics.comfortThreshold, sadTopics.considerationThreshold, sadTopics.curiosityThreshold));
            sadTopics.Subjects.Add(new Subject(SubjectType.Player, sadTopics.comfortThreshold, sadTopics.considerationThreshold, sadTopics.curiosityThreshold));
            sadTopics.addSubject(SubjectType.Mushrooms, sadTopics.comfortThreshold, sadTopics.considerationThreshold, sadTopics.curiosityThreshold);

            //Fun Topics
            Topic funTopics = new Topic(TopicType.Fun, 0.2f, -1.0f, 0.11f);
            funTopics.addSubject(SubjectType.Party, funTopics.comfortThreshold, funTopics.considerationThreshold, funTopics.curiosityThreshold);
            funTopics.addSubject(SubjectType.Games, funTopics.comfortThreshold, funTopics.considerationThreshold, funTopics.curiosityThreshold);
            funTopics.addSubject(SubjectType.Festival, funTopics.comfortThreshold, funTopics.considerationThreshold, funTopics.curiosityThreshold);

            //Friendly Topics
            Topic friendlyTopics = new Topic(TopicType.Friendly, 0.1f, 1.0f, 0.1f);
            friendlyTopics.addSubject(SubjectType.Gifts, friendlyTopics.comfortThreshold, friendlyTopics.considerationThreshold, friendlyTopics.curiosityThreshold);
            friendlyTopics.addSubject(SubjectType.Flowers, friendlyTopics.comfortThreshold, friendlyTopics.considerationThreshold, friendlyTopics.curiosityThreshold);

            //Scary Topics
            Topic scaryTopics = new Topic(TopicType.Scary, 0.9f, 1.0f, 0.85f);
            scaryTopics.addSubject(SubjectType.Forest, scaryTopics.comfortThreshold, scaryTopics.considerationThreshold, scaryTopics.curiosityThreshold);
            scaryTopics.addSubject(SubjectType.Ghosts, scaryTopics.comfortThreshold, scaryTopics.considerationThreshold, scaryTopics.curiosityThreshold);

            TopicList.Add(sadTopics);
            TopicList.Add(funTopics);
            TopicList.Add(friendlyTopics);
            TopicList.Add(scaryTopics);

        }

        public Topic getTopic(Subject s)
        {
            Topic t = new Topic();

            foreach (Topic tt in TopicList)
            {
                if (tt.Subjects.Contains(s))
                {
                    s.comfortThreshold = tt.comfortThreshold;
                    s.considerationThreshold = tt.considerationThreshold;
                    s.curiosityThreshold = tt.curiosityThreshold;
                    t = tt;
                }
            }

            return t;
        }
        #endregion


    }
}

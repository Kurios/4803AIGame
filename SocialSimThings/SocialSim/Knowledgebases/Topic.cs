using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialSim.Knowledgebases
{
    //A List of topic choices for the knowledgebases
    public enum TopicType
    {
        Friendly, Fun, Player, Scary
    }

    public class Topic
    {
        public TopicType Name;
        public float comfortThreshold;
        public float considerationThreshold;
        public float curiosityThreshold;
        public List<Subject> Subjects;
        public Topic()
        {
            //TopicType 
            Name = TopicType.Player;
            Subjects = new List<Subject>();
            comfortThreshold = 0;
            considerationThreshold = 0;
            curiosityThreshold = 0;
        }

        public Topic(TopicType t)
        {
            Name = t;
            Subjects = new List<Subject>();
            comfortThreshold = 0;
            considerationThreshold = 0;
            curiosityThreshold = 0;
        }


        public Topic(TopicType t, List<Subject> subjects)
        {
            Name = t;
            Subjects = subjects;
            comfortThreshold = 0;
            considerationThreshold = 0;
            curiosityThreshold = 0;
        }

        public Topic(TopicType t, float comfort, float consideration, float curious)
        {
            Name = t;
            Subjects = new List<Subject>();
            comfortThreshold = comfort;
            considerationThreshold = consideration;
            curiosityThreshold = curious;
        }

        public void addSubject(SubjectType subjectName, float comfort, float consideration, float curious)
        {
            Subjects.Add(new Subject(subjectName, comfort, consideration, curious));
        }

    }
}

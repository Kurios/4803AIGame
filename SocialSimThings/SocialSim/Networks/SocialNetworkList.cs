using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Knowledgebases;
using SocialSim.GameStuff;

namespace SocialSim.Networks
{
    public class SocialNetworkList
    {
        public List<SocialNetwork> socialNetworks;

        #region Constructors...

        public SocialNetworkList()
        {
            socialNetworks = new List<SocialNetwork>();
        }

        public SocialNetworkList(List<SocialNetwork> presetSN)
        {
            socialNetworks = presetSN;
        }
        #endregion

        #region Methods...

        public SocialNetwork getSocialNetwork(Topic t)
        {
            foreach (SocialNetwork sn in socialNetworks)
            {
                if (sn.TopicOfNetwork.Equals(t))
                {
                    return sn;
                }
            }
            return null;
        }

        public void updateSocialPairInAllNetworks(SocialPair sp)    //Updates this specific SocialPair
        {

        }

        public void addSocialNetwork(SocialNetwork sn)
        {
            socialNetworks.Add(sn);
        }

        public List<SocialGame> getPlayableGames(SocialPair sp, List<SocialGame> allGames)
        {
            List<SocialGame> playableGames = new List<SocialGame>();
            foreach (SocialNetwork sn in socialNetworks)
            {
                Topic t= sn.TopicOfNetwork;
                Console.WriteLine("NUM: " + t.Subjects.Count);
                List<SocialGame> playableGamesPart = sp.getPlayableGames(allGames, t);
                foreach (SocialGame game in playableGamesPart)
                {
                    playableGames.Add(game);
                }
            }
            return playableGames;
            //return sp.getPlayableGames(allGames);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SocialSim.Knowledgebases;

namespace SocialSim.Networks
{
    class SocialNetworkList
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
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Factories
{
    public class ConversaoFactory
    {
        private static volatile ConversaoFactory conversaoFactory;
        private static volatile ConversaoService conversaoService;

        public static ConversaoFactory GetInstance()
        {
            if (conversaoFactory == null)
                conversaoFactory = new ConversaoFactory();

            return conversaoFactory;
        }

        public ConversaoService GetConversaoService()
        {
            if (conversaoService == null)
                conversaoService = new ConversaoService();

            return conversaoService;
        }
    }
}

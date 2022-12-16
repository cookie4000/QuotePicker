using System;
using System.Collections.Generic;
using System.Text;
using DIFunction.Template;
using static DIFunction.Repository.QuoteBank;
using DIFunction.Interface;

namespace DIFunction.Repository
{
    public class QuoteBank : IQuoteBank
    {
        public Quote getQuote()
        {
            List<Quote> allQuotes = getQuotes();
            Random rand = new Random();
            int index = rand.Next(allQuotes.Count);

            return allQuotes[index];

        }
        private List<Quote> getQuotes()
        {
            List<Quote> allQuotes = new List<Quote>();
            allQuotes.Add(new Quote("Albert Einstein", "A person who never made a mistake never tried anything new"));
            allQuotes.Add(new Quote("George Eliot", "It is never too late to be what you might have been"));
            allQuotes.Add(new Quote("Mark Twain", "The two most important days in your life are the day you are born and the day you find out why"));

            return allQuotes;
        }
    }
}

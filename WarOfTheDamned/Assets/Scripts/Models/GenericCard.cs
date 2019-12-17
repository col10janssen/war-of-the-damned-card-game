using System;
using Interfaces;

namespace Models
{
    public class GenericCard : ICard
    {
        public string Id { get; set; }

        public GenericCard()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void Discard()
        {
            throw new NotImplementedException();
        }

        public void Exile()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}




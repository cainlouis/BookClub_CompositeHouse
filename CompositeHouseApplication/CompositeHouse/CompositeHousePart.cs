using System;
using System.Collections.Generic;

namespace CompositeHouse
{
    public class CompositeHousePart : IHousePart
    {
        /// <value>
        /// Field
        /// <c> houseParts </c>
        /// A list of all the house parts 
        /// </value>
        private List<IHousePart> houseParts;

        /// <value>
        /// Property
        /// <c> Name </c>
        /// Represents the name of the part created
        /// </value>
        public virtual string Name { get; }

        /// <value>
        /// Property
        /// <c> SquareFootage </c>
        /// Represents the square foot of the part
        /// </value>
        public virtual int SquaredFootage { get; }

        /// <summary>
        /// Parameterized constructor that initialize the fields
        /// </summary>
        /// <param name="name"> name of the part </param>
        /// <param name="squaredFootage"> the size of the part </param>
        public CompositeHousePart(string name, int squaredFootage)
        {
            Name = name;
            SquaredFootage = squaredFootage;
            houseParts = new List<IHousePart>();
        }

        /// <summary>
        /// Add the housePart it takes as input to the list of houseParts 
        /// </summary>
        /// <param name="housePart"> An IHousePart representing one part of the house </param>
        public void AddHousePart(IHousePart housePart)
        {
            houseParts.Add(housePart);
        }

        /// <summary>
        /// Calculate the size of all house parts
        /// </summary>
        ///<return> The sum of all the squaredFootage of all the houseParts </return> 
        public virtual int CalculateSize()
        {
            int totalSquaredFootage = SquaredFootage;
            foreach (IHousePart housePart in houseParts)
            {
                totalSquaredFootage += housePart.CalculateSize();
            }
            return totalSquaredFootage;
        }
    }
}
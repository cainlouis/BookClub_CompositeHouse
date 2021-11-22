using System;

namespace CompositeHouse
{
    public interface IHousePart
    {
        /// <value>
        /// Property
        /// <c> Name </c>
        /// Represents the name of the part created
        /// </value>
        string Name { get; }

        /// <value>
        /// Property
        /// <c> SquareFootage </c>
        /// Represents the square foot of the part
        /// </value>
        int SquaredFootage { get; }

        /// <summary>
        /// This method returns total square footage of an IHousePart
        /// </summary>
        int CalculateSize()
        {
            return SquaredFootage;
        }
    }
}
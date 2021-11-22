
namespace CompositeHouse
{
    public class SimpleHousePart : IHousePart
    {
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
        /// Parameterized constructor that initialize the field
        /// </summary>
        /// <param name="name"> name of the part </param>
        /// <param name="squaredFootage"> the size of the part </param>
        public SimpleHousePart(string name, int squareFootage)
        {
            Name = name;
            SquaredFootage = squareFootage;
        }

        /// <summary>
        /// This method returns total square footage of an IHousePart
        /// </summary>
        public virtual int CalculateSize()
        {
            return SquaredFootage;
        }
    }
}
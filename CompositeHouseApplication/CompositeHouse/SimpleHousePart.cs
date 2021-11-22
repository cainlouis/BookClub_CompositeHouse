
namespace CompositeHouse
{
    public class SimpleHousePart : IHousePart
    {
        /// <summary>
        /// Parameterized constructor that initialize the field
        /// </summary>
        /// <param name="name"> name of the part </param>
        /// <param name="squaredFootage"> the size of the part </param>
        public SimpleHousePart(string name, int squareFootage)
        {
            base.Name = name;
            base.SquareFootage = squareFootage;
        }

        /// <summary>
        /// This method returns total square footage of an IHousePart
        /// </summary>
        public virtual int CalculateSize()
        {
            return base.SquareFootage;
        }
    }
}
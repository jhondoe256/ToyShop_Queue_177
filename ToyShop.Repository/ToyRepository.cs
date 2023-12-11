using ToyShop.Data;

namespace ToyShop.Repository
{
    public class ToyRepository
    {
        private readonly Queue<Toy> _toyDbContext;
        private int _count = 0;

        public ToyRepository()
        {
            _toyDbContext = new Queue<Toy>();
            Seed();
        }

        //C
        public bool AddToy(Toy toy)
        {

            if (ValidateToy(toy) == true)
            {
                _count++;
                toy.Id = _count;
                _toyDbContext.Enqueue(toy);
                return true;
            }
            else
            {
                return false;
            }
        }

        //defensive approach
        private bool ValidateToy(Toy toy)
        {
            if (toy is null)
            {
                return false;
            }
            else if ((toy.Name == string.Empty) || (toy.Description == string.Empty))
            {
                return false;
            }
            else if ((toy.ToyType == 0) || (toy.Price <= 0.00M))
            {
                return false;
            }
            return true;
        }

        //R
        public Queue<Toy> GetToys()
        {
            return _toyDbContext;
        }

        //R
        public Toy GetToy()
        {
            if (_toyDbContext.Count() > 0)
            {
                return _toyDbContext.Peek();
            }

            return null;
        }

        //U
        public bool UpdateCurrentToy(Toy newToyData)
        {
            if (_toyDbContext.Count() > 0)
            {
                Toy searchedToy = GetToy();

                if (searchedToy != null)
                {
                    searchedToy.Name = newToyData.Name;
                    searchedToy.Description = newToyData.Description;
                    searchedToy.ToyType = newToyData.ToyType;
                    searchedToy.Price = newToyData.Price;
                    return true;
                }
            }
            return false;
        }

        //D
        public Toy RemoveCurrentToy()
        {
            if (_toyDbContext.Count() > 0)
            {
                Toy searchedToy = GetToy();

                if (searchedToy != null)
                {
                    Toy removedToy = _toyDbContext.Dequeue();
                    return removedToy;
                }
            }
            return null;
        }
    
        //Seed
        private void Seed()
        {
            Toy ninjaTurtle_Leo = new Toy("Leonardo","Leader of the ninja turtles", ToyType.ACTION_FIGURE, 9.99m);
            Toy sorry = new Toy("SORRY!","A game of revenge",ToyType.BOARD_GAME, 19.99m);

            AddToy(ninjaTurtle_Leo);
            AddToy(sorry);
        }
    }
}
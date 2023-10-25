namespace Calc.Data
{
    public interface IRepository
    {
        CalcDBContext Context { get; }
    }
    public class Repository: IRepository
    {
        public CalcDBContext Context { get; private set; }

        public Repository(CalcDBContext context)
        {
            Context = context;
        }
    }
}

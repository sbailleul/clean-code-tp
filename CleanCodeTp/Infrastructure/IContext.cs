using System.Threading.Tasks;

namespace CleanCodeTp.Infrastructure
{
    public interface IContext
    {
        public Task Init();
    }
}
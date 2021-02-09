namespace CleanCodeTp.Application
{
    public interface IHandler<in TCommand, out TResult>
    {
        public TResult Handle(TCommand message);
    }
}
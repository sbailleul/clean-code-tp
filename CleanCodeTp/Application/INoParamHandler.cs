namespace CleanCodeTp.Application
{
    public interface INoParamHandler<out TResult>
    {
        public TResult Handle();
    }
}
namespace CleanCodeTp.Application
{
    public interface INoReturnHandler<in TCommand>
    {
        public void Handle(TCommand message);
    }
}
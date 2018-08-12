

namespace Test.BaseFramework
{
    public class BasePageValidator<M>
        where M : BasePageElementMap, new()
    {
        protected M Map => new M();
    }
}

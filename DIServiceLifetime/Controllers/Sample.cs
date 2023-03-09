using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIServiceLifetime.Controllers
{
    public class Sample
    {
    }
    public interface IService
    {
        string Info();
    }

    public interface ISingleton : IService { }
    public interface IScoped : IService { }
    public interface ITransient : IService { }

    public abstract class Operation : ISingleton, IScoped, ITransient
    {
        private Guid _operationId;
        private string _lifeTime;

        public Operation(string lifeTime)
        {
            _operationId = Guid.NewGuid();
            _lifeTime = lifeTime;

            Console.WriteLine($"{_lifeTime} Service Created.");
        }

        public string Info()
        {
            Console.WriteLine($"{_lifeTime}: {_operationId}");
            return $"{_lifeTime}: {_operationId}";
        }
    }

    public class SingletonOperation : Operation
    {
        public SingletonOperation() : base("Singleton") { }
    }
    public class ScopedOperation : Operation
    {
        public ScopedOperation() : base("Scoped") { }
    }
    public class TransientOperation : Operation
    {
        public TransientOperation() : base("Transient") { }
    }

}

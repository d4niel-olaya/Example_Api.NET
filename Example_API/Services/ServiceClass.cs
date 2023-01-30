

namespace Example_API.Services
{
   public interface IRead<TModel>
   {
        public Task<IEnumerable<TModel>> get();

        public Task<IEnumerable<TModel>> getByid();

   }

   public interface IEdit<TModel>
   {
        public Task<bool> deleted();

        public Task<bool> update(TModel entity);
   }

   public interface IAdd<TModel>
   {
        public Task<bool> save(TModel entity);
   }

}
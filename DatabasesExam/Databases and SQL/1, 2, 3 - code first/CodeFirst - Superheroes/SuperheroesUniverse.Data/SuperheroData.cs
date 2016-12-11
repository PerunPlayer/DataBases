using System;
using System.Collections.Generic;
using SuperHeroes.Models;
using SuperheroesUniverse.Data.Contracts;
using SuperheroesUniverse.Data.Repository;
using SuperheroesUniverse.Data.Repositories;

namespace SuperheroesUniverse.Data
{
    public class SuperheroData : ISuperheroData
    {
        private readonly IDictionary<Type, object> repositories;
        private readonly ISuperheroDBContext context;

        public IRepository<Fraction> Fractions
        {
            get
            {
                return this.GetRepository<Fraction>();
            }
        }

        public IRepository<Planet> Planets
        {
            get
            {
                return this.GetRepository<Planet>();
            }
        }

        public IRepository<Power> Powers
        {
            get
            {
                return this.GetRepository<Power>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                Type type = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            var foundRepository = this.repositories[typeOfModel] as IRepository<T>;
            return foundRepository;
        }
    }
}

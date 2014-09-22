using System;
using CompanyDb.Data;

namespace CompanyDb.ImportRandomData
{
    public abstract class DataGenerator
    {
        private int dataCount;
        private RandomGenerator generator;
        private CompanyDbEntities dbContext;

        public DataGenerator(int dataCount, RandomGenerator generatorInstance, CompanyDbEntities dbContext)
        {
            this.DataCount = dataCount;
            this.Generator = generatorInstance;
            this.DbContext = dbContext;
        }

        protected int DataCount
        {
            get
            {
                return this.dataCount;
            }

            private set
            {
                this.dataCount = value;
            }
        }

        protected RandomGenerator Generator
        {
            get
            {
                return this.generator;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Random generator must be initialized.");
                }

                this.generator = value;
            }
        }

        protected CompanyDbEntities DbContext
        {
            get
            {
                return this.dbContext;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CompanyDb context must be initialized.");
                }

                this.dbContext = value;
            }
        }
    }
}

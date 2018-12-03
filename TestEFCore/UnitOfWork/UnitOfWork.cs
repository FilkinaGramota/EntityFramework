﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestEFCore
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly VideoLibraryDbContext context;

        public ICasseteRepository CasseteRep { get; set; }
        // IOderRepository
        // IFilmRepository

        public UnitOfWork(VideoLibraryDbContext context)
        {
            this.context = context;
            CasseteRep = new CassetteRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
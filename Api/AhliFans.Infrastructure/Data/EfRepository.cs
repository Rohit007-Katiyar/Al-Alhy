﻿using AhliFans.SharedKernel.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace AhliFans.Infrastructure.Data;

  public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
  {
      public EfRepository(AppDbContext dbContext) : base(dbContext)
      {
        
      }
  }

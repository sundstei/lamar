﻿using System;
using Microsoft.Extensions.DependencyInjection;
using LamarCodeGeneration.Util;

namespace Lamar.IoC.Resolvers
{
    public class TransientLambdaResolver<TContainer, T> : TransientResolver<T> 
    {
        private readonly Func<TContainer, T> _builder;
        
        public TransientLambdaResolver(Func<TContainer, T> builder)
        {
            _builder = builder;
        }
        
        public override T Build(Scope scope)
        {
            return _builder(scope.As<TContainer>());
        }
    }
}
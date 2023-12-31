﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{// aspect methodun başında sonunda hata verdiğinde çalışacak yapı try cacth
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //doğrulama sınıfı örneği oluşturur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //base type argümanları alınıyor Validatördeki type user gibi
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //aynı türden nesneleri seçiyor
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }//doğrulama gerçekleşir


    }
}

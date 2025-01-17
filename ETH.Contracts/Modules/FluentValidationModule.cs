using Autofac;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ETH.Contracts.Modules;

/// <summary>
/// The fluent validation autofac module.
/// </summary>
public class FluentValidationModule : Module
{
    /// <inheritdoc />
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .FirstOrDefault(a => a.FullName!.Contains("ETH.Contracts"));

        // Can be removed and refactored to First.
        if (assembly is null)
        {
            return;
        }

        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Validator"))
            .AsImplementedInterfaces()
            .SingleInstance();

        builder
            .RegisterType<FluentValidationModelValidatorProvider>()
            .As<IModelValidatorProvider>();
    }
}

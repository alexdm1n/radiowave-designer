using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

public interface IConfigurationViewModelBuilder
{
    Task<ConfigurationViewModel> Build();
}
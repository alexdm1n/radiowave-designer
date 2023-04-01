using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services;

public interface IHomeViewModelBuilder
{
    HomeViewModel Get();
}
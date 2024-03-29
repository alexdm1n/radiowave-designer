﻿using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Builders;

public interface IHomeViewModelBuilder
{
    Task<HomeViewModel> Get();
}
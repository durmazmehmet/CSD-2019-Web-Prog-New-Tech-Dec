package org.csystem.springboot.app.service.mapper;

import org.csystem.springboot.app.entity.Device;
import org.csystem.springboot.app.viewmodel.DeviceViewModel;
import org.mapstruct.Mapper;

@Mapper(implementationName = "DeviceViewModelMapperImpl", componentModel = "spring")
public interface IDeviceViewModelMapper {
    Device viewModelToModel(DeviceViewModel deviceViewModel);
    DeviceViewModel modelToViewModel(Device device);
}
